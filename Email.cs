using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace appsvc_fnc_dev_scw_email_dotnet001
{
    public class Email
    {
        [FunctionName("Email")]
        public void Run([QueueTrigger("email", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
        {
            log.LogInformation("Email trigger function triggered");

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables().Build();
            dynamic data = JsonConvert.DeserializeObject(myQueueItem);

            log.LogInformation($"myQueueItem = {myQueueItem}");

            var scopes = new[] { "user.read mail.send" };
            ROPCConfidentialTokenCredential auth = new ROPCConfidentialTokenCredential(log);
            var graphClient = new GraphServiceClient(auth, scopes);

            try {
                string emails = "";
                string siteUrl = $"{config["sharePointUrl"]}{data?.Id}";
                string displayName = data?.SpaceName;
                string displayNameFr = data?.SpaceNameFR;
                string status = data?.Status;
                string comments = data?.Comment;
                string requester = data?.RequesterName;
                string requesterEmail = data?.RequesterEmail;
                string EmailSender = config["userId"];
                string HD_Email = "";

                string ErrorMessage = data?.ErrorMessage;
                string Method = data?.Method;
                string FunctionApp = data?.FunctionApp;

                SendEmailToUser(graphClient, log, emails, siteUrl, displayName, displayNameFr, status, comments, requester, requesterEmail, EmailSender, HD_Email, ErrorMessage, FunctionApp, Method);
            }
            catch (Exception e)
            {
                log.LogInformation($"Email error: {e.Message}");
            }
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
        public static async void SendEmailToUser(GraphServiceClient graphClient, ILogger log, string emails, string siteUrl, string displayName, string displayNameFr, string status, string comments, string requester, string requesterEmail, string EmailSender, string HD_Email, string ErrorMessage, string FunctionApp, string Method)
        {

            switch (status)
            {
                case "Submitted":
                    var submitMsg = new Message
                    {
                        Subject = "We received your request for a GCXchange community / Nous avons reçu votre demande concernant une collectivité sur GCÉchange",
                        Body = new ItemBody
                        {
                            ContentType = BodyType.Html,
                            Content = Templates.RequestReceived(displayName, displayNameFr)
                        },
                        ToRecipients = new List<Recipient>()
                        {
                            new Recipient { EmailAddress = new EmailAddress { Address = $"{requesterEmail}" } }
                        }
                    };
                    try
                    {
                        await graphClient.Users[EmailSender].SendMail(submitMsg).Request().PostAsync();
                        log.LogInformation($"Send email to {requesterEmail} successfully.");
                    }
                    catch (ServiceException e)
                    {
                        log.LogError($"Exception: {e.Message}");
                        if (e.InnerException is not null)
                            log.LogError($"InnerException: {e.InnerException.Message}");
                        log.LogError($"Exception: {e.StackTrace}");
                    }
                    break;
                case "Rejected":


                    log.LogInformation($"comments: {comments}");

                    var rejectMsg = new Message
                    {
                        Subject = "Sorry, your GCXchange community was not created / Malheureusement, votre collectivité GCÉchange n'a pas été créé",
                        Body = new ItemBody
                        {
                            ContentType = BodyType.Html,
                            Content = Templates.RequestRejected(displayName, displayNameFr, comments)
                        },
                        ToRecipients = new List<Recipient>()
                        {
                            new Recipient { EmailAddress = new EmailAddress { Address = $"{requesterEmail}" } }
                        }
                    };

                    //var saveToSentItems = false;
                    await graphClient.Users[EmailSender].SendMail(rejectMsg).Request().PostAsync();
                    log.LogInformation($"Send email to {requesterEmail} successfully.");

                    break;
                case "Team Created":
                    var message = new Message
                    {
                        Subject = "Your GCXchange community is ready/Votre collectivité GCÉchange est prête",
                        Body = new ItemBody
                        {
                            ContentType = BodyType.Html,
                            Content = Templates.RequestApproved(displayName, displayNameFr, requester, siteUrl)
                        },
                        ToRecipients = new List<Recipient>()
                            {
                                new Recipient { EmailAddress = new EmailAddress { Address = $"{requesterEmail}" } }
                            }
                    };

                    var saveToSentItems = false;
                    await graphClient.Users[EmailSender].SendMail(message, saveToSentItems).Request().PostAsync();
                    log.LogInformation($"Send email to {requesterEmail} successfully.");

                    break;
                case "Notif_HD":
                    var HD_Msg = new Message
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
                    };
                    try
                    {
                        await graphClient.Users[EmailSender].SendMail(HD_Msg).Request().PostAsync();
                        log.LogInformation($"Send email to {HD_Email} successfully.");
                    }
                    catch (ServiceException e)
                    {
                        log.LogInformation($"Error: {e.Message}");
                    }

                    break;
                case "Failed":
                    var failedMsg = new Message
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
                    };
                    try
                    {
                        await graphClient.Users[EmailSender].SendMail(failedMsg).Request().PostAsync();
                        log.LogInformation($"Send email to {requesterEmail} successfully.");
                    }
                    catch (ServiceException e)
                    {
                        log.LogInformation($"Error: {e.Message}");
                    }

                    break;
                default:
                    log.LogInformation($"The status was {status}. This status is not part of the switch statement.");
                    break;
            };
        }
    }
}