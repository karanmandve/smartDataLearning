/********************************************************************************************************
                                         SQL Assessment 3                           Total Marks - 20
*********************************************************************************************************/


-- Execute below tables with the data and Solve the Questions
-- Note if you already have these tables then no need to create 

CREATE DATABASE Assessment3
USE Assessment3

Create table Roles
(
RoleId smallint primary key identity(100,2),
RoleName varchar(50)
)

insert into Roles(RoleName)
values('Dean'),('Accountant'),('Professor'),('Staff'),('Admin')



create table Users
(UserId smallint primary key identity,
 RoleId smallint foreign key references Roles(RoleID),
 UserName varchar(50) not null,
 Email varchar(50)not null)


insert into Users (RoleId,UserName,Email)
values(100,'DR.Parth','Dp.54@gmail.com'),
(104,'DR.Giri','Giri.54@gmail.com'),
(102,'Shubhash Sah','Shubhas@gmail.com'), 
(106,'Ramu Dawre','Rd@gmail.com'),
(108,'Mr Saini','Dp.54@gmail.com')

update Users
set Email = 'Saini@gmail.com'
where userid = 5




CREATE TABLE [GlobalCategory](
	GlobalCategoryId int IDENTITY(1,1) primary key NOT NULL,
	category_name nvarchar(100) NOT NULL,
	category_key nvarchar(100) NOT NULL

)

insert into GlobalCategory(category_name,category_key)
values('Gender','Represent Genders'),
      ('Ethnicity','Represent Ethnicity'),
	  ('Comminication','Represent Ethnicity'),
	  ('Language','Communication Way')



CREATE TABLE [CategoryToCode](
	CategoryToCodeId int IDENTITY(500,1) primary key NOT NULL,
	GlobalCategoryId int foreign key references GlobalCategory(GlobalCategoryId),
	CategoryValue nvarchar(100) NOT NULL
	)

insert into CategoryToCode(GlobalCategoryId,CategoryValue)
values(1,'Male'),(1,'Female'),(1,'Gay'),(1,'Tran'),(1,'Other'),
      (2,'Asian'),(2,'Hispanic'),(2,'Black'),(2,'White'),(2,'Indian'),
	  (4,'English'),(4,'Arebic'),(4,'Hindi'),(4,'Urdu'),(4,'British English')



CREATE TABLE Patient (
    PatientId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(70),
    LastName VARCHAR(70),
    Dob DATE,
    Gender INT,
    PatientLanguage INT,
    Ethnicity INT,
	CreatedBy smallint foreign key references Users(UserId),

CONSTRAINT FK_Patient_Gender FOREIGN KEY (Gender) REFERENCES CategoryToCode(CategoryToCodeId),
CONSTRAINT FK_Patient_Language FOREIGN KEY (PatientLanguage) REFERENCES CategoryToCode(CategoryToCodeId),
CONSTRAINT FK_Patient_Ethnicity FOREIGN KEY (Ethnicity) REFERENCES CategoryToCode(CategoryToCodeId)
);




INSERT INTO Patient (FirstName, LastName, Dob, Gender, PatientLanguage, Ethnicity,CreatedBy)
VALUES 
    ('John', 'Doe', '1985-05-15', 500, 510, 506,1),  
    ('Jane', 'Smith', '1990-08-22', 501, 511, 507,1),  
    ('Chris', 'Johnson', '1975-12-30', 500, 512, 505,1),  
    ('Emily', 'Davis', '2000-01-05', 501, 513, 508,1),  
    ('Michael', 'Brown', '1982-03-10', 500, 514, 509,2), 


	('Silva', 'Doe', '1985-05-15', 500, 510, 506,2),  
    ('Julia', 'Smith', '1990-08-22', 501, 511, 507,2),  
    ('Martian', 'Johnson', '1975-12-30', 500, 512, 505,1), 
    ('Lily', 'Davis', '2000-01-05', 501, 513, 508,2),  
    ('Mick', 'Brown', '1982-03-10', 500, 514, 509,1),  


	('Ram', 'Doe', '1985-05-15', 500, 510, 506,2),  
    ('Jeevna', 'Smith', '1990-08-22', 501, 511, 507,1),  
    ('Ramesh', 'Johnson', '1975-12-30', 500, 512, 505,1), 
    ('Ema', 'Davis', '2000-01-05', 501, 513, 508,2),  
    ('chael', 'Brown', '1982-03-10', 500, 514, 509,2) 


