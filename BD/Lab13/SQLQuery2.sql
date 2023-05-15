--lab13.2
--#1
GO
	CREATE PROCEDURE PROC1
	AS 
	BEGIN
		DECLARE @K INT = (SELECT COUNT(*) FROM �������������);
		SELECT *FROM �������������
		RETURN @K
	END
GO
DECLARE @K INT = 0;
EXEC @K = PROC1
PRINT 'NUMBER OF ROWS: '+ CONVERT(NVARCHAR(20),@K);

--#2
GO
	ALTER PROCEDURE PROC1
	 @F NVARCHAR(30) =NULL,
	 @O INT OUTPUT
	  AS
		BEGIN
		  DECLARE @K INT = (SELECT COUNT(*) FROM �������������);
		  SELECT *FROM ������������� WHERE �������_�������������� = @F
		  SET @O = @@ROWCOUNT;
		  RETURN @K;
		END


	GO
	DECLARE @K INT=0,@RC INT =0, @P VARCHAR(20)='Ivanov'
	EXEC @K = PROC1 @F=@P,@O=@RC OUTPUT;
	PRINT '���������� �����: '+CAST (@RC AS VARCHAR(10))
	PRINT '����� ���������� '+CAST (@K AS VARCHAR(10))
	
--#3
	CREATE TABLE #TEMPOTV
	(
		ID INT PRIMARY KEY,
		SURNAME NVARCHAR(30),
		NAME NVARCHAR(30),
		PATRONYMIC NVARCHAR(20),
		POSITION NVARCHAR(30),
		DATE DATE
	)
	GO
		ALTER PROCEDURE PROC1
			@F NVARCHAR(30) = NULL
				AS
				BEGIN
					SELECT *FROM ������������� WHERE �������_�������������� = @F
				END
	GO
		INSERT #TEMPOTV EXEC PROC1 @F='Ivanov'
		SELECT*FROM #TEMPOTV

--#4
CREATE TABLE #TEMP_SPIS(
		ID INT PRIMARY KEY,
		NAME NVARCHAR(60),
		CAUSE NVARCHAR(90),
		DATE DATE
	)
	DROP TABLE #TEMP_SPIS

	GO
		CREATE PROCEDURE TEMP_SPIS_INSERT 
			@A INT,
			@N NVARCHAR(60),
			@C NVARCHAR(90),
			@T DATE
		AS DECLARE @RC INT = 1;
		BEGIN TRY
		 INSERT INTO #TEMP_SPIS VALUES (@A,@N,@C,@T)
		 RETURN @RC;
		END TRY
		BEGIN CATCH
		 PRINT 'ERROR NUMBER: '+CAST(ERROR_NUMBER() AS VARCHAR(6));
		 PRINT 'MESSAGE :' + ERROR_MESSAGE();
		 PRINT '������� :' + CAST(ERROR_SEVERITY() AS VARCHAR(6));
		 PRINT '����� : ' + CAST(ERROR_STATE() AS VARCHAR(8));
		 PRINT '����� ������ :'+CAST(ERROR_LINE() AS VARCHAR(8));
		 IF(ERROR_PROCEDURE() IS NOT NULL)
		  PRINT 'NAME OF PROCEDURE: ' + ERROR_PROCEDURE();
		 RETURN -1;
		END CATCH

	GO
		DECLARE @RC INT;
		EXEC @RC = TEMP_SPIS_INSERT @A =5,@N = 'SAMSUNG',@C = '�������� �� ����� ����� ������', @T = '2009-12-2'
		PRINT '��� ������:'+CAST(@RC AS VARCHAR(3));
		SELECT *FROM #TEMP_SPIS 
	
	
	
	--#5
	GO
		CREATE PROCEDURE EQUIPMENT_REPORT
		 @P CHAR(10)
		 AS 
			DECLARE @RC INT =0;
			BEGIN TRY
			 DECLARE @REPORT CHAR(300) = '',@TEMP CHAR(40);
			 DECLARE CURS CURSOR FOR 
				SELECT ��������_������������ FROM ������������ WHERE ���_������������ = @P;
				IF(NOT EXISTS (SELECT ��������_������������ FROM ������������ WHERE ���_������������ = @P))
					RAISERROR('������',11,1) --�����������
				ELSE
					OPEN CURS
					FETCH CURS INTO @TEMP
					WHILE @@FETCH_STATUS =0
					BEGIN
					  SET @REPORT = RTRIM(@TEMP)+', '+@REPORT;
					  SET @RC +=1; 
					  FETCH CURS INTO @TEMP
					END;
				PRINT '�������� ������� �������� (���� SUBJECT) �� �����-�� SUBJECT � ���� ������ ����� �������: '+ @REPORT;
				CLOSE CURS
				RETURN @RC
			END TRY
			BEGIN CATCH 
				PRINT '������ � ����������';
				IF(ERROR_PROCEDURE() IS NOT NULL)
					PRINT '��� ���������: '+ERROR_PROCEDURE();
				RETURN @RC;
			END CATCH

	GO
	DECLARE @RC INT;
	EXEC @RC = EQUIPMENT_REPORT @P = '�������'
	PRINT 'NUMBER OF DISCIPLINES: '+CAST(@RC AS NVARCHAR(29));

	--#6
	CREATE TABLE #TEMP_OTV(
		DATE2 DATE PRIMARY KEY,
		DATE DATE,
	)


	GO
	CREATE PROCEDURE PAUDITORIUM_INSERTX
		@A INT,							--ID
		@N NVARCHAR(60),		--��� ������
		@C NVARCHAR(90),		--��� ����
		@T DATE,						--���� ��������
	  @TN DATE			--���� ������ ��������
	  AS
		DECLARE @RC INT = 1;
		BEGIN TRY
			SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
			BEGIN TRAN
			  INSERT INTO #TEMP_OTV
				VALUES (@T,@TN)
			 EXEC @RC = TEMP_SPIS_INSERT @A =@A, @N=@N,@C=@C,@T=@T;
			COMMIT TRAN;
			RETURN @RC;
		END TRY
		BEGIN CATCH
		 PRINT 'ERROR NUMBER: '+CAST(ERROR_NUMBER() AS VARCHAR(6));
		 PRINT 'MESSAGE :' + ERROR_MESSAGE();
		 PRINT '������� :' + CAST(ERROR_SEVERITY() AS VARCHAR(6));
		 PRINT '����� : ' + CAST(ERROR_STATE() AS VARCHAR(8));
		 PRINT '����� ������ :'+CAST(ERROR_LINE() AS VARCHAR(8));
		 IF(ERROR_PROCEDURE() IS NOT NULL)
		  PRINT 'NAME OF PROCEDURE: ' + ERROR_PROCEDURE();
		 IF (@@TRANCOUNT>0)
		  ROLLBACK TRAN;
		 RETURN -1;
		END CATCH

	GO
		DECLARE @RC INT;
		EXEC @RC = PAUDITORIUM_INSERTX @A	=0,@N='WTR.B3',@C = '������', @T = '2005-02-21',@TN = '2010-09-2'
		PRINT '@RC = ' + CAST (@RC AS VARCHAR(3))
	
	SELECT * FROM #TEMP_OTV;
	SELECT * FROM #TEMP_SPIS;
	













