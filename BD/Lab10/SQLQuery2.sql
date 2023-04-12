--lab10
--#1����������
use UNIVER 
exec sp_helpindex'AUDITORIUM_TYPE'
exec sp_helpindex'AUDITORIUM'
exec sp_helpindex'FACULTY'
exec sp_helpindex'GROUPS'
exec sp_helpindex'PROFESSION'
exec sp_helpindex'PROGRESS'
exec sp_helpindex'PULPIT'
exec sp_helpindex'STUDENT'
exec sp_helpindex'SUBJECT'
exec sp_helpindex'TEACHER'
exec sp_helpindex'TIMETABLE'



CREATE TABLE #TEMP
	(
		COLUMN1 INT ,
		COLUMN2 REAL,
		COLUMN3 NVARCHAR(MAX)
	)
DECLARE @ITERATION INT=0;
WHILE(@ITERATION<=1000)
BEGIN
	INSERT #TEMP(COLUMN1,COLUMN2,COLUMN3)
	VALUES(FLOOR(RAND()*10),RAND(),REPLICATE(1,@ITERATION))
	SET @ITERATION+=1;
END
SELECT *FROM #TEMP

SELECT *FROM #TEMP WHERE COLUMN1>8 ORDER BY COLUMN2 DESC
CHECKPOINT
DBCC DROPCLEANBUFFERS
CREATE CLUSTERED INDEX #TEMP_CL ON #TEMP(COLUMN2 DESC)
SELECT *FROM #TEMP WHERE COLUMN1>8 ORDER BY COLUMN2 DESC

EXEC sp_helpindex '#TEMP'
DROP TABLE #TEMP
--#2������������ ������������ ���������
CREATE TABLE #TEMP2
	(
		COLUMN1 REAL,
		COLUMN2 INT
	)
DECLARE @ITER INT = 0;
WHILE(@ITER<10000)
	BEGIN
		INSERT #TEMP2 (COLUMN1,COLUMN2)
		VALUES(RAND()*5.9,FLOOR(RAND()*100));
		SET @ITER +=1
	END
SELECT *FROM #TEMP2

SELECT * FROM #TEMP2 WHERE COLUMN1>0.4 AND COLUMN2=70
CHECKPOINT
DBCC DROPCLEANBUFFERS
CREATE INDEX #TEMP2_NONCLU ON #TEMP2(COLUMN1,COLUMN2);
--DROP INDEX #TEMP2.#TEMP2_NONCLU
SELECT * FROM #TEMP2 WHERE COLUMN1>0.4 AND COLUMN2=70

--NW
SELECT * FROM #TEMP2 WHERE COLUMN1>1 AND COLUMN2>70
SELECT * FROM #TEMP2 ORDER BY COLUMN1,COLUMN2
--W
SELECT * FROM #TEMP2 WHERE COLUMN1=1 AND COLUMN2>60
--#3
CREATE TABLE #TEMP3
	(
		COLUMN1 REAL,
		COLUMN2 INT
	)
DECLARE @ITERA INT = 0;
WHILE(@ITERA<10000)
	BEGIN
		INSERT #TEMP3 (COLUMN1,COLUMN2)
		VALUES(RAND()*5.9,FLOOR(RAND()*100));
		SET @ITERA +=1
	END
SELECT *FROM #TEMP3
SELECT COLUMN2 FROM #TEMP3 WHERE COLUMN1>1
CREATE INDEX #TEMP3_TKEY_X ON #TEMP3(COLUMN1) INCLUDE (COLUMN2)
SELECT COLUMN2 FROM #TEMP3 WHERE COLUMN1>1

--#4
CREATE TABLE #TEMP4
	(
		COLUMN1 REAL,
		COLUMN2 INT
	)
DECLARE @ITERAT INT = 0;
WHILE(@ITERAT<10000)
	BEGIN
		INSERT #TEMP4 (COLUMN1,COLUMN2)
		VALUES(RAND()*5.9,FLOOR(RAND()*100));
		SET @ITERAT +=1
	END
SELECT *FROM #TEMP4

SELECT COLUMN2 FROM #TEMP4 WHERE COLUMN2 BETWEEN 10 AND 30
SELECT COLUMN2 FROM #TEMP4 WHERE COLUMN2 >40 AND COLUMN2<70
SELECT COLUMN2 FROM #TEMP4 WHERE COLUMN2 = 90

CREATE INDEX #TEMP4_WHERE ON #TEMP4(COLUMN2) WHERE (COLUMN2>=40 AND COLUMN2<80)

--#5
CREATE TABLE #TEMP5
	(
		COLUMN1 REAL,
		COLUMN2 INT
	)
DECLARE @ITERATI INT = 0;
WHILE(@ITERATI<10000)
	BEGIN
		INSERT #TEMP5 (COLUMN1,COLUMN2)
		VALUES(RAND()*5.9,FLOOR(RAND()*100));
		SET @ITERATI +=1
	END
SELECT *FROM #TEMP5

CREATE INDEX #TEMP5_TKEY ON #TEMP5(COLUMN2)
--������� ������������
SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'tempdb'), 
OBJECT_ID(N'#TEMP5'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;
--
INSERT TOP(60000)#TEMP5 (COLUMN1,COLUMN2) SELECT COLUMN1,COLUMN2 FROM #TEMP5
--�������������
ALTER INDEX #TEMP5_TKEY ON #TEMP5 REORGANIZE
--�����������
ALTER INDEX #TEMP5_TKEY ON #TEMP5 REBUILD WITH(ONLINE=OFF);

--#6
DROP INDEX #TEMP5.#TEMP5_TKEY
CREATE INDEX #TEMP5_TKEY ON #TEMP5(COLUMN2)
								WITH (FILLFACTOR=65)
INSERT TOP(60000)#TEMP5 (COLUMN1,COLUMN2) SELECT COLUMN1,COLUMN2 FROM #TEMP5
SELECT name [������], avg_fragmentation_in_percent [������������ (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'tempdb'), 
OBJECT_ID(N'#TEMP5'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;
