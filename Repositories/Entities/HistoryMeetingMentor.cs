using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class HistoryMeetingMentor
    {
        public int HistoryId { get; set; }
        public int BookingId { get; set; }
        public int? StudentId { get; set; }
        public int? MentorId { get; set; }

        public virtual Booking Booking { get; set; } = null!;
    }
}
