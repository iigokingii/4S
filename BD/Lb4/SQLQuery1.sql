USE master;--lab4
go
	CREATE database UNIVER
	ON PRIMARY 
	(name =N'S_MyBase_mdf',filename=N'D:\2k2s\BD\Lab4\S_MyBase_mdf.mdf',
	size=10240Kb,maxsize=UNLIMITED,filegrowth=1024Kb),
	(name=N'S_MyBase_ndf',filename=N'D:\2k2s\BD\Lab4\S_MyBase_ndf.ndf',
	size=10240Kb,maxsize=1GB,filegrowth=25%),
	filegroup FG1
	(name=N'S_MyBase_fg1_1',filename=N'D:\2k2s\BD\Lab4\S_MyBase_fgq-1.ndf',
	size=10240Kb,maxsize=1GB,filegrowth=25%),
	(name=N'S_MyBase_fg1_2',filename=N'D:\2k2s\BD\Lab4\S_MyBase_fgq-2.ndf',
	size=10240Kb,maxsize=1GB,filegrowth=25%)
	log on 
	(name= N'S_MyBase_log',filename=N'D:\2k2s\BD\Lab4\S_MyBase_log.ldf',
	size=10240Kb,maxsize=2048GB,filegrowth=10%)
go

------------�������� � ���������� ������� AUDITORIUM_TYPE 
USE UNIVER
	create table AUDITORIUM_TYPE 
	(    AUDITORIUM_TYPE  char(10) constraint AUDITORIUM_TYPE_PK  primary key,  
		  AUDITORIUM_TYPENAME  varchar(30)       
	 )
		insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,  AUDITORIUM_TYPENAME )        
			values ('��', '����������');
		insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,  AUDITORIUM_TYPENAME )         
			values ('��-�', '������������ �����');
		insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME )         
			values ('��-�', '���������� � ���. ����������');
		insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE,  AUDITORIUM_TYPENAME )          
			values  ('��-X', '���������� �����������');
		insert into AUDITORIUM_TYPE   (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME )        
			values  ('��-��', '����. ������������ �����');

	-------------�������� � ���������� ������� AUDITORIUM 

	create table AUDITORIUM 
	(   AUDITORIUM   char(20)  constraint AUDITORIUM_PK  primary key,              
		AUDITORIUM_TYPE     char(10) constraint  AUDITORIUM_AUDITORIUM_TYPE_FK foreign key         
						  references AUDITORIUM_TYPE(AUDITORIUM_TYPE), 
	   AUDITORIUM_CAPACITY  integer constraint  AUDITORIUM_CAPACITY_CHECK default 1  check (AUDITORIUM_CAPACITY between 1 and 300),  -- ����������� 
	   AUDITORIUM_NAME      varchar(50)                                     
	)
	insert into  AUDITORIUM   (AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY)   
		values  ('206-1', '206-1','��-�', 15);
	insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY) 
		values  ('301-1',   '301-1', '��-�', 15);
	insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY )   
		values  ('236-1',   '236-1', '��',   60);
	insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY )  
		values  ('313-1',   '313-1', '��-�',   60);
	insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY )  
		values  ('324-1',   '324-1', '��-�',   50);
	insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY )   
		values  ('413-1',   '413-1', '��-�', 15);
	insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY ) 
		values  ('423-1',   '423-1', '��-�', 90);
	insert into  AUDITORIUM   (AUDITORIUM,   AUDITORIUM_NAME, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY )     
		values  ('408-2',   '408-2', '��',  90);

		------�������� � ���������� ������� FACULTY
  create table FACULTY
  (    FACULTY      char(10)   constraint  FACULTY_PK primary key,
       FACULTY_NAME  varchar(50) default '???'
  );
	insert into FACULTY   (FACULTY,   FACULTY_NAME )
		values  ('����',   '���������� ���������� � �������');
	insert into FACULTY   (FACULTY,   FACULTY_NAME )
		values  ('���',     '����������������� ���������');
	insert into FACULTY   (FACULTY,   FACULTY_NAME )
		values  ('���',     '���������-������������� ���������');
	insert into FACULTY   (FACULTY,   FACULTY_NAME )
		values  ('����',    '���������� � ������� ������ ��������������');
	insert into FACULTY   (FACULTY,   FACULTY_NAME )
		values  ('���',     '���������� ������������ �������');
	insert into FACULTY   (FACULTY,   FACULTY_NAME )
		values  ('��',     '��������� �������������� ����������');  

			------�������� � ���������� ������� PULPIT
  create table  PULPIT 
