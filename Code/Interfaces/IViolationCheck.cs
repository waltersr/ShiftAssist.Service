﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShiftAssist.Models;

namespace ShiftAssist.Interfaces
{
    interface IViolationCheck
    {
        void SetRulesToCheck();
        IList<Violation> CheckForViolations(DateTime startDt, DateTime endDt);
    }
}
