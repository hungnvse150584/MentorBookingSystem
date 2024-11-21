using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class GroupProject
    {
        public GroupProject()
        {
            Bookings = new HashSet<Booking>();
        }

        public int GroupId { get; set; }
        public string ProjectTopic { get; set; } = null!;
        public int? LeaderId { get; set; }
        public string ProjectProgress { get; set; } = null!;

        public virtual Student? Leader { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
