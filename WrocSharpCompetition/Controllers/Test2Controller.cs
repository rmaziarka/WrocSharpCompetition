using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WrocSharpCompetition.Models;

namespace WrocSharpCompetition.Controllers
{
    public class Test2Controller : BaseTestController
    {
        [CanStartTest(TestNumber = 2)]
        public ActionResult Index()
        {
            var test = _context.Set<Test>().First(el => el.Number == 2);
            return View(test);
        }

        [HttpPost]
        [CanStartTest(TestNumber = 2)]
        public ActionResult Index(string answer = "")
        {
            var fixedAnswer = answer.ToUpper().Replace(" ", "");

            if (fixedAnswer != "ANVQOFUHUFKUESDQMF")
            {
                ModelState.AddModelError("", "Answer is not correct. Try again.");
                var test = _context.Set<Test>().First(el => el.Number == 2);
                return View("Index",test);
            }

            return SaveAnswerAndRedirect(2);
        }
    }
}