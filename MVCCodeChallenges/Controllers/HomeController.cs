using MVCCodeChallenges.Models;
using MVCCodeChallenges.Services;
using MVCCodeChallenges.UtilityClasses;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCodeChallenges.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;
        CodeChallengesDB _db = new CodeChallengesDB();
        
        public HomeController(IMailService mail)
        {
            _mail = mail;
        }
        
        public ActionResult Index()
        {
            List<Challenge> model = _db.Challenges
                                        .Include("ChallengeInputs")
                                        .Include("ChallengeInputs.InputLookupValues")
                                        .OrderBy(c => c.Sequence)
                                        .ToList();

            // user has (ajax) submitted form inputs for a challenge (see challenge.js) - display results, including appropriate error messages if inputs are invalid or other errors occur.
            if (Request.IsAjaxRequest())
            {
                // step 1 of 3: get the right Challenge class path for step 3
                string challengeId = Request["challengeId"];
                int challengeIdNum = 0;
                bool challengeIdToInt = Int32.TryParse(challengeId, out challengeIdNum);
                string challengeClassPath = ChallengeClassPathGenerator.GetChallengeClassPath(challengeIdNum, model);

                
                // step 2 of 3: construct a dictionary of user input vals from the form, where the key is the input name
                OrderedDictionary userVals = new OrderedDictionary();
                foreach (var input in _db.ChallengeInputs.Where(c => c.ChallengeId == challengeIdNum))
                {
                    string key = input.InputNameAttr;
                    if (!String.IsNullOrEmpty(key) && !userVals.Contains(key))
                    {
                        string value = Request[key] == null ? "" : Request[key];
                        value = Server.HtmlEncode(Uri.UnescapeDataString(value));
                        userVals.Add(key, value);
                    }
                }

                // step 3 of 3: dynamically instantiate the appropriate Challenge class and run its OutputResult() method--any validation error strings will be returned from this function
                string output = DynamicMethodInvokeChallengeClass.GetResults(challengeClassPath, userVals);
                if (output != null)
                {
                    return Content(output, "text/html");
                }
                else
                {
                    return Content("Server error.  Corresponding challenge class not found.  Please contact your system administrator.", "text/html");
                }
            }
            else // is NOT an ajax form post
            {
                return View(model);
            }
        }

        public ActionResult GetResource(string filename)
        {
            string file = Server.MapPath("~/Content/Resources/" + filename);
            if (System.IO.File.Exists(file))
                return File("~/Content/Resources/" + filename, MimeMapping.GetMimeMapping(filename), filename);
            else
                return RedirectToAction("Index"); 
        }

        [ChildActionOnly]
        public ActionResult Contact()
        {
            return PartialView("_ContactPartial");
        }

        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            string toAddress = ConfigurationManager.AppSettings["ContactFormToEmail"];
            var msg = String.Format("Comment From: {1}{0}Email:{2}{0}Phone: {3}{0}Comment: {4}{0}",
                Environment.NewLine,
                model.Name,
                model.Email,
                model.Phone,
                model.Comment);

            if (_mail.SendMail(model.Email,
                toAddress,
                "Website contact: " + model.Name, 
                msg))
            {
                ViewBag.MailSent = true;
            }

            return PartialView("_ContactPartial");
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
