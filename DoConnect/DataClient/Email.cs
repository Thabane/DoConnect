using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.IO;
using System.Data;

namespace DataClient
{
    public static class Email
    {
        #region Send Email
        public static bool SendEmail(string strToAddress, string strSubject, string strBody, string strAttachment)
        {
            string strFromAddress = "doconnect@doconnect.co.za";

            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.Body = strBody;
                System.Net.Mail.MailAddress from = new MailAddress(strFromAddress);
                mail.From = from;

                mail.Subject = strSubject;
                mail.ReplyToList.Add("doconnect@doconnect.co.za");
                mail.To.Add(strToAddress);

                if (strAttachment.Equals(""))
                { }
                else
                {
                    Attachment attAttach = new Attachment(strAttachment);
                    mail.Attachments.Add(attAttach);
                }

                SmtpClient client = new SmtpClient("mail.doconnect.co.za");
                client.Port = 25;
                client.Credentials = new System.Net.NetworkCredential("doconnect@doconnect.co.za", "@DoConnect123");
                client.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                client.Send(mail);

                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}
