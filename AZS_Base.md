create database PetrolStation;
use  PetrolStation;

create table AZS(
id int primary key identity,
AZSName varchar (25) not null,
AZSLocation varchar (50) not null,
A95Volume decimal not null,
A92Volume decimal not null,
DTVolume decimal not null,
A95remains decimal not null,
A92remains decimal not null,
DTremains decimal not null,
);

create table Employees(
id int primary key identity,
LastName varchar (25) not null,
FirstName varchar (25) not null,
Post varchar (25) not null,
BirthDate datetime not null,
AZS_id int foreign key (AZS_id) references AZS(id)
);

create table Products(
id int primary key identity,
ProductName varchar (25) not null,
ProductPrice decimal not null,
AZS_id int foreign key (AZS_id) references AZS(id)
);

create table Orders(
id int primary key identity,
OrderDate datetime not null,
Quantity decimal not null,
ProductPrice decimal not null,
AZS_id  int foreign key (AZS_id ) references AZS(id),
Product_id int foreign key (Product_id ) references Products(id),
Employe_id int foreign key (Employe_id ) references Employees(id)
);


insert into AZS values ('OKKO', 'ул. Старовокзальная д.56', 5000, 5000, 10000, 2300, 2700, 3400);
insert into AZS values ('Sentoza', 'ул. Лермонтова д.2', 10000, 10000, 15000, 3500, 4200, 8000);
insert into AZS values ('HTC', 'ул. Никопольское шоссе д.10', 3000, 3000, 5000, 1500, 1200, 2300);

insert into Employees values ('Григоренко', 'Дмитрий','Заправщик', '2000-11-02',1);
insert into Employees values ('Овчаренко', 'Анатолий','Заправщик', '2001-01-04',1);

insert into Employees values ('Андрюсенко', 'Александр','Заправщик', '1999-05-03',2);
insert into Employees values ('Селезень', 'Дмитрий','Заправщик', '2000-02-06',2);

insert into Employees values ('Зинченко', 'Федор','Заправщик', '2001-06-11', 3);
insert into Employees values ('Павлов', 'Семен','Заправщик', '1998-01-12',3);

insert into Products values ('А95', 32,1);
insert into Products values ('А92', 30,1);
insert into Products values ('ДТ',31,1);

insert into Products values ('А95', 29,2);
insert into Products values ('А92', 28,2);
insert into Products values ('ДТ',26,2);

insert into Products values ('А95', 29.5,3);
insert into Products values ('А92', 28.5,3);
insert into Products values ('ДТ',26.5,3);


insert into Orders values (getdate(),20,32,1,1,1);
insert into Orders values (getdate(),10,29,2,4,3);
insert into Orders values (getdate(),50,29.5,3,7,5);

insert into Orders values (getdate(),10,30,1,2,2);
insert into Orders values (getdate(),30,28,2,5,4);
insert into Orders values (getdate(),200,28.5,3,8,6);

insert into Orders values (getdate(),60,31,1,3,2);
insert into Orders values (getdate(),70,26,2,6,1);
insert into Orders values (getdate(),80,26.5,3,9,5);

