--Lab15.2
	--#1
		CREATE TABLE TR_AUDIT_2
		(
			ID INT IDENTITY,
				STMT VARCHAR(20)
					CHECK(STMT IN ('INS','DEL','UPD')),
				TRNAME VARCHAR(50),
				CC VARCHAR(MAX)
		)
		GO
		CREATE TRIGGER INS_TRIG ON Списанное_оборудование AFTER INSERT
			AS
			BEGIN
			DECLARE @NAME NVARCHAR(60),@CAUSE NVARCHAR(90),@DATE DATE
			DECLARE @INSERT NVARCHAR(MAX)
			SET @NAME = (SELECT Название_Оборудования FROM inserted)
			SET @CAUSE = (SELECT Причина_Списания FROM inserted)
			SET @DATE = (SELECT Дата_Списания FROM inserted)
			SET @INSERT = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50))
			INSERT INTO TR_AUDIT_2
				VALUES('INS','INS_TRIG',@INSERT);
			RETURN
			END
		
		INSERT INTO Списанное_оборудование
			VALUES(6,'HUAWEI','ОБНОВЛЕН','2001-02-03');
		SELECT * FROM TR_AUDIT_2
		
	--#2
	GO
		CREATE TRIGGER DEL_TRIG ON Списанное_оборудование AFTER DELETE
		AS
		BEGIN
			DECLARE @NAME NVARCHAR(60),@CAUSE NVARCHAR(90),@DATE DATE
			DECLARE @DELETE NVARCHAR(MAX)
			SET @NAME = (SELECT Название_Оборудования FROM deleted)
			SET @CAUSE = (SELECT Причина_Списания FROM deleted)
			SET @DATE = (SELECT Дата_Списания FROM deleted)
			SET @DELETE = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50))
			INSERT INTO TR_AUDIT_2
				VALUES('DEL','DEL_TRIG',@DELETE);
		RETURN
		END

	DELETE FROM Списанное_оборудование WHERE Id = 6
	SELECT * FROM TR_AUDIT_2
	DROP TRIGGER DEL_TRIG

	--#3
	GO
		CREATE TRIGGER UPD_TRIG ON Списанное_оборудование AFTER UPDATE
		AS
		BEGIN
			DECLARE @NAME NVARCHAR(60),@CAUSE NVARCHAR(90),@DATE DATE
			DECLARE @TEXT NVARCHAR(MAX)
			SET @NAME = (SELECT Название_Оборудования FROM deleted)
			SET @CAUSE = (SELECT Причина_Списания FROM deleted)
			SET @DATE = (SELECT Дата_Списания FROM deleted)
			SET @TEXT = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50))
			SET @NAME = (SELECT Название_Оборудования FROM inserted)
			SET @CAUSE = (SELECT Причина_Списания FROM inserted)
			SET @DATE = (SELECT Дата_Списания FROM inserted)
			SET @TEXT = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50)) + ', '+ @TEXT
			INSERT INTO TR_AUDIT_2
				VALUES('DEL','UPD_TRIG',@TEXT);
		RETURN
		END
		UPDATE Списанное_оборудование SET Дата_Списания='2000-01-11' WHERE Id=6
		SELECT * FROM TR_AUDIT_2
	--#4
	GO
		CREATE TRIGGER TRIG ON Списанное_оборудование AFTER INSERT,UPDATE,DELETE
		AS
		BEGIN
			DECLARE @INS INT= (SELECT COUNT(*) FROM inserted)
			DECLARE @DEL INT= (SELECT COUNT(*) FROM deleted)
			DECLARE @NAME NVARCHAR(60),@CAUSE NVARCHAR(90),@DATE DATE
			DECLARE @TEXT NVARCHAR(MAX)
			IF(@DEL=0 AND @INS>0)
			BEGIN
				PRINT'INSERT:'
				SET @NAME = (SELECT Название_Оборудования FROM inserted)
				SET @CAUSE = (SELECT Причина_Списания FROM inserted)
				SET @DATE = (SELECT Дата_Списания FROM inserted)
				SET @TEXT = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50))
				INSERT INTO TR_AUDIT_2
					VALUES('INS','TRIG',@TEXT);
			END
			IF(@INS = 0 AND @DEL>0)
				BEGIN
					PRINT'DELETE:';
					SET @NAME = (SELECT Название_Оборудования FROM deleted)
					SET @CAUSE = (SELECT Причина_Списания FROM deleted)
					SET @DATE = (SELECT Дата_Списания FROM deleted)
					SET @TEXT = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50))
					INSERT INTO TR_AUDIT_2
						VALUES('DEL','TRIG',@TEXT);
				END
				IF(@INS>0 AND @DEL>0)
				BEGIN
					PRINT 'UPDATE'
					SET @NAME = (SELECT Название_Оборудования FROM deleted)
					SET @CAUSE = (SELECT Причина_Списания FROM deleted)
					SET @DATE = (SELECT Дата_Списания FROM deleted)
					SET @TEXT = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50))
					SET @NAME = (SELECT Название_Оборудования FROM inserted)
					SET @CAUSE = (SELECT Причина_Списания FROM inserted)
					SET @DATE = (SELECT Дата_Списания FROM inserted)
					SET @TEXT = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50)) + ', '+ @TEXT
					INSERT INTO TR_AUDIT_2
						VALUES('UPD','TRIG',@TEXT);
				END
			RETURN
		END
		SELECT * FROM Списанное_оборудование

		DELETE FROM Списанное_оборудование WHERE Id=6
		INSERT INTO Списанное_оборудование
			VALUES(6,'LENOVO','ВЫХОД ИЗ СТРОЯ','2016-02-22');
		UPDATE Списанное_оборудование SET Причина_Списания='УСТАРЕЛ' WHERE Id=6
		SELECT * FROM TR_AUDIT_2
		
		

	--#5
		GO
		CREATE TRIGGER DDL_TRIG ON DATABASE FOR ALTER_TABLE
		AS
		BEGIN
			PRINT 'DDL TRIGGER UPDATE:';
			UPDATE Оборудование SET Количество = 200 WHERE Название_Оборудования LIKE 'WTR 2'
		RETURN
		END
		
		ALTER TABLE Оборудование ADD CONSTRAINT Количество CHECK(Количество <=100)
		DROP TRIGGER DDL_TRIG

		ALTER TABLE Оборудование DROP CONSTRAINT Количество
	--#6
		GO
		CREATE TRIGGER DEL_TRIG_1 ON Списанное_оборудование AFTER DELETE
		AS
		BEGIN
			DECLARE @NAME NVARCHAR(60),@CAUSE NVARCHAR(90),@DATE DATE
			DECLARE @DELETE NVARCHAR(MAX)
			SET @NAME = (SELECT Название_Оборудования FROM deleted)
			SET @CAUSE = (SELECT Причина_Списания FROM deleted)
			SET @DATE = (SELECT Дата_Списания FROM deleted)
			SET @DELETE = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50))
			INSERT INTO TR_AUDIT_2
				VALUES('DEL','DEL_TRIG_1',@DELETE);
		RETURN
		END

		GO
		CREATE TRIGGER DEL_TRIG_2 ON Списанное_оборудование AFTER DELETE
		AS
		BEGIN
			DECLARE @NAME NVARCHAR(60),@CAUSE NVARCHAR(90),@DATE DATE
			DECLARE @DELETE NVARCHAR(MAX)
			SET @NAME = (SELECT Название_Оборудования FROM deleted)
			SET @CAUSE = (SELECT Причина_Списания FROM deleted)
			SET @DATE = (SELECT Дата_Списания FROM deleted)
			SET @DELETE = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50))
			INSERT INTO TR_AUDIT_2
				VALUES('DEL','DEL_TRIG_2',@DELETE);
		RETURN
		END

		GO
		CREATE TRIGGER DEL_TRIG_3 ON Списанное_оборудование AFTER DELETE
		AS
		BEGIN
			DECLARE @NAME NVARCHAR(60),@CAUSE NVARCHAR(90),@DATE DATE
			DECLARE @DELETE NVARCHAR(MAX)
			SET @NAME = (SELECT Название_Оборудования FROM deleted)
			SET @CAUSE = (SELECT Причина_Списания FROM deleted)
			SET @DATE = (SELECT Дата_Списания FROM deleted)
			SET @DELETE = @NAME + ', '+@CAUSE+', '+CAST(@DATE AS nvarchar(50))
			INSERT INTO TR_AUDIT_2
				VALUES('DEL','DEL_TRIG_3',@DELETE);
		RETURN
		END

		select t.name, e.type_desc 
         from sys.triggers  t join  sys.trigger_events e  
                  on t.object_id = e.object_id  
                            where OBJECT_NAME(t.parent_id) = 'Списанное_оборудование' and 
	                                                                        e.type_desc = 'DELETE' ;  
				
				exec  SP_SETTRIGGERORDER @triggername = 'DEL_TRIG_3', 
	                        @order = 'FIRST', @stmttype = 'DELETE';

				exec  SP_SETTRIGGERORDER @triggername = 'DEL_TRIG_2', 
	                        @order = 'LAST', @stmttype = 'DELETE';

	
	--#7
		GO
			CREATE TRIGGER SPIS_TRAN ON Оборудование AFTER INSERT
				AS 
				BEGIN
					DECLARE @NUMB INT = (SELECT Количество FROM inserted)
					IF(@NUMB>100)
					BEGIN
						RAISERROR('NUMBER LOWER THAN 100',10,1);
						ROLLBACK;
					END
				RETURN
				END

				INSERT INTO Оборудование 
					VALUES('LENOVO','НОУТБУК','2000-10-20',120,'Подраздел 4',2,5);

	--#8
		GO
			CREATE TRIGGER EQ_ENSTEAD_OFF ON Оборудование INSTEAD OF DELETE
			AS
			BEGIN
			RAISERROR('УДАЛЕНИЕ ЗАПРЕЩЕНО',10,1);
			RETURN
			END
		DELETE FROM Оборудование WHERE Название_Оборудования = 'WTR 2'
		SELECT * FROM Оборудование

		DROP TRIGGER DEL_TRIG_3
		DROP TRIGGER DEL_TRIG_2
		DROP TRIGGER DEL_TRIG_1
		DROP TRIGGER UPD_TRIG
		DROP TRIGGER DEL_TRIG
		DROP TRIGGER INS_TRIG
		DROP TRIGGER TRIG

	--#9
		GO
			CREATE TRIGGER DDL_UNIVER ON DATABASE 
									FOR DDL_DATABASE_LEVEL_EVENTS AS
			declare @t varchar(50) =  EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)');
		declare @t1 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)');
		declare @t2 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)'); 
		if @t1 = 'Товары' 
		begin
				 print 'Тип события: '+@t;
				 print 'Имя объекта: '+@t1;
				 print 'Тип объекта: '+@t2;
				 raiserror( N'операции с таблицей Товары запрещены', 16, 1);  
				 rollback;    
		 end;
		
		ALTER TABLE STUDENT DROP COLUMN FOTO

