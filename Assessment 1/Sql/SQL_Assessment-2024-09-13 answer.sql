/********************************************************************************************************
                                         SQL Assessment                             Total Marks - 20
*********************************************************************************************************



Q.1] Imagine you are tasked with designing a database for a Hospital Management System. For this scenario,        [2]
     you need to create a schema that includes three tables to model the relationships between patients and practitioners and Appointment             
	 (Patient, Practitioner, Appointment) Please create these tables with proper relations.
	 Follow proper naming convention and datatype,
	 use identity,Constraints,Also Insert sample data (alteast 4 rows each)

Note :- While Designing the database please follow the normalization techniques.



Create below tables into the your database and solve below questions */

CREATE TABLE Patient (
    PatientID       INT PRIMARY KEY IDENTITY(1,1),
    PatienFirstName VARCHAR(50) NOT NULL,
    PatienLastName  VARCHAR(50) NOT NULL,
    DateOfBirth     DATE NOT NULL,
	PhoneNumber     VARCHAR(20) NOT NULL,
	PatientDisease  VARCHAR(200) NOT NULL,
	Email           VARCHAR(80)
);


-- INSERT SAMPLE DATA
INSERT INTO Patient (PatienFirstName, PatienLastName, DateOfBirth, PhoneNumber, PatientDisease, Email)
VALUES 
('Sukhdev', 'Mate', '2002-03-20', '9145678459', 'Allergie', 'tejasmate@gmail.com')
,('Avinash', 'Datt', '2001-04-23', '8568574586', 'Colds and Flu', 'avinashdatt@gmail.com')
,('Sam', 'Yadav', '2000-06-10', '8675668968', 'Diarrhea', 'samyadav@gmail.com')
,('Sanjay', 'Bhatt', '2002-03-05', '9978767896', 'Headaches', 'sanjaybhatt@gmail.com')

--SELECT * FROM Patient;



CREATE TABLE Practitioner (
    PractitionerID        INT PRIMARY KEY IDENTITY(1,1),
    PractitionerFirstName VARCHAR(50) NOT NULL,
    PractitionerLastName  VARCHAR(50) NOT NULL,
	Speciality            VARCHAR(50) NOT NULL,
    DateOfBirth           DATE NOT NULL,
	PhoneNumber           VARCHAR(20) NOT NULL,
	Email                 VARCHAR(80)
);

-- INSERT SAMPLE DATA
INSERT INTO Practitioner (PractitionerFirstName, PractitionerLastName, Speciality, DateOfBirth, PhoneNumber, Email)
VALUES 
('John', 'avado', 'cardiology', '1995-03-20','9346637659', 'johnavado@gmail.com')
,('Bran', 'Mukhni', 'gastroenterology', '1993-02-10','8534445586', 'branmukhni@gmail.com')
,('Daadu', 'Sharma', 'endocrinology', '1994-07-13','8376668968', 'daadusharma@gmail.com')
,('Piramal', 'Ambani', 'nephrology', '1997-05-12','9934566796', 'piramalambani@gmail.com')

-- SELECT * FROM Practitioner;



CREATE TABLE Appointment (
    AppointmentID                INT PRIMARY KEY IDENTITY(1,1),
	AppointmentDateAndTime       DATETIME NOT NULL,
	PatientID                    INT NOT NULL,
	PractitionerID               INT NOT NULL,
	FOREIGN KEY (PatientID)      REFERENCES Patient(PatientID),
	FOREIGN KEY (PractitionerID) REFERENCES Practitioner(PractitionerID)
);

-- INSERT SAMPLE DATA
INSERT INTO Appointment (AppointmentDateAndTime, PatientID, PractitionerID)
VALUES 
('2024-9-14 15:20:36', 1, 1)
,('2024-9-15 16:40:13', 2, 2)
,('2024-10-02 11:40:23', 3, 3)
,('2024-11-12 14:10:55', 4, 4)

-- SELECT * FROM Appointment;


create database assessment1;
use assessment1;

CREATE TABLE Product1 (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100),
    Category VARCHAR(100),
    Price DECIMAL(10, 2),
    ManufactureDate DATE,
    ExpiryDate DATE
);


