--#1
GO
	CREATE VIEW [��������](ID,NAME,CAUSE,DATE)
		AS SELECT Id,��������_������������,�������_��������,����_��������
		FROM ���������_������������
GO
SELECT * FROM ��������

--#2
GO
	CREATE VIEW [���������� ������������ � ��������������]
		AS SELECT ������������.�������������_���������[�������������],
				  COUNT(*)[���������� ��������� ������������]
		FROM ������������
		GROUP BY ������������.�������������_���������
GO
SELECT *FROM [���������� ������������ � ��������������]

--#3
GO
	CREATE VIEW [���������](��������,����_��������)
	AS SELECT ��������_������������,����_��������
	FROM ���������_������������
	WHERE �������_�������� NOT LIKE '�����%'
GO
SELECT *FROM ���������
--#4
GO
	CREATE VIEW [��������](ID,SURNAME,NAME,DATE)
	AS SELECT Id_��������,�������_��������������,���_�������������,����_������_��_������
	FROM �������������
	WHERE ����_������_��_������>'2002-03-21' WITH CHECK OPTION
GO
DROP VIEW [��������]
SELECT *FROM ��������
INSERT INTO [��������](ID,SURNAME,NAME,DATE)
VALUES(9,'IVANOV','IVAN','2000-02-22')

--#5
GO
	CREATE VIEW [��������������](NAME,TYPE,DATE,NUMBER)
	AS SELECT TOP 150 ��������_������������,���_������������,����_�����������,����������
	FROM ������������
	ORDER BY ��������_������������ DESC
GO
SELECT * FROM ��������������

--#6
GO
	CREATE VIEW [���������� ������������ � ��������������_#6] WITH SCHEMABINDING
		AS SELECT ������������.�������������_���������[�������������],
				  COUNT(*)[���������� ��������� ������������]
		FROM DBO.������������
		GROUP BY ������������.�������������_���������
GO
SELECT *FROM [���������� ������������ � ��������������]