using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class Schedule
    {
        public Schedule()
        {
            Bookings = new HashSet<Booking>();
        }

        public int ScheduleId { get; set; }
        public int MentorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        public virtual Mentor Mentor { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
