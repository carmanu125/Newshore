USE [NewshoreDB]
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 2/06/2023 12:34:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[ID] [int] NULL,
	[Origin] [varchar](3) NULL,
	[Destination] [varchar](3) NULL,
	[Price] [money] NULL,
	[id_Transport] [int] NULL,
	[id_JourneyFlight] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journey]    Script Date: 2/06/2023 12:34:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journey](
	[ID] [int] NOT NULL,
	[Origin] [varchar](3) NULL,
	[Destination] [varchar](3) NULL,
	[Price] [money] NULL,
	[id_Journey_Flight] [int] NULL,
 CONSTRAINT [PK_Journey] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JourneyFlight]    Script Date: 2/06/2023 12:34:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JourneyFlight](
	[id_Flight] [int] NOT NULL,
	[id_Journey] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transport]    Script Date: 2/06/2023 12:34:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transport](
	[ID] [int] NOT NULL,
	[FlightCarrier] [varchar](2) NULL,
	[FlightNumber] [varchar](4) NULL,
 CONSTRAINT [PK_Transport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Transport] FOREIGN KEY([id_Transport])
REFERENCES [dbo].[Transport] ([ID])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Transport]
GO
