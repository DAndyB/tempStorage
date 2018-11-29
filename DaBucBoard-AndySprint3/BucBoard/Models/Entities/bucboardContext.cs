using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BucBoard.Models.Entities
{
    public partial class bucboardContext : DbContext
    {
        public bucboardContext()
        {
        }

        public bucboardContext(DbContextOptions<bucboardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<Custom> Custom { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Premade> Premade { get; set; }
        public virtual DbSet<Recurring> Recurring { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=bucboard.c6qfhcwpa69s.us-east-2.rds.amazonaws.com;port=3306;user=bucboard;password=se2fall2018;database=bucboard");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.ToTable("Calendar", "bucboard");

                entity.HasIndex(e => e.UserId)
                    .HasName("userID");

                entity.Property(e => e.CalendarId)
                    .HasColumnName("calendarID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Month)
                    .HasColumnName("month")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Calendar)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Calendar_ibfk_1");
            });

            modelBuilder.Entity<Custom>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("Custom", "bucboard");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EventType)
                    .HasColumnName("eventType")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsAvalible)
                    .HasColumnName("isAvalible")
                    .HasColumnType("tinyint(1)");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.Custom)
                    .HasForeignKey<Custom>(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Custom_ibfk_1");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event", "bucboard");

                entity.HasIndex(e => e.CalendarId)
                    .HasName("calendarID");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CalendarId)
                    .HasColumnName("calendarID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("date");

                entity.Property(e => e.EventName)
                    .HasColumnName("eventName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("date");

                entity.HasOne(d => d.Calendar)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.CalendarId)
                    .HasConstraintName("Event_ibfk_1");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message", "bucboard");

                entity.HasIndex(e => e.EventId)
                    .HasName("eventID");

                entity.Property(e => e.MessageId)
                    .HasColumnName("messageID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reciever)
                    .HasColumnName("reciever")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sender)
                    .HasColumnName("sender")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("Message_ibfk_1");
            });

            modelBuilder.Entity<Premade>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("Premade", "bucboard");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EventType)
                    .HasColumnName("eventType")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.Premade)
                    .HasForeignKey<Premade>(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Premade_ibfk_1");
            });

            modelBuilder.Entity<Recurring>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("Recurring", "bucboard");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IsAvalible)
                    .HasColumnName("isAvalible")
                    .HasColumnType("tinyint(1)");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.Recurring)
                    .HasForeignKey<Recurring>(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Recurring_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "bucboard");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Department)
                    .HasColumnName("department")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("isAdmin")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OfficeNumber)
                    .HasColumnName("officeNumber")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
