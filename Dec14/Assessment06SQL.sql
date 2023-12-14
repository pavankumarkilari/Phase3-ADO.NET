create database ProductInventoryDB

use ProductInventoryDB

create table Products(
ProductId int primary key,
ProductName nvarchar(50),
Price float,
Quantity int,
MfDate date,
ExpDate date)

insert into Products values
(101,'Laptop',25000.80,1,'12/04/2018','06/04/2025'),
(102,'Mobile',12000.80,1,'04/12/2021','04/12/2027'),
(103,'Smart watch',10000.50,2,'07/12/2022','11/12/2024'),
(104,'Earphones',3000.50,5,'01/25/2020','01/24/2021'),
(105,'Charger',2400.99,3,'07/06/2018','07/05/2022')

select * from Products
