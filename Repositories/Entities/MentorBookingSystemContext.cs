using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Repositories.Entities
{
    public partial class MentorBookingSystemContext : DbContext
    {
        public MentorBookingSystemContext()
        {
        }

        public MentorBookingSystemContext(DbContextOptions<MentorBookingSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<BookingTransaction> BookingTransactions { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<GroupMember> GroupMembers { get; set; } = null!;
        public virtual DbSet<GroupProject> GroupProjects { get; set; } = null!;
        public virtual DbSet<HistoryMeetingMentor> HistoryMeetingMentors { get; set; } = null!;
        public virtual DbSet<Mentor> Mentors { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Wallet> Wallets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(this.GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true).Build();
            return config["ConnectionStrings:DefaultConnectionString"];
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId)
                    .ValueGeneratedNever()
                    .HasColumnName("adminID");

                entity.HasOne(d => d.AdminNavigation)
                    .WithOne(p => p.Admin)
                    .HasForeignKey<Admin>(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_User");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId)
                    .ValueGeneratedNever()
                    .HasColumnName("bookingID");

                entity.Property(e => e.BookingEndDate)
                    .HasColumnType("date")
                    .HasColumnName("bookingEndDate");

                entity.Property(e => e.BookingStartDate)
                    .HasColumnType("date")
                    .HasColumnName("bookingStartDate");

                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.ScheduleId).HasColumnName("scheduleID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Group Project");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Schedule");
            });

            modelBuilder.Entity<BookingTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("Booking Transaction");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("transactionID");

                entity.Property(e => e.BookingAmount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("bookingAmount");

                entity.Property(e => e.BookingId).HasColumnName("bookingID");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bookingStatus");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.WalletId).HasColumnName("walletID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingTransactions)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking Transaction_Booking");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.BookingTransactions)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking Transaction_Wallet");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.FeebackId);

                entity.ToTable("Feedback");

                entity.Property(e => e.FeebackId)
                    .ValueGeneratedNever()
                    .HasColumnName("feebackID");

                entity.Property(e => e.Comment)
                    .HasMaxLength(300)
                    .HasColumnName("comment");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createdDate");

                entity.Property(e => e.RatingPoint).HasColumnName("ratingPoint");

                entity.Property(e => e.StudentId).HasColumnName("studentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedback_Student");
            });

            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Group Members");

                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.StudentId).HasColumnName("studentID");

                entity.HasOne(d => d.Group)
                    .WithMany()
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group Members_Group Project");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group Members_Student");
            });

            modelBuilder.Entity<GroupProject>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("Group Project");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("groupID");

                entity.Property(e => e.LeaderId).HasColumnName("leaderID");

                entity.Property(e => e.ProjectProgress).HasColumnName("projectProgress");

                entity.Property(e => e.ProjectTopic)
                    .HasMaxLength(50)
                    .HasColumnName("projectTopic");

                entity.HasOne(d => d.Leader)
                    .WithMany(p => p.GroupProjects)
                    .HasForeignKey(d => d.LeaderId)
                    .HasConstraintName("FK_Group Project_Student");
            });

            modelBuilder.Entity<HistoryMeetingMentor>(entity =>
            {
                entity.HasKey(e => e.HistoryId);

                entity.ToTable("History meeting mentor");

                entity.Property(e => e.HistoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("historyID");

                entity.Property(e => e.BookingId).HasColumnName("bookingID");

                entity.Property(e => e.MentorId).HasColumnName("mentorID");

                entity.Property(e => e.StudentId).HasColumnName("studentID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.HistoryMeetingMentors)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_History meeting mentor_Booking");
            });

            modelBuilder.Entity<Mentor>(entity =>
            {
                entity.ToTable("Mentor");

                entity.Property(e => e.MentorId)
                    .ValueGeneratedNever()
                    .HasColumnName("mentorID");

                entity.Property(e => e.BookingLimited).HasColumnName("bookingLimited");

                entity.Property(e => e.Expertise)
                    .HasMaxLength(500)
                    .HasColumnName("expertise");

                entity.Property(e => e.MentorName)
                    .HasMaxLength(100)
                    .HasColumnName("mentorName");

                entity.Property(e => e.ScheduleId).HasColumnName("scheduleID");

                entity.Property(e => e.Skill)
                    .HasMaxLength(500)
                    .HasColumnName("skill");

                entity.HasOne(d => d.MentorNavigation)
                    .WithOne(p => p.Mentor)
                    .HasForeignKey<Mentor>(d => d.MentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mentor_User");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("paymentID");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("amount");

                entity.Property(e => e.WalletId).HasColumnName("walletID");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Wallet");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId)
                    .ValueGeneratedNever()
                    .HasColumnName("scheduleID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.MentorId).HasColumnName("mentorID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Mentor)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.MentorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Mentor");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("studentID");

                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.IsLeader).HasColumnName("isLeader");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(100)
                    .HasColumnName("studentName");

                entity.HasOne(d => d.StudentNavigation)
                    .WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("userID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.Property(e => e.WalletId)
                    .ValueGeneratedNever()
                    .HasColumnName("walletID");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("balance");

                entity.Property(e => e.StudentId).HasColumnName("studentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wallet_Student");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
