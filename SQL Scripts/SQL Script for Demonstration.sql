create database MVVMTrainingDB
go

use MVVMTrainingDB
go

create table Customers (
	CustomerId int identity primary key,
	CustomerName nvarchar(50),
	Address nvarchar(255),
	CreditLimit int,
	ActiveStatus bit
)
go

insert into Customers values
	( N'Northwind Traders', 'Bangalore', 12000, 1 ),
	( N'Southwind Traders', 'Bangalore', 12000, 1 ),
	( N'Eastwind Traders', 'Bangalore', 12000, 1 ),
	( N'Westwind Traders', 'Bangalore',52000, 0 ),
	( N'Oxyrich Traders', 'Bangalore', 42000, 1 ),
	( N'Adventureworks', 'Bangalore', 32000, 1 ),
	( N'Citizen Kane', 'Mysore', 22000, 1 ),
	( N'ePublishers', 'Mangalore', 12000, 1 )
go

select * from Customers
go
