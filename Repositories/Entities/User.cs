using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual Admin? Admin { get; set; }
        public virtual Mentor? Mentor { get; set; }
        public virtual Student? Student { get; set; }
    }
}
