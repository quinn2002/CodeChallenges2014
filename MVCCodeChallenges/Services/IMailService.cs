using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCodeChallenges.Services
{
    public interface IMailService
    {
        bool SendMail(string from, string to, string subject, string body);
    }
}
