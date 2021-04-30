using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FluentAPI
{
    public class StringConnection : DbContext
    {
        public StringConnection()
            : base("StringConnection")
        {
        }

        public virtual DbSet<Albums> Albums { get; set; }
        public virtual DbSet<Avatars> Avatars { get; set; }
        public virtual DbSet<Dialogs> Dialogs { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<MessageAvatars> MessageAvatars { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<PhotoMessages> PhotoMessages { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserDialogs> UserDialogs { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Albums>()
                .HasMany(e => e.Photos)
                .WithOptional(e => e.Albums)
                .HasForeignKey(e => e.AlbumId);

            modelBuilder.Entity<Avatars>()
                .HasMany(e => e.Likes)
                .WithOptional(e => e.Avatars)
                .HasForeignKey(e => e.Avatars_Id);

            modelBuilder.Entity<Avatars>()
                .HasMany(e => e.MessageAvatars)
                .WithOptional(e => e.Avatars)
                .HasForeignKey(e => e.AvatarId);

            modelBuilder.Entity<Dialogs>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.Dialogs)
                .HasForeignKey(e => e.DialogId);

            modelBuilder.Entity<Dialogs>()
                .HasMany(e => e.UserDialogs)
                .WithOptional(e => e.Dialogs)
                .HasForeignKey(e => e.DialogId);

            modelBuilder.Entity<Messages>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Messages>()
                .HasMany(e => e.MessageAvatars)
                .WithOptional(e => e.Messages)
                .HasForeignKey(e => e.MessageId);

            modelBuilder.Entity<Messages>()
                .HasMany(e => e.PhotoMessages)
                .WithOptional(e => e.Messages)
                .HasForeignKey(e => e.MessageId);

            modelBuilder.Entity<Photos>()
                .HasMany(e => e.Likes)
                .WithOptional(e => e.Photos)
                .HasForeignKey(e => e.Photos_Id);

            modelBuilder.Entity<Photos>()
                .HasMany(e => e.PhotoMessages)
                .WithOptional(e => e.Photos)
                .HasForeignKey(e => e.PhotoId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Albums)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Avatars)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Friends)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.User1Id);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Friends1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.User2Id);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Likes)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.Users_Id);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserDialogs)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);
        }
    }
}
