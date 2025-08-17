INSERT INTO Departments (DepartmentID, Name, Budget) VALUES (1,
'Computer Science', 50000);
INSERT INTO Courses (CourseID, Title, Credits, DepartmentID) VALUES
(1, 'Database Systems', 4, 1);
INSERT INTO Students (StudentID, FirstName, LastName, EnrollmentDate,
Email) VALUES (1, 'John', 'Doe', '2023-01-10',
'john.doe@example.com');
INSERT INTO Enrollments (EnrollmentID, CourseID, StudentID, Grade)
VALUES (1, 1, 1, 95);
