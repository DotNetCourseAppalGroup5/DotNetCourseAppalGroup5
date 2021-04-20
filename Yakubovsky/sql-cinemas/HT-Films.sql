Create database CinemaUnHT2
GO

use CinemaUnHT2
create table Users
(
  Id int primary key identity(1,1),
  UserName nvarchar(30) not null
)

create table Film
(
  Id int identity(1,1) unique,
  FilmName nvarchar(30),
  Duration tinyint not null,
  primary key(id)
)

create table Seans
(
  Id int primary key identity(1,1),
  FilmId int references Film(id),
  TimeOfStart time not null
)

create table Ticket
(
    Id int identity(1,1) unique,
    TicketPrice tinyint not null default(7),
	SeansId int references Seans(id),
    primary key(id)
)

create table Orders
(
  id int primary key identity(1,1),
  UserId int references Users(id),
  TiketId int references Ticket(id),
  DateOfOrder date not null,
  FilmId int references Film(id)
)


insert Users(UserName) values ('Tim')
insert Users(UserName) values ('Bob')
insert Users(UserName) values ('Alex')
insert Users(UserName) values ('Vadimir')
insert Users(UserName) values ('Tanya')
insert Users(UserName) values ('Olgerd')
insert Users(UserName) values ('Tissaya')
insert Users(UserName) values ('Khabib')
insert Users(UserName) values ('Valya')
GO

insert Film (FilmName,Duration) values ('Batman',70)
insert Film (FilmName,Duration) values ('Joker',90)
insert Film (FilmName,Duration) values ('Lord of the rings',180)
insert Film (FilmName,Duration) values ('Avengers',97)
insert Film (FilmName,Duration) values ('Transformers',139)
insert Film (FilmName,Duration) values ('Agent 47',85)
GO

insert Seans(FilmId,TimeOfStart) values (1,'23:00:00')
insert Seans(FilmId,TimeOfStart) values (2,'21:00:00')
insert Seans(FilmId,TimeOfStart) values (3,'19:00:00')
insert Seans(FilmId,TimeOfStart) values (4,'17:00:00')
insert Seans(FilmId,TimeOfStart) values (5,'15:30:00')
insert Seans(FilmId,TimeOfStart) values (6,'22:00:00')
insert Seans(FilmId,TimeOfStart) values (3,'10:00:00')
Go

insert Ticket(TicketPrice,SeansId) values (7,1)
insert Ticket(TicketPrice,SeansId) values (9,2)
insert Ticket(TicketPrice,SeansId) values (8,3)
insert Ticket(TicketPrice,SeansId) values (7,1)
insert Ticket(TicketPrice,SeansId) values (9,2)
insert Ticket(TicketPrice,SeansId) values (14,4)
Go

insert Orders(UserId,TiketId,DateOfOrder,FilmId) values (9,1,'2019-08-24',1)
insert Orders(UserId,TiketId,DateOfOrder,FilmId) values (8,2,'2019-08-22',2)
insert Orders(UserId,TiketId,DateOfOrder,FilmId) values (7,3,'2019-08-22',2)
insert Orders(UserId,TiketId,DateOfOrder,FilmId) values (6,2,'2019-08-24',4)
insert Orders(UserId,TiketId,DateOfOrder,FilmId) values (5,2,'2019-08-24',6)
insert Orders(UserId,TiketId,DateOfOrder,FilmId) values (4,3,'2019-08-23',5)
insert Orders(UserId,TiketId,DateOfOrder,FilmId) values (3,1,'2019-08-24',2)
insert Orders(UserId,TiketId,DateOfOrder,FilmId) values (2,1,'2019-08-23',1)
insert Orders(UserId,TiketId,DateOfOrder,FilmId) values (1,2,'2019-08-21',2)
GO


