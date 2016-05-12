using System.Collections.Generic;

namespace ShiftAssist.Models
{
    public class Violation
    {
        public Rule RuleViolated { get; set; }
        public List<Shift> OffendingShifts { get;  set; }


        public Violation(Rule ruleViolated, List<Shift> shifts)
        {
            RuleViolated = ruleViolated;
            OffendingShifts = shifts;
        }
    }
}
