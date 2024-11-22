namespace MentorBookingManagement
{
    public class MentorRequest
    {
        public int MentorId { get; set; }
        public string MentorName { get; set; } = null!;
        public string Skill { get; set; } = null!;
        public string Expertise { get; set; } = null!;
        public int ScheduleId { get; set; }
        public int BookingLimited { get; set; }

    }
}
