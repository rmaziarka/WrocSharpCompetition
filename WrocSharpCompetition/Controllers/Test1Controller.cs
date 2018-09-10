using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WrocSharpCompetition.Models;

namespace WrocSharpCompetition.Controllers
{
    public class Test1Controller: BaseTestController
    {
        [CanStartTest(TestNumber = 1)]
        public ActionResult Index()
        {
            var test = _context.Set<Test>().First(el => el.Number == 1);
            return View(test);
        }

        [HttpPost]
        [CanStartTest(TestNumber = 1)]
        public ActionResult Index(string answer = "")
        {
            var fixedAnswer = answer.ToUpper().Replace(" ", "");

            if (fixedAnswer != "0100111101000010010010100100010101000011010101000100100101010110010010010101010001011001")
            {
                ModelState.AddModelError("", "Answer is not correct. Try again.");
                var test = _context.Set<Test>().First(el => el.Number == 1);
                return View("Index", test);
            }

            return SaveAnswerAndRedirect(1);
        }
    }
}