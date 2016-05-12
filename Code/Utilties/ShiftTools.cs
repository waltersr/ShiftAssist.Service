using System;
using System.Collections.Generic;
using ShiftAssist.Models;


namespace ShiftAssist.Service
{
    static class ShiftTools
    {
        public static TimeSpan GetShiftTimeInRange(List<Shift> shifts, DateTime start, DateTime end)
        {
            long ticks = 0;
            DateTime calculatedStart, calculatedEnd;

            foreach(var shift in shifts)
            {
                // Determine if shift in time range and if so, all of shift or just part.
                // Then determine ticks in time range.
                if (shift.Start < end)
                    calculatedStart = shift.Start > start ? shift.Start : start;
                else
                    continue;

                if (shift.End > start)
                    calculatedEnd = shift.End < end ? shift.End : end;
                else
                    continue;

                ticks += calculatedEnd.Ticks - calculatedStart.Ticks;
            }

            return TimeSpan.FromTicks(ticks);
        }
    }
}
