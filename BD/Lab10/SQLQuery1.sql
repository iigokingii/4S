--lab10
--#1
use S_MyBase 
exec sp_helpindex'������������'
exec sp_helpindex'�������������'
exec sp_helpindex'���������_������������'

--CREATE CLUSTERED INDEX ������������_cl ON ������������(���������� desc) 
SELECT *FROM ������������ WHERE ��������_������������ LIKE 'sams'

--#2
CREATE INDEX #������������_NONCLU ON ������������(����������,�������������_���������)
DROP INDEX ������������.#������������_NONCLU
SELECT *FROM ������������ WHERE �������������_��������� like '%%' and ���������� =2
--#3
CREATE INDEX #������������_NUMB_N ON ������������(����������) INCLUDE (��������_������������)
SELECT ��������_������������ FROM ������������ WHERE ����������=2


--#4
CREATE INDEX #������������_WHERE ON ������������(����������) WHERE (����������>3)

SELECT ���������� FROM ������������ WHERE ����������>3
--#5
CREATE TABLE #TEMP
	(
	��������_������������ NVARCHAR(30),
	���_������������ NVARCHAR(30),
	����_����������� DATE,
	���������� SMALLINT,
	�������������_��������� NVARCHAR(30),
	Id_��������������_�������� INT,
	Id_����������_������������ INT
	)
	INSERT INTO #TEMP(��������_������������,���_������������,����_�����������,����������,�������������_���������,Id_��������������_��������,Id_����������_������������)
	VALUES('Huawei','�������','2004-02-02',2,'��������� 3',1,5)
CREATE INDEX #TEMP_���������� ON #TEMP(����������);
DROP INDEX ������������.#������������_����������
SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'tempdb'), 
OBJECT_ID(N'#TEMP'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;


DECLARE @ITERATION INT = 10;
WHILE(@ITERATION>0)
BEGIN
	INSERT TOP(10000) #TEMP(��������_������������,���_������������,����_�����������,����������,�������������_���������,Id_��������������_��������,Id_����������_������������) SELECT * FROM #TEMP
	SET @ITERATION-=1;
END
	INSERT TOP(9000000) #TEMP(��������_������������,���_������������,����_�����������,����������,�������������_���������,Id_��������������_��������,Id_����������_������������) SELECT * FROM #TEMP

ALTER INDEX #TEMP_���������� ON #TEMP REORGANIZE
ALTER INDEX #TEMP_���������� ON #TEMP REBUILD WITH (ONLINE=OFF)
--#6
DROP INDEX #TEMP.#TEMP_����������
CREATE INDEX #TEMP_���������� ON #TEMP(����������)
									with (FILLFACTOR=65)
DECLARE @ITERATIO INT = 10;
WHILE(@ITERATIO>0)
BEGIN
	INSERT TOP(10000) #TEMP(��������_������������,���_������������,����_�����������,����������,�������������_���������,Id_��������������_��������,Id_����������_������������) SELECT * FROM #TEMP
	SET @ITERATIO-=1;
END
	INSERT TOP(9000000) #TEMP(��������_������������,���_������������,����_�����������,����������,�������������_���������,Id_��������������_��������,Id_����������_������������) SELECT * FROM #TEMP

SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'tempdb'), 
OBJECT_ID(N'#TEMP'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;