(   PULPIT   char(20)  constraint PULPIT_PK  primary key,
    PULPIT_NAME  varchar(100), 
    FACULTY   char(10)   constraint PULPIT_FACULTY_FK foreign key 
                         references FACULTY(FACULTY) 
);  
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY )	
		values  ('����', '�������������� ������ � ���������� ','��'  )
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('��', '�����������','���')          
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('��', '��������������','���')           
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('�����', '���������� � ����������������','���')                
	insert into PULPIT   (PULPIT,  PULPIT_NAME, FACULTY)
		values  ('����', '������ ������� � ������������','���') 
	insert into PULPIT   (PULPIT,  PULPIT_NAME, FACULTY)
		values  ('���', '������� � ������������������','���')              
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('������','������������ �������������� � ������-��������� �����-��������','���')          
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('��', '���������� ����', '����')                          
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('�����','������ ����� � ���������� �������������','����')  
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('���','���������� �������������������� �����������', '����')   
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('�����','���������� � ������� ������� �� ���������','����')    
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('��', '������������ �����','���') 
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('���','���������� ����������� ���������','���')             
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('�������','���������� �������������� ������� � ����� ���������� ���������� ','����') 
	insert into PULPIT   (PULPIT, PULPIT_NAME, FACULTY)
		values  ('�����','��������� � ��������� ���������� �����������','����')                                               
	insert into PULPIT   (PULPIT,    PULPIT_NAME, FACULTY)
		values  ('����',    '������������� ������ � ����������','���')   
	insert into PULPIT   (PULPIT,    PULPIT_NAME, FACULTY)
		values  ('����',   '����������� � ��������� ������������������','���')   
	insert into PULPIT   (PULPIT,    PULPIT_NAME, FACULTY)
		values  ('������', '����������, �������������� �����, ������� � ������', '���')    
------�������� � ���������� ������� PROGRESS
create table PROGRESS
 (  SUBJECT   char(10) constraint PROGRESS_SUBJECT_FK foreign key
                      references SUBJECT(SUBJECT),                
     IDSTUDENT integer  constraint PROGRESS_IDSTUDENT_FK foreign key         
                      references STUDENT(IDSTUDENT),        
     PDATE    date, 
     NOTE     integer check (NOTE between 1 and 10)
  )
insert into PROGRESS (SUBJECT, IDSTUDENT, PDATE, NOTE)
    values  ('����', 1001,  '01.10.2013',8),
           ('����', 1002,  '01.10.2013',7),
           ('����', 1003,  '01.10.2013',5),
           ('����', 1005,  '01.10.2013',4)
insert into PROGRESS (SUBJECT, IDSTUDENT, PDATE, NOTE)
    values   ('����', 1014,  '01.12.2013',5),
           ('����', 1015,  '01.12.2013',9),
           ('����', 1016,  '01.12.2013',5),
           ('����', 1017,  '01.12.2013',4)
insert into PROGRESS (SUBJECT, IDSTUDENT, PDATE, NOTE)
    values ('��',   1018,  '06.5.2013',4),
           ('��',   1019,  '06.05.2013',7),
           ('��',   1020,  '06.05.2013',7),
           ('��',   1021,  '06.05.2013',9),
           ('��',   1022,  '06.05.2013',5),
           ('��',   1023,  '06.05.2013',6)

		   ------�������� � ���������� ������� STUDENT
create table STUDENT 
(    IDSTUDENT   integer  identity(1000,1) constraint STUDENT_PK  primary key,
      IDGROUP   integer  constraint STUDENT_GROUP_FK foreign key         
                      references GROUPS(IDGROUP),        
      NAME   nvarchar(100), 
      BDAY   date,
      STAMP  timestamp,
      INFO     xml,
      FOTO     varbinary
 ) 
