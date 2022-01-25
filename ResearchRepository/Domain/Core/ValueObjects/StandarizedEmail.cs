using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ResearchRepository.Domain.Core.ValueObjects
{
    public class StandarizedEmail
    {
        private string content= "";

        public StandarizedEmail(string newContent) //for tests and specific content
        {
            content = newContent;
        }
        public StandarizedEmail(int emailType)
        {
            switch (emailType)
            {
                case 1: //A new has just been published
                    content = File.ReadAllText("../WebApplication_ResearchRepository/wwwroot/emails/NewsEmail.html");
                    break;
                case 2: //An account confirmation email
                    content = File.ReadAllText("../WebApplication_ResearchRepository/wwwroot/emails/AccountVerification.html");
                    break;
                case 3:
                    content = File.ReadAllText("../WebApplication_ResearchRepository/wwwroot/emails/PasswordReset.html");
                    break;
                case 4:
                    content = File.ReadAllText("../WebApplication_ResearchRepository/wwwroot/emails/ContactFormEmail.html");
                    break;
                case 5:
                    content = File.ReadAllText("../WebApplication_ResearchRepository/wwwroot/emails/ReceiveFormConfirmation.html");
                    break;
                default:
                    content = File.ReadAllText("../WebApplication_ResearchRepository/wwwroot/emails/DefaultEmail.html");
                    break;                
            }
        }

        public void setSubscriptionEmailContent(string groupName, string link)
        {
            content = content.Replace("NOMBRE_GRUPO", groupName);
            content = content.Replace("LINK_NOTICIA", link);
        }

        public void setAccountConfirmationEmail(string emailTokenURL)
        {
            content = content.Replace("LINK_VERIFICACION",emailTokenURL);
        }

        public void setDefaultContent(string newContent)
        {
            content = content.Replace("DEFAULT_CONTENT",newContent);
        }
        public void setResetPassword(string link)
        {
            content = content.Replace("LINK_RECUPERACION", link);
        }
        public void setContactFormContent(string groupName, string userName, string subject, string organization = "")
        {
            content = content.Replace("GROUP_NAME", groupName);
            content = content.Replace("USER_NAME", userName);
            content = content.Replace("SUBJECT", subject);
            if (organization != "")
            {
                content = content.Replace("ORGANIZATION", organization);
            }
            else
            {
                content = content.Replace("ORGANIZATION", "-");
            }
        }

        public string getContent()
        {
            return content;
        }

    }
}

