/********************************************************************************************************
                                         SQL Assessment 2                            Total Marks - 20
*********************************************************************************************************/


-- Execute below tables with the data and Solve the Questions

CREATE DATABASE assessment2;
USE assessment2;



CREATE TABLE Patient (
    PatientId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    Active BIT,
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO Patient (FirstName, LastName, DateOfBirth, Gender, Active) 
VALUES ('Sam', 'Will', '1985-06-15', 'Male', 1),
       ('Mark', 'Wagh', '1990-03-10', 'Female', 1),
	   ('Maria', 'Joseph', '1990-03-10', 'Female', 1),
	   ('Jane', 'Foster', '1990-03-10', 'Female', 1),
	   ('Ramesh', 'Kumar', '1990-03-10', 'Male', 0),
	   ('Will', 'Smith', '1990-03-10', 'Male', 1),
	   ('Julia', 'Robert', '1990-03-10', 'Female', 0)



CREATE TABLE PatientContact (
    ContactId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
    ContactType NVARCHAR(50),
    ContactValue NVARCHAR(100),
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO PatientContact (PatientId, ContactType, ContactValue) 
VALUES (1, 'phone', '9638527412'),
       (2, 'phone', '8638527412'),
       (3, 'phone', '7638527412'),
	   (4, 'phone', '6638527412'),
	   (5, 'phone', '5638527412'),
	   (6, 'phone', '4638527412')




CREATE TABLE Practitioner (
    PractitionerId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Specialty NVARCHAR(100),
    Active BIT,
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO Practitioner (FirstName, LastName, Specialty, Active)
VALUES ('Dr. Alice', 'Wong', 'Cardiology', 1),
       ('Dr. Bob', 'Lee', 'Neurology', 1),
	   ('Dr. Ashish', 'Gaikwad', 'Opth', 1),
	   ('Dr. Robin', 'Lee', 'Gnya', 1)





CREATE TABLE AppointmentStatus (
    AppointmentStatusId INT PRIMARY KEY IDENTITY(1,1),
    Status NVARCHAR(50),
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO AppointmentStatus (Status)
VALUES ('Scheduled'),
       ('Completed'),
       ('Cancelled');



CREATE TABLE Appointment (
    AppointmentId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
    AppointmentStatusId INT,
    AppointmentDate DATETIME,
    Reason NVARCHAR(255),
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO Appointment (PatientId, AppointmentStatusId, AppointmentDate, Reason)
VALUES (1, 1, '2024-09-25 10:00', 'Routine Checkup'),
       (2, 2, '2024-09-25 11:30', 'Follow-up'),
	   (3, 1, '2024-09-25 12:30', 'Routine Checkup'),
	   (4, 1, '2024-09-25 03:30', 'Follow-up'),
	   (5, 3, '2024-09-25 05:30', 'Routine Checkup')




CREATE TABLE PatientPractitionerAppointmentMapping (
    MappingId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT FOREIGN KEY REFERENCES Patient(PatientId),
    PractitionerId INT FOREIGN KEY REFERENCES Practitioner(PractitionerId),
    AppointmentId INT FOREIGN KEY REFERENCES Appointment(AppointmentId),
    CreatedDatetime DATETIME DEFAULT GETDATE()
);

-- Sample Data
INSERT INTO PatientPractitionerAppointmentMapping (PatientId, PractitionerId, AppointmentId)
VALUES (1, 1, 1),
       (2, 2, 2),
	   (5, 3, 2),
	   (6, 4, 2)




select * from Patient
select * from PatientContact
select * from Practitioner
select * from AppointmentStatus
select * from Appointment
select * from PatientPractitionerAppointmentMapping









-- 1] Retrieve all patient details along with their appointment status with only Active patients.

SELECT    p.*, aps.[Status]
FROM      Patient as p
LEFT JOIN Appointment as a 
ON        p.PatientId = a.PatientId
LEFT JOIN AppointmentStatus as aps
ON        a.AppointmentStatusId = aps.AppointmentStatusId
WHERE     P.Active = 1


-- 2] Fetch the names of patients along with their practitioner for each appointment.

SELECT     pat.FirstName, pat.LastName, prac.FirstName, prac.LastName 
FROM       Patient as pat
INNER JOIN PatientPractitionerAppointmentMapping as ppam 
ON         pat.PatientId = ppam.PatientId 
INNER JOIN Practitioner as prac 
ON         ppam.PractitionerId = prac.PractitionerId


-- 3] Get the contact details of all patients who have an appointment. 

SELECT     pat.*, pc.* 
FROM       Patient as pat 
INNER JOIN Appointment as app 
ON         Pat.PatientId = app.PatientId 
LEFT JOIN  PatientContact as pc 
ON         pat.PatientId = pc.PatientId



-- 4] Find the appointment details for a patient named 'Sam Will'.

SELECT     * 
FROM       Patient as pat 
INNER JOIN Appointment as app 
ON         pat.PatientId = app.PatientId
WHERE      pat.FirstName = 'Sam' and pat.LastName = 'Will'


-- 5] List all practitioners along with the patients they have treated.

