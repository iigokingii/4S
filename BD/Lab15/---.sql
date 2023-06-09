--Lab15
--#1
	CREATE TABLE TR_AUDIT
	(
		ID INT IDENTITY,
		STMT VARCHAR(20)
			CHECK(STMT IN ('INS','DEL','UPD')),
		TRNAME VARCHAR(50),
		CC VARCHAR(MAX),
	)
		GO
		CREATE TRIGGER TR_TEACHER_INS ON TEACHER AFTER INSERT
			AS 
			BEGIN
				DECLARE @TEACHER CHAR(10),@TEACHER_NAME VARCHAR(100),@GENDER CHAR(1),@PULPIT CHAR(10);
				DECLARE @INSERT VARCHAR(301);
				PRINT 'INSERT:'
				SET @TEACHER = (SELECT [TEACHER] FROM inserted)
				SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM inserted)
				SET @GENDER = (SELECT GENDER FROM inserted)
				SET @PULPIT = (SELECT PULPIT FROM inserted)
				SET @INSERT = @TEACHER+', '+@TEACHER_NAME+', '+@GENDER+', '+@PULPIT;
				INSERT INTO TR_AUDIT(STMT,TRNAME,CC) 
					VALUES	('INS','TR_TEACHER_INS',@INSERT);
				RETURN;
			END

		INSERT INTO TEACHER(TEACHER,TEACHER_NAME,GENDER,PULPIT)
			VALUES ('IVNV','IVANOV IVAN IVANOVICH','�','��');

		SELECT * FROM TR_AUDIT
	--#2
	GO
		CREATE TRIGGER TR_TEACHER_DEL ON TEACHER AFTER DELETE
			AS 
			BEGIN
				DECLARE @TEACHER CHAR(10),@TEACHER_NAME VARCHAR(100),@GENDER CHAR(1),@PULPIT CHAR(10);
				DECLARE @DELETE VARCHAR(301);
				PRINT 'DELETE:'
				SET @TEACHER = (SELECT [TEACHER] FROM deleted)
				SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM deleted)
				SET @GENDER = (SELECT GENDER FROM deleted)
				SET @PULPIT = (SELECT PULPIT FROM deleted)
				SET @DELETE = @TEACHER+', '+@TEACHER_NAME+', '+@GENDER+', '+@PULPIT;
				INSERT INTO TR_AUDIT(STMT,TRNAME,CC) 
					VALUES	('DEL','TR_TEACHER_DEL',@DELETE);
				RETURN;
			END

		DELETE FROM TEACHER WHERE TEACHER.TEACHER LIKE 'IVNV'
		SELECT * FROM TR_AUDIT
	--#3
		GO
			CREATE TRIGGER TR_TEACHER_UPD ON TEACHER AFTER UPDATE
			AS 
			BEGIN
				DECLARE @TEACHER CHAR(10),@TEACHER_NAME VARCHAR(100),@GENDER CHAR(1),@PULPIT CHAR(10);
				DECLARE @UPDATE VARCHAR(MAX);
				PRINT 'UPDATE:'
				SET @TEACHER = (SELECT [TEACHER] FROM deleted)
				SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM deleted)
				SET @GENDER = (SELECT GENDER FROM deleted)
				SET @PULPIT = (SELECT PULPIT FROM deleted)
				SET @UPDATE = @TEACHER+', '+@TEACHER_NAME+', '+@GENDER+', '+@PULPIT;
				SET @TEACHER = (SELECT [TEACHER] FROM inserted)
				SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM inserted)
				SET @GENDER = (SELECT GENDER FROM inserted)
				SET @PULPIT = (SELECT PULPIT FROM inserted)
				SET @UPDATE = RTRIM(@TEACHER)+', '+RTRIM(@TEACHER_NAME)+', '+@GENDER+', '+@PULPIT +', '+ @UPDATE;
				INSERT INTO TR_AUDIT(STMT,TRNAME,CC) 
					VALUES	('UPD','TR_TEACHER_UPD',@UPDATE);
				RETURN;
			END
		UPDATE TEACHER SET TEACHER_NAME = 'MAKRUSH KIRILL GENADEVICH' WHERE TEACHER.TEACHER = 'IVNV';
		SELECT *FROM TR_AUDIT
	--#4
	GO
		CREATE TRIGGER TR_TEACHER ON TEACHER AFTER INSERT,UPDATE,DELETE
		AS
		BEGIN
				DECLARE @TEACHER CHAR(10),@TEACHER_NAME VARCHAR(100),@GENDER CHAR(1),@PULPIT CHAR(10);
				DECLARE @TEXT VARCHAR(MAX);
				DECLARE @INS INT = (SELECT COUNT(*) FROM inserted);
				DECLARE @DEL INT = (SELECT COUNT(*) FROM deleted);
				IF(@INS > 0 AND @DEL=0)
					BEGIN
						PRINT'INSERT';
						SET @TEACHER = (SELECT [TEACHER] FROM inserted)
						SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM inserted)
						SET @GENDER = (SELECT GENDER FROM inserted)
						SET @PULPIT = (SELECT PULPIT FROM inserted)
						SET @TEXT = @TEACHER+', '+@TEACHER_NAME+', '+@GENDER+', '+@PULPIT;
						INSERT INTO TR_AUDIT(STMT,TRNAME,CC) 
							VALUES	('INS','TR_TEACHER',@TEXT);
					END
				IF(@INS=0 AND @DEL>0)
					BEGIN
						PRINT'DELETE';
						SET @TEACHER = (SELECT [TEACHER] FROM deleted)
						SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM deleted)
						SET @GENDER = (SELECT GENDER FROM deleted)
						SET @PULPIT = (SELECT PULPIT FROM deleted)
						SET @TEXT = @TEACHER+', '+@TEACHER_NAME+', '+@GENDER+', '+@PULPIT;
						INSERT INTO TR_AUDIT(STMT,TRNAME,CC) 
							VALUES	('DEL','TR_TEACHER',@TEXT);
					END
				IF(@INS>0 AND @DEL>0)
					BEGIN
						PRINT 'UPDATE';
						SET @TEACHER = (SELECT [TEACHER] FROM deleted)
						SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM deleted)
						SET @GENDER = (SELECT GENDER FROM deleted)
						SET @PULPIT = (SELECT PULPIT FROM deleted)
						SET @TEXT = @TEACHER+', '+@TEACHER_NAME+', '+@GENDER+', '+@PULPIT;
						SET @TEACHER = (SELECT [TEACHER] FROM inserted)
						SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM inserted)
						SET @GENDER = (SELECT GENDER FROM inserted)
						SET @PULPIT = (SELECT PULPIT FROM inserted)
						SET @TEXT = RTRIM(@TEACHER)+', '+RTRIM(@TEACHER_NAME)+', '+@GENDER+', '+@PULPIT +', '+ @TEXT;
						INSERT INTO TR_AUDIT(STMT,TRNAME,CC) 
							VALUES	('UPD','TR_TEACHER',@TEXT);
					END
		RETURN
		END
		INSERT INTO TEACHER VALUES('IVNV','IVANOV IVAN IVANOVICH','�','��');
		SELECT * FROM TR_AUDIT
		UPDATE TEACHER SET TEACHER_NAME = 'MAKRUSH KIRILL GENADEVICH' WHERE TEACHER.TEACHER = 'IVNV';
		SELECT * FROM TR_AUDIT
		DELETE FROM TEACHER WHERE TEACHER.TEACHER LIKE 'IVNV'
		SELECT * FROM TR_AUDIT
	--#5
		ALTER TABLE PROGRESS ADD CONSTRAINT NOTE CHECK(NOTE>4 AND NOTE<11)
		--DDL trigger fires only after the events that fired them are executed successfully.
		GO
		CREATE TRIGGER TESTAFTER ON DATABASE FOR ALTER_TABLE
		AS
		BEGIN
			PRINT 'DDL TRIGGER UPDATE: ';
			UPDATE PROGRESS SET NOTE = 3 WHERE IDSTUDENT = 1001
		RETURN;
		END
		
		ALTER TABLE PROGRESS DROP CONSTRAINT NOTE

	--#6
	GO
		CREATE TRIGGER TR_TEACHER_DEL1 ON TEACHER AFTER DELETE
			AS
			BEGIN
				DECLARE @TEACHER CHAR(10),@TEACHER_NAME VARCHAR(100),@GENDER CHAR(1),@PULPIT CHAR(10);
				DECLARE @DELETE VARCHAR(301);
				PRINT 'DELETE:'
				SET @TEACHER = (SELECT [TEACHER] FROM deleted)
				SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM deleted)
				SET @GENDER = (SELECT GENDER FROM deleted)
				SET @PULPIT = (SELECT PULPIT FROM deleted)
				SET @DELETE = @TEACHER+', '+@TEACHER_NAME+', '+@GENDER+', '+@PULPIT;
				INSERT INTO TR_AUDIT(STMT,TRNAME,CC) 
					VALUES	('DEL','TR_TEACHER_DEL1',@DELETE);
			END

	GO
		CREATE TRIGGER TR_TEACHER_DEL2 ON TEACHER AFTER DELETE
			AS
			BEGIN
				DECLARE @TEACHER CHAR(10),@TEACHER_NAME VARCHAR(100),@GENDER CHAR(1),@PULPIT CHAR(10);
				DECLARE @DELETE VARCHAR(301);
				PRINT 'DELETE:'
				SET @TEACHER = (SELECT [TEACHER] FROM deleted)
				SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM deleted)
				SET @GENDER = (SELECT GENDER FROM deleted)
				SET @PULPIT = (SELECT PULPIT FROM deleted)
				SET @DELETE = @TEACHER+', '+@TEACHER_NAME+', '+@GENDER+', '+@PULPIT;
				INSERT INTO TR_AUDIT(STMT,TRNAME,CC) 
					VALUES	('DEL','TR_TEACHER_DEL2',@DELETE);
			END
	GO
		CREATE TRIGGER TR_TEACHER_DEL3 ON TEACHER AFTER DELETE
			AS
			BEGIN
				DECLARE @TEACHER CHAR(10),@TEACHER_NAME VARCHAR(100),@GENDER CHAR(1),@PULPIT CHAR(10);
				DECLARE @DELETE VARCHAR(301);
				PRINT 'DELETE:'
				SET @TEACHER = (SELECT [TEACHER] FROM deleted)
				SET @TEACHER_NAME = (SELECT [TEACHER_NAME] FROM deleted)
				SET @GENDER = (SELECT GENDER FROM deleted)
				SET @PULPIT = (SELECT PULPIT FROM deleted)
				SET @DELETE = @TEACHER+', '+@TEACHER_NAME+', '+@GENDER+', '+@PULPIT;
				INSERT INTO TR_AUDIT(STMT,TRNAME,CC) 
					VALUES	('DEL','TR_TEACHER_DEL3',@DELETE);
			END

			  select t.name, e.type_desc 
         from sys.triggers  t join  sys.trigger_events e  
                  on t.object_id = e.object_id  
                            where OBJECT_NAME(t.parent_id) = 'TEACHER' and 
	                                                                        e.type_desc = 'DELETE' ;  
				
				exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', 
	                        @order = 'FIRST', @stmttype = 'DELETE';

				exec  SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', 
	                        @order = 'LAST', @stmttype = 'DELETE';

	--#7
		GO
			CREATE TRIGGER TRIG ON TEACHER AFTER INSERT 
			AS
			BEGIN
			 DECLARE @NUMBER INT= (SELECT COUNT(*) FROM TEACHER)
			 IF(@NUMBER > 13)
			 BEGIN
				RAISERROR('MAX NUMBER OF TEACHERS LOWER THAN 13',10,1);
				ROLLBACK;
			 END
			RETURN
			END

		INSERT INTO TEACHER VALUES('DVRVNK','DVOROVENKO MAKSIM','�','����');
		SELECT * FROM TEACHER
	--#8
	GO
		CREATE TRIGGER TR_INSTEAD_OFF ON FACULTY INSTEAD OF DELETE
			AS
				RAISERROR(N'�������� ���������',10,1);
			RETURN
		
		DELETE FROM FACULTY WHERE FACULTY='����'
		SELECT * FROM FACULTY

		--DROP TRIGGER TR_TEACHER_INS
		--DROP TRIGGER TR_TEACHER_DEL
		--DROP TRIGGER TR_TEACHER_UPD
		--DROP TRIGGER TR_TEACHER
		--DROP TABLE TR_AUDIT
		--DROP TRIGGER TR_TEACHER_DEL2
		--DROP TRIGGER TR_TEACHER_DEL1
		--DROP TRIGGER TR_TEACHER_DEL3
	--#9
		GO
			CREATE TRIGGER DDL_UNIVER ON DATABASE 
									FOR DDL_DATABASE_LEVEL_EVENTS AS
			declare @t varchar(50) =  EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)');
		declare @t1 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)');
		declare @t2 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)'); 
		if @t1 = '������' 
		begin
				 print '��� �������: '+@t;
				 print '��� �������: '+@t1;
				 print '��� �������: '+@t2;
				 raiserror( N'�������� � �������� ������ ���������', 16, 1);  
				 rollback;    
		 end;
		
		ALTER TABLE STUDENT DROP COLUMN FOTO

