--lab8
USE UNIVER
	--#1
	GO
		CREATE VIEW [�������������]
			AS SELECT	
				TEACHER[���],
				TEACHER_NAME[���_�������������],
				GENDER[���],
				PULPIT[���_�������]
			FROM TEACHER;	
	GO
	SELECT * FROM �������������

	--#2
	GO
		CREATE VIEW [����������_������]
			AS SELECT
				FACULTY.FACULTY[���������],
				COUNT(*)[����������]
			FROM FACULTY INNER JOIN PULPIT
			ON PULPIT.FACULTY=FACULTY.FACULTY
			GROUP BY FACULTY.FACULTY
	GO
	SELECT *FROM ����������_������
	--#3
	GO
		CREATE VIEW ���������(���,������������_���������)
		AS SELECT
			AUDITORIUM,
			AUDITORIUM_NAME
			FROM AUDITORIUM
				WHERE AUDITORIUM_TYPE LIKE '��%'
	GO
	GO
		ALTER VIEW ���������(���,������������_���������)
		AS SELECT
			AUDITORIUM,
			AUDITORIUM_NAME
			FROM AUDITORIUM
				WHERE AUDITORIUM_TYPE LIKE '��%'
	GO
	
	SELECT * FROM ���������

	INSERT ��������� values('238-5','232-5')
	INSERT ��������� values('232-7','232-7')

	DELETE FROM AUDITORIUM WHERE AUDITORIUM ='232-7'

	--#4
	GO
		CREATE VIEW ����������_���������(���,������������_���������)
			AS SELECT
				AUDITORIUM,
				AUDITORIUM_NAME
				FROM AUDITORIUM
					WHERE AUDITORIUM_TYPE LIKE '��%' WITH CHECK OPTION
	GO
	SELECT * FROM ����������_���������;
	INSERT INTO ����������_���������(���,������������_���������)
		VALUES('WERWER','WERWER');
	--#5
	GO
		CREATE VIEW ����������(���, ������������_����������, ���_�������)
			AS SELECT
			TOP 150 SUBJECT_NAME,SUBJECT.SUBJECT,PULPIT
			FROM SUBJECT
			ORDER BY SUBJECT_NAME
	GO
	SELECT *FROM ����������
	--#6
	DROP VIEW ����������_������_#6
	GO
		CREATE VIEW [����������_������_#6] WITH SCHEMABINDING
			AS SELECT
				f.FACULTY[���������],
				COUNT(*)[����������]
			FROM dbo.FACULTY f INNER JOIN dbo.PULPIT p
			ON p.FACULTY=f.FACULTY
			GROUP BY f.FACULTY
	GO
	SELECT *FROM ����������_������_#6
	--SCHEMABINDING
	ALTER TABLE FACULTY DROP COLUMN FACULTY
	SELECT *FROM ����������_������_#6
	 