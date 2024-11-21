using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            BookingTransactions = new HashSet<BookingTransaction>();
            HistoryMeetingMentors = new HashSet<HistoryMeetingMentor>();
        }

        public int BookingId { get; set; }
        public int GroupId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime BookingStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }

        public virtual GroupProject Group { get; set; } = null!;
        public virtual Schedule Schedule { get; set; } = null!;
        public virtual ICollection<BookingTransaction> BookingTransactions { get; set; }
        public virtual ICollection<HistoryMeetingMentor> HistoryMeetingMentors { get; set; }
    }
}
