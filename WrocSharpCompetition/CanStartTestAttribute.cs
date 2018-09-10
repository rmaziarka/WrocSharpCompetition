using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WrocSharpCompetition.Models;

namespace WrocSharpCompetition
{
    public class CanStartTestAttribute: ActionFilterAttribute
    {
        public int TestNumber { get; set;}
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var context = new ApplicationDbContext();

            var test = context.Set<Test>().First(el => el.Number == TestNumber);
            if (test.Status != TestStatus.Started)
            {
                var url = test.Status == TestStatus.NotStarted
                    ? "/Home/TestHasNotStarted"
                    : "/Home/TestHasEnded";
                url += "?number=" + test.Number;

                filterContext.Result = new RedirectResult(url);
                return;
            }

            var userId = HttpContext.Current.User.Identity.GetUserId();
            var testAnswer = context.Set<TestAnswer>()
                .FirstOrDefault(el => el.UserId == userId && el.TestId == test.Id);

            if (testAnswer != null)
            {
                var url = "/Home/TestAnswered?number=" + test.Number;
                filterContext.Result = new RedirectResult(url);
            }
        }

    }
}