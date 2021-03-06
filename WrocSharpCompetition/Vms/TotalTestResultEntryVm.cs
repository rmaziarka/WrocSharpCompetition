﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WrocSharpCompetition.Vms
{
    public class TotalTestResultEntryVm
    {
        public string FullName { get; set; }

        public TimeSpan TotalOffset { get; set; }

        public int TotalPoints { get; set; }

        public string UserId { get; set; }
    }

    public class TotalTestResultEntryVmComparer : IEqualityComparer<TotalTestResultEntryVm>
    {
        public bool Equals(TotalTestResultEntryVm x, TotalTestResultEntryVm y)
        {
            return x.UserId == y.UserId;
        }

        public int GetHashCode(TotalTestResultEntryVm obj)
        {
            return obj.UserId.GetHashCode();
        }
    }
}