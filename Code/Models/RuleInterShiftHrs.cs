using System;
using System.Collections.Generic;
using System.Linq;


namespace ShiftAssist.Models
{
    /// <summary>
    /// Violation of rule that a worker must have a minimum of 8 hours off between shifts.
    /// </summary>
    public class RuleInterShiftHrs : Rule
    {
        public override string Description => "A minimum of 8 hours off required between shifts.";


        public RuleInterShiftHrs()
        {  }


        /// <summary>
        /// Check for violations of this rule based on shifts and time range.
        /// </summary>
        /// <param name="shifts"></param>
        /// <param name="startDt"></param>
        /// <param name="endDt"></param>
        /// <returns></returns>
        public override IList<Violation> CheckForViolations(List<Shift> shifts, DateTime start, DateTime end)
        {
            List<Violation> violations = new List<Violation>();
            List<Shift> orderedFilteredShifts;
            
            if (start == default(DateTime) || end == default(DateTime))
                throw new ArgumentOutOfRangeException();

            if (shifts != null && shifts.Count > 0)
            {
                // Filter out shifts not within time range and order shifts based on start datetime.
                orderedFilteredShifts = shifts.Where(s => s.Start <= end && s.End >= start). OrderBy(s => s.Start).ToList<Shift>();

                // Step through ordered and filtered shifts and inspect break periods between shifts, break must be 8 or more hrs.
                for (int i = 0; i < orderedFilteredShifts.Count(); i++)
                {
                    // If not last shift, compare end of current shift to start of next shift.
                    // If it is last shift and less than 8 hours to the end of the time range from the end of shift, it cannot be determined if a violation occurred.
                    // So, there is no need to look at time from end of last shift to end of time range.
                    if (i + 1 < orderedFilteredShifts.Count())
                    {
                        if (orderedFilteredShifts[i + 1].Start.Ticks - orderedFilteredShifts[i].End.Ticks < TimeSpan.TicksPerHour * 8)
                            violations.Add(new Violation(this, new List<Shift>() { orderedFilteredShifts[i] }));
                    }
                }
            }

            return violations;
        }
    }
}