insert into STUDENT (IDGROUP,NAME, BDAY)
    values (2, '����� ������� ��������',         '12.07.1994'),
           (2, '������� �������� ����������',    '06.03.1994'),
           (2, '�������� ����� �����������',     '09.11.1994'),
           (2, '������� ����� ���������',        '04.10.1994'),
           (2, '��������� ��������� ����������', '08.01.1994'),
           (3, '������� ������ ���������',       '02.08.1993'),
           (3, '������� ��� ����������',         '07.12.1993'),
           (3, '������� ����� �����������',      '02.12.1993'),
           (4, '������� ������ �����������',     '08.03.1992'),
           (4, '������� ����� �������������',    '02.06.1992'),
           (4, '�������� ����� �����������',     '11.12.1992'),
           (4, '�������� ������� �������������', '11.05.1992'),
           (4, '����������� ������� ��������',   '09.11.1992'),
           (4, '�������� ������� ����������',    '01.11.1992'),
           (5, '�������� ����� ������������',    '08.07.1995'),
           (5, '������ ������� ����������',      '02.11.1995'),
           (5, '������ ��������� �����������',   '07.05.1995'),
           (5, '����� ��������� ���������',      '04.08.1995'),
           (6, '���������� ����� ����������',    '08.11.1994'),
           (6, '�������� ������ ��������',       '02.03.1994'),
           (6, '���������� ����� ����������',    '04.06.1994'),
           (6, '��������� ���������� ���������', '09.11.1994'),
           (6, '����� ��������� �������',        '04.07.1994'),
           (7, '����������� ����� ������������', '03.01.1993'),
           (7, '������� ���� ��������',          '12.09.1993'),
           (7, '��������� ������ ��������',      '12.06.1993'),
           (7, '���������� ��������� ����������','09.02.1993'),
           (7, '������� ������ ���������',       '04.07.1993'),
           (8, '������ ������� ���������',       '08.01.1992'),
           (8, '��������� ����� ����������',     '12.05.1992'),
           (8, '�������� ����� ����������',      '08.11.1992'),
           (8, '������� ������� ���������',      '12.03.1992'),
           (9, '�������� ����� �������������',   '10.08.1995'),
           (9, '���������� ������ ��������',     '02.05.1995'),
           (9, '������ ������� �������������',   '08.01.1995'),
           (9, '��������� ��������� ��������',   '11.09.1995'),
           (10, '������ ������� ������������',   '08.01.1994'),
           (10, '������ ������ ����������',      '11.09.1994'),
           (10, '����� ���� �������������',      '06.04.1994'),
           (10, '������� ������ ����������',     '12.08.1994')
insert into STUDENT (IDGROUP,NAME, BDAY)
    values (11, '��������� ��������� ����������','07.11.1993'),
           (11, '������ ������� ����������',     '04.06.1993'),
           (11, '������� ����� ����������',      '10.12.1993'),
           (11, '������� ������ ����������',     '04.07.1993'),
           (11, '������� ����� ���������',       '08.01.1993'),
           (11, '����� ������� ����������',      '02.09.1993'),
           (12, '���� ������ �����������',       '11.12.1995'),
           (12, '������� ���� �������������',    '10.06.1995'),
           (12, '��������� ���� ���������',      '09.08.1995'),
           (12, '����� ����� ���������',         '04.07.1995'),
           (12, '��������� ������ ����������',   '08.03.1995'),
           (12, '����� ����� ��������',          '12.09.1995'),
           (13, '������ ����� ������������',     '08.10.1994'),
           (13, '���������� ����� ����������',   '10.02.1994'),
           (13, '�������� ������� �������������','11.11.1994'),
           (13, '���������� ����� ����������',   '10.02.1994'),
           (13, '����������� ����� ��������',    '12.01.1994'),
           (14, '�������� ������� �������������','11.09.1993'),
           (14, '������ �������� ����������',    '01.12.1993'),
           (14, '���� ������� ����������',       '09.06.1993'),
           (14, '�������� ���������� ����������','05.01.1993'),
           (14, '����������� ����� ����������',  '01.07.1993'),
           (15, '������� ��������� ���������',   '07.04.1992'),
           (15, '������ �������� ���������',     '10.12.1992'),
           (15, '��������� ����� ����������',    '05.05.1992'),
           (15, '���������� ����� ������������', '11.01.1992'),
           (15, '�������� ����� ����������',     '04.06.1992'),
           (16, '����� ����� ����������',        '08.01.1994'),
           (16, '��������� ��������� ���������', '07.02.1994'),
           (16, '������ ������ �����������',     '12.06.1994'),
           (16, '������� ����� ��������',        '03.07.1994'),
           (16, '������ ������ ���������',       '04.07.1994'),
           (17, '������� ��������� ����������',  '08.11.1993'),
           (17, '������ ����� ����������',       '02.04.1993'),
           (17, '������ ���� ��������',          '03.06.1993'),
           (17, '������� ������ ���������',      '05.11.1993'),
           (17, '������ ������ �������������',   '03.07.1993'),
           (18, '��������� ����� ��������',      '08.01.1995'),
           (18, '���������� ��������� ���������','06.09.1995'),
           (18, '�������� ��������� ����������', '08.03.1995'),
           (18, '��������� ����� ��������',      '07.08.1995')

		   ------�������� � ���������� ������� GROUPS
