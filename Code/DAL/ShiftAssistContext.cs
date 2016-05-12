using System.Data.Entity;
using ShiftAssist.Models;

namespace ShiftAssist.DAL
{
    public class ShiftAssistContext : DbContext
    {
        public ShiftAssistContext() : base()
        { }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        //public DbSet<Violation> Violations { get; set; }
    }
}