Create table ContactType 
(ContactTypeId smallint primary key identity(200,1),ContactType varchar(50))

insert into ContactType(ContactType)
values('Mobile'),('Email'),('Fax'),('Other')


create table PatientContact 
(
PatientContactId int primary key identity,
PatientId int foreign key references Patient(PatientId),
ContactTypeId smallint foreign key references ContactType(ContactTypeId),
ContactValue varchar(100),
Isactive bit ,
CreateDatetime datetime
)


select * from ContactType
--select * from Patient
select * from PatientContact


insert into PatientContact (PatientId,ContactTypeId,ContactValue,Isactive,CreateDatetime)
values (2 ,200,'8527412365',1,getdate()-100),
       (2 ,200,'7418523698',1,getdate()-200),
       (2 ,203,'456-859-96',1,getdate()-12),
	   (12,200,'8657458965',1,getdate()-500),
	   (12,201,'Test@gmail.com',1,getdate()-450),
	   (15,200,'3256987456',1,getdate()-50),
	   (13,200,'3265874562',1,getdate()-2),
	   (14,200,'6547895412',1,getdate()),
	   (14,202,'456-959-63',1,getdate()),
	   (14,200,'4593256874',1,getdate()-1000),
	   (11,201,'Yup.test@gmail.com',1,getdate())




Create table PatientAddress
(
AddressId int primary key identity,
PatientId int foreign key references Patient(PatientId),
AddressLine1 varchar(200),
AddressLine2 varchar(200),
ZipCode char(6),
City varchar(100),
CreatedDatetime datetime
)


INSERT INTO PatientAddress (PatientId, AddressLine1, AddressLine2, ZipCode, City, CreatedDatetime) VALUES
(1, '123 Main St', 'Apt 4B', '123456', 'New York', '2023-09-27 09:45:00'),
(1, '456 Elm St', 'Suite 12', '654321', 'Los Angeles', '2023-09-27 10:15:00'),
(1, '789 Oak St', NULL, '789123', 'Chicago', '2023-09-27 11:05:00'),
(3, '321 Pine St', 'Floor 2', '321987', 'Houston', '2023-09-27 12:25:00'),
(3, '654 Maple Ave', NULL, '654789', 'San Francisco', '2023-09-27 14:10:00'),
(3, '987 Cedar Rd', 'Building 5', '987654', 'Miami', '2023-09-27 15:20:00'),
(5, '543 Birch Dr', 'Apt 7A', '543210', 'Phoenix', '2023-09-27 16:45:00'),
(5, '876 Willow St', NULL, '876543', 'Dallas', '2023-09-27 17:30:00'),
(5, '345 Poplar Ln', 'Suite 22', '345678', 'Denver', '2023-09-27 18:15:00'),
(5, '210 Spruce Blvd', 'Apt 1C', '210987', 'Boston', '2023-09-27 19:05:00'),
(10, '12 River St', NULL, '112233', 'Seattle', '2023-09-28 08:30:00'),
(10, '98 Lake View', 'Apt 9C', '334455', 'Austin', '2023-09-28 09:45:00'),
(10, '67 Hilltop Dr', 'Unit 3', '556677', 'Portland', '2023-09-28 10:50:00'),
(11, '234 Forest Ave', NULL, '778899', 'Atlanta', '2023-09-28 11:35:00'),
(11, '89 Green St', 'Suite 6B', '998877', 'Orlando', '2023-09-28 12:25:00'),
(12, '45 Ocean Blvd', 'Apt 2A', '123789', 'San Diego', '2023-09-28 13:55:00'),
(13, '16 Mountain Rd', NULL, '654123', 'Salt Lake City', '2023-09-28 14:40:00'),
(13, '301 Valley St', 'Floor 4', '987321', 'Las Vegas', '2023-09-28 15:20:00'),
(13, '77 Meadow Ln', 'Unit 8', '321654', 'Kansas City', '2023-09-28 16:10:00'),
(13, '91 Sunset Blvd', NULL, '789654', 'Charlotte', '2023-09-28 17:45:00');




