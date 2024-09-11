create database practice;
use practice;


create table emp(
emp_id int identity(1,1) PRIMARY KEY,
emp_name varchar(50),
emp_phone_no bigint,
);



insert into emp(emp_name, emp_phone_no) values ('niraj sharma', 9145634543), ('gopal das', 9145634543);




select * from emp;

--drop table emp;