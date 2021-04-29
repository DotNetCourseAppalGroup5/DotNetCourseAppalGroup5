using Entity.Database;
using Entity.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class StringContex : DbContext
    {
        public void Migrate()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<StringContex, Configuration>());
            Database.Initialize(false);
        }

        public StringContex() : base("StringContext")
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Avatar> Avatars { get; set; }
        public virtual DbSet<Dialog> Dialogs { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<LikeAvatar> LikeAvatars { get; set; }
        public virtual DbSet<LikePhoto> LikePhotos { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageAvatar> MessageAvatars { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<PhotoMessage> PhotoMessages { get; set; }
        public virtual DbSet<UserDialog> UserDialogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }
}