CREATE TABLE Practitioners (
    PractitionerId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(70),
    LastName VARCHAR(70),
    Specialty NVARCHAR(100),
    Email VARCHAR(100),
    ContactNumber VARCHAR(15),
    CreatedBy SMALLINT FOREIGN KEY REFERENCES Users(UserId),
    CreatedDatetime DATETIME
);

-- Sample Data
INSERT INTO Practitioners (FirstName, LastName, Specialty, Email, ContactNumber, CreatedBy, CreatedDatetime)
VALUES 
('Dr. James', 'Brown', 'Cardiology', 'james.brown@example.com', '123-456-7890', 1, GETDATE()),
('Dr. Sarah', 'Taylor', 'Dermatology', 'sarah.taylor@example.com', '987-654-3210', 2, GETDATE()),
('Dr. Michael', 'Johnson', 'Orthopedics', 'michael.johnson@example.com', '654-987-1234', 1, GETDATE());




CREATE TABLE AppointmentStatus (
    StatusId SMALLINT PRIMARY KEY IDENTITY(300, 1),
    StatusDescription VARCHAR(50)
);

-- Sample Data
INSERT INTO AppointmentStatus (StatusDescription)
VALUES 
('Scheduled'), 
('Confirmed'), 
('Cancelled'), 
('Completed');






CREATE TABLE Appointment (
    AppointmentId INT PRIMARY KEY IDENTITY,
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
    PractitionerId INT FOREIGN KEY REFERENCES Practitioners(PractitionerId),
    AppointmentDate DATETIME,
    AppointmentTime TIME,
    StatusId SMALLINT FOREIGN KEY REFERENCES AppointmentStatus(StatusId),
    CreatedBy SMALLINT FOREIGN KEY REFERENCES Users(UserId),
    CreatedDatetime DATETIME
);



-- Insert 20 sample appointment records
INSERT INTO Appointment (PatientId, PractitionerId, AppointmentDate, AppointmentTime, StatusId, CreatedBy, CreatedDatetime)
VALUES 
(1, 1, '2023-10-01', '10:00:00', 300, 1, GETDATE()),
(2, 2, '2023-10-02', '11:00:00', 301, 2, GETDATE()),
(3, 1, '2023-10-03', '09:30:00', 300, 1, GETDATE()),
(4, 3, '2023-10-04', '15:00:00', 302, 2, GETDATE()),
(5, 1, '2023-10-05', '13:00:00', 303, 1, GETDATE()),
(6, 2, '2023-10-06', '10:30:00', 300, 2, GETDATE()),
(7, 3, '2023-10-07', '12:00:00', 301, 1, GETDATE()),
(8, 2, '2023-10-08', '14:00:00', 303, 2, GETDATE()),
(9, 1, '2023-10-09', '08:30:00', 302, 1, GETDATE()),
(10, 1, '2023-10-10', '10:15:00', 301, 2, GETDATE()),
(11, 3, '2023-10-11', '16:00:00', 300, 1, GETDATE()),
(12, 2, '2023-10-12', '09:45:00', 302, 2, GETDATE()),
(13, 3, '2023-10-13', '11:30:00', 301, 1, GETDATE()),
(14, 1, '2023-10-14', '15:30:00', 300, 2, GETDATE()),
(15, 2, '2023-10-15', '13:45:00', 303, 1, GETDATE())



Create Table ClaimProcess
(
ClaimProcessId int primary key identity (21,6),
AppointmentId int foreign key references Appointment(AppointmentId),
ClaimStatus varchar(50)
)

insert into ClaimProcess(AppointmentId,ClaimStatus)
values
(2,'Pending'),
(3,'Pending'),
(4,'In-Progress'),
(5,'Pending'),
(6,'Pending'),
(7,'Pending'),
(8,'Partially Done'),
(9,'Partially Done'),
(10,'Done'),
(11,'Pending'),
(12,'Done'),
(13,'Pending')




