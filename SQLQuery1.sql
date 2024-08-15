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
VALUES ('Nguyen Van A', '2000-08-15', 'Nam', 'Hà Nội', '0123456789', 'nguyenvana@gmail.com');

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

INSERT INTO Teacher (FullName, DateOfBirth, Gender, Address, Phone, Email, Major)
VALUES ('Tran Thi B', '1980-05-20', 'Nữ', 'Hà Nội', '0987123456', 'tranthib@gmail.com', 'Toán học');

UPDATE Teacher
SET Address = 'Ha Noi', Phone = '0978345678'
WHERE TeacherID = 2;

SELECT * FROM Teacher
WHERE FullName LIKE '%Tran Thi B%';


-- Thêm dữ liệu mẫu vào bảng Teacher
INSERT INTO Teacher (FullName, DateOfBirth, Gender, Address, Phone, Email, Major)
VALUES ('Linh Nguyen', '1980-05-15', 'Female', '456 Main St', '0909876543', 'linh@gmail.com', 'Mathematics');
GO

-- Tạo bảng Courses
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(100) NOT NULL,
    TeacherID INT FOREIGN KEY REFERENCES Teacher(TeacherID)
);
GO

-- Thêm dữ liệu mẫu vào bảng Courses
INSERT INTO Courses (CourseName, TeacherID)
VALUES ('SE07102', 1);
GO

-- Tạo bảng Score
CREATE TABLE Score(
    ScoreID INT PRIMARY KEY IDENTITY(1,1),
    Scorename NVARCHAR(100) NOT NULL,
    Part1 FLOAT NOT NULL,
    Part2 FLOAT NOT NULL,
    Final FLOAT NOT NULL,
    StudentID INT FOREIGN KEY REFERENCES Student(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID)
);
GO

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
SELECT Student.FullName, Courses.CourseName, Score.Scorename, Score.Part1, Score.Part2, Score.Final
FROM Score
JOIN Student ON Score.StudentID = Student.StudentID
JOIN Courses ON Score.CourseID = Courses.CourseID
WHERE Student.StudentID = 1;
GO

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

-- Tạo bảng Enrollments
CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT FOREIGN KEY REFERENCES Student(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID)
);
GO

-- Tạo bảng Attendance
CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT FOREIGN KEY REFERENCES Student(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    AttendanceDate DATE,
    Status NVARCHAR(20)
);
GO

-- Tạo bảng Mark
CREATE TABLE Mark(
    S_ID INT FOREIGN KEY REFERENCES Student(StudentID),
    C_ID INT FOREIGN KEY REFERENCES Courses(CourseID),
    Attendance NVARCHAR(10) NOT NULL CHECK (Attendance LIKE '%'),
    Assm1 INT NOT NULL,
    Assm2 INT NOT NULL,
    CONSTRAINT PK_Mark PRIMARY KEY(S_ID, C_ID)
);
GO

-- Truy vấn lấy thông tin từ bảng Mark
SELECT Mark.S_ID, Student.FullName, Mark.C_ID, Courses.CourseName, Mark.Attendance, Mark.Assm1, Mark.Assm2
FROM Mark
LEFT JOIN Student ON Mark.S_ID = Student.StudentID
LEFT JOIN Courses ON Mark.C_ID = Courses.CourseID;
GO
