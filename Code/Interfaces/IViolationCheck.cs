using System.Collections.Generic;

using ShiftAssist.Models;

namespace ShiftAssist.Interfaces
{
    interface IViolationCheck
    {
        void SetViolationsToCheck();
        List<Violation> CheckForViolations();
    }
}
