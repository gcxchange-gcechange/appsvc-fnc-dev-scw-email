namespace appsvc_fnc_dev_scw_email_dotnet001
{
    internal class Templates
    {
        public static string RequestReceived(string displayNameEn, string displayNameFr)
        {
            return @$"
            <a href='#fr'>La version française suit</a> 
 
            <p>Hello from GCXchange!</p>
 
            <p>Thank you for your request for a new community on GCXchange <strong>{displayNameEn}</strong>.</p>
 
            <p><strong>So, what's next?</strong></p>
 
            <p>We will review your request and if all is in order, your new community will be created. At that time, you will receive a second e-mail with the details you need to finish creating the community page and begin collaborating.</p>
 
            <p>This process takes 24 to 48 business hours from the time you submitted your request.</p>
 
            <strong>In the meantime,</strong><br/>
            <br/>
            Have a look at the <a href='https://gcxgce.sharepoint.com/sites/Support'>GCXchange Support page</a> for:<br/>
            <ul>
	            <li>Tips for becoming a collaboration pro</li>
	            <li>Best practices for Information management</li>
	            <li>Terms and conditions</li>
            </ul>

            <p>We at GCXchange are always keeping accessibility in mind, guided by the Accessible Canada Act. Visit our <a href='https://gcxgce.sharepoint.com/sites/Support'>Support Page</a> to learn more.</p>
            
            <br/>

            <p>Looking forward to collaborating with you!</p>
            
            The GCXchange team<br />
            <br />

            <hr>

            <p id='fr'>Bonjour!</p>
 
            <p>Merci pour votre demande concernant la création d’une nouvelle collectivité sur GCÉchange <strong>{displayNameFr}</strong>.</p>
 
            <p><strong>Quelles sont donc les prochaines étapes?</strong></p>
 
            <p>Nous examinerons votre demande et, si tout est en ordre, votre nouvelle collectivité sera créée. Vous recevrez alors un deuxième courriel renfermant les renseignements nécessaires pour terminer la création de la page de la collectivité et commencer à collaborer.</p>
 
            <p>Ce processus prend de 24 à 48 heures ouvrables à partir du moment où vous soumettez votre demande.</p>
 
            <strong>Entre-temps</strong><br />
            <br />
            Jetez un coup d’œil à la <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/fr/Home.aspx'>page de soutien GCÉchange</a> pour :<br />
            <ul>
                <li>des conseils pour devenir un pro de la collaboration;</li>
                <li>des pratiques exemplaires relatives à la gestion de l’information;</li>
                <li>les conditions d’utilisation.</li>
            </ul>

            <p>À GCÉchange, nous gardons toujours l’accessibilité à l’esprit, guidés par la Loi canadienne sur l’accessibilité. Visitez notre <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/fr/Home.aspx'>page de soutien</a> pour en apprendre davantage.</p>
            
            <br />

            <p>Au plaisir de collaborer avec vous!</p>

            L’équipe de GCÉchange
            ";
        }

        public static string RequestReceivedProB(string displayNameEn, string displayNameFr)
        {
            return @$"
            <a href='#fr'>La version française suit</a>

            <p>Hello from GCXchange!</p>

            <p>Thank you for requesting a new Protected B community on GCXchange {displayNameEn}.</p>

            <p>We are reviewing your request. This process takes 24 to 48 business hours from the time you submitted your request. If your request is approved, you will receive a second e-mail with the details you need to finish creating the community page and begin collaborating.</p>

            <p>In the meantime, visit the <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/FAQ.aspx'>GCXchange Support page</a> for <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/Learn-more-about-gcxchange.aspx'>tips and tricks</a> on becoming a collaboration pro:</p>

            <ul>
                <li>Check out the <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/FAQ.aspx'>FAQs</a>, specifically the section on Protected A and B communities and information</li>
                <li>Review the Terms and Conditions of use for Protected A and B Communities so that you know your roles and responsibilities as the Owner of a Protected community</li>
                <li>Learn how to promote accessibility on your community</li>
            </ul>

            <br />

            <p>Looking forward to collaborating with you!</p>

            The GCXchange team<br />
            <br />

            <hr>

            <p id='fr'>Bonjour!</p>

            <p>Merci pour votre demande concernant la création d’une nouvelle collectivité ayant accès aux renseignements Protégé B sur GCÉchange {displayNameFr}.</p>

            <p>Nous examinons votre demande. Ce processus prend de 24 à 48 heures ouvrables à partir du moment où vous soumettez votre demande. Si votre demande est approuvée, vous recevrez un deuxième courriel renfermant les renseignements nécessaires pour terminer la création de la page de la collectivité et commencer à collaborer.</p>

            <p>En attendant, consultez la <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/fr/FAQ.aspx'>page de soutien GCÉchange</a> pour obtenir des <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/fr/Learn-more-about-gcxchange.aspx'>conseils</a> pour devenir un pro de la collaboration :</p>

            <ul>
                <li>Consultez la <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/fr/FAQ.aspx'>FAQ</a>, en particulier la section sur les collectivités et les renseignements Protégé A et Protégé B.</li>
                <li>Passez en revue les conditions d’utilisation pour les collectivités ayant accès aux renseignements Protégé A et Protégé B pour connaître vos rôles et responsabilités en tant que propriétaire d’une collectivité ayant accès à des renseignements protégés.</li>
                <li>Apprenez à promouvoir l’accessibilité dans votre collectivité.</li>
            </ul>

            <br />

            <p>Au plaisir de collaborer avec vous!</p>

            L’équipe de GCÉchange
            ";
        }

        public static string RequestRejected(string displayNameEn, string displayNameFr, string comments)
        {
            return @$"
            <a href='#fr'>La version française suit</a>
 
            <p>We have reviewed your request for a GCXchange community <strong>{displayNameEn}</strong>.</p>
 
            <p>Your request has not been approved at this time for the following reason(s):</p>
 
            <p>{comments}</p>
            <br />

            <p>We are here to help!  If you are still interested in creating a community, or if you think that our decision has been made by error, please contact us via the <a href='https://gcxgce.sharepoint.com/sites/Support'>GCXchange Support Page</a></p>

            <br /> 

            <p>We are looking forward to seeing you back on GCXchange soon to connect and collaborate!</p>

            The GCXchange team<br />
            <br />

            <hr>

            <p id='fr'>Nous avons examiné votre demande de création d’une collectivité GCÉchange <strong>{displayNameFr}</strong>.</p>
 
            <p>À cette étape, votre demande n’a pas été approuvée pour la ou les raisons suivantes:</p>

            <p>{comments}</p>
            <br />

            <p>Nous sommes là pour vous aider! Si vous souhaitez toujours créer une collectivité, ou si vous pensez que notre décision a été faite par erreur, veuillez communiquer avec nous par l’entremise de la <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/fr/Home.aspx'>page d’aide de GCÉchange</a>.</p>

            <br />

            <p>Nous espérons vous revoir bientôt sur GCÉchange pour tisser des liens et collaborer!</p>

            L’équipe GCÉchange
            ";
        }

        public static string RequestRejectedProB(string displayNameEn, string displayNameFr, string comments)
        {
            return @$"
            <a href='#fr'>La version française suit</a> 

            <p>We have reviewed your request for a GCXchange Protected B community {displayNameEn}.</p>

            <p>Your request has not been approved at this time for the following reason(s):</p>

            <p>{comments}</p>

            <p>If you are still interested in creating a community, or if you think that our decision has been made by error, please <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/Submit-a-ticket.aspx'>submit a ticket</a> to our Support team.</p>

            <br />

            <p>We are looking forward to seeing you back on GCXchange soon to connect and collaborate!</p>

            The GCXchange team<br />
            <br />

            <hr>
 
            <p id='fr'>Nous avons examiné votre demande de création d’une collectivité ayant accès aux renseignements Protégé B sur GCÉchange {displayNameEn}.</p>

            <p>À cette étape, votre demande n’a pas été approuvée pour la ou les raisons suivantes :</p>

            <p>{comments}</p>

            <p>Si vous souhaitez toujours créer une collectivité, ou si vous pensez que notre décision a été faite par erreur, veuillez <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/fr/Submit-a-ticket.aspx'>soumettre un billet</a> à notre équipe de soutien.</p>

            <br />

            <p>Nous espérons vous revoir bientôt sur GCÉchange pour tisser des liens et collaborer!</p>

            L’équipe de GCÉchange 
            ";
        }

        public static string RequestApproved(string displayNameEn, string displayNameFr, string communityOwner, string siteUrl)
        {
            return @$"
            <a href='#fr'>La version française suit</a> 

            <p><strong>Welcome to GCXchange!</strong></p>

            <p>{communityOwner}, your community {displayNameEn} is now ready for collaboration!</p>

            <p><strong>How do you access your community on GCXchange SharePoint?</strong></p>

            <p>Easy! Follow this <a href='{siteUrl}'>link</a> to access your community.</p>

            <p><strong>How do you access your community on Microsoft (MS) Teams?</strong></p>

            <p>To access your Teams channel, click “Conversations” on your SharePoint page.</p>

            <p>From now on, when you open the MS Teams app you can switch between your new GCXchange Teams account and your departmental Teams account. Follow these simple instructions:</p>
            <ol>
                <li>Open MS Teams</li>
                <li>Click on your Avatar</li>
                <li>Select either GCXchange or your department from the drop-down option, and you will be able to switch between the two Teams sessions</li>
            </ol>

            <p>Pro tip: access GCXchange Teams using a web browser so that you can have both GCXchange Teams and your departmental Teams sessions open at the same time.</p>

            <p><strong>So, what's next?</strong></p>
            <ol>
                <li>Start adding content to your SharePoint community page on GCXchange
                <li>Start conversations and upload files to your GCXchange Teams channel
            </ol>

            <p>Visit the <a href='https://gcxgce.sharepoint.com/sites/Support'>GCXchange Support page</a> for more tips and information about communities.</p>

            <br />

            <p>Happy Collaborating!</p>

            The GCXchange team<br />

            <br />
            <hr>

            <p id='fr'><strong>Bienvenue à GCÉchange!</strong></p>

            <p>{communityOwner}, votre collectivité {displayNameFr} est à prête à accueillir des collaborations!</p>

            <p><strong>Comment accéder à la collectivité GCÉchange sur la plateforme SharePoint?</strong></p>

            <p>C’est facile à faire! Cliquez sur ce <a href='{siteUrl}/SitePages/fr/Home.aspx'>lien</a> pour accéder à votre collectivité.</p>

            <p><strong>Comment accéder à la collectivité GCÉchange sur la plateforme MS Teams?</strong></p>

            <p>Pour accéder à votre plateforme sur Teams, cliquez sur la rubrique «Conversations» sur la page SharePoint.</p>

            <p>Dorénavant, quand vous ouvrez votre application MS Teams, vous pouvez alterner entre votre nouveau compte GCÉchange Teams et votre compte Teams administratif. Suivez ces instructions simples:</p>
            <ol>
                <li>Ouvrez MS Teams.</li>
                <li>Cliquez sur votre avatar.</li>
                <li>Sélectionnez soit le compte GCÉchange soit le compte administratif du menu déroulant, et vous pourrez passer entre les deux séances sur Teams.</li>
            </ol>

            <p>Astuce pro: Accédez à GCÉchange Teams à l’aide d’un navigateur Web afin de pouvoir ouvrir en même temps les séances de GCÉchange Teams et celles de votre administration.</p>

            <p><strong>Quelle est la prochaine étape?</strong></p>
            <ol>
                <li>Vous pouvez maintenant ajouter du contenu à la page GCÉchange sur SharePoint.</li>
                <li>Commencez des conversations et téléchargez des dossiers sur votre chaîne Teams GCÉchange.</li>
            </ol>

            <p>Veuillez consulter la <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/fr/Home.aspx'>page assistance de GCÉchange</a> pour obtenir plus d’astuce et de plus amples renseignements sur les collectivités.</p>

            <br />

            <p>Bonne continuation avec cette collaboration!</p>

            Équipe GCÉchange
            ";
        }

        public static string RequestApprovedProB(string displayNameEn, string displayNameFr, string communityOwner, string siteUrl)
        {
            return @$"
            <a href='#fr'>La version française suit</a>

            <p>Welcome to GCXchange!</p> 

            <p>{communityOwner}, your Protected B community {displayNameEn} is now ready!</p> 

            <p>Please note that protected information can only be shared in a Protected A and B community in GCXchange. It is important to review and accept the Terms and Conditions of use for Protected A and B communities before proceeding.</p>

            <p>To access your community, visit <a href='{siteUrl}'>{displayNameEn}</a>.</p>

            <p>You can also access your community’s Teams channel by clicking “Conversations” in the menu on your SharePoint page.</p>

            <p>Now, you can start adding content to your SharePoint community page on GCXchange.</p>

            <p>You should also invite your Members to your new community. Since this is a Protected B community, Members cannot search for it, and only Owners can invite them.</p>

            <p>Please inform your co-Owners that the community has now been approved and that they need to review and approve the Terms and Conditions of use for Protected A and B communities. Don't forget that your community needs to have at least 2 Owners at all times.</p>

            <p>Visit the GCXchange Support page for more information about Protected A and B communities, including <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/FAQ.aspx'>helpful FAQs</a>.</p>

            <br />

            <p>Happy Collaborating!</p>

            The GCXchange team<br />
            <br />

            <hr>

            <p id='fr'><strong>Bienvenue à GCÉchange!</strong></p>

            <p>{communityOwner}, votre collectivité ayant accès aux renseignements Protégé B {displayNameFr} est maintenant prête!</p>

            <p>Veuillez noter que les renseignements protégés ne peuvent être partagés que dans une collectivité ayant accès aux renseignements Protégé A et Protégé B dans GCÉchange. Il est important d’examiner et d’accepter les conditions d’utilisation pour les collectivités ayant accès aux renseignements Protégé A et Protégé B avant d’aller de l’avant.</p>

            <p>Pour accéder à votre collectivité, visitez <a href='{siteUrl}/SitePages/fr/Home.aspx'>{displayNameFr}</a>.</p>

            <p>Vous pouvez également accéder au canal Teams de votre collectivité en cliquant sur « Conversations » dans le menu de votre page sur SharePoint.</p>

            <p>Vous pouvez maintenant commencer à ajouter du contenu à la page GCÉchange de votre collectivité sur SharePoint.</p>

            <p>Vous devriez également inviter vos membres dans votre nouvelle collectivité. Étant donné que c’est une collectivité ayant aux renseignements Protégé B, les membres ne peuvent pas la chercher, et seuls les propriétaires peuvent les inviter.</p>

            <p>Veuillez informer vos copropriétaires que la collectivité a maintenant été approuvée et qu’ils doivent examiner et approuver les conditions d’utilisation pour les collectivités ayant accès aux renseignements Protégé A et Protégé B. N’oubliez pas que votre collectivité doit avoir au moins deux propriétaires en tout temps.</p>

            <p>Visitez la page de soutien GCÉchange pour obtenir de plus amples renseignements sur les collectivités ayant accès aux renseignements Protégé A et Protégé B, y compris une <a href='https://gcxgce.sharepoint.com/sites/Support/SitePages/fr/FAQ.aspx'>FAQ utile</a>.</p>

            <br />

            <p>Bonne collaboration!</p>

            L’équipe de GCÉchange 
            ";
        }
    }
}