namespace Entity.Migrations
{
    using Entity.Database;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StringContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Entity.StringContex";
        }

        protected override void Seed(StringContex db)
        {
            User us1 = new User
            {
                LastName = "Vadim",
                FirstName = "Bezhkov",
                Email = "vadimbezhkov3112@gmail.com",
                Login = "Vadim",
                Password = "123",
                SecondName = "Alexandrovich",
                TimeRegistration = DateTime.Now
            };
            User us2 = new User
            {
                LastName = "Pavel",
                FirstName = "Kononovich",
                Email = "kononsoft@gmail.com",
                Login = "imkonon",
                Password = "12345",
                SecondName = "Alexandrovich",
                TimeRegistration = DateTime.Now
            };
            User us3 = new User
            {
                LastName = "Sergei",
                FirstName = "Necrashevich",
                Email = "lohopetushok@gmail.com",
                Login = "necr",
                Password = "iamlox",
                SecondName = "Vladimirovich",
                TimeRegistration = DateTime.Now
            };
            User us4 = new User
            {
                LastName = "Pavel",
                FirstName = "Birulchik",
                Email = "sedoibatman@gmail.com",
                Login = "vsexyevo",
                Password = "y menya",
                SecondName = "Vladimirovich",
                TimeRegistration = DateTime.Now
            };
            User us5 = new User
            {
                LastName = "Dmitriy",
                FirstName = "Omelyanovich",
                Email = "poidyraskazyVinogradovy@gmail.com",
                Login = "vsegdasvejeedixanie",
                Password = "y menya",
                SecondName = "Vinogradovich",
                TimeRegistration = DateTime.Now
            };

            db.Users.Add(us1);
            db.Users.Add(us2);
            db.Users.Add(us3);
            db.Users.Add(us4);
            db.Users.Add(us5);
            db.SaveChanges();

            Album al = new Album { Name = "leto", UserId = us1.Id, TimeCreation = DateTime.Now };
            Album a2 = new Album { Name = "zima", UserId = us2.Id, TimeCreation = DateTime.Now };
            Album a3 = new Album { Name = "value", UserId = us3.Id, TimeCreation = DateTime.Now };
            Album a4 = new Album { Name = "pae", UserId = us4.Id, TimeCreation = DateTime.Now };
            Album a5 = new Album { Name = "let", UserId = us5.Id, TimeCreation = DateTime.Now };

            db.Albums.AddRange(new List<Album>() { al, a2, a3, a4, a5 });
            db.SaveChanges();

            Avatar av = new Avatar() { UserId = us1.Id, Path = "https://myserver.vb.com", Active = true };
            Avatar av1 = new Avatar() { UserId = us1.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av2 = new Avatar() { UserId = us1.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av3 = new Avatar() { UserId = us1.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av4 = new Avatar() { UserId = us1.Id, Path = "https://myserver.vb.com", Active = false };

            Avatar av5 = new Avatar() { UserId = us2.Id, Path = "https://myserver.vb.com", Active = true };
            Avatar av6 = new Avatar() { UserId = us2.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av7 = new Avatar() { UserId = us2.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av8 = new Avatar() { UserId = us2.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av9 = new Avatar() { UserId = us2.Id, Path = "https://myserver.vb.com", Active = false };

            Avatar av35 = new Avatar() { UserId = us3.Id, Path = "https://myserver.vb.com", Active = true };
            Avatar av36 = new Avatar() { UserId = us3.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av37 = new Avatar() { UserId = us3.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av38 = new Avatar() { UserId = us3.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av39 = new Avatar() { UserId = us3.Id, Path = "https://myserver.vb.com", Active = false };

            Avatar av45 = new Avatar() { UserId = us4.Id, Path = "https://myserver.vb.com", Active = true };
            Avatar av46 = new Avatar() { UserId = us4.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av47 = new Avatar() { UserId = us4.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av48 = new Avatar() { UserId = us4.Id, Path = "https://myserver.vb.com", Active = false };
            Avatar av49 = new Avatar() { UserId = us4.Id, Path = "https://myserver.vb.com", Active = false };

            db.Avatars.AddRange(new List<Avatar>() { av,av1,av2,av3,av4,av5,av6,av7,av8,av9,av35,
                            av36,av3,av38,av39,av45,av46,av47,av48,av49, });
            db.SaveChanges();

            Dialog dial = new Dialog() { Name = "Tratata", TimeCreation = DateTime.Now };
            Dialog dial2 = new Dialog() { Name = "Tratata", TimeCreation = DateTime.Now };
            Dialog dial3 = new Dialog() { Name = "Tratata", TimeCreation = DateTime.Now };
            Dialog dial4 = new Dialog() { Name = "Tratata", TimeCreation = DateTime.Now };
            Dialog dial5 = new Dialog() { Name = "Tratata", TimeCreation = DateTime.Now };
            db.Dialogs.AddRange(new List<Dialog>() { dial, dial2, dial3, dial4, dial5 });
            db.SaveChanges();

            Friend friend = new Friend() { User1Id = us1.Id, User2Id = us2.Id };
            Friend friend1 = new Friend() { User1Id = us2.Id, User2Id = us3.Id };
            Friend friend2 = new Friend() { User1Id = us2.Id, User2Id = us4.Id };
            Friend friend3 = new Friend() { User1Id = us2.Id, User2Id = us5.Id };
            Friend friend4 = new Friend() { User1Id = us1.Id, User2Id = us3.Id };
            Friend friend5 = new Friend() { User1Id = us1.Id, User2Id = us4.Id };
            Friend friend6 = new Friend() { User1Id = us1.Id, User2Id = us5.Id };
            db.Friends.AddRange(new List<Friend>() {friend, friend1, friend2, friend3,
                            friend4, friend5, friend6 });
            db.SaveChanges();


            LikeAvatar like1 = new LikeAvatar() { UserId = us1.Id, Сondition = true, Avatars = av1 };
            LikeAvatar like2 = new LikeAvatar() { UserId = us2.Id, Сondition = true, Avatars = av2 };
            LikeAvatar like3 = new LikeAvatar() { UserId = us3.Id, Сondition = true, Avatars = av1 };
            LikeAvatar like4 = new LikeAvatar() { UserId = us4.Id, Сondition = true, Avatars = av2 };

            db.LikeAvatars.Add(like1);
            db.LikeAvatars.Add(like2);
            db.LikeAvatars.Add(like3);
            db.LikeAvatars.Add(like4);
            db.SaveChanges();

            Message mes7 = new Message() { DialogId = dial.Id, Text = "Hello", TextChanged = false, Users = us1 };
            Message mes1 = new Message() { DialogId = dial2.Id, Text = "Hello friend", TextChanged = false, Users = us2 };
            Message mes2 = new Message() { DialogId = dial3.Id, Text = "yes", TextChanged = false, Users = us3 };
            Message mes3 = new Message() { DialogId = dial4.Id, Text = "no", TextChanged = false, Users = us4 };
            Message mes4 = new Message() { DialogId = dial5.Id, Text = "Good", TextChanged = false, Users = us1 };
            Message mes5 = new Message() { DialogId = dial.Id, Text = "Fine", TextChanged = false, Users = us2 };
            Message mes6 = new Message() { DialogId = dial3.Id, Text = "Red", TextChanged = false, Users = us1 };

            db.Messages.AddRange(new List<Message>() { mes7, mes1, mes2, mes3, mes4, mes5, mes6 });
            db.SaveChanges();

            MessageAvatar ma = new MessageAvatar() { AvatarId = av1.Id, MessageId = mes1.Id };
            MessageAvatar ma1 = new MessageAvatar() { AvatarId = av2.Id, MessageId = mes2.Id };
            MessageAvatar ma2 = new MessageAvatar() { AvatarId = av3.Id, MessageId = mes3.Id };
            MessageAvatar ma3 = new MessageAvatar() { AvatarId = av4.Id, MessageId = mes4.Id };
            MessageAvatar ma4 = new MessageAvatar() { AvatarId = av5.Id, MessageId = mes5.Id };

            db.MessageAvatars.AddRange(new List<MessageAvatar> { ma, ma1, ma2, ma3, ma4 });
            db.SaveChanges();

            Photo p1 = new Photo() { Path = "https://myserver.vb.com", AlbumId = al.Id, TimeCreation = DateTime.Now };
            Photo p2 = new Photo() { Path = "https://myserver.vb.com", AlbumId = a2.Id, TimeCreation = DateTime.Now };
            Photo p3 = new Photo() { Path = "https://myserver.vb.com", AlbumId = a3.Id, TimeCreation = DateTime.Now };
            Photo p4 = new Photo() { Path = "https://myserver.vb.com", AlbumId = a4.Id, TimeCreation = DateTime.Now };
            Photo p5 = new Photo() { Path = "https://myserver.vb.com", AlbumId = a5.Id, TimeCreation = DateTime.Now };

            db.Photos.AddRange(new List<Photo>() { p1, p2, p3, p4, p5 });
            db.SaveChanges();


            PhotoMessage pm = new PhotoMessage() { PhotoId = p1.Id, MessageId = mes1.Id };
            PhotoMessage pm1 = new PhotoMessage() { PhotoId = p1.Id, MessageId = mes7.Id };
            PhotoMessage pm2 = new PhotoMessage() { PhotoId = p2.Id, MessageId = mes3.Id };
            PhotoMessage pm3 = new PhotoMessage() { PhotoId = p3.Id, MessageId = mes4.Id };
            PhotoMessage pm4 = new PhotoMessage() { PhotoId = p4.Id, MessageId = mes2.Id };
            PhotoMessage pm5 = new PhotoMessage() { PhotoId = p1.Id, MessageId = mes3.Id };

            db.PhotoMessages.AddRange(new List<PhotoMessage> { pm, pm1, pm2, pm3, pm4, pm5 });
            db.SaveChanges();

            LikePhoto like5 = new LikePhoto() { UserId = us1.Id, Сondition = true, Photos = p1 };
            LikePhoto like6 = new LikePhoto() { UserId = us2.Id, Сondition = true, Photos = p2 };
            LikePhoto like7 = new LikePhoto() { UserId = us3.Id, Сondition = true, Photos = p3 };
            LikePhoto like8 = new LikePhoto() { UserId = us4.Id, Сondition = true, Photos = p4 };

            db.LikePhotos.Add(like5);
            db.LikePhotos.Add(like6);
            db.LikePhotos.Add(like7);
            db.LikePhotos.Add(like8);
            db.SaveChanges();

            UserDialog ud1 = new UserDialog() { UserId = us1.Id, DialogId = dial.Id, TimeCreation = DateTime.Now };
            UserDialog ud2 = new UserDialog() { UserId = us2.Id, DialogId = dial2.Id, TimeCreation = DateTime.Now };
            UserDialog ud3 = new UserDialog() { UserId = us3.Id, DialogId = dial3.Id, TimeCreation = DateTime.Now };
            UserDialog ud4 = new UserDialog() { UserId = us4.Id, DialogId = dial4.Id, TimeCreation = DateTime.Now };
            UserDialog ud5 = new UserDialog() { UserId = us5.Id, DialogId = dial5.Id, TimeCreation = DateTime.Now };
            db.UserDialogs.AddRange(new List<UserDialog>() { ud1, ud2, ud3, ud4, ud5 });
            db.SaveChanges();
            base.Seed(db);
        }
    }
}

