--Lab14.2 
	--#1
		GO
			CREATE FUNCTION COUNT_EQUIPMENT(@TYPE NVARCHAR(30))
				RETURNS INT 
				AS 
				BEGIN
					DECLARE @RC INT = 0;
					SET @RC = (SELECT COUNT(*) FROM ������������ 
											INNER JOIN �������������
												ON ������������.Id_��������������_�������� =�������������.Id_��������
													WHERE ������������.���_������������ = @TYPE)
					RETURN @RC;
				END
		GO
			DECLARE @F INT = DBO.COUNT_EQUIPMENT('�������');
			PRINT '���������� ���������: '+CAST(@F AS VARCHAR(5));


		GO
			ALTER FUNCTION COUNT_EQUIPMENT(@TYPE NVARCHAR(30),@ID INT)
				RETURNS INT 
				AS 
				BEGIN
					DECLARE @RC INT = 0;
					SET @RC = (SELECT COUNT(*) FROM ������������ 
											INNER JOIN �������������
												ON ������������.Id_��������������_�������� =�������������.Id_��������
													WHERE ������������.���_������������ = @TYPE
																	AND
																������������.Id_��������������_�������� = @ID)
					RETURN @RC;
				END
		GO
			DECLARE @F INT = DBO.COUNT_EQUIPMENT('�������',1);
			PRINT '���������� ���������: '+CAST(@F AS VARCHAR(5));
	--#2
		GO
			CREATE FUNCTION NAME_LIST(@TYPE NVARCHAR(30))
				RETURNS NVARCHAR(300)
				AS
				BEGIN
					DECLARE CURS CURSOR LOCAL 
						FOR 
							SELECT ��������_������������ FROM ������������
								WHERE ���_������������ = @TYPE
					DECLARE @TEMP NVARCHAR(30);
					DECLARE @LIST NVARCHAR(300)='';
					OPEN CURS
					FETCH CURS INTO @TEMP;
					WHILE @@FETCH_STATUS=0
					BEGIN
						SET @LIST =RTRIM(@TEMP)+', '+@LIST;
						FETCH CURS INTO @TEMP
					END
					CLOSE CURS
					RETURN @LIST;
				END
		GO
			SELECT ���_������������,DBO.NAME_LIST(���_������������)[�������� ��������] FROM ������������
			DROP FUNCTION DBO.NAME_LIST

	--#3
		GO
			CREATE FUNCTION SSS(@NAME NVARCHAR(30),@SURNAME NVARCHAR(30))
			RETURNS TABLE
			AS RETURN
			 SELECT ������������.��������_������������,�������_�������������� FROM ������������
				LEFT OUTER JOIN �������������
					ON ������������.Id_��������������_�������� = �������������.Id_��������
				WHERE ������������.��������_������������ = ISNULL(@NAME,������������.��������_������������)
									AND
							�������������.�������_�������������� = ISNULL(@SURNAME,�������������.�������_��������������)
		
		GO
			SELECT * FROM DBO.SSS(NULL,NULL);
			SELECT * FROM DBO.SSS('Huawei',NULL);
			SELECT * FROM DBO.SSS(NULL,'SAD');
			SELECT * FROM DBO.SSS('SE','SAD');
		DROP FUNCTION SSS
				
	--#4
		GO
			CREATE FUNCTION DDF(@TYPE NVARCHAR(30))
			RETURNS INT
			AS
			BEGIN
				DECLARE @RC INT = 0;
				SET @RC = (SELECT COUNT(*) FROM ������������ WHERE ������������.���_������������ = ISNULL(@TYPE,���_������������))
				RETURN @RC;
			END
		GO
			SELECT ���_������������,dbo.DDF(���_������������)[���������� ������������] 
			FROM ������������
				GROUP BY ���_������������
			SELECT dbo.DDF(NULL)[����� ������������];
