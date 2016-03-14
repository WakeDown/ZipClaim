﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using MailMessage = System.Net.Mail.MailMessage;
using MailPriority = System.Net.Mail.MailPriority;

namespace ZipClaim.Helpers
{
    public class MessageHelper
    {
        public class Email
        {
            #region constructor
            public Email(string appPath)
            {
                //var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var config = WebConfigurationManager.OpenWebConfiguration(appPath);
                var mailSettings = config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
                _smtpmailserver = mailSettings.Smtp.Network.Host;
                _portnumber = mailSettings.Smtp.Network.Port;
                _fromAddress = mailSettings.Smtp.From;
            }
            #endregion constructor

            private static string _smtpmailserver = ConfigurationManager.AppSettings["smtpServer"];
            private static string _fromAddress = ConfigurationManager.AppSettings["addressFrom"];
            private static int _portnumber = 25;

            public static void SendMail(string toAddress, string subject, string text)
            {
                //var smtp = new SmtpClient();
                //smtp.Host = _smtpmailserver;
                //smtp.Port = _portnumber;
                ////smtp.EnableSsl = true;
                ////smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                ////smtp.Credentials = new NetworkCredential("", "");
                //smtp.Timeout = 20000;

                //text = text.Replace("\r\n", "<br />").Replace("\r", "<br />").Replace("\n", "<br />");

                //MailMessage msg = new MailMessage(_fromAddress, toAddress, subject, text);
                //msg.IsBodyHtml = true;

                //smtp.Send(msg);

                MailMessage mail = new MailMessage();
                //foreach (MailAddress ma in to)
                //{
                //    mail.To.Add(ma);
                //}
                mail.To.Add(new MailAddress(toAddress));

                mail.Subject = subject;
                mail.Body = text;
                mail.IsBodyHtml = true;
                //if (form == null)
                //{
                mail.From = new MailAddress("delivery@unitgroup.ru");
                //}
                //else
                //{
                //    mail.From = form; 
                //}

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.office365.com";
                client.Credentials = new NetworkCredential("delivery@unitgroup.ru", "pRgvD7TL");
                Task.Run(() => client.Send(mail));
            }

        }
    }
}