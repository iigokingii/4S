--lab8
USE UNIVER
	--#1
	GO
		CREATE VIEW [ПРЕПОДАВАТЕЛЬ]
			AS SELECT	
				TEACHER[КОД],
				TEACHER_NAME[ИМЯ_ПРЕПОДАВАТЕЛЯ],
				GENDER[ПОЛ],
				PULPIT[КОД_КАФЕДРЫ]
			FROM TEACHER;	
	GO
	SELECT * FROM ПРЕПОДАВАТЕЛЬ

	--#2
	GO
		CREATE VIEW [Количество_кафедр]
			AS SELECT
				FACULTY.FACULTY[ФАКУЛЬТЕТ],
				COUNT(*)[КОЛИЧЕСТВО]
			FROM FACULTY INNER JOIN PULPIT
			ON PULPIT.FACULTY=FACULTY.FACULTY
			GROUP BY FACULTY.FACULTY
	GO
	SELECT *FROM Количество_кафедр
	--#3
	GO
		CREATE VIEW Аудитории(КОД,НАИМЕНОВАНИЕ_АУДИТОРИИ)
		AS SELECT
			AUDITORIUM,
			AUDITORIUM_NAME
			FROM AUDITORIUM
				WHERE AUDITORIUM_TYPE LIKE 'ЛК%'
	GO
	GO
		ALTER VIEW Аудитории(КОД,НАИМЕНОВАНИЕ_АУДИТОРИИ)
		AS SELECT
			AUDITORIUM,
			AUDITORIUM_NAME
			FROM AUDITORIUM
				WHERE AUDITORIUM_TYPE LIKE 'ЛК%'
	GO
	
	SELECT * FROM Аудитории

	INSERT Аудитории values('238-5','232-5')
	INSERT Аудитории values('232-7','232-7')

	DELETE FROM AUDITORIUM WHERE AUDITORIUM ='232-7'

	--#4
	GO
		CREATE VIEW Лекционные_аудитории(КОД,НАИМЕНОВАНИЕ_АУДИТОРИИ)
			AS SELECT
				AUDITORIUM,
				AUDITORIUM_NAME
				FROM AUDITORIUM
					WHERE AUDITORIUM_TYPE LIKE 'ЛК%' WITH CHECK OPTION
	GO
	SELECT * FROM Лекционные_аудитории;
	INSERT INTO Лекционные_аудитории(КОД,НАИМЕНОВАНИЕ_АУДИТОРИИ)
		VALUES('WERWER','WERWER');
	--#5
	GO
		CREATE VIEW Дисциплины(код, наименование_дисциплины, код_кафедры)
			AS SELECT
			TOP 150 SUBJECT_NAME,SUBJECT.SUBJECT,PULPIT
			FROM SUBJECT
			ORDER BY SUBJECT_NAME
	GO
	SELECT *FROM Дисциплины
	--#6
	DROP VIEW КОЛИЧЕСТВО_КАФЕДР_#6
	GO
		CREATE VIEW [КОЛИЧЕСТВО_КАФЕДР_#6] WITH SCHEMABINDING
			AS SELECT
				f.FACULTY[ФАКУЛЬТЕТ],
				COUNT(*)[КОЛИЧЕСТВО]
			FROM dbo.FACULTY f INNER JOIN dbo.PULPIT p
			ON p.FACULTY=f.FACULTY
			GROUP BY f.FACULTY
	GO
	SELECT *FROM КОЛИЧЕСТВО_КАФЕДР_#6
	--SCHEMABINDING
	ALTER TABLE FACULTY DROP COLUMN FACULTY
	SELECT *FROM КОЛИЧЕСТВО_КАФЕДР_#6
	 