CREATE TABLE InsuranceProviders (
    InsuranceProviderId INT PRIMARY KEY IDENTITY,
    InsuranceProviderName VARCHAR(100) NOT NULL,
	PhoneNumber  varchar(70),
	Email varchar(40),
    [Address] VARCHAR(200)
);


INSERT INTO InsuranceProviders (InsuranceProviderName, PhoneNumber, Email, [Address])
VALUES 
('HealthCare Inc.', '555-1234', 'contact@healthcareinc.com', '101 Health St, New York, NY'),
('Wellness Insurance Co.', '555-5678', 'info@wellnessinsure.com', '202 Wellness Blvd, Los Angeles, CA'),
('CareFirst Insurance', '555-8765', 'support@carefirst.com', '303 Care Ave, Chicago, IL'),
('Guardian Health Plans', '555-4321', 'service@guardianhealth.com', '404 Guardian Way, Houston, TX'),
('United Health Group', '555-3456', 'customer.service@unitedhealth.com', '505 United Dr, Miami, FL'),
('Optima Health', '555-7654', 'help@optimahealth.com', '606 Optima Ln, San Francisco, CA'),
('Blue Cross Blue Shield', '555-6543', 'info@bcbs.com', '707 Blue Cross Rd, Seattle, WA'),
('Aetna Inc.', '555-9876', 'claims@aetna.com', '808 Aetna Blvd, Boston, MA'),
('Cigna Health Insurance', '555-8765', 'contact@cigna.com', '909 Cigna Ct, Denver, CO'),
('Humana Inc.', '555-1234', 'support@humana.com', '101 Humana St, Atlanta, GA');




CREATE TABLE PatientInsurance (
    PatientInsuranceId INT PRIMARY KEY IDENTITY,
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
    InsuranceProviderId INT FOREIGN KEY REFERENCES InsuranceProviders(InsuranceProviderId),
    PolicyNumber VARCHAR(50),
    CoverageDetails VARCHAR(200)
);


INSERT INTO PatientInsurance (PatientId, InsuranceProviderId, PolicyNumber,CoverageDetails)
VALUES 
(1, 1, 'HC123456',  'Full Coverage'),
(2, 2, 'WI654321',  'Partial Coverage'),
(3, 1, 'HC789012',  'Full Coverage'),
(4, 3, 'CP345678',  'Emergency Only'),
(5, 4, 'GH910111',  'Full Coverage'),
(6, 5, 'UHG121314', 'Dental Coverage'),
(7, 1, 'HC151617',  'Vision and Dental'),
(8, 2, 'WI181920',  'Full Coverage'),
(9, 3, 'CP212223',  'Partial Coverage'),
(10, 4, 'GH242526', 'Full Coverage');


CREATE TABLE Medication (
    MedicationId INT PRIMARY KEY IDENTITY,
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
    AppointmentId INT FOREIGN KEY REFERENCES Appointment(AppointmentId),
    MedicationName VARCHAR(100),
    Dosage VARCHAR(50),
    Frequency VARCHAR(50)
   
);

INSERT INTO Medication (PatientId, AppointmentId, MedicationName, Dosage)
VALUES 
(1, 2, 'Lisinopril', '10 mg'),
(2, 3, 'Hydrocortisone Cream', '1%'),
(3, 4, 'Ibuprofen', '400 mg'),
(4, 5, 'Cetirizine', '10 mg'),
(5, 6, 'Metformin', '500 mg'),
(6, 7, 'Tamiflu', '75 mg'),
(10,11 , 'Sertraline', '50 mg'),
(14,15 , 'Albuterol Inhaler', '90 mcg'),
(15,8 , 'Acetaminophen', '500 mg') -- 16 AppointmentId does not exist in appointment table giving error so changing to 8


/******************************************************************************************
                                      Questions
*******************************************************************************************/

-- 1] Write a SQL query to list all users along with their roles. Include UserName, Email, and RoleName.


SELECT     [user].UserName, [user].Email, [role].RoleName 
FROM       Users as [user] 
left join  Roles as [role] on [user].RoleId = [role].RoleId


-- 2] Retrieve the full name and contact information of all patients along with their respective practitioners' names.


