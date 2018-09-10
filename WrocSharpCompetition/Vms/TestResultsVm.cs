using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WrocSharpCompetition.Vms
{
    public class TestResultsVm
    {
        public List<SingleTestResultsVm> SingleTestResults { get; set; } 

        public List<TotalTestResultEntryVm> TotalTestResults { get; set; }
    }
}