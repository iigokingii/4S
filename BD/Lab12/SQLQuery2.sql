--Lab12�2B
	--#4
		--B--
			BEGIN TRANSACTION
			SELECT @@SPID
			INSERT ���������_������������ VALUES(7,'ASD SXXC XCX','������','1994-02-10');
			UPDATE ���������_������������ SET ��������_������������ = 'Xiaomi'
														WHERE id =7
		--T1--
		--T2--
		ROLLBACK;
	--#5
		--B--
		BEGIN TRAN
		--T1--
		UPDATE ���������_������������ SET ��������_������������ = 'Huawei'
														WHERE ��������_������������ LIKE '%Xiaomi%'
		COMMIT;
		--T2--
	--#6
		DELETE ���������_������������ WHERE id =8
		--B--
		BEGIN TRAN
		--T1--
		INSERT INTO ���������_������������ VALUES(8,'TEMPS','TEMP DESCRIPTION','2002-10-2');
		COMMIT;
		--T2--
	--#7
		--B--
		BEGIN TRAN
		DELETE ���������_������������ WHERE Id=8;
		INSERT INTO ���������_������������ VALUES(8,'TEMPS','TEMP DESCRIPTION','2002-10-2');
		UPDATE ���������_������������ SET �������_�������� = '�������' WHERE Id=8;
		SELECT * FROM ���������_������������ WHERE Id=8;
		--T1--
		COMMIT;
		SELECT * FROM ���������_������������ WHERE Id=8;
		--T2--
