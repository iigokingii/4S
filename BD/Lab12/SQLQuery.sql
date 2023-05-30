--Lab12�2
	--#1
		GO
			SET NOCOUNT ON
			IF EXISTS(SELECT*FROM SYS.OBJECTS
									WHERE	OBJECT_ID = object_id(N'DBO.TEMP'))
				DROP TABLE TEMP;
			DECLARE @C INT, @FLAG CHAR ='C';
			SET IMPLICIT_TRANSACTIONS ON
			CREATE TABLE TEMP
			(
				ID INT,
				NAME NVARCHAR(30),
				SURNAME NVARCHAR(30)
			)
			INSERT INTO TEMP VALUES
			(0,'KIRILL','DRACH'),
			(1,'VADIM','YATCKEVICH'),
			(2,'DIMA','LESHUK')
			SET @C = (SELECT COUNT(*) FROM TEMP)
			PRINT 'NUMBER OF STUDENTS: '+CAST(@C AS NVARCHAR(10));
			IF(@FLAG LIKE 'C')
				COMMIT;
			ELSE
				ROLLBACK;
			SET IMPLICIT_TRANSACTIONS OFF;
			IF EXISTS(SELECT*FROM SYS.OBJECTS
									WHERE	OBJECT_ID = object_id(N'DBO.TEMP'))
				PRINT 'TABLE TEMP EXISTS'
			ELSE
				PRINT 'TABLE TEMP DOESNT EXIST';
	--#2
	GO
			BEGIN TRY
				BEGIN TRAN
					DELETE ������������� WHERE Id_�������� = 1001;
					INSERT ������������� VALUES (3,'QW','QWE','QWE','XZC','2002-1-22')
				COMMIT TRAN;
			END TRY
			BEGIN CATCH
				PRINT '������:'+CASE
													WHEN ERROR_NUMBER()=2627 AND PATINDEX('%PK__��������%',ERROR_MESSAGE())>0
														THEN ' �� ������� �������� ������������� ���� � ������ "dbo.�������������".'
													ELSE
														'������ ������: '+ cast(ERROR_NUMBER() AS VARCHAR(5))+ERROR_MESSAGE()
												END;
				IF @@TRANCOUNT>0
				ROLLBACK TRAN;
			END CATCH
	--#3
	GO
		DECLARE @POINT NVARCHAR (2)
			BEGIN TRY
				BEGIN TRAN
					DELETE ������������� WHERE Id_�������� = 1001;
					SET @POINT = 'P1'
					INSERT ������������� VALUES (3,'QW','QWE','QWE','XZC','2002-1-22')
				COMMIT TRAN;
			END TRY
			BEGIN CATCH
				PRINT '������:'+CASE
													WHEN ERROR_NUMBER()=2627 AND PATINDEX('%PK__��������%',ERROR_MESSAGE())>0
														THEN ' �� ������� �������� ������������� ���� � ������ "dbo.�������������".'
													ELSE
														'������ ������: '+ cast(ERROR_NUMBER() AS VARCHAR(5))+ERROR_MESSAGE()
												END;
				IF @@TRANCOUNT>0
				BEGIN
				PRINT 'CHECK POINT: '+@POINT
				ROLLBACK TRAN @POINT;
				COMMIT TRAN;
				END
			END CATCH
	--#4
	--A--
			GO
				SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
				BEGIN TRAN
		--T1--
				SELECT @@SPID, 'insert equipment' '���������', * FROM ���������_������������ 
																										WHERE id = 7
				SELECT @@SPID, 'UPDATE equipment' '���������', * FROM ���������_������������ 
																										WHERE id = 7
				COMMIT;
		--T2--
	--#5
		--A--
		SET TRANSACTION ISOLATION LEVEL READ COMMITTED
		BEGIN TRAN
		SELECT COUNT(*) FROM ���������_������������ WHERE ��������_������������ LIKE '%Xiaomi%';
		--T1--
		--T2--
		SELECT 'UPDATE AUDITORIUM_TYPE' '���������', COUNT(*) FROM ���������_������������ 
																										WHERE ��������_������������ LIKE '%Xiaomi%';
		COMMIT;
	--#6
		SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
		BEGIN TRAN
		SELECT * FROM ���������_������������ WHERE Id = 8
		--T1--
		--T2--
		SELECT CASE
							WHEN Id = 8 
								THEN 'INSERTED ROW INTO AUDITORIUM_TYPE'
							ELSE
								''
							END 'REZULT',��������_������������ FROM ���������_������������ WHERE Id=8
		COMMIT;
	--#7
		--A--
		SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
		BEGIN TRAN
		DELETE ���������_������������ WHERE Id=8;
		INSERT INTO ���������_������������ VALUES(8,'TEMPS','TEMP DESCRIPTION','2002-10-2');
		UPDATE ���������_������������ SET �������_�������� = '�������' WHERE Id=8;
		SELECT * FROM ���������_������������ WHERE Id=8;
		--T1--
		SELECT * FROM ���������_������������ WHERE Id=8;
		--T2--
		COMMIT;