-- Create the new database
CREATE DATABASE UniPortalDB;

-- Switch to the new database
USE UniPortalDB;

-- Create the Course table
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY AUTO_INCREMENT,
    Sub VARCHAR(255) NOT NULL, -- Subject
    ClassNumber INT NOT NULL
);

-- Create the Student table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY AUTO_INCREMENT,
    PasswordHash VARCHAR(255) NOT NULL,
    FullName VARCHAR(255) NOT NULL,
    DateOfBirth DATE NOT NULL
);

-- Create the Admin table
CREATE TABLE Admins (
    AdminID INT PRIMARY KEY AUTO_INCREMENT,
    PasswordHash VARCHAR(255) NOT NULL
);

-- Create the StudentCourse (junction) table for many-to-many relation
CREATE TABLE StudentCourses (
    StudentCourseID INT PRIMARY KEY AUTO_INCREMENT,
    StudentID INT,
    CourseID INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);
