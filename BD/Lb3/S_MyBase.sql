USE master;--lab3
go
	CREATE database S_MyBase
	ON PRIMARY 
	(name =N'S_MyBase_mdf',filename=N'D:\2k2s\BD\Lab3\S_MyBase_mdf.mdf',
	size=10240Kb,maxsize=UNLIMITED,filegrowth=1024Kb),
	(name=N'S_MyBase_ndf',filename=N'D:\2k2s\BD\Lab3\S_MyBase_ndf.ndf',
	size=10240Kb,maxsize=1GB,filegrowth=25%),
	filegroup FG1 
	(name=N'S_MyBase_fg1_1',filename=N'D:\2k2s\BD\Lab3\S_MyBase_fgq-1.ndf',
	size=10240Kb,maxsize=1GB,filegrowth=25%),
	(name=N'S_MyBase_fg1_2',filename=N'D:\2k2s\BD\Lab3\S_MyBase_fgq-2.ndf',
	size=10240Kb,maxsize=1GB,filegrowth=25%)
	log on 
	(name= N'S_MyBase_log',filename=N'D:\2k2s\BD\Lab3\S_MyBase_log.ldf',
	size=10240Kb,maxsize=2048GB,filegrowth=10%)
go
USE S_MyBase
	CREATE TABLE �������������(
		Id_�������� int primary key,
		�������_�������������� nvarchar(30),
		���_������������� nvarchar(30),
		��������_�������������� nvarchar(20),
		��������� nvarchar(30),
		����_������_��_������ date,
	) on FG1
	CREATE TABLE ���������_������������(
		Id int primary key,
		��������_������������ nvarchar(60),
		�������_�������� nvarchar(90),
		����_�������� date,
	)on FG1
	CREATE TABLE ������������(
		��������_������������ nvarchar(30) primary key,
		���_������������ nvarchar(30),
		����_����������� date,
		���������� smallint,
		�������������_��������� nvarchar(50),
		Id_��������������_�������� int foreign key references
													�������������(Id_��������),
		Id_����������_������������ int foreign key references
													���������_������������(Id),
	)on FG1
	--���������� ������� � ������������
	ALTER TABLE ������������� ADD ���_�������� nchar(1) default '�' check(���_�������� in ('�','�'));
	--ALTER TABLE ������������� ADD ��������_�������������� nvarchar(20);
	--�������� �������
	ALTER TABLE ������������� DROP Column ���_��������;
	--DROP TABLE �������������;

	INSERT INTO ������������� (Id_��������,�������_��������������,���_�������������,��������_��������������,���������,����_������_��_������)
		VALUES	(1,'Ivanov','Vanya','fearless','ssd','2001-12-20'),
				(2,'SAD','Ness','zagruzchick','freav','2002-2-20'),
				(3,'Summer','Time','razgruschick','Sadness','2005-5-24');
	INSERT INTO ���������_������������ --(Id,��������_������������,�������_��������,����_��������)
		VALUES	(1,'samsung','����� �� �����','2002-12-01'),
				(2,'WTR 2','����� �� �����','2012-12-01'),
				(3,'X','����� �� �����','2009-12-01');
	INSERT INTO ������������(��������_������������,���_������������,����_�����������,����������,�������������_���������,
							Id_��������������_��������,Id_����������_������������)
		VALUES	('samsung','�������','2002-1-20',2,'��������� 1',2,3),
				('WTR 2','������','2022-1-20',5,'��������� 2',1,3),
				('X','�������','2015-1-20',3,'��������� 1',3,2),
				('wRF.e GF','�������','2042-1-20',2,'��������� 4',2,2)

	SELECT *FROM �������������;
	--������� ��������� ��� �� r � ���� ������ �� 1 �� 2 
	SELECT Id,��������_������������ FROM ���������_������������;

	SELECT COUNT(*)[����� ������� � ������� ������������] FROM ������������;
	

	SELECT *FROM ������������;
	UPDATE ������������ SET ���������� = 100 WHERE ��������_������������ ='samsung';
	SELECT *FROM ������������;
	UPDATE ������������ SET ���������� = 2 WHERE ��������_������������='samsung';