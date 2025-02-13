create database APIUsers
use APIUsers

drop table Users


CREATE TABLE Users
(
	ID int IDENTITY(1,1) primary key,
	Name varchar(50) not null,
	Email varchar (150) not null,
	pass varchar (100) not null
)