--#1--lab6
	SELECT ���_������������,
	MAX(����������)[MAX_NUMBER],
	MIN(����������)[MIN_NUMBER],
	AVG(����������)[AVG_NUMBER],
	SUM(����������)[SUM_NUMBER]
	FROM ������������
	GROUP BY ���_������������
--#2
	SELECT ������������.��������_������������,
	COUNT(*)[NUMBER_OF_ORDERS],
	MAX(����������)[MAX_NUMBER],
	MIN(����������)[MIN_NUMBER],
	AVG(����������)[AVG_NUMBER],
	SUM(����������)[SUM_NUMBER]
	FROM ������������
	INNER JOIN ���������_������������
		ON ���������_������������.Id=������������.Id_����������_������������
	group by ������������.��������_������������ with ROLLUP
--#3
	SELECT *
	FROM(SELECT 
			CASE
				WHEN ���������� = 2 THEN 'QUANTITY EQUALS 2'
				WHEN ���������� = 3 THEN 'QUANTITY EQUALS 3'
				WHEN ���������� BETWEEN 4 AND 12 THEN 'QUANTITY BETWEEN 4 AND 12'
				ELSE 'QUANTITY OVER 12'
			END [QUANTITY LIMITS],COUNT(*)AS NUMBER
		FROM ������������ GROUP BY 
			CASE
				WHEN ���������� = 2 THEN 'QUANTITY EQUALS 2'
				WHEN ���������� = 3 THEN 'QUANTITY EQUALS 3'
				WHEN ���������� BETWEEN 4 AND 12 THEN 'QUANTITY BETWEEN 4 AND 12'
				ELSE 'QUANTITY OVER 12'
			END)AS SEL
		ORDER BY CASE[QUANTITY LIMITS]
				WHEN 'QUANTITY EQUALS 2' THEN 2
				WHEN 'QUANTITY EQUALS 3' THEN 3
				WHEN 'QUANTITY BETWEEN 4 AND 12' THEN 7
				ELSE 100
			END 
--#4
	SELECT ������������.����������,������������.���_������������,������������.�������������_���������,
	ROUND(AVG(CAST(������������.���������� AS float(4))),2) AS[ROUNDED_AVG]
	FROM ������������
	GROUP BY ������������.����������,������������.���_������������,������������.�������������_���������
--#5
	SELECT ������������.����������,������������.���_������������,������������.�������������_���������,
	ROUND(AVG(CAST(������������.���������� AS float(4))),2) AS[ROUNDED_AVG]
	FROM ������������
	WHERE �������������_��������� not like '��������� 3'
	GROUP BY ������������.����������,������������.���_������������,������������.�������������_���������
--#6
	SELECT ������������.��������_������������,
	COUNT(*)[NUMBER_OF_ORDERS],
	MAX(����������)[MAX_NUMBER],
	MIN(����������)[MIN_NUMBER],
	AVG(����������)[AVG_NUMBER],
	SUM(����������)[SUM_NUMBER]
	FROM ������������
	INNER JOIN ���������_������������
		ON ���������_������������.Id=������������.Id_����������_������������
		WHERE Id_��������������_��������=3
	group by ������������.��������_������������ with CUBE
--#7
SELECT ������������.����������,������������.��������_������������,COUNT(*)AS [NUMBER]
FROM ������������
GROUP BY ������������.����������,������������.��������_������������
	HAVING ���������� BETWEEN 1 AND 21
