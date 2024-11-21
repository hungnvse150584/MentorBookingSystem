using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class Feedback
    {
        public int FeebackId { get; set; }
        public int StudentId { get; set; }
        public int RatingPoint { get; set; }
        public string Comment { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
