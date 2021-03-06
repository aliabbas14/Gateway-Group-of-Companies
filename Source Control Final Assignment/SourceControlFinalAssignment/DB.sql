USE [master]
GO
/****** Object:  Database [SourceControlFinalAssignment]    Script Date: 11-01-2021 01:35:57 PM ******/
CREATE DATABASE [SourceControlFinalAssignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SourceControlFinalAssignment', FILENAME = N'C:\Users\aliabbas\SourceControlFinalAssignment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SourceControlFinalAssignment_log', FILENAME = N'C:\Users\aliabbas\SourceControlFinalAssignment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SourceControlFinalAssignment] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SourceControlFinalAssignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SourceControlFinalAssignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET  MULTI_USER 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SourceControlFinalAssignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SourceControlFinalAssignment] SET QUERY_STORE = OFF
GO
USE [SourceControlFinalAssignment]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [SourceControlFinalAssignment]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 11-01-2021 01:35:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[RegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](70) NOT NULL,
	[Dob] [datetime] NOT NULL,
	[Phone] [varchar](20) NULL,
	[Password] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [int] NOT NULL,
	[Address] [varchar](200) NULL,
	[photo] [varchar](50) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[system_logging]    Script Date: 11-01-2021 01:35:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[system_logging](
	[system_logging_guid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[entered_date] [datetime] NULL,
	[log_application] [varchar](200) NULL,
	[log_date] [varchar](100) NULL,
	[log_level] [varchar](100) NULL,
	[log_logger] [varchar](8000) NULL,
	[log_message] [varchar](8000) NULL,
	[log_machine_name] [varchar](8000) NULL,
	[log_user_name] [varchar](8000) NULL,
	[log_call_site] [varchar](8000) NULL,
	[log_thread] [varchar](100) NULL,
	[log_exception] [varchar](8000) NULL,
	[log_stacktrace] [varchar](8000) NULL,
 CONSTRAINT [PK_system_logging_1] PRIMARY KEY CLUSTERED 
(
	[system_logging_guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [SourceControlFinalAssignment] SET  READ_WRITE 
GO
