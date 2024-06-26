USE [StudentCourseDB]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 07-04-2024 16:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 07-04-2024 16:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[Gender] [char](1) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 07-04-2024 16:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[StudentCourseId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[CourseId] [int] NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[StudentCourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllCourses]    Script Date: 07-04-2024 16:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedure to retrieve all courses
CREATE PROCEDURE [dbo].[SP_GetAllCourses]
AS
BEGIN
    SELECT * FROM Course
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllStudents]    Script Date: 07-04-2024 16:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedure to retrieve all students
CREATE PROCEDURE [dbo].[SP_GetAllStudents]
AS
BEGIN
    SELECT * FROM Student
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertCourse]    Script Date: 07-04-2024 16:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedure to insert a new course
CREATE PROCEDURE [dbo].[SP_InsertCourse]
    @CourseName VARCHAR(50)
AS
BEGIN
    INSERT INTO Course (CourseName)
    VALUES (@CourseName)
END

GO
/****** Object:  StoredProcedure [dbo].[SP_InsertStudent]    Script Date: 07-04-2024 16:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedure to insert a new student
CREATE PROCEDURE [dbo].[SP_InsertStudent]
    @StudentName VARCHAR(50),
    @DateOfBirth DATE,
    @Gender VARCHAR(1)
AS
BEGIN
    INSERT INTO Student (StudentName, DateOfBirth, Gender)
    VALUES (@StudentName, @DateOfBirth, @Gender)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertStudentCourse]    Script Date: 07-04-2024 16:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Procedure to assign a course to a student
CREATE PROCEDURE [dbo].[SP_InsertStudentCourse]
    @StudentId INT,
    @CourseId INT
AS
BEGIN
    INSERT INTO StudentCourse (StudentId, CourseId)
    VALUES (@StudentId, @CourseId)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCourse]    Script Date: 07-04-2024 16:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedure to insert a new student
Create PROCEDURE [dbo].[SP_UpdateCourse]
	@CourseId Int,
    @CourseName VARCHAR(50)
AS
BEGIN
    UPDATE Course 
	SET 
		CourseName = @CourseName 
		where  CourseId = @CourseId;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateStudent]    Script Date: 07-04-2024 16:40:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedure to insert a new student
CREATE PROCEDURE [dbo].[SP_UpdateStudent]
	@StudentId Int,
    @StudentName VARCHAR(50),
    @DateOfBirth DATE,
    @Gender VARCHAR(1)
AS
BEGIN
    UPDATE Student 
	SET 
		StudentName = @StudentName,
		DateOfBirth = @DateOfBirth,
		@Gender=@Gender 
		where  StudentId = @StudentId;
END
GO
