USE [master]
GO
/****** Object:  Database [EHealthCare]    Script Date: 11/15/2015 13:26:02 ******/
CREATE DATABASE [EHealthCare] ON  PRIMARY 
( NAME = N'EHealthCare', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\EHealthCare.mdf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EHealthCare_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\EHealthCare_log.ldf' , SIZE = 7616KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EHealthCare] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EHealthCare].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EHealthCare] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [EHealthCare] SET ANSI_NULLS OFF
GO
ALTER DATABASE [EHealthCare] SET ANSI_PADDING OFF
GO
ALTER DATABASE [EHealthCare] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [EHealthCare] SET ARITHABORT OFF
GO
ALTER DATABASE [EHealthCare] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [EHealthCare] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [EHealthCare] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [EHealthCare] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [EHealthCare] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [EHealthCare] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [EHealthCare] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [EHealthCare] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [EHealthCare] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [EHealthCare] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [EHealthCare] SET  DISABLE_BROKER
GO
ALTER DATABASE [EHealthCare] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [EHealthCare] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [EHealthCare] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [EHealthCare] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [EHealthCare] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [EHealthCare] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [EHealthCare] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [EHealthCare] SET  READ_WRITE
GO
ALTER DATABASE [EHealthCare] SET RECOVERY SIMPLE
GO
ALTER DATABASE [EHealthCare] SET  MULTI_USER
GO
ALTER DATABASE [EHealthCare] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [EHealthCare] SET DB_CHAINING OFF
GO
USE [EHealthCare]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 11/15/2015 13:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [nvarchar](max) NULL,
	[User_Password] [nvarchar](max) NULL,
	[User_Phone] [nvarchar](max) NULL,
	[User_Mail] [nvarchar](max) NULL,
	[User_Country] [nvarchar](max) NULL,
	[User_Gender] [nvarchar](max) NULL,
	[User_DOB] [nvarchar](max) NULL,
	[User_Photo] [image] NULL,
	[Role_Id] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleDetails]    Script Date: 11/15/2015 13:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleDetails](
	[Role_Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](max) NULL,
	[Role_Details] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleDetails] PRIMARY KEY CLUSTERED 
(
	[Role_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReviewDetails]    Script Date: 11/15/2015 13:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReviewDetails](
	[Review_id] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [int] NULL,
	[Review_Text] [nvarchar](max) NULL,
	[Review_Date] [nvarchar](max) NULL,
	[Raised_By] [int] NULL,
	[User_Role] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReviewDetails] PRIMARY KEY CLUSTERED 
(
	[Review_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientDetails]    Script Date: 11/15/2015 13:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientDetails](
	[Patient_Id] [int] IDENTITY(1,1) NOT NULL,
	[Patient_State] [nvarchar](max) NULL,
	[Patient_Country] [nvarchar](max) NULL,
	[Patient_Hospital] [nvarchar](max) NULL,
	[Patient_Disease] [nvarchar](max) NULL,
	[Patient_Age] [nvarchar](max) NULL,
	[Patient_Gender] [nvarchar](max) NULL,
	[Patient_Report] [nvarchar](max) NULL,
	[Patient_Name] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[User_Id] [int] NULL,
	[Appo_Id]  AS ('APPO'+right('00'+CONVERT([varchar](5),[Patient_Id],(0)),(5))) PERSISTED,
	[Doc_Id] [int] NULL,
	[Appo_Date] [nvarchar](max) NULL,
	[IsConfirm] [bit] NULL,
 CONSTRAINT [PK_PatientDetails] PRIMARY KEY CLUSTERED 
(
	[Patient_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MedicineDetails]    Script Date: 11/15/2015 13:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicineDetails](
	[Med_Id] [int] IDENTITY(1,1) NOT NULL,
	[Med_Name] [nvarchar](max) NULL,
	[Med_Composition] [nvarchar](max) NULL,
	[Med_Disease] [nvarchar](max) NULL,
	[Med_Price] [int] NULL,
 CONSTRAINT [PK_MedicineDetails] PRIMARY KEY CLUSTERED 
(
	[Med_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HospitaMaster]    Script Date: 11/15/2015 13:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HospitaMaster](
	[Hospital_Id] [int] IDENTITY(1,1) NOT NULL,
	[Hospital_Name] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[Hospital_Full_Address] [nvarchar](max) NULL,
	[Hospital_Details] [nvarchar](max) NULL,
 CONSTRAINT [PK_HospitaMaster] PRIMARY KEY CLUSTERED 
(
	[Hospital_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorsDetails]    Script Date: 11/15/2015 13:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorsDetails](
	[Doc_Id] [int] IDENTITY(1,1) NOT NULL,
	[Doc_Name] [nvarchar](max) NULL,
	[Doc_Country] [nvarchar](max) NULL,
	[Doc_State] [nvarchar](max) NULL,
	[Doc_Hospital] [nvarchar](max) NULL,
	[Doc_Specialist] [nvarchar](max) NULL,
	[Doc_RegId] [nvarchar](max) NULL,
	[Doc_Exp] [nvarchar](max) NULL,
	[Doc_Details] [nvarchar](max) NULL,
	[Doc_Home_Fee] [nvarchar](max) NULL,
	[Doc_OnSite_Fee] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[User_Id] [int] NOT NULL,
 CONSTRAINT [PK_DoctorsDetails] PRIMARY KEY CLUSTERED 
(
	[Doc_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppoDetails]    Script Date: 11/15/2015 13:26:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppoDetails](
	[Appo_Id] [int] IDENTITY(1,1) NOT NULL,
	[Doc_Id] [int] NULL,
	[Appo_Date] [nvarchar](max) NULL,
	[Patient_Id] [int] NULL,
	[User_Id] [nvarchar](max) NULL,
	[IsConfirm] [bit] NULL,
	[Appo_Hospital] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppoDetails] PRIMARY KEY CLUSTERED 
(
	[Appo_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_UserDetails_IsActive]    Script Date: 11/15/2015 13:26:06 ******/
ALTER TABLE [dbo].[UserDetails] ADD  CONSTRAINT [DF_UserDetails_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
