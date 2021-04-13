USE [cinema]
GO
/****** Object:  Table [dbo].[cashbox]    Script Date: 13.04.2021 15:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cashbox](
	[ticket_number] [int] IDENTITY(1,1) NOT NULL,
	[is_paid] [bit] NOT NULL,
	[is_canceled] [bit] NOT NULL,
	[schedule_id] [int] NULL,
 CONSTRAINT [PK_ticket_number] PRIMARY KEY CLUSTERED 
(
	[ticket_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[films]    Script Date: 13.04.2021 15:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[films](
	[film_id] [int] IDENTITY(1,1) NOT NULL,
	[film_name] [varchar](250) NOT NULL,
	[duration_minutes] [tinyint] NULL,
 CONSTRAINT [PK_film_id] PRIMARY KEY CLUSTERED 
(
	[film_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[schedule]    Script Date: 13.04.2021 15:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schedule](
	[schedule_id] [int] IDENTITY(1,1) NOT NULL,
	[schedule_date] [smalldatetime] NOT NULL,
	[schedule_time] [time](7) NOT NULL,
	[is_holiday] [bit] NOT NULL,
	[film_id] [int] NULL,
	[ticket_id] [int] NULL,
 CONSTRAINT [PK_schedule_id] PRIMARY KEY CLUSTERED 
(
	[schedule_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tickets]    Script Date: 13.04.2021 15:04:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tickets](
	[tickets_id] [int] IDENTITY(1,1) NOT NULL,
	[ticket_price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tickets_id] PRIMARY KEY CLUSTERED 
(
	[tickets_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cashbox] ON 

INSERT [dbo].[cashbox] ([ticket_number], [is_paid], [is_canceled], [schedule_id]) VALUES (1, 1, 0, 1)
INSERT [dbo].[cashbox] ([ticket_number], [is_paid], [is_canceled], [schedule_id]) VALUES (2, 1, 1, 6)
INSERT [dbo].[cashbox] ([ticket_number], [is_paid], [is_canceled], [schedule_id]) VALUES (3, 0, 0, 3)
INSERT [dbo].[cashbox] ([ticket_number], [is_paid], [is_canceled], [schedule_id]) VALUES (4, 1, 0, 4)
INSERT [dbo].[cashbox] ([ticket_number], [is_paid], [is_canceled], [schedule_id]) VALUES (5, 1, 0, 2)
SET IDENTITY_INSERT [dbo].[cashbox] OFF
GO
SET IDENTITY_INSERT [dbo].[films] ON 

INSERT [dbo].[films] ([film_id], [film_name], [duration_minutes]) VALUES (1, N'avengers', 120)
INSERT [dbo].[films] ([film_id], [film_name], [duration_minutes]) VALUES (2, N'batman', 90)
INSERT [dbo].[films] ([film_id], [film_name], [duration_minutes]) VALUES (3, N'spiderman', 60)
INSERT [dbo].[films] ([film_id], [film_name], [duration_minutes]) VALUES (4, N'сatwoman', 120)
INSERT [dbo].[films] ([film_id], [film_name], [duration_minutes]) VALUES (5, N'hulk', 90)
SET IDENTITY_INSERT [dbo].[films] OFF
GO
SET IDENTITY_INSERT [dbo].[schedule] ON 

INSERT [dbo].[schedule] ([schedule_id], [schedule_date], [schedule_time], [is_holiday], [film_id], [ticket_id]) VALUES (1, CAST(N'2021-04-22T00:00:00' AS SmallDateTime), CAST(N'09:00:00' AS Time), 0, 2, 3)
INSERT [dbo].[schedule] ([schedule_id], [schedule_date], [schedule_time], [is_holiday], [film_id], [ticket_id]) VALUES (2, CAST(N'2021-04-26T00:00:00' AS SmallDateTime), CAST(N'12:00:00' AS Time), 0, 1, 2)
INSERT [dbo].[schedule] ([schedule_id], [schedule_date], [schedule_time], [is_holiday], [film_id], [ticket_id]) VALUES (3, CAST(N'2021-04-27T00:00:00' AS SmallDateTime), CAST(N'15:00:00' AS Time), 1, 5, 1)
INSERT [dbo].[schedule] ([schedule_id], [schedule_date], [schedule_time], [is_holiday], [film_id], [ticket_id]) VALUES (4, CAST(N'2021-04-28T00:00:00' AS SmallDateTime), CAST(N'18:00:00' AS Time), 0, 3, 5)
INSERT [dbo].[schedule] ([schedule_id], [schedule_date], [schedule_time], [is_holiday], [film_id], [ticket_id]) VALUES (5, CAST(N'2021-04-29T00:00:00' AS SmallDateTime), CAST(N'21:00:00' AS Time), 1, 4, 4)
INSERT [dbo].[schedule] ([schedule_id], [schedule_date], [schedule_time], [is_holiday], [film_id], [ticket_id]) VALUES (6, CAST(N'2021-04-22T00:00:00' AS SmallDateTime), CAST(N'09:00:00' AS Time), 0, 2, 3)
INSERT [dbo].[schedule] ([schedule_id], [schedule_date], [schedule_time], [is_holiday], [film_id], [ticket_id]) VALUES (7, CAST(N'2021-04-21T00:00:00' AS SmallDateTime), CAST(N'12:00:00' AS Time), 0, 1, 2)
INSERT [dbo].[schedule] ([schedule_id], [schedule_date], [schedule_time], [is_holiday], [film_id], [ticket_id]) VALUES (8, CAST(N'2021-04-18T00:00:00' AS SmallDateTime), CAST(N'15:00:00' AS Time), 1, 5, 1)
INSERT [dbo].[schedule] ([schedule_id], [schedule_date], [schedule_time], [is_holiday], [film_id], [ticket_id]) VALUES (9, CAST(N'2021-04-15T00:00:00' AS SmallDateTime), CAST(N'18:00:00' AS Time), 0, 3, 5)
INSERT [dbo].[schedule] ([schedule_id], [schedule_date], [schedule_time], [is_holiday], [film_id], [ticket_id]) VALUES (10, CAST(N'2021-04-17T00:00:00' AS SmallDateTime), CAST(N'21:00:00' AS Time), 1, 4, 4)
SET IDENTITY_INSERT [dbo].[schedule] OFF
GO
SET IDENTITY_INSERT [dbo].[tickets] ON 

INSERT [dbo].[tickets] ([tickets_id], [ticket_price]) VALUES (1, CAST(5 AS Decimal(18, 0)))
INSERT [dbo].[tickets] ([tickets_id], [ticket_price]) VALUES (2, CAST(6 AS Decimal(18, 0)))
INSERT [dbo].[tickets] ([tickets_id], [ticket_price]) VALUES (3, CAST(8 AS Decimal(18, 0)))
INSERT [dbo].[tickets] ([tickets_id], [ticket_price]) VALUES (4, CAST(9 AS Decimal(18, 0)))
INSERT [dbo].[tickets] ([tickets_id], [ticket_price]) VALUES (5, CAST(10 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[tickets] OFF
GO
ALTER TABLE [dbo].[cashbox]  WITH CHECK ADD FOREIGN KEY([schedule_id])
REFERENCES [dbo].[schedule] ([schedule_id])
GO
ALTER TABLE [dbo].[schedule]  WITH CHECK ADD FOREIGN KEY([film_id])
REFERENCES [dbo].[films] ([film_id])
GO
ALTER TABLE [dbo].[schedule]  WITH CHECK ADD FOREIGN KEY([ticket_id])
REFERENCES [dbo].[tickets] ([tickets_id])
GO
ALTER TABLE [dbo].[films]  WITH CHECK ADD  CONSTRAINT [CK_duration_minutes] CHECK  (([duration_minutes]=(60) OR [duration_minutes]=(90) OR [duration_minutes]=(120)))
GO
ALTER TABLE [dbo].[films] CHECK CONSTRAINT [CK_duration_minutes]
GO
ALTER TABLE [dbo].[tickets]  WITH CHECK ADD  CONSTRAINT [CK_ticket_price] CHECK  (([ticket_price]>=(0)))
GO
ALTER TABLE [dbo].[tickets] CHECK CONSTRAINT [CK_ticket_price]
GO
