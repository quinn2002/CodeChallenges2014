using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MVCCodeChallenges.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string from, string to, string subject, string body)
        {
            try
            {
                var msg = new MailMessage(from, to, subject, body);
                var client = new SmtpClient();
                client.Send(msg);
                Debug.WriteLine(String.Concat("*************Sent email (no actual email sent in debug mode): ", msg, "\n**********************"));
            }
            catch (Exception ex)
            {
                // TODO - handle error for release mode
                Debug.WriteLine(String.Concat("*************Sent email FAILED: " + ex));
                return false;
            }

            return true;
        }
    }
}