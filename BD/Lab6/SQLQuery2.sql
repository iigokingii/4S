--#1--lab6
	SELECT Тип_Оборудования,
	MAX(Количество)[MAX_NUMBER],
	MIN(КОЛИЧЕСТВО)[MIN_NUMBER],
	AVG(Количество)[AVG_NUMBER],
	SUM(Количество)[SUM_NUMBER]
	FROM Оборудование
	GROUP BY Тип_Оборудования
--#2
	SELECT Оборудование.Название_Оборудования,
	COUNT(*)[NUMBER_OF_ORDERS],
	MAX(Количество)[MAX_NUMBER],
	MIN(КОЛИЧЕСТВО)[MIN_NUMBER],
	AVG(Количество)[AVG_NUMBER],
	SUM(Количество)[SUM_NUMBER]
	FROM Оборудование
	INNER JOIN Списанное_оборудование
		ON Списанное_оборудование.Id=Оборудование.Id_Списанного_Оборудования
	group by Оборудование.Название_Оборудования with ROLLUP
--#3
	SELECT *
	FROM(SELECT 
			CASE
				WHEN Количество = 2 THEN 'QUANTITY EQUALS 2'
				WHEN Количество = 3 THEN 'QUANTITY EQUALS 3'
				WHEN Количество BETWEEN 4 AND 12 THEN 'QUANTITY BETWEEN 4 AND 12'
				ELSE 'QUANTITY OVER 12'
			END [QUANTITY LIMITS],COUNT(*)AS NUMBER
		FROM Оборудование GROUP BY 
			CASE
				WHEN Количество = 2 THEN 'QUANTITY EQUALS 2'
				WHEN Количество = 3 THEN 'QUANTITY EQUALS 3'
				WHEN Количество BETWEEN 4 AND 12 THEN 'QUANTITY BETWEEN 4 AND 12'
				ELSE 'QUANTITY OVER 12'
			END)AS SEL
		ORDER BY CASE[QUANTITY LIMITS]
				WHEN 'QUANTITY EQUALS 2' THEN 2
				WHEN 'QUANTITY EQUALS 3' THEN 3
				WHEN 'QUANTITY BETWEEN 4 AND 12' THEN 7
				ELSE 100
			END 
--#4
	SELECT Оборудование.Количество,Оборудование.Тип_Оборудования,Оборудование.Подразделение_Установки,
	ROUND(AVG(CAST(Оборудование.Количество AS float(4))),2) AS[ROUNDED_AVG]
	FROM Оборудование
	GROUP BY Оборудование.Количество,Оборудование.Тип_Оборудования,Оборудование.Подразделение_Установки
--#5
	SELECT Оборудование.Количество,Оборудование.Тип_Оборудования,Оборудование.Подразделение_Установки,
	ROUND(AVG(CAST(Оборудование.Количество AS float(4))),2) AS[ROUNDED_AVG]
	FROM Оборудование
	WHERE Подразделение_Установки not like 'Подраздел 3'
	GROUP BY Оборудование.Количество,Оборудование.Тип_Оборудования,Оборудование.Подразделение_Установки
--#6
	SELECT Оборудование.Название_Оборудования,
	COUNT(*)[NUMBER_OF_ORDERS],
	MAX(Количество)[MAX_NUMBER],
	MIN(КОЛИЧЕСТВО)[MIN_NUMBER],
	AVG(Количество)[AVG_NUMBER],
	SUM(Количество)[SUM_NUMBER]
	FROM Оборудование
	INNER JOIN Списанное_оборудование
		ON Списанное_оборудование.Id=Оборудование.Id_Списанного_Оборудования
		WHERE Id_Ответственного_Рабочего=3
	group by Оборудование.Название_Оборудования with CUBE
--#7
SELECT Оборудование.Количество,Оборудование.Название_Оборудования,COUNT(*)AS [NUMBER]
FROM Оборудование
GROUP BY Оборудование.Количество,Оборудование.Название_Оборудования
	HAVING Количество BETWEEN 1 AND 21