SELECT    CONCAT(pat.FirstName, ' ', pat.LastName) as [Full Name], patcon.*, 
	      CONCAT(pract.FirstName, ' ', pract.LastName ) as [Practitioners Full Name] 
FROM      Patient pat 
left join PatientContact as patcon on pat.PatientId = patcon.PatientId 
left join Appointment as app on pat.PatientId = app.PatientId
left join Practitioners as pract on app.PractitionerId = pract.PractitionerId


--3] Create a temporary table to store the email addresses of all users who have the role of 'Professor' and display the data.


SELECT    [user].UserName, [user].Email, [role].RoleName 
INTO      #UserRoleData 
FROM      Users [user] 
left join Roles [role] on [user].RoleId = [role].RoleId 
WHERE     [role].RoleName = 'Professor'

SELECT * FROM #UserRoleData


--4] Write a query to create a temporary table that holds the counts of patients per ethnicity and then select from that temporary table.


SELECT pat.Ethnicity, COUNT(pat.Ethnicity) as [Number Of Patients] 
INTO   #PatientPerEthnicity 
FROM   Patient as pat group by pat.Ethnicity 

SELECT * FROM #PatientPerEthnicity


--5] Write an INSERT statement to add a new role called 'Nurse' to the Roles table.


INSERT INTO Roles (RoleName) 
VALUES            ('Nurse')


--6] Insert a new patient record into the Patient table with the 
   --following details: FirstName = 'Alice', 
   --                   LastName = 'Green', 
			--		  Dob = '1995-07-22', 
			--		  Gender = 500, 
			--		  PatientLanguage = 510,
			--		  Ethnicity = 506, 
			--		  CreatedBy = 1.


INSERT INTO Patient (FirstName, LastName, Dob, Gender, PatientLanguage, Ethnicity, CreatedBy)
VALUES              ('Alice', 'Green', '1995-07-22', 500, 510, 506, 1)


--7] Create a CTE that lists all practitioners and their appointment counts.


WITH PractitionersAppointmentCountsCTE AS (
	SELECT    pract.FirstName, pract.LastName, pract.Specialty, COUNT(pract.PractitionerId) as [Number of Appointment] 
	FROM      Practitioners as pract 
	left join Appointment as app on pract.PractitionerId = app.PractitionerId 
	GROUP BY  pract.FirstName, pract.LastName, pract.Specialty
)

SELECT * FROM PractitionersAppointmentCountsCTE


--8] Write a CTE to find all patients who have had appointments in the last 30 days.


-- INSERTING NEW APPOINTMENT FOR CHECKING IF IT IS WORKING OR NOT
INSERT INTO Appointment (PatientId, PractitionerId, AppointmentDate, AppointmentTime, StatusId, CreatedBy, CreatedDatetime)
VALUES 
(16, 1, '2024-10-1', '10:00:00', 300, 1, GETDATE())

WITH PatientCTE AS (
	SELECT    CONCAT(pat.FirstName, ' ', pat.LastName) as [Patient Name], app.AppointmentDate, app.AppointmentTime, app.PractitionerId
	FROM      Patient as pat 
	left join Appointment as app on pat.PatientId = app.PatientId 
	WHERE     app.AppointmentDate >= DATEADD(DAY, -30, GETDATE())
)

SELECT * FROM PatientCTE


--9] Write a SQL query that retrieves all patient names and their email contacts, using ISNULL to display 
--  'No Email' if the contact is missing.


SELECT    CONCAT(pat.FirstName, ' ', pat.LastName) as [Patient Full Name], 
		  isnull(patcon.ContactValue, 'No Email') as [Contact Details]
FROM      Patient as pat 
left join PatientContact as patcon on pat.PatientId = patcon.PatientId
WHERE     patcon.ContactTypeId = 201  -- only checking email id so replace "no email" where email is null, not a contact ( 201 is for email id )



--10] Use ISNULL to replace any NULL values in the ContactValue field of the PatientContact table with 'No Contact'.


SELECT    CONCAT(pat.FirstName, ' ', pat.LastName) as [Patient Full Name], 
		  isnull(patcon.ContactValue, 'No Contact') as [Contact Details]
