CREATE DATABASE  CINEMA
GO
Use CINEMA

CREATE Table Film
(
	FilmID int IDENTITY(1,1),
	NameFilm NVARCHAR (30) NOT NULL,
	Duration TINYINT DEFAULT 60,
	CONSTRAINT PK_FilmID Primary Key (FilmID),
	CONSTRAINT UQ_NameFilm UNIQUE (NameFilm),
	CONSTRAINT CK_Duration CHECK (Duration=90 AND Duration=60 AND Duration=120)
)

CREATE TABLE SessionFILM 
(
	SessionID int IDENTITY(1,1),
	DateTimeSession SMALLDATETIME NOT NULL,
	CONSTRAINT PK_SessionID Primary Key (SessionID)
)

CREATE Table Ticket
(
	TicketID int  IDENTITY(1,1),
	NumberTicket UNIQUEIDENTIFIER ,
	SessionID int REFERENCES SessionFILM (SessionID),
	FilmID int REFERENCES Film (FilmID),
	Price SMALLMONEY NOT NULL 
	CONSTRAINT PK_Id_Ticket Primary Key (TicketID),
	CONSTRAINT UQ_Number_Ticket UNIQUE (NumberTicket),
	CONSTRAINT CK_Price CHECK (Price>0 AND PRICE <50)
)

CREATE TABLE TicketSOLD
(
	TicketSoldID int IDENTITY(1,1),
	TicketID int REFERENCES Ticket(TicketID),
	SessionID int REFERENCES SessionFILM (SessionID),
	DateTimeSold SMALLDATETIME NOT NULL,
	SumTicket SMALLMONEY NOT NULL ,
	CONSTRAINT PK_TicketSoldID Primary Key (TicketSoldID),
	CONSTRAINT CK_SumTicket CHECK (SumTicket>0 AND SumTicket <50)
)