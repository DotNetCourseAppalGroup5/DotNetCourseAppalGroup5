CREATE DATABASE Classmates1
GO

USE [Classmates1]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UserId] [int] NULL,
	[TimeCreation] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Albums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Avatars]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Avatars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Path] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Avatars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dialogs]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dialogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TimeCreation] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Dialogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Friends]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friends](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User1Id] [int] NULL,
	[User2Id] [int] NULL,
 CONSTRAINT [PK_dbo.Friends] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Likes]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Сondition] [bit] NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[Photos_Id] [int] NULL,
	[Avatars_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Likes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageAvatars]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageAvatars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AvatarId] [int] NULL,
	[MessageId] [int] NULL,
 CONSTRAINT [PK_dbo.MessageAvatars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DialogId] [int] NULL,
	[Text] [text] NOT NULL,
	[TextChanged] [bit] NOT NULL,
	[Users_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhotoMessages]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhotoMessages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PhotoId] [int] NULL,
	[MessageId] [int] NULL,
 CONSTRAINT [PK_dbo.PhotoMessages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Path] [nvarchar](50) NOT NULL,
	[AlbumId] [int] NULL,
	[TimeCreation] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Photos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDialogs]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDialogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[DialogId] [int] NULL,
	[TimeCreation] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.UserDialogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[SecondName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Login] [nvarchar](30) NOT NULL,
	[DateBirth] [datetime] NULL,
	[TimeRegistration] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Albums] ON 

INSERT [dbo].[Albums] ([Id], [Name], [UserId], [TimeCreation]) VALUES (1, N'leto', 1, CAST(N'2021-04-29T13:12:00.840' AS DateTime))
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [TimeCreation]) VALUES (2, N'zima', 2, CAST(N'2021-04-29T13:12:00.840' AS DateTime))
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [TimeCreation]) VALUES (3, N'value', 3, CAST(N'2021-04-29T13:12:00.840' AS DateTime))
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [TimeCreation]) VALUES (4, N'pae', 4, CAST(N'2021-04-29T13:12:00.840' AS DateTime))
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [TimeCreation]) VALUES (5, N'let', 5, CAST(N'2021-04-29T13:12:00.840' AS DateTime))
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [TimeCreation]) VALUES (6, N'leto', 6, CAST(N'2021-04-29T13:15:15.483' AS DateTime))
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [TimeCreation]) VALUES (7, N'zima', 7, CAST(N'2021-04-29T13:15:15.483' AS DateTime))
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [TimeCreation]) VALUES (8, N'value', 8, CAST(N'2021-04-29T13:15:15.483' AS DateTime))
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [TimeCreation]) VALUES (9, N'pae', 9, CAST(N'2021-04-29T13:15:15.483' AS DateTime))
INSERT [dbo].[Albums] ([Id], [Name], [UserId], [TimeCreation]) VALUES (10, N'let', 10, CAST(N'2021-04-29T13:15:15.483' AS DateTime))
SET IDENTITY_INSERT [dbo].[Albums] OFF
GO
SET IDENTITY_INSERT [dbo].[Avatars] ON 

INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (1, 1, N'https://myserver.vb.com', 1)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (2, 1, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (3, 1, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (4, 1, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (5, 1, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (6, 2, N'https://myserver.vb.com', 1)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (7, 2, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (8, 2, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (9, 2, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (10, 2, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (11, 3, N'https://myserver.vb.com', 1)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (12, 3, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (13, 3, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (14, 3, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (15, 4, N'https://myserver.vb.com', 1)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (16, 4, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (17, 4, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (18, 4, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (19, 4, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (20, 6, N'https://myserver.vb.com', 1)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (21, 6, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (22, 6, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (23, 6, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (24, 6, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (25, 7, N'https://myserver.vb.com', 1)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (26, 7, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (27, 7, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (28, 7, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (29, 7, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (30, 8, N'https://myserver.vb.com', 1)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (31, 8, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (32, 8, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (33, 8, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (34, 9, N'https://myserver.vb.com', 1)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (35, 9, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (36, 9, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (37, 9, N'https://myserver.vb.com', 0)
INSERT [dbo].[Avatars] ([Id], [UserId], [Path], [Active]) VALUES (38, 9, N'https://myserver.vb.com', 0)
SET IDENTITY_INSERT [dbo].[Avatars] OFF
GO
SET IDENTITY_INSERT [dbo].[Dialogs] ON 

INSERT [dbo].[Dialogs] ([Id], [Name], [TimeCreation]) VALUES (1, N'Tratata', CAST(N'2021-04-29T13:12:00.950' AS DateTime))
INSERT [dbo].[Dialogs] ([Id], [Name], [TimeCreation]) VALUES (2, N'Tratata', CAST(N'2021-04-29T13:12:00.950' AS DateTime))
INSERT [dbo].[Dialogs] ([Id], [Name], [TimeCreation]) VALUES (3, N'Tratata', CAST(N'2021-04-29T13:12:00.950' AS DateTime))
INSERT [dbo].[Dialogs] ([Id], [Name], [TimeCreation]) VALUES (4, N'Tratata', CAST(N'2021-04-29T13:12:00.950' AS DateTime))
INSERT [dbo].[Dialogs] ([Id], [Name], [TimeCreation]) VALUES (5, N'Tratata', CAST(N'2021-04-29T13:12:00.950' AS DateTime))
INSERT [dbo].[Dialogs] ([Id], [Name], [TimeCreation]) VALUES (6, N'Tratata', CAST(N'2021-04-29T13:15:15.563' AS DateTime))
INSERT [dbo].[Dialogs] ([Id], [Name], [TimeCreation]) VALUES (7, N'Tratata', CAST(N'2021-04-29T13:15:15.563' AS DateTime))
INSERT [dbo].[Dialogs] ([Id], [Name], [TimeCreation]) VALUES (8, N'Tratata', CAST(N'2021-04-29T13:15:15.563' AS DateTime))
INSERT [dbo].[Dialogs] ([Id], [Name], [TimeCreation]) VALUES (9, N'Tratata', CAST(N'2021-04-29T13:15:15.563' AS DateTime))
INSERT [dbo].[Dialogs] ([Id], [Name], [TimeCreation]) VALUES (10, N'Tratata', CAST(N'2021-04-29T13:15:15.563' AS DateTime))
SET IDENTITY_INSERT [dbo].[Dialogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Friends] ON 

INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (1, 1, 2)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (2, 2, 3)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (3, 2, 4)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (4, 2, 5)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (5, 1, 3)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (6, 1, 4)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (7, 1, 5)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (8, 6, 7)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (9, 7, 8)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (10, 7, 9)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (11, 7, 10)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (12, 6, 8)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (13, 6, 9)
INSERT [dbo].[Friends] ([Id], [User1Id], [User2Id]) VALUES (14, 6, 10)
SET IDENTITY_INSERT [dbo].[Friends] OFF
GO
SET IDENTITY_INSERT [dbo].[Likes] ON 

INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (1, 1, 1, N'LikeAvatar', NULL, 2)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (2, 2, 1, N'LikeAvatar', NULL, 3)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (3, 3, 1, N'LikeAvatar', NULL, 2)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (4, 4, 1, N'LikeAvatar', NULL, 3)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (5, 1, 1, N'LikePhoto', 1, NULL)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (6, 2, 1, N'LikePhoto', 2, NULL)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (7, 3, 1, N'LikePhoto', 3, NULL)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (8, 4, 1, N'LikePhoto', 4, NULL)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (9, 6, 1, N'LikeAvatar', NULL, 21)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (10, 7, 1, N'LikeAvatar', NULL, 22)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (11, 8, 1, N'LikeAvatar', NULL, 21)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (12, 9, 1, N'LikeAvatar', NULL, 22)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (13, 6, 1, N'LikePhoto', 6, NULL)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (14, 7, 1, N'LikePhoto', 7, NULL)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (15, 8, 1, N'LikePhoto', 8, NULL)
INSERT [dbo].[Likes] ([Id], [UserId], [Сondition], [Discriminator], [Photos_Id], [Avatars_Id]) VALUES (16, 9, 1, N'LikePhoto', 9, NULL)
SET IDENTITY_INSERT [dbo].[Likes] OFF
GO
SET IDENTITY_INSERT [dbo].[MessageAvatars] ON 

INSERT [dbo].[MessageAvatars] ([Id], [AvatarId], [MessageId]) VALUES (1, 2, 2)
INSERT [dbo].[MessageAvatars] ([Id], [AvatarId], [MessageId]) VALUES (2, 3, 3)
INSERT [dbo].[MessageAvatars] ([Id], [AvatarId], [MessageId]) VALUES (3, 4, 4)
INSERT [dbo].[MessageAvatars] ([Id], [AvatarId], [MessageId]) VALUES (4, 5, 5)
INSERT [dbo].[MessageAvatars] ([Id], [AvatarId], [MessageId]) VALUES (5, 6, 6)
INSERT [dbo].[MessageAvatars] ([Id], [AvatarId], [MessageId]) VALUES (6, 21, 9)
INSERT [dbo].[MessageAvatars] ([Id], [AvatarId], [MessageId]) VALUES (7, 22, 10)
INSERT [dbo].[MessageAvatars] ([Id], [AvatarId], [MessageId]) VALUES (8, 23, 11)
INSERT [dbo].[MessageAvatars] ([Id], [AvatarId], [MessageId]) VALUES (9, 24, 12)
INSERT [dbo].[MessageAvatars] ([Id], [AvatarId], [MessageId]) VALUES (10, 25, 13)
SET IDENTITY_INSERT [dbo].[MessageAvatars] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (1, 1, N'Hello', 0, 1)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (2, 2, N'Hello friend', 0, 2)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (3, 3, N'yes', 0, 3)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (4, 4, N'no', 0, 4)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (5, 5, N'Good', 0, 1)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (6, 1, N'Fine', 0, 2)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (7, 3, N'Red', 0, 1)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (8, 6, N'Hello', 0, 6)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (9, 7, N'Hello friend', 0, 7)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (10, 8, N'yes', 0, 8)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (11, 9, N'no', 0, 9)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (12, 10, N'Good', 0, 6)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (13, 6, N'Fine', 0, 7)
INSERT [dbo].[Messages] ([Id], [DialogId], [Text], [TextChanged], [Users_Id]) VALUES (14, 8, N'Red', 0, 6)
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[PhotoMessages] ON 

INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (1, 1, 2)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (2, 1, 1)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (3, 2, 4)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (4, 3, 5)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (5, 4, 3)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (6, 1, 4)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (7, 6, 9)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (8, 6, 8)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (9, 7, 11)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (10, 8, 12)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (11, 9, 10)
INSERT [dbo].[PhotoMessages] ([Id], [PhotoId], [MessageId]) VALUES (12, 6, 11)
SET IDENTITY_INSERT [dbo].[PhotoMessages] OFF
GO
SET IDENTITY_INSERT [dbo].[Photos] ON 

INSERT [dbo].[Photos] ([Id], [Path], [AlbumId], [TimeCreation]) VALUES (1, N'https://myserver.vb.com', 1, CAST(N'2021-04-29T13:12:01.093' AS DateTime))
INSERT [dbo].[Photos] ([Id], [Path], [AlbumId], [TimeCreation]) VALUES (2, N'https://myserver.vb.com', 2, CAST(N'2021-04-29T13:12:01.093' AS DateTime))
INSERT [dbo].[Photos] ([Id], [Path], [AlbumId], [TimeCreation]) VALUES (3, N'https://myserver.vb.com', 3, CAST(N'2021-04-29T13:12:01.093' AS DateTime))
INSERT [dbo].[Photos] ([Id], [Path], [AlbumId], [TimeCreation]) VALUES (4, N'https://myserver.vb.com', 4, CAST(N'2021-04-29T13:12:01.093' AS DateTime))
INSERT [dbo].[Photos] ([Id], [Path], [AlbumId], [TimeCreation]) VALUES (5, N'https://myserver.vb.com', 5, CAST(N'2021-04-29T13:12:01.093' AS DateTime))
INSERT [dbo].[Photos] ([Id], [Path], [AlbumId], [TimeCreation]) VALUES (6, N'https://myserver.vb.com', 6, CAST(N'2021-04-29T13:15:15.683' AS DateTime))
INSERT [dbo].[Photos] ([Id], [Path], [AlbumId], [TimeCreation]) VALUES (7, N'https://myserver.vb.com', 7, CAST(N'2021-04-29T13:15:15.683' AS DateTime))
INSERT [dbo].[Photos] ([Id], [Path], [AlbumId], [TimeCreation]) VALUES (8, N'https://myserver.vb.com', 8, CAST(N'2021-04-29T13:15:15.683' AS DateTime))
INSERT [dbo].[Photos] ([Id], [Path], [AlbumId], [TimeCreation]) VALUES (9, N'https://myserver.vb.com', 9, CAST(N'2021-04-29T13:15:15.683' AS DateTime))
INSERT [dbo].[Photos] ([Id], [Path], [AlbumId], [TimeCreation]) VALUES (10, N'https://myserver.vb.com', 10, CAST(N'2021-04-29T13:15:15.683' AS DateTime))
SET IDENTITY_INSERT [dbo].[Photos] OFF
GO
SET IDENTITY_INSERT [dbo].[UserDialogs] ON 

INSERT [dbo].[UserDialogs] ([Id], [UserId], [DialogId], [TimeCreation]) VALUES (1, 1, 1, CAST(N'2021-04-29T13:12:01.130' AS DateTime))
INSERT [dbo].[UserDialogs] ([Id], [UserId], [DialogId], [TimeCreation]) VALUES (2, 2, 2, CAST(N'2021-04-29T13:12:01.130' AS DateTime))
INSERT [dbo].[UserDialogs] ([Id], [UserId], [DialogId], [TimeCreation]) VALUES (3, 3, 3, CAST(N'2021-04-29T13:12:01.130' AS DateTime))
INSERT [dbo].[UserDialogs] ([Id], [UserId], [DialogId], [TimeCreation]) VALUES (4, 4, 4, CAST(N'2021-04-29T13:12:01.130' AS DateTime))
INSERT [dbo].[UserDialogs] ([Id], [UserId], [DialogId], [TimeCreation]) VALUES (5, 5, 5, CAST(N'2021-04-29T13:12:01.130' AS DateTime))
INSERT [dbo].[UserDialogs] ([Id], [UserId], [DialogId], [TimeCreation]) VALUES (6, 6, 6, CAST(N'2021-04-29T13:15:15.727' AS DateTime))
INSERT [dbo].[UserDialogs] ([Id], [UserId], [DialogId], [TimeCreation]) VALUES (7, 7, 7, CAST(N'2021-04-29T13:15:15.727' AS DateTime))
INSERT [dbo].[UserDialogs] ([Id], [UserId], [DialogId], [TimeCreation]) VALUES (8, 8, 8, CAST(N'2021-04-29T13:15:15.727' AS DateTime))
INSERT [dbo].[UserDialogs] ([Id], [UserId], [DialogId], [TimeCreation]) VALUES (9, 9, 9, CAST(N'2021-04-29T13:15:15.727' AS DateTime))
INSERT [dbo].[UserDialogs] ([Id], [UserId], [DialogId], [TimeCreation]) VALUES (10, 10, 10, CAST(N'2021-04-29T13:15:15.727' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserDialogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Email], [Password], [Login], [DateBirth], [TimeRegistration]) VALUES (1, N'Bezhkov', N'Vadim', N'Alexandrovich', N'vadimbezhkov3112@gmail.com', N'123', N'Vadim', NULL, CAST(N'2021-04-29T13:12:00.490' AS DateTime))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Email], [Password], [Login], [DateBirth], [TimeRegistration]) VALUES (2, N'Kononovic', N'Pavel', N'Alexandrovich', N'kononsoft@gmail.com', N'12345', N'imkonon', NULL, CAST(N'2021-04-29T13:12:00.490' AS DateTime))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Email], [Password], [Login], [DateBirth], [TimeRegistration]) VALUES (3, N'Necrashevich', N'Sergei', N'Vladimirovich', N'lohopetushok@gmail.com', N'iamlox', N'necr', NULL, CAST(N'2021-04-29T13:12:00.490' AS DateTime))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Email], [Password], [Login], [DateBirth], [TimeRegistration]) VALUES (4, N'Birulchik', N'Pavel', N'Vladimirovich', N'sedoibatman@gmail.com', N'y menya', N'vsexyevo', NULL, CAST(N'2021-04-29T13:12:00.490' AS DateTime))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Email], [Password], [Login], [DateBirth], [TimeRegistration]) VALUES (5, N'Omelyanovich', N'Dmitriy', N'Vinogradovich', N'poidyraskazyVinogradovy@gmail.com', N'y menya', N'vsegdasvejeedixanie', NULL, CAST(N'2021-04-29T13:12:00.490' AS DateTime))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Email], [Password], [Login], [DateBirth], [TimeRegistration]) VALUES (6, N'Bezhkov', N'Vadim', N'Alexandrovich', N'vadimbezhkov3112@gmail.com', N'123', N'Vadim', NULL, CAST(N'2021-04-29T13:15:14.993' AS DateTime))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Email], [Password], [Login], [DateBirth], [TimeRegistration]) VALUES (7, N'Kononovic', N'Pavel', N'Alexandrovich', N'kononsoft@gmail.com', N'12345', N'imkonon', NULL, CAST(N'2021-04-29T13:15:14.993' AS DateTime))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Email], [Password], [Login], [DateBirth], [TimeRegistration]) VALUES (8, N'Necrashevich', N'Sergei', N'Vladimirovich', N'lohopetushok@gmail.com', N'iamlox', N'necr', NULL, CAST(N'2021-04-29T13:15:14.993' AS DateTime))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Email], [Password], [Login], [DateBirth], [TimeRegistration]) VALUES (9, N'Birulchik', N'Pavel', N'Vladimirovich', N'sedoibatman@gmail.com', N'y menya', N'vsexyevo', NULL, CAST(N'2021-04-29T13:15:14.993' AS DateTime))
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Email], [Password], [Login], [DateBirth], [TimeRegistration]) VALUES (10, N'Omelyanovich', N'Dmitriy', N'Vinogradovich', N'poidyraskazyVinogradovy@gmail.com', N'y menya', N'vsegdasvejeedixanie', NULL, CAST(N'2021-04-29T13:15:14.993' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_UserId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Albums]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Avatars]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_User1Id]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_User1Id] ON [dbo].[Friends]
(
	[User1Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_User2Id]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_User2Id] ON [dbo].[Friends]
(
	[User2Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Avatars_Id]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_Avatars_Id] ON [dbo].[Likes]
(
	[Avatars_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Photos_Id]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_Photos_Id] ON [dbo].[Likes]
(
	[Photos_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Likes]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NoLikeWhereOnCondition=true]    Script Date: 29.04.2021 14:46:10 ******/
CREATE UNIQUE NONCLUSTERED INDEX [NoLikeWhereOnCondition=true] ON [dbo].[Likes]
(
	[UserId] ASC,
	[Discriminator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AvatarId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_AvatarId] ON [dbo].[MessageAvatars]
(
	[AvatarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MessageId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_MessageId] ON [dbo].[MessageAvatars]
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DialogId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_DialogId] ON [dbo].[Messages]
(
	[DialogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_Id]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_Users_Id] ON [dbo].[Messages]
(
	[Users_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MessageId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_MessageId] ON [dbo].[PhotoMessages]
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PhotoId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_PhotoId] ON [dbo].[PhotoMessages]
(
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AlbumId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_AlbumId] ON [dbo].[Photos]
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DialogId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_DialogId] ON [dbo].[UserDialogs]
(
	[DialogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 29.04.2021 14:46:10 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserDialogs]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Albums_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [FK_dbo.Albums_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Avatars]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Avatars_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Avatars] CHECK CONSTRAINT [FK_dbo.Avatars_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Friends]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Friends_dbo.Users_User1Id] FOREIGN KEY([User1Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Friends] CHECK CONSTRAINT [FK_dbo.Friends_dbo.Users_User1Id]
GO
ALTER TABLE [dbo].[Friends]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Friends_dbo.Users_User2Id] FOREIGN KEY([User2Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Friends] CHECK CONSTRAINT [FK_dbo.Friends_dbo.Users_User2Id]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Likes_dbo.Avatars_Avatars_Id] FOREIGN KEY([Avatars_Id])
REFERENCES [dbo].[Avatars] ([Id])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_dbo.Likes_dbo.Avatars_Avatars_Id]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Likes_dbo.Photos_Photos_Id] FOREIGN KEY([Photos_Id])
REFERENCES [dbo].[Photos] ([Id])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_dbo.Likes_dbo.Photos_Photos_Id]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Likes_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_dbo.Likes_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[MessageAvatars]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MessageAvatars_dbo.Avatars_AvatarId] FOREIGN KEY([AvatarId])
REFERENCES [dbo].[Avatars] ([Id])
GO
ALTER TABLE [dbo].[MessageAvatars] CHECK CONSTRAINT [FK_dbo.MessageAvatars_dbo.Avatars_AvatarId]
GO
ALTER TABLE [dbo].[MessageAvatars]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MessageAvatars_dbo.Messages_MessageId] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Messages] ([Id])
GO
ALTER TABLE [dbo].[MessageAvatars] CHECK CONSTRAINT [FK_dbo.MessageAvatars_dbo.Messages_MessageId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Messages_dbo.Dialogs_DialogId] FOREIGN KEY([DialogId])
REFERENCES [dbo].[Dialogs] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_dbo.Messages_dbo.Dialogs_DialogId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Messages_dbo.Users_Users_Id] FOREIGN KEY([Users_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_dbo.Messages_dbo.Users_Users_Id]
GO
ALTER TABLE [dbo].[PhotoMessages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PhotoMessages_dbo.Messages_MessageId] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Messages] ([Id])
GO
ALTER TABLE [dbo].[PhotoMessages] CHECK CONSTRAINT [FK_dbo.PhotoMessages_dbo.Messages_MessageId]
GO
ALTER TABLE [dbo].[PhotoMessages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PhotoMessages_dbo.Photos_PhotoId] FOREIGN KEY([PhotoId])
REFERENCES [dbo].[Photos] ([Id])
GO
ALTER TABLE [dbo].[PhotoMessages] CHECK CONSTRAINT [FK_dbo.PhotoMessages_dbo.Photos_PhotoId]
GO
ALTER TABLE [dbo].[Photos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Photos_dbo.Albums_AlbumId] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[Photos] CHECK CONSTRAINT [FK_dbo.Photos_dbo.Albums_AlbumId]
GO
ALTER TABLE [dbo].[UserDialogs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserDialogs_dbo.Dialogs_DialogId] FOREIGN KEY([DialogId])
REFERENCES [dbo].[Dialogs] ([Id])
GO
ALTER TABLE [dbo].[UserDialogs] CHECK CONSTRAINT [FK_dbo.UserDialogs_dbo.Dialogs_DialogId]
GO
ALTER TABLE [dbo].[UserDialogs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserDialogs_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserDialogs] CHECK CONSTRAINT [FK_dbo.UserDialogs_dbo.Users_UserId]
GO
/****** Object:  StoredProcedure [dbo].[AddLikeAvatar]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddLikeAvatar]
	-- Add the parameters for the stored procedure here
  @AvatarId int,
	@UserID int,
	@Condition bit =True

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert INTO Likes(Avatars_Id,UserId,Сondition)
Values (@AvatarID,@UserID,@Condition)
END
GO
/****** Object:  StoredProcedure [dbo].[AddLikePhoto]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddLikePhoto]
	-- Add the parameters for the stored procedure here
	@Photos_Id int,
	@UserId int,
	@Condition bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Likes(Photos_Id,UserId,Сondition)
	Values (@Photos_Id,@UserId,@Condition)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddUser]
	-- Add the parameters for the stored procedure here
	@FirstName nvarchar(50),
	@LatstName nvarchar(50),
	@SecondName nvarchar(50),
	@Email nvarchar(50),
	@Password varchar(30),
	@Login varchar(30),
	@DateBirth date,
	@TimeRegistration datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert Into Users (FirstName,LastName,SecondName,Email,Password,Login,DateBirth,TimeRegistration)
	Values (@FirstName,@LatstName,@SecondName,@Email,@Password,@Login,@DateBirth,@TimeRegistration)

END
GO
/****** Object:  StoredProcedure [dbo].[LikeDelete]    Script Date: 29.04.2021 14:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LikeDelete]
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete From Likes
	Where ID=@ID
END
GO
