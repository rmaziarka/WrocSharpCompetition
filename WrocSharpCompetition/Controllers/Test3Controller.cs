using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WrocSharpCompetition.Models;

namespace WrocSharpCompetition.Controllers
{
    public class Test3Controller : BaseTestController
    {
        [CanStartTest(TestNumber = 3)]
        public ActionResult Index()
        {
            var test = _context.Set<Test>().First(el => el.Number == 3);
            return View(test);
        }

        [HttpPost]
        [CanStartTest(TestNumber = 3)]
        public ActionResult Index(string answer = "")
        {
            var fixedAnswer = answer.ToUpper().Replace(" ", "");

            if (fixedAnswer != "READYMIX")
            {
                ModelState.AddModelError("", "Answer is not correct. Try again.");
                var test = _context.Set<Test>().First(el => el.Number == 3);
                return View("Index", test);
            }

            return SaveAnswerAndRedirect(3);
        }
    }
}