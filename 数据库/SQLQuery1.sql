create database TutorSystem

create table StudentLogin(
Saccount varchar(20) primary key,
Spassword varchar(20)
)
insert into StudentLogin values('20143018','20143018')
insert into StudentLogin values('20143019','20143019')


create table TutorLogin(
Taccount varchar(20) primary key,
Tpassword varchar(20)
)
insert into TutorLogin values('01','01')




create table Tutor(
Tworknumber varchar(10) primary key,
Tname varchar(20),
Tchoose int,
Tyes int
)
insert into Tutor values('01','吴邪','0','0')
insert into Tutor values('02','王建民','0','0')
insert into Tutor values('03','王威','0','0')

create table Student(
Sstudynumber varchar(10) primary key,
Sname varchar(20),
Sclass varchar(30),
Schoose int,
Syes int
)
insert into Student values('20143018','李杨','信1405-1','0','0')

create table ST(
Sstudynumber varchar(10),
Tworknumber varchar(10),
SgetT int,
TgetS int,
STok int,
primary key(Sstudynumber,Tworknumber),
foreign key(Sstudynumber) references Student(Sstudynumber),
foreign key(Tworknumber) references Tutor(Tworknumber)
)

