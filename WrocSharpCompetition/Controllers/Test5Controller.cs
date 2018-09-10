using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WrocSharpCompetition.Models;

namespace WrocSharpCompetition.Controllers
{
    public class Test5Controller : BaseTestController
    {
        [CanStartTest(TestNumber = 5)]
        public ActionResult Index()
        {
            var test = _context.Set<Test>().First(el => el.Number == 5);
            return View(test);
        }

        [HttpPost]
        [CanStartTest(TestNumber = 5)]
        public ActionResult Index(string answer = "")
        {
            var fixedAnswer = answer.ToUpper().Replace(" ", "").Replace(".",",");
            double integralSolution = 0;
            double.TryParse(fixedAnswer, out integralSolution);
            integralSolution = Math.Truncate(integralSolution);

            if (integralSolution != 44.0)
            {
                ModelState.AddModelError("", "Answer is not correct. Try again.");
                var test = _context.Set<Test>().First(el => el.Number == 5);
                return View("Index", test);
            }

            return SaveAnswerAndRedirect(5);
        }
    }
}