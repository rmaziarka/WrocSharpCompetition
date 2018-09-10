using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WrocSharpCompetition.Models;

namespace WrocSharpCompetition.Controllers
{
    public class Test4Controller : BaseTestController
    {
        [CanStartTest(TestNumber = 4)]
        public ActionResult Index()
        {
            var test = _context.Set<Test>().First(el => el.Number == 4);
            return View(test);
        }

        [HttpPost]
        [CanStartTest(TestNumber = 4)]
        public ActionResult Index(string answer = "")
        {
            var answers = new []{ "TALOFA", "FALOPA", "TALOFALAVA", "MALOLESOIFUA", "MALO"};
            var fixedAnswer = answer.ToUpper().Replace(" ", "");

            if (!answers.Contains(fixedAnswer))
            {
                ModelState.AddModelError("", "Answer is not correct. Try again.");
                var test = _context.Set<Test>().First(el => el.Number == 4);
                return View("Index", test);
            }

            return SaveAnswerAndRedirect(4);
        }
    }
}