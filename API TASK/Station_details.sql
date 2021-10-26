create database RailEnquery
CREATE TABLE [dbo].[Station](
	[StationId] [int]  NOT NULL,
	[StationName] [varchar](250) NULL,
	[TrainId] [int] NULL,
	[TrainName] [varchar](150) NULL,
	[Arrival_Time] [varchar] (7) NULL,
	[Departure_Time] [varchar](7) NULL,
	[Operation_Days] [varchar](500) NULL,
	[Operating_Date][varchar](500) NULL
)
 
select * from Station
drop table Station


