create database AS08DB

use AS08DB

create table Products
(PId nvarchar(50) primary key ,
PName nvarchar(50) not null,
PPrice float not null,
MnfDate date not null,
ExpDate date not null)

insert into Products values('P00001','Laptop',25000.80,'12/04/2018','06/04/2025')
insert into Products values('P00002','Mobile',12000.80,'04/12/2021','04/12/2027')
insert into Products values('P00003','Smart watch',10000.50,'07/12/2022','11/12/2024')
insert into Products values('P00004','Earphones',3000.50,'01/25/2020','01/24/2021')
insert into Products values('P00005','Charger',2400.99,'07/06/2018','07/05/2022')
insert into Products values('P00006','Chair',600.20,'12/01/2021','12/31/2032')
insert into Products values('P00007','Fridge',50000,'11/09/2018','12/31/2027')
insert into Products values('P00008','Dust Bin',180.66,'03/12/2019','12/11/2019')
insert into Products values('P00009','Water Heater',300.99,'10/25/2022','07/13/2025')
insert into Products values('P00010','LED Tv',30000.90,'11/01/2017','12/18/2025')

select  top 5 * from Products order by PName DESC