FROM      Patient as pat 
left join PatientContact as patcon on pat.PatientId = patcon.PatientId


--11] Create a view named ActivePatients that displays all patients who have an active status in the PatientContact table.


CREATE VIEW vwActivePatients
AS
SELECT    pat.*, patcon.ContactTypeId, patcon.ContactValue, patcon.Isactive
FROM      Patient as pat 
left join PatientContact as patcon on pat.PatientId = patcon.PatientId 
WHERE	  patcon.Isactive = 1;

SELECT * FROM vwActivePatients


--12] Write a query to create a view that shows the total number of appointments for each practitioner.


CREATE VIEW vwPractitionerNumberOfAppointment
AS
SELECT    pract.FirstName, pract.LastName, pract.Specialty, COUNT(pract.PractitionerId) as [Number of Appointment] 
FROM      Practitioners as pract 
left join Appointment as app on pract.PractitionerId = app.PractitionerId 
GROUP BY  pract.FirstName, pract.LastName, pract.Specialty;

SELECT * FROM vwPractitionerNumberOfAppointment --INSERTED ADDITIONAL APPOINTMENT AFTER RUNNING THIS SO CHANGES IN VALUES


--13] Write a query to get the patient with only EmailAddres.


SELECT * 
FROM   Patient as pat 
join   PatientContact as patcon on pat.PatientId = patcon.PatientId 
WHERE  patcon.ContactTypeId = 201


--14] Create a query to list all medications prescribed along with the associated patient's name and appointment date.


SELECT    CONCAT(pat.FirstName, ' ', pat.LastName) as [Patient Full Name], med.MedicationName, med.Dosage, app.AppointmentDate  
FROM      Patient as pat join Medication as med on pat.PatientId = med.PatientId 
left join Appointment as app on app.AppointmentId = med.AppointmentId


--15] Question: Create a stored procedure named GetPatientsByCriteria that accepts the following parameters:

--    @Gender INT
--    @Ethnicity INT
--    @CreatedBy SMALLINT

--The procedure should return a list of patients that match the specified gender, ethnicity, and creator.

/* 

select * from patient
select * from CategoryToCode
select * from GlobalCategory

EXECUTE SPGetPatientsByCriteria 500, 505, 1 

*/

CREATE OR ALTER PROCEDURE SPGetPatientsByCriteria @Gender INT = NULL,
												  @Ethnicity INT = NULL,
												  @CreatedBy SMALLINT = NULL
AS
BEGIN
	SELECT * 
	FROM   Patient as pat 
	WHERE  pat.Gender = @Gender and pat.Ethnicity = @Ethnicity and pat.CreatedBy = @CreatedBy 
END


--16]  Get Appointments by Patient and Status

--Question: Write a stored procedure named GetAppointmentsByPatientAndStatus that takes two parameters:

--    @PatientId INT
--    @StatusId SMALLINT

--This procedure should return all appointments for a specified patient that match the given status.


/* 

EXECUTE SPGetAppointmentsByPatientAndStatus 1, 300 

*/

CREATE OR ALTER PROCEDURE SPGetAppointmentsByPatientAndStatus @PatientId INT = NULL,
															  @StatusId SMALLINT = NULL
AS
BEGIN
	SELECT * 
	FROM   Patient as pat 
	join   Appointment as app on pat.PatientId = app.PatientId 
	WHERE  app.PatientId = @PatientId and app.StatusId = @StatusId
END


--17]. Update Patient Insurance Information

--Question: Create a stored procedure called UpdatePatientInsurance that accepts the following parameters:

--    @PatientId INT
--    @InsuranceProviderId INT
--    @PolicyNumber VARCHAR(50)
--    @CoverageDetails VARCHAR(200)

--The procedure should update the insurance information for a specific patient with the provided details.


/* 

EXECUTE SPUpdatePatientInsurance 1, 1, 'AHC123456', 'Half Converage' 
SELECT * FROM PatientInsurance

*/

CREATE OR ALTER PROCEDURE SPUpdatePatientInsurance @PatientId INT = NULL,
												   @InsuranceProviderId INT = NULL,
												   @PolicyNumber VARCHAR(50) = NULL,
												   @CoverageDetails VARCHAR(200) = NULL
