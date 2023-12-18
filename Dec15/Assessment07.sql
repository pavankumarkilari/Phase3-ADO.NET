--creating database
create database LibraryDB
--using databse
use LibraryDB
--creating a table
create table Books(
BookId int primary key,
Title nvarchar(50),
Author nvarchar(50),
Genre nvarchar(50),
Quantity int)
--inserting records
insert into Books values
(101, 'Bahubali', 'Rajamouli', 'Fiction', 5),
(102, 'Salaar', 'Prasanth Neel', 'Action', 10),
(103, 'Project-K', 'Nag Ashwin', 'Science-Fiction', 7),
(104, 'Raja Deluxe', 'Maruthi', 'Horror-Comedy', 6)
--displaying records
select * from Books