create table GROUPS 
(   IDGROUP  integer  identity(1,1) constraint GROUP_PK  primary key,              
    FACULTY   char(10) constraint  GROUPS_FACULTY_FK foreign key         
                                                         references FACULTY(FACULTY), 
     PROFESSION  char(20) constraint  GROUPS_PROFESSION_FK foreign key         
                                                         references PROFESSION(PROFESSION),
    YEAR_FIRST  smallint  check (YEAR_FIRST<=YEAR(GETDATE())),
	COURSE AS (YEAR(CURDATE())-YEAR_FIRST),
  )
insert into GROUPS   (FACULTY,  PROFESSION, YEAR_FIRST )
         values ('����','1-40 01 02', 2013), --1
                ('����','1-40 01 02', 2012),
                ('����','1-40 01 02', 2011),
                ('����','1-40 01 02', 2010),
                ('����','1-47 01 01', 2013),---5 ��
                ('����','1-47 01 01', 2012),
                ('����','1-47 01 01', 2011),
                ('����','1-36 06 01', 2010),-----8 ��
                ('����','1-36 06 01', 2013),
                ('����','1-36 06 01', 2012),
                ('����','1-36 06 01', 2011),
                ('����','1-36 01 08', 2013),---12 ��                                                  
                ('����','1-36 01 08', 2012),
                ('����','1-36 07 01', 2011),
                ('����','1-36 07 01', 2010),
                ('���','1-48 01 02', 2012), ---16 �� 
                ('���','1-48 01 02', 2011),
                ('���','1-48 01 05', 2013),
                ('���','1-54 01 03', 2012),
                ('���','1-75 01 01', 2013),--20 ��      
                ('���','1-75 02 01', 2012),
                ('���','1-75 02 01', 2011),
                ('���','1-89 02 02', 2012),
                ('���','1-89 02 02', 2011),  
                ('����','1-36 05 01', 2013),
                ('����','1-36 05 01', 2012),
                ('����','1-46 01 01', 2012),--27 ��
                ('���','1-25 01 07', 2013), 
                ('���','1-25 01 07', 2012),     
                ('���','1-25 01 07', 2010),
                ('���','1-25 01 08', 2013),
                ('���','1-25 01 08', 2012) ---32 ��      
------�������� � ���������� ������� SUBJECT
create table SUBJECT
    (     SUBJECT  char(10) constraint SUBJECT_PK  primary key, 
           SUBJECT_NAME varchar(100) unique,
           PULPIT  char(20) constraint SUBJECT_PULPIT_FK foreign key 
                         references PULPIT(PULPIT)   
     )
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT )
		values ('����',   '������� ���������� ������ ������', '����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,  PULPIT)
		values ('��',     '���� ������','����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,  PULPIT )
		values ('���',    '�������������� ����������','����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,  PULPIT )
		values ('����',  '������ �������������� � ����������������', '����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,  PULPIT )
		values ('��',     '������������� ������ � ������������ ��������', '��-��');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,  PULPIT )
		values ('���',    '���������������� ������� ����������', '����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,  PULPIT )
		values ('����',  '������������� ������ ��������� ����������', '��-��');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,  PULPIT )
		values ('���',     '�������������� �������������� ������', '����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,  PULPIT )
		values ('��',      '������������ ��������� ','����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,  PULPIT )
		values ('�����',   '��������. ������, �������� � �������� �����', '��-����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,  PULPIT )
		values ('���',     '������������ �������������� �������', '����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT )
		values ('���',     '����������� ��������. ������������', '������');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT)
		values ('��',   '���������� ����������', '����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,PULPIT )
		values ('��',   '�������������� ����������������','����');  
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT )
		values ('����', '���������� ������ ���',  '����');                   
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,PULPIT )
		values ('���',  '��������-��������������� ����������������', '����');
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT )
		values ('��', '��������� ������������������','����')
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT )
		values ('��', '������������� ������','����')
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT )
		values ('������OO','�������� ������ ������ � ���� � ���. ������.','��')
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT )
		values ('�������','������ ������-��������� � ������������� �����-����',  '������')
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,PULPIT )
		values ('��', '���������� �������� ','��')
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,PULPIT )
		values ('��',    '�����������', '�����') 
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT )
		values ('��',    '������������ �����', '��')   
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,PULPIT )
		values ('���',    '���������� ��������� �������','��������') 
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT )
		values ('���',    '������ ��������� ����','��')
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,PULPIT )
		values ('����',   '���������� � ������������ �������������', '�����') 
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME,PULPIT )
		values ('����',   '���������� ���������� �������� ���������� ','�������')
	insert into SUBJECT   (SUBJECT,   SUBJECT_NAME, PULPIT )
		values ('���',    '���������� ������������','��������')  
		
