--lab10
--#1
use S_MyBase 
exec sp_helpindex'Оборудование'
exec sp_helpindex'Ответственный'
exec sp_helpindex'Списанное_оборудование'

--CREATE CLUSTERED INDEX Оборудование_cl ON Оборудование(Количество desc) 
SELECT *FROM Оборудование WHERE Название_Оборудования LIKE 'sams'

--#2
CREATE INDEX #Оборудование_NONCLU ON Оборудование(Количество,Подразделение_Установки)
DROP INDEX Оборудование.#Оборудование_NONCLU
SELECT *FROM Оборудование WHERE Подразделение_Установки like '%%' and Количество =2
--#3
CREATE INDEX #Оборудование_NUMB_N ON Оборудование(Количество) INCLUDE (Название_Оборудования)
SELECT Название_Оборудования FROM Оборудование WHERE Количество=2


--#4
CREATE INDEX #Оборудование_WHERE ON Оборудование(Количество) WHERE (Количество>3)

SELECT КОЛИЧЕСТВО FROM Оборудование WHERE Количество>3
--#5
CREATE TABLE #TEMP
	(
	Название_Оборудования NVARCHAR(30),
	Тип_Оборудования NVARCHAR(30),
	Дата_Поступления DATE,
	Количество SMALLINT,
	Подразделение_Установки NVARCHAR(30),
	Id_Ответственного_Рабочего INT,
	Id_Списанного_Оборудования INT
	)
	INSERT INTO #TEMP(Название_Оборудования,Тип_Оборудования,Дата_Поступления,Количество,Подразделение_Установки,Id_Ответственного_Рабочего,Id_Списанного_Оборудования)
	VALUES('Huawei','Принтер','2004-02-02',2,'Подраздел 3',1,5)
CREATE INDEX #TEMP_Количество ON #TEMP(Количество);
DROP INDEX Оборудование.#Оборудование_Количество
SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'tempdb'), 
OBJECT_ID(N'#TEMP'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;


DECLARE @ITERATION INT = 10;
WHILE(@ITERATION>0)
BEGIN
	INSERT TOP(10000) #TEMP(Название_Оборудования,Тип_Оборудования,Дата_Поступления,Количество,Подразделение_Установки,Id_Ответственного_Рабочего,Id_Списанного_Оборудования) SELECT * FROM #TEMP
	SET @ITERATION-=1;
END
	INSERT TOP(9000000) #TEMP(Название_Оборудования,Тип_Оборудования,Дата_Поступления,Количество,Подразделение_Установки,Id_Ответственного_Рабочего,Id_Списанного_Оборудования) SELECT * FROM #TEMP

ALTER INDEX #TEMP_Количество ON #TEMP REORGANIZE
ALTER INDEX #TEMP_Количество ON #TEMP REBUILD WITH (ONLINE=OFF)
--#6
DROP INDEX #TEMP.#TEMP_Количество
CREATE INDEX #TEMP_Количество ON #TEMP(Количество)
									with (FILLFACTOR=65)
DECLARE @ITERATIO INT = 10;
WHILE(@ITERATIO>0)
BEGIN
	INSERT TOP(10000) #TEMP(Название_Оборудования,Тип_Оборудования,Дата_Поступления,Количество,Подразделение_Установки,Id_Ответственного_Рабочего,Id_Списанного_Оборудования) SELECT * FROM #TEMP
	SET @ITERATIO-=1;
END
	INSERT TOP(9000000) #TEMP(Название_Оборудования,Тип_Оборудования,Дата_Поступления,Количество,Подразделение_Установки,Id_Ответственного_Рабочего,Id_Списанного_Оборудования) SELECT * FROM #TEMP

SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
FROM sys.dm_db_index_physical_stats(DB_ID(N'tempdb'), 
OBJECT_ID(N'#TEMP'), NULL, NULL, NULL) ss  JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  WHERE name is not null;