SELECT     pat.*, pract.* 
FROM       Patient as pat 
INNER JOIN PatientPractitionerAppointmentMapping as ppam 
ON         pat.PatientId = ppam.PatientId 
INNER JOIN Practitioner as pract 
ON         ppam.PractitionerId = pract.PractitionerId


-- 6] Retrieve a list of all patients and their corresponding appointment status (if any).

SELECT     pat.*, appst.[Status]
FROM       Patient as pat
LEFT JOIN Appointment as app
ON         pat.PatientId = app.PatientId
LEFT JOIN  AppointmentStatus as appst
ON         appst.AppointmentStatusId = app.AppointmentStatusId


-- 7] Fetch the patient details along with their contact information. Include patients without contact details.

SELECT    * 
FROM      Patient as pat 
FULL JOIN PatientContact as patcon 
ON        pat.PatientId = patcon.PatientId


-- 8] List all patients and their practitioner for each appointment, showing patients even if they don't have a practitioner assigned.

SELECT     pat.FirstName, pat.LastName, prac.FirstName, prac.LastName 
FROM       Patient as pat
FULL JOIN PatientPractitionerAppointmentMapping as ppam 
ON         pat.PatientId = ppam.PatientId 
FULL JOIN Practitioner as prac 
ON         ppam.PractitionerId = prac.PractitionerId


-- 9] Get all practitioners and their appointments, including those practitioners without any appointments.


-- 10] Give me list off patients with contact details and having AppointmentReason = 'Follow-up'



-- 11] Count how many appointments each patient has.

SELECT app.AppointmentId, count(*) as Appointment from Patient as pat inner join Appointment as app on pat.PatientId = app.PatientId group by app.AppointmentId

-- 12] Retrieve the number of patients for each gender.

SELECT   Gender, count(Gender) as Number_Of_Patient 
FROM     Patient 
GROUP BY Gender


-- 13] Give PatientName,PractitionerName,with their appointmentStatus.


-- 14] Give me Patient,Practitioner,Appointment,AppointmentStatus informatin using joins






-- Stored Procedure Questions:   [2 Marks Each]

-- 15] Write a stored procedure that takes a PatientId as input and returns the patient's contact details.

CREATE PROCEDURE GetPatientContactDetails
										  @patientId INT
AS
BEGIN
    SELECT *
	FROM PatientContact
	WHERE PatientId = @patientId
END;

EXEC GetPatientContactDetails @patientId = 3

--16] Write a stored procedure that takes PractitionerId as input and returns all the appointments they have.

CREATE PROCEDURE GetPractitionerAppointments
											@practitionerId INT
AS
BEGIN
	SELECT app.*
	FROM   Appointment as app
	JOIN   PatientPractitionerAppointmentMapping as ppam 
	ON     app.AppointmentId = ppam.AppointmentId
END;

EXEC GetPractitionerAppointments @practitionerId = 1


-- 17] Create a stored procedure to add a new patient, taking FirstName, LastName, DateOfBirth, and Gender as parameters.




*/