------�������� � ���������� ������� TEACHER
 create table TEACHER
 (   TEACHER    char(10)  constraint TEACHER_PK  primary key,
     TEACHER_NAME  varchar(100), 
     GENDER     char(1) CHECK (GENDER in ('�', '�')),
     PULPIT   char(20) constraint TEACHER_PULPIT_FK foreign key 
                         references PULPIT(PULPIT) 
 );
insert into  TEACHER    (TEACHER,   TEACHER_NAME, GENDER, PULPIT )
                       values  ('����',    '������ �������� �������������', '�',  '����');
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('���',     '����� ��������� ����������', '�', '���');
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('���',     '��������� ����� ��������', '�', '����');
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                      values  ('���',     '����� ������� ��������', '�', '����');
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('���',     '����� ������� �������������',  '�', '����');                     
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('���',     '����� ����� �������������',  '�',   '����');                                                                                           
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
             values  ('������',   '���������� ��������� �������������', '�','������');
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('���',     '��������� ������� �����������', '�', '������');                       
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('����',   '������� ��������� ����������', '�', '����');
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('����',   '������ ������ ��������', '�', '��');
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('����', '������� ������ ����������',  '�',  '������');
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('���',     '���������� ������� ��������', '�', '������');
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('���',   '������ ������ ���������� ', '�', '��');                      
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('�����',   '��������� �������� ���������', '�', '�����'); 
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('������',   '���������� �������� ����������', '�', '��'); 
insert into  TEACHER    (TEACHER,  TEACHER_NAME, GENDER, PULPIT )
                       values  ('�����',   '�������� ������ ����������', '�', '��'); 




