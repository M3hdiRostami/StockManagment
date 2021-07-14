-- =============================================
-- Author:		<Mahdi Rostami>
-- Create date: <14/07/2021>
-- Description:	GetStocks(@ProductID varchar,@Sdate INT ,@Edate INT ) for report
-- =============================================
CREATE PROCEDURE [dbo].[GetStocks](@ProductID nvarchar(30),@Startdate INT ,@Enddate INT )
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		--declare resulttable
		DECLARE @Temp TABLE 
		(
			  RowNo int
			 ,ActionType nvarchar(10)
	         ,DocumentNo VARCHAR(16)
             ,CreationDate VARCHAR(15)
             ,InputValue numeric(25,6)
             ,OutputValue numeric(25,6)
             ,TotalStock numeric(25,6)
		)
      --DECLARE THE VARIABLES FOR HOLDING DATA.
      DECLARE @IslemTur nvarchar(5)
	         ,@EvrakNo VARCHAR(16)
             ,@Tarih VARCHAR(15)
             ,@GirisMiktar numeric(25,6)
             ,@CikisMiktar numeric(25,6)
             ,@Miktar numeric(25,6)
             ,@Stock numeric(25,6)=0
			 ,@Counter INT=1

 
      --DECLARE THE CURSOR FOR A QUERY.
      DECLARE PrintStiCursor CURSOR READ_ONLY
		FOR
      SELECT s.IslemTur,s.EvrakNo,CONVERT(VARCHAR(15), CAST(s.tarih - 2 AS datetime), 104),s.Miktar FROM 
	  STI s 
	  inner join STK p on s.MalID=p.ID
	  WHERE p.MalKodu=@ProductID and @Startdate <= s.Tarih and @Enddate >= s.Tarih
	  order by Tarih asc
      --OPEN CURSOR.
      OPEN PrintStiCursor
 
      --FETCH THE RECORD INTO THE VARIABLES.
      FETCH NEXT FROM PrintStiCursor INTO
			  @IslemTur 
             ,@EvrakNo 
             ,@Tarih
			 ,@Miktar 

            
      --LOOP UNTIL RECORDS ARE AVAILABLE.
      WHILE @@FETCH_STATUS = 0
      BEGIN
             
			IF @IslemTur = 0 	
				 BEGIN
				     SET @IslemTur=N'Giriş'
					 SET @GirisMiktar=@Miktar
					 SET @CikisMiktar=0
					 SET @Stock=@Stock+@Miktar
				 END
			ELSE
			BEGIN
						SET @IslemTur=N'Çıkış'
						SET @CikisMiktar=@Miktar
						SET @GirisMiktar=0
						SET @Stock=@Stock-@Miktar

			END
			 --PRINT CURRENT RECORD.
            
			 INSERT INTO @temp values(@Counter,@IslemTur,@EvrakNo,@Tarih,@GirisMiktar,@CikisMiktar,@Stock)
			 
             --INCREMENT COUNTER.
             SET @Counter = @Counter + 1
 
             --FETCH THE NEXT RECORD INTO THE VARIABLES.
             FETCH NEXT FROM PrintStiCursor INTO
             @IslemTur 
             ,@EvrakNo 
             ,@Tarih 
             ,@Miktar 
            
      END
 
      --CLOSE THE CURSOR.
      CLOSE PrintStiCursor
      DEALLOCATE PrintStiCursor
	  select * from @Temp
END