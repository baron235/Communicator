using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Communicator_Backend.Models
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CommunicatorUser> CommunicatorUser { get; set; }
        public virtual DbSet<Friendship> Friendship { get; set; }
        public virtual DbSet<Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\marta\\Documents\\communicatorDataBase.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommunicatorUser>(entity =>
            {
                entity.ToTable("communicator_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Friendship>(entity =>
            {
                entity.ToTable("friendship");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Friend1).HasColumnName("friend1");

                entity.Property(e => e.Friend2).HasColumnName("friend2");

                entity.HasOne(d => d.Friend1Navigation)
                    .WithMany(p => p.FriendshipFriend1Navigation)
                    .HasForeignKey(d => d.Friend1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__friendshi__frien__32E0915F");

                entity.HasOne(d => d.Friend2Navigation)
                    .WithMany(p => p.FriendshipFriend2Navigation)
                    .HasForeignKey(d => d.Friend2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__friendshi__frien__33D4B598");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContentLink)
                    .HasColumnName("content_link")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FromUserId).HasColumnName("from_user_id");

                entity.Property(e => e.IsRead).HasColumnName("isread");

                entity.Property(e => e.MessageType)
                    .HasColumnName("message_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SendTime)
                    .HasColumnName("send_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToUserId).HasColumnName("to_user_id");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.MessageFromUser)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__message__from_us__36B12243");

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.MessageToUser)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__message__to_user__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
