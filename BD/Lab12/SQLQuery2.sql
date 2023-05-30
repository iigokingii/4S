--Lab12№2B
	--#4
		--B--
			BEGIN TRANSACTION
			SELECT @@SPID
			INSERT Списанное_оборудование VALUES(7,'ASD SXXC XCX','Сломан','1994-02-10');
			UPDATE Списанное_оборудование SET Название_Оборудования = 'Xiaomi'
														WHERE id =7
		--T1--
		--T2--
		ROLLBACK;
	--#5
		--B--
		BEGIN TRAN
		--T1--
		UPDATE Списанное_оборудование SET Название_Оборудования = 'Huawei'
														WHERE Название_Оборудования LIKE '%Xiaomi%'
		COMMIT;
		--T2--
	--#6
		DELETE Списанное_оборудование WHERE id =8
		--B--
		BEGIN TRAN
		--T1--
		INSERT INTO Списанное_оборудование VALUES(8,'TEMPS','TEMP DESCRIPTION','2002-10-2');
		COMMIT;
		--T2--
	--#7
		--B--
		BEGIN TRAN
		DELETE Списанное_оборудование WHERE Id=8;
		INSERT INTO Списанное_оборудование VALUES(8,'TEMPS','TEMP DESCRIPTION','2002-10-2');
		UPDATE Списанное_оборудование SET Причина_Списания = 'Устарел' WHERE Id=8;
		SELECT * FROM Списанное_оборудование WHERE Id=8;
		--T1--
		COMMIT;
		SELECT * FROM Списанное_оборудование WHERE Id=8;
		--T2--
