--Lab14.2 
	--#1
		GO
			CREATE FUNCTION COUNT_EQUIPMENT(@TYPE NVARCHAR(30))
				RETURNS INT 
				AS 
				BEGIN
					DECLARE @RC INT = 0;
					SET @RC = (SELECT COUNT(*) FROM Оборудование 
											INNER JOIN Ответственный
												ON Оборудование.Id_Ответственного_Рабочего =Ответственный.Id_Рабочего
													WHERE Оборудование.Тип_Оборудования = @TYPE)
					RETURN @RC;
				END
		GO
			DECLARE @F INT = DBO.COUNT_EQUIPMENT('Принтер');
			PRINT 'КОЛИЧЕСТВО ПРИНТЕРОВ: '+CAST(@F AS VARCHAR(5));


		GO
			ALTER FUNCTION COUNT_EQUIPMENT(@TYPE NVARCHAR(30),@ID INT)
				RETURNS INT 
				AS 
				BEGIN
					DECLARE @RC INT = 0;
					SET @RC = (SELECT COUNT(*) FROM Оборудование 
											INNER JOIN Ответственный
												ON Оборудование.Id_Ответственного_Рабочего =Ответственный.Id_Рабочего
													WHERE Оборудование.Тип_Оборудования = @TYPE
																	AND
																Оборудование.Id_Ответственного_Рабочего = @ID)
					RETURN @RC;
				END
		GO
			DECLARE @F INT = DBO.COUNT_EQUIPMENT('Принтер',1);
			PRINT 'КОЛИЧЕСТВО ПРИНТЕРОВ: '+CAST(@F AS VARCHAR(5));
	--#2
		GO
			CREATE FUNCTION NAME_LIST(@TYPE NVARCHAR(30))
				RETURNS NVARCHAR(300)
				AS
				BEGIN
					DECLARE CURS CURSOR LOCAL 
						FOR 
							SELECT Название_Оборудования FROM Оборудование
								WHERE Тип_Оборудования = @TYPE
					DECLARE @TEMP NVARCHAR(30);
					DECLARE @LIST NVARCHAR(300)='';
					OPEN CURS
					FETCH CURS INTO @TEMP;
					WHILE @@FETCH_STATUS=0
					BEGIN
						SET @LIST =RTRIM(@TEMP)+', '+@LIST;
						FETCH CURS INTO @TEMP
					END
					CLOSE CURS
					RETURN @LIST;
				END
		GO
			SELECT Тип_Оборудования,DBO.NAME_LIST(Тип_Оборудования)[ПЕРЕЧЕНЬ НАЗВАНИЙ] FROM Оборудование
			DROP FUNCTION DBO.NAME_LIST

	--#3
		GO
			CREATE FUNCTION SSS(@NAME NVARCHAR(30),@SURNAME NVARCHAR(30))
			RETURNS TABLE
			AS RETURN
			 SELECT Оборудование.Название_Оборудования,Фамилия_Ответственного FROM Оборудование
				LEFT OUTER JOIN Ответственный
					ON Оборудование.Id_Ответственного_Рабочего = Ответственный.Id_Рабочего
				WHERE Оборудование.Название_Оборудования = ISNULL(@NAME,Оборудование.Название_Оборудования)
									AND
							Ответственный.Фамилия_Ответственного = ISNULL(@SURNAME,Ответственный.Фамилия_Ответственного)
		
		GO
			SELECT * FROM DBO.SSS(NULL,NULL);
			SELECT * FROM DBO.SSS('Huawei',NULL);
			SELECT * FROM DBO.SSS(NULL,'SAD');
			SELECT * FROM DBO.SSS('SE','SAD');
		DROP FUNCTION SSS
				
	--#4
		GO
			CREATE FUNCTION DDF(@TYPE NVARCHAR(30))
			RETURNS INT
			AS
			BEGIN
				DECLARE @RC INT = 0;
				SET @RC = (SELECT COUNT(*) FROM Оборудование WHERE Оборудование.Тип_Оборудования = ISNULL(@TYPE,Тип_Оборудования))
				RETURN @RC;
			END
		GO
			SELECT Тип_Оборудования,dbo.DDF(Тип_Оборудования)[КОЛИЧЕСТВО ОБОРУДОВАНИЯ] 
			FROM Оборудование
				GROUP BY Тип_Оборудования
			SELECT dbo.DDF(NULL)[ВСЕГО ОБОРУДОВАНИЯ];
