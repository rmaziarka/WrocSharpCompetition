using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WrocSharpCompetition.Models;
using WrocSharpCompetition.Vms;

namespace WrocSharpCompetition.Controllers
{
    [Authorize]
    public class BaseTestController : Controller
    {
        protected ApplicationDbContext _context;
        public BaseTestController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult SaveAnswerAndRedirect(int testNumber)
        {
            var test = _context.Set<Test>().First(el => el.Number == testNumber);
            var testAnswer = new TestAnswer()
            {
                TestId = test.Id,
                UserId = User.Identity.GetUserId(),
                AnsweringTime = DateTime.Now,
                AnsweringTimeOffset = DateTime.Now.Subtract(test.StartDate.Value)
            };

            _context.Set<TestAnswer>().Add(testAnswer);
            _context.SaveChanges();

            var vm = new AnswerVm() {TestAnswer = testAnswer, TestNumber = testNumber };
            return View("Answered", vm);
        }

    }
}