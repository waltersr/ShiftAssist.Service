using System;
using System.ComponentModel.DataAnnotations;

namespace ShiftAssist.Models
{
    public class Shift
    {
        public int Id { get; protected set; }
        public DateTime Start { get; protected set; }
        public DateTime End { get; protected set; }


        public Shift(DateTime start, DateTime end)
        {
            if (start == default(DateTime) || end == default(DateTime) || start >= end)
                throw new ArgumentOutOfRangeException();

            Start = start;
            End = end;
        }
    }
}
