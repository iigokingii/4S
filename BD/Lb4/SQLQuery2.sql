USE  S_MyBase
	--#1--lab4
		SELECT ������������.��������_������������,�������������.�������_��������������,�������������.���������,�������������.����_������_��_������
			FROM ������������
			INNER JOIN �������������
				ON �������������.Id_��������=������������.Id_��������������_��������
	--#2
		SELECT ������������.��������_������������,�������������.�������_��������������,�������������.���������,�������������.����_������_��_������
			FROM ������������
			INNER JOIN �������������
				ON �������������.Id_��������=������������.Id_��������������_��������
					AND
					������������.��������_������������ LIKE '%sams%'
	--#3
		SELECT ������������.����������,������������.���_������������,������������.��������_������������,���������_������������.�������_��������,�������������.����_������_��_������,�������������.���_�������������,
			CASE 
				WHEN (������������.���������� BETWEEN 2 AND 2) THEN '���'
				WHEN (������������.���������� BETWEEN 3 AND 3) THEN	'���'
				WHEN (������������.���������� BETWEEN 4 AND 10) THEN '������ 4, �� ������ 10'
			ELSE '������ ����������'
			END[����������(�����)]
		FROM ������������ 
		INNER JOIN ���������_������������
			ON ������������.Id_����������_������������=���������_������������.Id
		INNER JOIN �������������
			ON ������������.Id_��������������_�������� = �������������.Id_��������
				ORDER BY ������������.����������
	--#4
		SELECT isnull(���������_������������.��������_������������,'***')[�������� ������������], isnull(������������.���_������������,'***')[��� ������������]
			FROM ���������_������������
				LEFT OUTER JOIN ������������
					ON ������������.Id_����������_������������=���������_������������.Id
	--#5
		--1,2
		SELECT isnull(���������_������������.��������_������������,'***')[��������_������������],������������.����_�����������,���������_������������.����_��������
			FROM ���������_������������ 
			FULL OUTER JOIN ������������
				ON ������������.Id_����������_������������ = ���������_������������.Id

		SELECT isnull(���������_������������.��������_������������,'***')[��������_������������],������������.����_�����������,���������_������������.����_��������
			FROM  ������������
			FULL OUTER JOIN ���������_������������
				ON  ���������_������������.Id=������������.Id_����������_������������ 
		--3
		SELECT ������������.��������_������������,������������.���_������������,���������_������������.*
			FROM ������������
			LEFT JOIN ���������_������������
				ON ���������_������������.Id=������������.Id_��������������_��������
				WHERE ������������.Id_��������������_�������� IS NOT NULL
		--4
		SELECT ���������_������������.Id,���������_������������.����_��������,isnull(���������_������������.��������_������������,'&&&')[��������_������������],�������_��������
			FROM ������������
			RIGHT JOIN ���������_������������
				ON ���������_������������.Id=������������.Id_��������������_��������
				WHERE ������������.Id_��������������_�������� IS NULL
		--5
		Select ������������.��������_������������,������������.����_�����������,������������.�������������_���������,�������������.���������,�������������.���_�������������,�������������.��������_��������������,�������������.�������_��������������
			FROM ������������
			FULL OUTER JOIN �������������
				ON ������������.Id_��������������_��������=�������������.Id_��������
				
		--6 ����.1
		SELECT ������������.��������_������������,�������������.�������_��������������,�������������.���������,�������������.����_������_��_������
			FROM ������������
			CROSS JOIN �������������
			WHERE �������������.Id_��������=������������.Id_��������������_��������





