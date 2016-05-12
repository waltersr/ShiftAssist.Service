using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ShiftAssist.Models
{
    public class Resident : Worker
    {
        public Resident() : base()
        {  }


        public override IList<Violation> CheckForViolations(DateTime start, DateTime end)
        {
            List<Violation> violations = new List<Violation>();
            RulesToCheck.ForEach(rule => violations.AddRange(rule.CheckForViolations(Shifts, start, end)));
            return violations;
        }


        public override void SetRulesToCheck()
        {
            RulesToCheck.Add(new RuleInterShiftHrs());
            RulesToCheck.Add(new RuleIntraShiftHrs());
            RulesToCheck.Add(new RuleWeeklyDayOff());
            RulesToCheck.Add(new RuleWeeklyWorkedHrs());
        }
    }
}