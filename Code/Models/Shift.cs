using System;
using System.ComponentModel.DataAnnotations;

namespace ShiftAssist.Models
{
    public abstract class Shift
    {
        public int Id;
        public DateTime Start { get; protected set; }
        public DateTime End { get; protected set; }
        //public Violation Violation { get; set; }

        public virtual bool IsValid()
        {
            // TODO: Implement Shift.IsValid().
            throw new NotImplementedException();
        }

    }
}