AS
BEGIN
	UPDATE PatientInsurance 
	SET    InsuranceProviderId = @InsuranceProviderId, 
		   PolicyNumber = @PolicyNumber,
		   CoverageDetails = @CoverageDetails
	WHERE  PatientId = @PatientId
END



--18] . Get Practitioner Appointments in Date Range

--Question: Write a stored procedure named GetPractitionerAppointmentsInDateRange that takes three parameters:

--    @PractitionerId INT
--    @StartDate DATETIME
--    @EndDate DATETIME

--This procedure should return all appointments scheduled for a specific practitioner within the specified date range.


/* 

select * from Appointment
EXECUTE SPGetPractitionerAppointmentsInDateRange 1, '2023-10-01', '2023-10-5' 

*/

CREATE OR ALTER PROCEDURE SPGetPractitionerAppointmentsInDateRange @PractitionerId INT = NULL,
																   @StartDate DATETIME = NULL,
																   @EndDate DATETIME = NULL
AS
BEGIN
	SELECT * 
	FROM   Appointment as app 
	WHERE  app.PractitionerId = @PractitionerId and app.AppointmentDate BETWEEN @StartDate and @EndDate
END



--19]. Insert New Contact for Patient

--Question: Create a stored procedure called InsertPatientContact that accepts the following parameters:

--    @PatientId INT
--    @ContactTypeId SMALLINT
--    @ContactValue VARCHAR(100)
--    @IsActive BIT

/* 

EXECUTE SPInsertPatientContact 2, 200, 0987654321, 1
select * from PatientContact

*/

CREATE OR ALTER PROCEDURE SPInsertPatientContact @PatientId INT = NULL,
												 @ContactTypeId SMALLINT = NULL,
												 @ContactValue VARCHAR(100) = NULL,
												 @IsActive BIT = NULL
AS
BEGIN
	INSERT INTO PatientContact (PatientId, ContactTypeId, ContactValue, Isactive, CreateDatetime) 
	VALUES                     (@PatientId, @ContactTypeId, @ContactValue, @IsActive, GETDATE())
END




--20] Create stored procedure which accepts 5 parameters
--  @PatientId,
--	@PatientFirstName,
--	@AppointmentStatus,
--	@Roles

--fetch data based on 
--PatientId and PatientFirstName
--AppointmentStatus,
--Roles


/* 

EXECUTE SPInsertPatientContact 1, 'John', 300, 'Dean'

select * from Patient
select * from Appointment
select * from AppointmentStatus
select * from Roles
select * from Users
*/


CREATE OR ALTER PROCEDURE SPInsertPatientContact @PatientId INT = NULL,
												 @PatientFirstName VARCHAR(70) = NULL,
												 @AppointmentStatus INT = NULL,
												 @RoleName VARCHAR(50) = NULL 
AS
BEGIN
	SELECT    *
	FROM      Patient as pat 
	left join Appointment as app on pat.PatientId = app.PatientId
	left join Users as [user] on [user].UserId = app.CreatedBy
	left join Roles as [role] on [role].RoleId = [user].RoleId
	WHERE     pat.PatientId = @PatientId and pat.FirstName = @PatientFirstName and app.StatusId = @AppointmentStatus and [Role].RoleName = @RoleName
END



--21] Write a SQL query to select all patients and display their 
--   names along with a new column called AgeGroup, which categorizes 
--   patients into 'Child' (age < 18), 'Adult' (age 18-65), and 'Senior' (age > 65) based on their date of birth.


SELECT

CONCAT(FirstName, ' ', LastName) as [Full Name], dob,
CASE
	when DATEDIFF(YEAR, Dob, GETDATE()) < 18 then 'Child'
	when DATEDIFF(YEAR, Dob, GETDATE()) BETWEEN 18 and 65 then 'Adult'
	when DATEDIFF(YEAR, Dob, GETDATE()) > 65 then 'Senior'
end as AgeGroup

FROM Patient


