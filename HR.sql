USE [master]
GO
/****** Object:  Database [HR]    Script Date: 5/6/2024 5:14:30 PM ******/
CREATE DATABASE [HR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HR.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HR_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HR] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HR] SET ARITHABORT OFF 
GO
ALTER DATABASE [HR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HR] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HR] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HR] SET  MULTI_USER 
GO
ALTER DATABASE [HR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HR] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HR] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HR] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HR] SET QUERY_STORE = OFF
GO
USE [HR]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/6/2024 5:14:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [varchar](50) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Role] [varchar](20) NOT NULL,
	[Name] [varchar](100) NULL,
	[ICNo] [varchar](20) NULL,
	[Gender] [varchar](10) NULL,
	[Address] [text] NULL,
	[ContactNo] [varchar](20) NULL,
	[EmailAddress] [varchar](100) NULL,
 CONSTRAINT [PK__Users__1788CCAC7AE2B6E3] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (1, N'uig1234', N'1234', N'Admin', N'lim', N'002002-10-2939', N'Female', NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (2, N'uid12', N'1111', N'Employee', N'Grace', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (3, N'EMP01', N'1234', N'Admin', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (4, N'test123', N'12', N'Admin', N'tan', N'02012012020', N'Female', N'No12, ureureo', N'01923923923', N'tan@gmail.com')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (5, N'EMP02', N'5678', N'Employee', N'Rany', N'0238473893', N'Male', N'No8943 Taman dydy', N'023883372', N'rany@gmail.com')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (6, N'EMP03', N'03', N'Employee', N'Law', N'45678776543', N'Male', N'no22323', N'67893345', N'law@gmail.com')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (7, N'EMP04', N'04', N'Employee', N'Tin', N'0398439', N'Female', N'No 12222', N'0238781293', N'tin@gmail.com')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (8, N'EMP05', N'05', N'Employee', N'Yap', N'749322-08-4232', N'Male', N'No12, 383y3', N'032927323', N'yap@gmail.com')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (9, N'EMP06', N'06', N'Employee', N'Jam', N'8912039320392', N'Female', N'No122, Taman', N'012532342543', N'jam@gmail.com')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (10, N'EMP07', N'07', N'Admin', N'Wan', N'29128127187212712', N'Female', N'No66', N'9218561278', N'wan@gmail.com')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (11, N'EMP09', N'09', N'Employee', N'Nini', N'049389383', N'Male', N'No1233', N'03847832', N'nini@gmail.com')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (12, N'EMP10', N'10', N'Employee', N'ren', N'4565483291', N'Male', N'No1234532', N'034589483', N'ren@gmail.com')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (13, N'EMP11', N'11', N'Employee', N'Han', N'973657682798', N'Female', N'No2637', N'283767281', N'han@gmail.com')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (14, N'EMP12', N'12', N'Employee', N'yewq', N'12737761298', N'Female', N'No3a Pro', N'w6w12', N'6wqw78q7w')
INSERT [dbo].[Users] ([UserID], [EmployeeID], [Password], [Role], [Name], [ICNo], [Gender], [Address], [ContactNo], [EmailAddress]) VALUES (15, N'uig1', N'1', N'Employee', N'y', N'987664532', N'Male', N'No9 Taman yas', N'02345654312', N'y@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__7AD04FF093D4817F]    Script Date: 5/6/2024 5:14:31 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__Users__7AD04FF093D4817F] UNIQUE NONCLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [HR] SET  READ_WRITE 
GO
