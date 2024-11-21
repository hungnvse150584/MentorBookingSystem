using System;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public partial class Student
    {
        public Student()
        {
            Feedbacks = new HashSet<Feedback>();
            GroupProjects = new HashSet<GroupProject>();
            Wallets = new HashSet<Wallet>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public bool? IsLeader { get; set; }
        public int GroupId { get; set; }

        public virtual User StudentNavigation { get; set; } = null!;
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<GroupProject> GroupProjects { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