--22] Create a query that retrieves all patients and displays a new column InsuranceStatus. 
--    Use the IIF function to show 'Insured' if the patient has an insurance record and 'Uninsured' otherwise.


SELECT    pat.*, iif(patins.PatientInsuranceId is NULL,'Uninsured','Insured') as InsuranceStatus 
FROM      Patient as pat 
left join PatientInsurance as patins on pat.PatientId = patins.PatientId 


--23] Give me a select query which get date after 20 days 


SELECT DATEADD(Day, 20, GETDATE()) AS [Date After 20 Days];


--24] Question: Write a SQL query to retrieve a list of all appointments along with the following information:

--    Patient's FirstName and LastName
--    Practitioner's FirstName and LastName
--    Appointment Date and Time
--    Appointment Status Description


SELECT    CONCAT(pat.FirstName, ' ', pat.LastName) as [Patient Full Name], 
		  CONCAT(pract.FirstName, ' ', pract.LastName) as [Practitioner Full Name], 
	      app.AppointmentDate, app.AppointmentTime, appstat.StatusDescription
FROM      Patient as pat 
left join Appointment as app on pat.PatientId = app.PatientId
left join Practitioners as pract on app.PractitionerId = pract.PractitionerId 
left join AppointmentStatus as appstat on appstat.StatusId = app.StatusId


--25] Patient Insurance and Contact Information

--Question: Create a query that retrieves the following details for each patient:

--    Patient's Full Name (FirstName and LastName)
--    Insurance Provider Name
--    Contact Value from PatientContact
--    Contact Type Description


SELECT    CONCAT(pat.FirstName, ' ', pat.LastName), inspro.InsuranceProviderName, patcon.ContactValue, contype.ContactType
FROM      Patient as pat 
left join PatientInsurance as patins on pat.PatientId = patins.PatientId
left join InsuranceProviders as inspro on patins.InsuranceProviderId = inspro.InsuranceProviderId
left join PatientContact as patcon on pat.PatientId = patcon.PatientId
left join ContactType as contype on patcon.ContactTypeId = contype.ContactTypeId



--26] Question: Write a query that displays the following details:

--    Patient's Full Name (FirstName and LastName)
--    Medication Name
--    Practitioner’s Full Name (FirstName and LastName) who prescribed the medication
--    Appointment Date


SELECT    CONCAT(pat.FirstName, ' ', pat.LastName) as [Patient Full Name], med.MedicationName, 
          CONCAT(pract.FirstName, ' ', pract.LastName) as [Practitioner Full Name], app.AppointmentDate  
FROM      Patient as pat 
left join Medication as med on pat.PatientId = med.PatientId 
left join Appointment as app on pat.PatientId = app.PatientId
left join Practitioners as pract on app.PractitionerId = pract.PractitionerId


--27] Question: Create a query that retrieves a summary of claims for each patient, including:

--    Patient's Full Name
--    Appointment Date
--    Claim Status
--    Practitioner's Full Name who handled the appointment


SELECT    CONCAT(pat.FirstName, ' ', pat.LastName) as [Patient Full Name], app.AppointmentDate, claim.ClaimStatus,
	      CONCAT(pract.FirstName, ' ', pract.LastName) as [Practitioner Full Name]
FROM      Patient as pat 
left join Appointment as app on pat.PatientId = app.PatientId
left join ClaimProcess as claim on claim.AppointmentId = app.AppointmentId
left join Practitioners as pract on app.PractitionerId = pract.PractitionerId


--28] Question: Write a SQL query to list all patients along with their address and insurance details, including:

--    Patient's Full Name
--    Address Line 1 and Line 2
--    Insurance Provider Name
--    Coverage Details


SELECT    CONCAT(pat.FirstName, ' ', pat.LastName) as [Patient Full Name], 
		  patadd.AddressLine1, patadd.AddressLine2, inspro.InsuranceProviderName, patins.CoverageDetails  
FROM      Patient as pat 
left join PatientAddress as patadd on pat.PatientId = patadd.PatientId
left join PatientInsurance as patins on pat.PatientId = patins.PatientId 
left join InsuranceProviders as inspro on patins.InsuranceProviderId = inspro.InsuranceProviderId











      

















