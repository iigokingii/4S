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
	CREATE TABLE Ответственный(
		Id_Рабочего int primary key,
		Фамилия_Ответственного nvarchar(30),
		Имя_Ответсвенного nvarchar(30),
		Отчество_Ответственного nvarchar(20),
		Должность nvarchar(30),
		Дата_приема_на_работу date,
	) on FG1
	CREATE TABLE Списанное_оборудование(
		Id int primary key,
		Название_Оборудования nvarchar(60),
		Причина_Списания nvarchar(90),
		Дата_Списания date,
	)on FG1
	CREATE TABLE Оборудование(
		Название_Оборудования nvarchar(30) primary key,
		Тип_Оборудования nvarchar(30),
		Дата_Поступления date,
		Количество smallint,
		Подразделение_Установки nvarchar(50),
		Id_Ответственного_Рабочего int foreign key references
													Ответственный(Id_Рабочего),
		Id_Списанного_Оборудования int foreign key references
													Списанное_оборудование(Id),
	)on FG1
	--добавление столбца с ограничением
	ALTER TABLE Ответственный ADD Пол_Рабочего nchar(1) default 'М' check(Пол_Рабочего in ('М','Ж'));
	--ALTER TABLE Ответственный ADD Отчество_Ответственного nvarchar(20);
	--удаление столбца
	ALTER TABLE Ответственный DROP Column Пол_Рабочего;
	--DROP TABLE Ответственный;

	INSERT INTO Ответственный (Id_Рабочего,Фамилия_Ответственного,Имя_Ответсвенного,Отчество_Ответственного,Должность,Дата_приема_на_работу)
		VALUES	(1,'Ivanov','Vanya','fearless','ssd','2001-12-20'),
				(2,'SAD','Ness','zagruzchick','freav','2002-2-20'),
				(3,'Summer','Time','razgruschick','Sadness','2005-5-24');
	INSERT INTO Списанное_оборудование --(Id,Название_Оборудования,Причина_Списания,Дата_Списания)
		VALUES	(1,'samsung','Выход из строя','2002-12-01'),
				(2,'WTR 2','Выход из строя','2012-12-01'),
				(3,'X','Выход из строя','2009-12-01');
	INSERT INTO Оборудование(Название_Оборудования,Тип_Оборудования,Дата_Поступления,Количество,Подразделение_Установки,
							Id_Ответственного_Рабочего,Id_Списанного_Оборудования)
		VALUES	('samsung','Принтер','2002-1-20',2,'Подраздел 1',2,3),
				('WTR 2','Станок','2022-1-20',5,'Подраздел 2',1,3),
				('X','Телефон','2015-1-20',3,'Подраздел 1',3,2),
				('wRF.e GF','Принтер','2042-1-20',2,'Подраздел 4',2,2)

	SELECT *FROM Ответственный;
	--удалить работника фам на r и дата приема от 1 до 2 
	SELECT Id,Название_Оборудования FROM Списанное_оборудование;

	SELECT COUNT(*)[Всего записей в таблице Оборудование] FROM Оборудование;
	

	SELECT *FROM Оборудование;
	UPDATE Оборудование SET Количество = 100 WHERE Название_Оборудования ='samsung';
	SELECT *FROM Оборудование;
	UPDATE Оборудование SET Количество = 2 WHERE Название_Оборудования='samsung';