create table PROFESSION
  (	   
	   PROFESSION   char(20) constraint PROFESSION_PK  primary key,
       FACULTY    char(10) constraint PROFESSION_FACULTY_FK foreign key 
                            references FACULTY(FACULTY),
       PROFESSION_NAME varchar(100),    QUALIFICATION   varchar(50)  
  );  
	 insert into PROFESSION(FACULTY, PROFESSION, PROFESSION_NAME, QUALIFICATION)    
		values    ('��',  '1-40 01 02',   '�������������� ������� � �����-�����', '�������-�����������-�������������' );
	 insert into PROFESSION(FACULTY, PROFESSION, PROFESSION_NAME, QUALIFICATION)    
		values    ('��',  '1-47 01 01', '������������ ����', '��������-��������' );
	 insert into PROFESSION(FACULTY, PROFESSION,  PROFESSION_NAME, QUALIFICATION)    
		values    ('��',  '1-36 06 01',  '��������������� ������������ � ������� ��������� ����������', '�������-��������������' );                     
	 insert into PROFESSION(FACULTY, PROFESSION,  PROFESSION_NAME, QUALIFICATION)  
		values    ('����',  '1-36 01 08',    '��������������� � ������������ ������� �� �������������� ����������', '�������-�������' );
	 insert into PROFESSION(FACULTY, PROFESSION,  PROFESSION_NAME, QUALIFICATION)      
		values    ('����',  '1-36 07 01',  '������ � �������� ���������� ����������� � ����������� ������������ ����������', '�������-�������' );
	 insert into PROFESSION(FACULTY, PROFESSION, PROFESSION_NAME, QUALIFICATION)  
		values    ('���',  '1-75 01 01',      '������ ���������', '������� ���-���� ���������' );
	 insert into PROFESSION(FACULTY, PROFESSION,  PROFESSION_NAME, QUALIFICATION)   
		values    ('���',  '1-75 02 01',   '������-�������� �������������', '������� ������-��������� �������������' );
	 insert into PROFESSION(FACULTY, PROFESSION,     PROFESSION_NAME, QUALIFICATION)   
		values    ('���',  '1-89 02 02',     '������ � ���������������-���', '���������� � ����� �������' );
	 insert into PROFESSION(FACULTY, PROFESSION, PROFESSION_NAME, QUALIFICATION)  
		values    ('���',  '1-25 01 07',  '��������� � ���������� �� ����-�������', '���������-��������' );
	 insert into PROFESSION(FACULTY, PROFESSION,  PROFESSION_NAME, QUALIFICATION)      
		values    ('���',  '1-25 01 08',    '������������� ����, ������ � �����', '���������' );                      
	 insert into PROFESSION(FACULTY, PROFESSION,     PROFESSION_NAME, QUALIFICATION)  
		values    ('����',  '1-36 05 01',   '������ � ������������ ������� ���������', '�������-�������' );
	 insert into PROFESSION(FACULTY, PROFESSION,   PROFESSION_NAME, QUALIFICATION)   
		values    ('����',  '1-46 01 01',      '�������������� ����', '�������-��������' );
	 insert into PROFESSION(FACULTY, PROFESSION,     PROFESSION_NAME, QUALIFICATION)      
		values    ('���',  '1-48 01 02',  '���������� ���������� ��-���������� �������, ���������� � �������', '�������-�����-��������' );                
	 insert into PROFESSION(FACULTY, PROFESSION,   PROFESSION_NAME, QUALIFICATION)    
		values    ('���',  '1-48 01 05',    '���������� ���������� ��-��������� ���������', '�������-�����-��������' ); 
	 insert into PROFESSION(FACULTY, PROFESSION,    PROFESSION_NAME, QUALIFICATION)  
		values    ('���',  '1-54 01 03',   '������-���������� ������ � ������� �������� �������� ���������', '������� �� ������������' ); 


		--#1
			SELECT AUDITORIUM.AUDITORIUM_NAME,AUDITORIUM.AUDITORIUM_TYPE,AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
				FROM AUDITORIUM INNER JOIN AUDITORIUM_TYPE
				ON AUDITORIUM.[AUDITORIUM_TYPE]=AUDITORIUM_TYPE.AUDITORIUM_TYPE;
		--#2
			SELECT AUDITORIUM.AUDITORIUM_NAME,AUDITORIUM.AUDITORIUM_TYPE,AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
				FROM AUDITORIUM INNER JOIN AUDITORIUM_TYPE
				ON AUDITORIUM.[AUDITORIUM_TYPE]=AUDITORIUM_TYPE.AUDITORIUM_TYPE AND
										AUDITORIUM_TYPE.AUDITORIUM_TYPENAME LIKE '%���������%';
		--#3
			SELECT FACULTY.FACULTY, PULPIT.PULPIT,SUBJECT.SUBJECT, PROFESSION.PROFESSION, STUDENT.NAME,
			  case
				when (PROGRESS.NOTE between 6 and 6) then 'six'
				when (PROGRESS.NOTE between 7 and 7) then 'seven'
				when (PROGRESS.NOTE between 8 and 8) then 'eight'
				else 'another mark'
				end as MARK
			  FROM	FACULTY 
				   INNER JOIN PULPIT ON FACULTY.FACULTY = PULPIT.FACULTY
				   INNER JOIN SUBJECT ON PULPIT.PULPIT = SUBJECT.PULPIT
				   INNER JOIN PROGRESS ON SUBJECT.SUBJECT = PROGRESS.SUBJECT
				   INNER JOIN STUDENT ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
				   INNER JOIN GROUPS ON  STUDENT.IDGROUP = GROUPS.IDGROUP
				   INNER JOIN PROFESSION ON GROUPS.PROFESSION = PROFESSION.PROFESSION

				ORDER BY FACULTY.FACULTY, PULPIT.PULPIT, PROFESSION.PROFESSION, STUDENT.NAME , PROGRESS.NOTE DESC;
		--#4
			SELECT isnull(TEACHER.TEACHER_NAME,'***')[TEACHER],PULPIT.PULPIT_NAME[PULPIT]
				FROM PULPIT LEFT OUTER JOIN TEACHER
					ON TEACHER.PULPIT=PULPIT.PULPIT
		--#5
				--1,2
			SELECT isnull(TEACHER.TEACHER_NAME,'***')[TEACHER],PULPIT.PULPIT_NAME[PULPIT]
				FROM PULPIT FULL OUTER JOIN TEACHER
					ON PULPIT.PULPIT = TEACHER.PULPIT

			SELECT isnull(TEACHER.TEACHER_NAME,'***')[TEACHER],PULPIT.PULPIT_NAME[PULPIT]
				FROM TEACHER FULL OUTER JOIN PULPIT
					ON TEACHER.PULPIT = PULPIT.PULPIT
				--3
			SELECT isnull(TEACHER.TEACHER_NAME,'***')[TEACHER],PULPIT.PULPIT_NAME[PULPIT]
				FROM TEACHER FULL OUTER JOIN PULPIT
					ON TEACHER.PULPIT = PULPIT.PULPIT
						WHERE PULPIT.PULPIT_NAME is NULL
				--4
			SELECT isnull(TEACHER.TEACHER_NAME,'***')[TEACHER],PULPIT.PULPIT_NAME[PULPIT]
				FROM TEACHER RIGHT JOIN PULPIT
					ON TEACHER.PULPIT = PULPIT.PULPIT
						WHERE TEACHER is NULL
				--5
			SELECT PULPIT.PULPIT,TEACHER.TEACHER_NAME
				FROM TEACHER FULL OUTER JOIN PULPIT
					ON PULPIT.PULPIT = TEACHER.PULPIT
						WHERE TEACHER.TEACHER_NAME IS NOT NULL
		--#6
			SELECT AUDITORIUM.AUDITORIUM_NAME,AUDITORIUM.AUDITORIUM_TYPE,AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
				FROM AUDITORIUM CROSS JOIN AUDITORIUM_TYPE
			
		--#7 IN SECOND REQUEST
		--#8 DOP
	--CREATE TABLE TIMETABLE(
	--	ID	INT PRIMARY KEY,
	--	IDGROUP INT FOREIGN KEY REFERENCES GROUPS(IDGROUP),
	--2	AUDITIRIUM CHAR(20) FOREIGN KEY REFERENCES AU	``DITORIUM(AUDITORIUM),
	--	TEACHER CHAR(10) FOREIGN KEY REFERENCES TEACHER(TEACHER),
	--	DAY_OF_WEEK NVARCHAR(10),
	--	SUBJECT CHAR(10) FOREIGN KEY REFERENCES SUBJECT(SUBJECT),
	--);
	--INSERT INTO TIMETABLE
	--	VALUES	(1,22,'301-1','������','WEDNESDAY','��'),
	--			(2,32,'206-1','���','WEDNESDAY','���'),
	--			(3,31,'324-1','���','TUESDAY','���'),
	--			(4,29,'413-1','���','FRIDAY','��'),
	--			(5,27,'423-1','����','SATURDAY','����'),
	--			(6,25,'301-1','���','TUESDAY','���'),
	--			(7,24,'236-1','����','WEDNESDAY','���')

	--	--#1
	--	SELECT AUDITORIUM.AUDITORIUM_CAPACITY,AUDITORIUM.AUDITORIUM_NAME,TIMETABLE.SUBJECT
	--	FROM TIMETABLE
	--	INNER JOIN AUDITORIUM
	--		ON AUDITORIUM.AUDITORIUM = TIMETABLE.AUDITIRIUM




	--	--#2
	--	SELECT AUDITORIUM.AUDITORIUM[���������_���������],TIMETABLE.DAY_OF_WEEK
	--		FROM AUDITORIUM
	--		LEFT OUTER JOIN TIMETABLE
	--			ON  TIMETABLE.AUDITIRIUM=AUDITORIUM.AUDITORIUM
	--				--WHERE TIMETABLE.DAY_OF_WEEK ='WEDNESDAY'
	--				--		AND
	--					WHERE AUDITORIUM.AUDITORIUM IS NULL
	--	--#3







					




			 

			




