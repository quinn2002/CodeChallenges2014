using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MVCCodeChallenges.Services
{
    public class MockMailService : IMailService
    {
        public bool SendMail(string from, string to, string subject, string body)
        {
            string msg = String.Format("**********************\nFrom: {1}{0}To:{2}{0}Subject: {3}{0}Body: \n\n{4}{0}\n************************************",
                Environment.NewLine,
                from,
                to,
                subject,
                body);
            Debug.WriteLine(String.Concat("Sent email (no actual email sent in debug mode): ", msg));
            return true;
        }
    }
}