-- Insert sample data into Product table
INSERT INTO Product1 (ProductName, Category, Price, ManufactureDate, ExpiryDate)
VALUES 
('Milk', 'Dairy', 1.50, '2024-01-15', '2024-04-15')
,('Bread', 'Bakery', 2.00, '2024-02-01', '2024-02-15')
,('Orange Juice', 'Beverages', 3.00, '2024-01-20', '2024-06-20')
,('Cereal', 'Groceries', 4.50, '2023-12-01', '2024-12-01')
,('Yogurt', 'Dairy', 2.75, '2024-01-10', '2024-03-10')
,('Apple', 'Fruits', 1.20, '2024-01-25', '2024-02-25')
,('Chicken Breast', 'Meat', 5.00, '2024-02-10', '2024-03-10')
,('Pasta', 'Groceries', 3.20, '2023-11-20', '2024-11-20')
,('Olive Oil', 'Condiments', 7.50, '2023-10-15', '2025-10-15')
,('Coffee', 'Beverages', 6.00, '2023-09-01', '2024-09-01')
,('Tea', 'Beverages', 10.00, '2024-09-13', '2024-09-14')

/*

Each Question have 1 marks
*/
-- Q[2]:  Retrieve details of products that belong to the 'Dairy' category.

SELECT * 
FROM   Product1
WHERE  Category = 'Dairy';


-- Q[3]:  Find all products that are not in the 'Beverages' category.

SELECT *
FROM   Product1
WHERE  Category <> 'Beverages';


-- Q[4]:  List products that have a price greater than 3.00.

SELECT *
FROM   Product1
WHERE  Price > 3;


-- Q[5]:  Retrieve products that have a price less than 2.00.

SELECT *
FROM   Product1
WHERE  Price < 2;


-- Q[6]:  Find products that were manufactured on or after '2024-01-01'.

SELECT *
FROM   Product1
WHERE  ManufactureDate >= '2024-01-01';


-- Q[7]:  Get the list of products that have an expiry date on or before '2024-06-01'.

SELECT *
FROM   Product1
WHERE  ExpiryDate <= '2024-06-01';


--Q[8]:  Retrieve products whose price is not less than 4.00.

SELECT *
FROM   Product1
WHERE  Price >= 4;


--Q[9]:  Find products whose price is not greater than 2.50.

SELECT *
FROM   Product1
WHERE  Price <= 2.50;


--Q[10]: List products that belong to the 'Groceries' category and have a price greater than 3.00.

SELECT *
FROM   Product1
WHERE  Category = 'Groceries' AND Price > 3;


--Q[11]: Find products that are either in the 'Dairy' category or have a price less than 2.00.

SELECT *
FROM   Product1
WHERE  Category = 'Dairy' OR Price < 2;


--Q[12]: Retrieve products that are not 'Bread'.

SELECT *
FROM   Product1
WHERE  ProductName <> 'Bread';


--Q[13]: Get products that have a price between 2.00 and 5.00 inclusive.

SELECT *
FROM   Product1
WHERE  Price BETWEEN 2 AND 5;


--Q[14]: Find products whose names start with the letter 'C'.

SELECT *
FROM   Product1
WHERE  ProductName LIKE 'C%';


--Q[15]: Retrieve products whose names contain the word 'Oil'.

SELECT *
FROM   Product1
WHERE  ProductName LIKE '%Oil%';


--Q[16]: Retrieve the current date and time from the SQL server.

DECLARE @CurrentDateAndTime DATETIME;
SET     @CurrentDateAndTime = GETDATE();
SELECT  @CurrentDateAndTime;


--Q[17]: List all products that were manufactured today.

DECLARE @CurrentDate DATE;
SET     @CurrentDate = GETDATE();

-- Explicitly added one row to today date of product name tea
SELECT *
FROM   Product1
WHERE  ManufactureDate = @CurrentDate;


--Q[18]: Give me list of product with Product Name (Orange Juice,Apple,Coffee).

SELECT *
FROM   Product1
WHERE  ProductName IN ('Orange Juice', 'Apple', 'Coffee');



/********************************************************************************************************
                                          ALL THE BEST
********************************************************************************************************* */






