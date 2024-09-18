use practice;
-- exec sp_databases;
-- SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'; 



create table customers(
customer_id int PRIMARY KEY IDENTITY,
customer_name varchar(100),
customer_age Tinyint,
customer_address varchar(300),
);


INSERT INTO customers (customer_name, customer_age, customer_address) 
VALUES 
('Tejas Mate', 18, 'kamal chowk'),
('Vedant Pingle', 255, 'kapil nagar');


select * from customers;


-- creating new table of orders of customers

create table orders(
order_id INT PRIMARY KEY IDENTITY,
order_name varchar(200),
order_amount INT,
customer_id INT,
FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);


INSERT INTO orders (order_name, order_amount, customer_id)
VALUES ('colgate', 50, 1),
       ('parleG', 10, 1)

INSERT INTO orders (order_name, order_amount, customer_id)
VALUES ('Backpack', 300, 2),
       ('Shoes', 500, 2)

select * from orders;

