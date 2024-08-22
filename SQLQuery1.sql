-- Tạo cơ sở dữ liệu
CREATE DATABASE StudentSystem;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE StudentSystem;
GO

-- Tạo bảng Student
CREATE TABLE Student(
    StudentID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
    FullName NVARCHAR(50),
    DateOfBirth DATETIME,
    Gender NVARCHAR(50) CHECK (Gender IN ('Male', 'Female')),
    Address NVARCHAR(100),
    Phone NVARCHAR(50),
    Email NVARCHAR(100)
);
GO

SELECT * FROM Student
WHERE FullName LIKE '%Nguyen Van A%';

INSERT INTO Student (FullName, DateOfBirth, Gender, Address, Phone, Email)
VALUES ('Nguyen Van A', '2000-08-15', 'Male', 'Hà Nội', '0123456789', 'nguyenvana@gmail.com');
GO

UPDATE Student
SET Address = 'TP.HCM', Phone = '0987654321'
WHERE StudentID = 1;

DELETE FROM Student
WHERE StudentID = 1;


-- Thêm dữ liệu mẫu vào bảng Student
INSERT INTO Student (FullName, DateOfBirth, Gender, Address, Phone, Email)
VALUES ('An Nguyen', '2000-01-01', 'Male', '123 Main St', '0909123456', 'an@gmail.com');
GO

-- Tạo bảng Teacher
CREATE TABLE Teacher(
    TeacherID INT PRIMARY KEY IDENTITY(1,1), 
    FullName NVARCHAR(50),
    DateOfBirth DATETIME,
    Gender NVARCHAR(50) CHECK (Gender IN ('Male', 'Female')),
    Address NVARCHAR(100),
    Phone NVARCHAR(50),
    Email NVARCHAR(100),
    Major NVARCHAR(50)
);
GO

SET IDENTITY_INSERT Teacher ON;
INSERT INTO Teacher (FullName, TeacherID, DateOfBirth, Gender, Address, Phone, Email, Major)
VALUES ('Tran Thi B', '1', '1980-05-20', 'Male', 'Hà Nội', '0987123456', 'tranthib@gmail.com', 'Toán học');
SET IDENTITY_INSERT Teacher OFF;

UPDATE Teacher
SET Address = 'Ha Noi', Phone = '0978345678'
WHERE TeacherID = 2;

SELECT * FROM Teacher
WHERE FullName LIKE '%Tran Thi B%';


-- Thêm dữ liệu mẫu vào bảng Teacher
IF NOT EXISTS (SELECT 1 FROM Teacher WHERE TeacherID = 2)
BEGIN
INSERT INTO Teacher (FullName, TeacherID, DateOfBirth, Gender, Address, Phone, Email, Major)
VALUES ('Linh Nguyen', '2', '1980-05-15', 'Female', '456 Main St', '0909876543', 'linh@gmail.com', 'Mathematics');
END

DBCC CHECKIDENT ('Teacher', RESEED, 1);
SELECT * FROM[dbo].[Teacher]

-- Tạo bảng Courses
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(100) NOT NULL,
    TeacherID INT FOREIGN KEY REFERENCES Teacher(TeacherID)
);
GO

SELECT * FROM Teacher WHERE TeacherID = 1;

-- Thêm dữ liệu mẫu vào bảng Courses
INSERT INTO Courses (CourseName, TeacherID)
VALUES ('SE07102', 1); 
GO

 SELECT * FROM[dbo].[Courses]


 SELECT
    s.StudentID,
    s.FullName,
    c.CourseID,
    c.CourseName
FROM
    Student s
LEFT JOIN
    Score sc ON s.StudentID = sc.StudentID
LEFT JOIN
    Courses c ON sc.CourseID = c.CourseID;
GO



-- Tạo bảng Score
CREATE TABLE Score (
    ScoreID INT PRIMARY KEY IDENTITY(1,1),
    Scorename NVARCHAR(100) NOT NULL,
    Part1 FLOAT NOT NULL,
    Part2 FLOAT NOT NULL,
    Final FLOAT NOT NULL,
    StudentID INT NOT NULL, -- StudentID is required
    CourseID INT NOT NULL, -- CourseID is required
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);
GO

SELECT StudentID FROM Student WHERE FullName = 'Nguyen Van A';
SELECT CourseID FROM Courses WHERE CourseName = 'SE07102';

-- Thêm dữ liệu mẫu vào bảng Score
INSERT INTO Score (Scorename, Part1, Part2, Final, StudentID, CourseID)
VALUES ('Midterm Exam', 8.0, 7.5, 8.5, 1, 1); 
GO

-- Truy vấn cập nhật điểm
UPDATE Score
SET Final = 9.0
WHERE StudentID = 1 AND CourseID = 1;
GO

-- Truy vấn xóa điểm
DELETE FROM Score
WHERE StudentID = 1 AND CourseID = 1;
GO

-- Truy vấn lấy thông tin điểm
SELECT
    s.FullName AS StudentName,
    sc.Scorename,
    sc.Part1,
    sc.Part2,
    sc.Final,
    c.CourseName
FROM
    Score sc
JOIN
    Student s ON sc.StudentID = s.StudentID
JOIN
    Courses c ON sc.CourseID = c.CourseID;
GO

SELECT * FROM[dbo].[Score]

-- Tạo bảng Users
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);
GO

-- Thêm dữ liệu mẫu vào bảng Users
INSERT INTO Users (Username, Password, Role)
VALUES ('linhne', '1234', '1'),
       ('admin', '5678', '2');
GO

-- Xóa toàn bộ dữ liệu trong bảng Student và Score
DELETE FROM Student;
DELETE FROM Score;
GO

SELECT * FROM[dbo].[Users]

-- Tạo bảng Enrollments
CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT FOREIGN KEY REFERENCES Student(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID)
);
GO



DROP TABLE Score;
GO

CREATE TABLE Score (
    ScoreID INT PRIMARY KEY IDENTITY(1,1),
    Scorename NVARCHAR(100) NOT NULL,
    Part1 FLOAT NOT NULL,
    Part2 FLOAT NOT NULL,
    Final FLOAT NOT NULL,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);
GO

SELECT * FROM sys.objects WHERE name = N'Scores';

INSERT INTO Score (Scorename, Part1, Part2, Final, StudentID, CourseID)
VALUES ('Midterm Exam', 8.0, 7.5, 8.5, 1, 1); 
GO

