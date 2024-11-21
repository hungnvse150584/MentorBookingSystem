using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class GroupMember
    {
        public int GroupId { get; set; }
        public int StudentId { get; set; }

        public virtual GroupProject Group { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
