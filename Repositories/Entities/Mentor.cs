using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class Mentor
    {
        public Mentor()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int MentorId { get; set; }
        public string MentorName { get; set; } = null!;
        public string Skill { get; set; } = null!;
        public string Expertise { get; set; } = null!;
        public int ScheduleId { get; set; }
        public int BookingLimited { get; set; }

        public virtual User MentorNavigation { get; set; } = null!;
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
