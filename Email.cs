using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.SendMail;
using Newtonsoft.Json;

namespace appsvc_fnc_dev_scw_email_dotnet001
{
    public class Email
    {
        private readonly ILogger<Email> _logger;
        public Email(ILogger<Email> logger)
        {
            _logger = logger;
        }

        [Function("Email")]
        public async Task<IActionResult> RunAsync([QueueTrigger("email", Connection = "AzureWebJobsStorage")] string myQueueItem)
        {
            _logger.LogError($"Email trigger function triggered {DateTime.Now}");

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables().Build();

            dynamic data = JsonConvert.DeserializeObject(myQueueItem);
            _logger.LogError($"myQueueItem = {myQueueItem}");

            var scopes = new[] { "user.read mail.send" };
            ROPCConfidentialTokenCredential auth = new ROPCConfidentialTokenCredential(_logger);
            var graphClient = new GraphServiceClient(auth, scopes);

            IActionResult result;

            try
            {
                string emails = "";
                string siteUrl = $"{config["sharePointUrl"]}{data?.Id}";
                string displayName = data?.SpaceName;
                string displayNameFr = data?.SpaceNameFR;
                string status = data?.Status;
                string comments = data?.Comment;
                string requester = data?.RequesterName;
                string requesterEmail = data?.RequesterEmail;
                string securityCategory = data?.SecurityCategory;
                string EmailSender = config["userId"];
                string HD_Email = "";

                string ErrorMessage = data?.ErrorMessage;
                string Method = data?.Method;
                string FunctionApp = data?.FunctionApp;

                result = await SendEmailToUser(graphClient, _logger, securityCategory, emails, siteUrl, displayName, displayNameFr, status, comments, requester, requesterEmail, EmailSender, HD_Email, ErrorMessage, FunctionApp, Method);
            }
            catch (Exception e)
            {
                result = new BadRequestResult();
                _logger.LogInformation($"Email error: {e.Message}");
            }

            return new OkResult();
        }

        /// <summary>
        /// Send email to users, when status is submitted, rejected and team created.
        /// </summary>
        /// <param name="graphClient"></param>
        /// <param name="log"></param>
        /// <param name="emails"></param>
        /// <param name="siteUrl"></param>
        /// <param name="displayName"></param>
        /// <param name="status"></param>
        /// <param name="comments"></param>
        /// <param name="requester"></param>
        /// <param name="requesterEmail"></param>
        public async Task<IActionResult> SendEmailToUser(GraphServiceClient graphClient, ILogger log, string SecurityCategory, string emails, string siteUrl, string displayName, string displayNameFr, string status, string comments, string requester, string requesterEmail, string EmailSender, string HD_Email, string ErrorMessage, string FunctionApp, string Method)
        {
            SendMailPostRequestBody requestBody;

            switch (status)
            {
                case "Submitted":
                    requestBody = new SendMailPostRequestBody
                    {
                        Message = new Message
                        {
                            Subject = "We received your request for a GCXchange community / Nous avons reçu votre demande concernant une collectivité sur GCÉchange",
                            Body = new ItemBody
                            {
                                ContentType = BodyType.Html,
                                Content = (SecurityCategory == "unclassified") ? Templates.RequestReceived(displayName, displayNameFr) : Templates.RequestReceivedProB(displayName, displayNameFr)
                            },
                            ToRecipients = new List<Recipient>()
                            {
                                new Recipient { EmailAddress = new EmailAddress { Address = $"{requesterEmail}" } }
                            }
                        }
                    };

                    await graphClient.Users[EmailSender].SendMail.PostAsync(requestBody);
                    log.LogInformation($"Send email to {requesterEmail} successfully.");
                    break;
                case "Rejected":
                    requestBody = new SendMailPostRequestBody
                    {
                        Message = new Message
                        {
                            Subject = "Sorry, your GCXchange community was not created / Malheureusement, votre collectivité GCÉchange n'a pas été créé",
                            Body = new ItemBody
                            {
                                ContentType = BodyType.Html,
                                Content = (SecurityCategory == "unclassified") ? Templates.RequestRejected(displayName, displayNameFr, comments) : Templates.RequestRejectedProB(displayName, displayNameFr, comments)
                            },
                            ToRecipients = new List<Recipient>()
                            {
                                new Recipient { EmailAddress = new EmailAddress { Address = $"{requesterEmail}" } }
                            }
                        }
                    };
                    
                    await graphClient.Users[EmailSender].SendMail.PostAsync(requestBody);
                    log.LogInformation($"Send email to {requesterEmail} successfully.");
                    break;
                case "Team Created":
                    requestBody = new SendMailPostRequestBody
                    {
                        Message = new Message
                        {
                            Subject = "Your GCXchange community is ready/Votre collectivité GCÉchange est prête",
                            Body = new ItemBody
                            {
                                ContentType = BodyType.Html,
                                Content = (SecurityCategory == "unclassified") ? Templates.RequestApproved(displayName, displayNameFr, requester, siteUrl) : Templates.RequestApprovedProB(displayName, displayNameFr, requester, siteUrl)
                            },
                            ToRecipients = new List<Recipient>()
                            {
                                new Recipient { EmailAddress = new EmailAddress { Address = $"{requesterEmail}" } }
                            }
                        }
                    };

                    await graphClient.Users[EmailSender].SendMail.PostAsync(requestBody);
                    log.LogInformation($"Send email to {requesterEmail} successfully.");
                    break;
                case "Notif_HD":
                    requestBody = new SendMailPostRequestBody
                    {
                        Message = new Message
                        {
                            Subject = $"New pending request! {displayName}",
                            Body = new ItemBody
                            {
                                ContentType = BodyType.Html,
                                Content = $"<a href=\"https://gcxgce.sharepoint.com/teams/scw\">Click here</a> to review the request."
                            },
                            ToRecipients = new List<Recipient>()
                            {
                                new Recipient { EmailAddress = new EmailAddress { Address = $"{HD_Email}" } }
                            }
                        }
                    };

                    await graphClient.Users[EmailSender].SendMail.PostAsync(requestBody);
                    log.LogInformation($"Send email to {HD_Email} successfully.");
                    break;
                case "Failed":
                    requestBody = new SendMailPostRequestBody
                    {
                        Message = new Message
                        {
                            Subject = "SCW - Failure Notification",
                            Body = new ItemBody
                            {
                                ContentType = BodyType.Html,
                                Content = $"<p>The Space Creation Wizard failed.</p><strong>Site URL:</strong> {siteUrl}<br /><br /><strong>Function App:</strong> {FunctionApp}<br /><strong>Method:</strong> {Method}<br /><br /><strong>Error Message:</strong><br />{ErrorMessage.Replace("\r\n", "<br />")}"
                            },
                            ToRecipients = new List<Recipient>()
                            {
                                new Recipient { EmailAddress = new EmailAddress { Address = $"{requesterEmail}" } }
                            }
                        }
                    };

                    await graphClient.Users[EmailSender].SendMail.PostAsync(requestBody);
                    log.LogInformation($"Send email to {requesterEmail} successfully.");
                    break;
                default:
                    log.LogInformation($"The status was {status}. This status is not part of the switch statement.");
                    break;
            };

            return new OkResult();
        }
    }
}