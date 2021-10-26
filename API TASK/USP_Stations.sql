CREATE PROCEDURE [dbo].[USP_Stations](
 
	@ACTION			CHAR(1)      =	NULL,
	@STATIONID			INT          =	NULL,
	@STATIONNAME		    VARCHAR(250) =	NULL,
	@TRAINID       		INT          =	NULL,
	@TRAINNAME	    VARCHAR(350) =	NULL,
	@ARRTIME			TIME(7) =	NULL,
	@ENDTIME			TIME(7)  =	NULL,
	@OPERATINGDAYS		VARCHAR(500) =	NULL,
	@OPERATINGDATE		VARCHAR(500)= NULL
)	
AS
BEGIN
	SET NOCOUNT ON;
		IF(@ACTION='A')
		BEGIN

			SELECT StationId,StationName,TrainId,TrainName,Arrival_Time,Departure_Time,Operation_Days,Operating_Date From Station order by Operating_Date asc
					
		END
		ELSE IF(@ACTION='B')
		BEGIN
			IF NOT EXISTS(SELECT 1 FROM Station WHERE StationId=@STATIONID AND TrainId=@TRAINID)
			BEGIN

				INSERT INTO Station(
					StationId,StationName,TrainId,TrainName,Arrival_Time,Departure_Time,Operation_Days,Operating_Date
					)
					VALUES (
					@STATIONID,@STATIONNAME,@TRAINID,@TRAINNAME,@ARRTIME,@ENDTIME,@OPERATINGDAYS,@OPERATINGDATE
					)
			END
		END
		
		ELSE IF(@ACTION='C')
		BEGIN
			DELETE FROM Station WHERE StationId=@STATIONID
		END
		ELSE IF(@ACTION='D')
					BEGIN
						SELECT StationId,StationName,TrainId,TrainName,Arrival_Time,Departure_Time,Operation_Days,Operating_Date From Station
						WHERE	StationId=@STATIONID  order by Operating_Date asc
					END
		ELSE IF(@ACTION='E')
		BEGIN
			SELECT StationId,StationName,TrainId,TrainName,Arrival_Time,Departure_Time,Operation_Days,Operating_Date FROM Station WHERE StationId=@STATIONID AND Arrival_Time=@ARRTIME  
		END
		ELSE IF(@ACTION='F')
		BEGIN
			SELECT StationId,StationName,TrainId,TrainName,Arrival_Time,Departure_Time,Operation_Days,Operating_Date FROM Station WHERE StationId=@STATIONID AND Operating_Date=@OPERATINGDATE  
		END
		ELSE IF(@ACTION='G')
					BEGIN
						SELECT StationId,StationName,TrainId,TrainName,Arrival_Time,Departure_Time,Operation_Days,Operating_Date From Station
						WHERE	TrainId=@TRAINID  order by Operating_Date asc
					END
		ELSE IF(@ACTION='H')
		BEGIN
			SELECT StationId,StationName,TrainId,TrainName,Arrival_Time,Departure_Time,Operation_Days,Operating_Date FROM Station WHERE TrainId=@TRAINID AND Arrival_Time=@ARRTIME  
		END
		ELSE IF(@ACTION='I')
					BEGIN
						SELECT StationId,StationName,TrainId,TrainName,Arrival_Time,Departure_Time,Operation_Days,Operating_Date From Station
						WHERE	Operating_Date=@OPERATINGDATE
					END
		ELSE IF(@ACTION='J')
		BEGIN
			SELECT StationId,StationName,TrainId,TrainName,Arrival_Time,Departure_Time,Operation_Days,Operating_Date FROM Station WHERE TrainId=@TRAINID AND Operating_Date=@OPERATINGDATE 
		END
		ELSE IF(@ACTION='K')
					BEGIN
						SELECT StationId,StationName,TrainId,TrainName,Arrival_Time,Departure_Time,Operation_Days,Operating_Date From Station
						WHERE	Arrival_Time=@ARRTIME  order by Operating_Date asc
					END
					
		ELSE IF(@ACTION='L')
		BEGIN
			DELETE FROM Station WHERE TrainId=@TRAINID
		END
				
END

DROP PROCEDURE USP_Stations;
GO
