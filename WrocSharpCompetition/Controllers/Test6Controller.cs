using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WrocSharpCompetition.Models;

namespace WrocSharpCompetition.Controllers
{
    public class Test6Controller : BaseTestController
    {
        [CanStartTest(TestNumber = 6)]
        public ActionResult Index()
        {
            var test = _context.Set<Test>().First(el => el.Number == 6);
            return View(test);
        }

        [HttpPost]
        [CanStartTest(TestNumber = 6)]
        public ActionResult Index(string answer = "")
        {
            var fixedAnswer = answer.ToUpper().Replace(" ", "");

            if (fixedAnswer != "PEOPLE")
            {
                ModelState.AddModelError("", "Answer is not correct. Try again.");
                var test = _context.Set<Test>().First(el => el.Number == 6);
                return View("Index", test);
            }

            return SaveAnswerAndRedirect(6);
        }
    }
}