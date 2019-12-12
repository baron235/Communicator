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
        public virtual DbSet<UserFile> UserFile { get; set; }

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
                entity.HasKey(e => e.Login)
                    .HasName("PK__communic__7838F27381967C34");

                entity.ToTable("communicator_user");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar).HasColumnName("avatar");

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

                entity.HasOne(d => d.AvatarNavigation)
                    .WithMany(p => p.CommunicatorUser)
                    .HasForeignKey(d => d.Avatar)
                    .HasConstraintName("FK__communica__avata__5CD6CB2B");
            });

            modelBuilder.Entity<Friendship>(entity =>
            {
                entity.ToTable("friendship");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Friend1)
                    .IsRequired()
                    .HasColumnName("friend1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Friend2)
                    .IsRequired()
                    .HasColumnName("friend2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Friend1Navigation)
                    .WithMany(p => p.FriendshipFriend1Navigation)
                    .HasForeignKey(d => d.Friend1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__friendshi__frien__5FB337D6");

                entity.HasOne(d => d.Friend2Navigation)
                    .WithMany(p => p.FriendshipFriend2Navigation)
                    .HasForeignKey(d => d.Friend2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__friendshi__frien__60A75C0F");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.FromUser)
                    .IsRequired()
                    .HasColumnName("from_user")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsRead).HasColumnName("isread");

                entity.Property(e => e.MessageType).HasColumnName("message_type");

                entity.Property(e => e.SendTime)
                    .HasColumnName("send_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ToUser)
                    .IsRequired()
                    .HasColumnName("to_user")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK__message__file_id__656C112C");

                entity.HasOne(d => d.FromUserNavigation)
                    .WithMany(p => p.MessageFromUserNavigation)
                    .HasForeignKey(d => d.FromUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__message__from_us__6383C8BA");

                entity.HasOne(d => d.ToUserNavigation)
                    .WithMany(p => p.MessageToUserNavigation)
                    .HasForeignKey(d => d.ToUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__message__to_user__6477ECF3");
            });

            modelBuilder.Entity<UserFile>(entity =>
            {
                entity.ToTable("user_file");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
