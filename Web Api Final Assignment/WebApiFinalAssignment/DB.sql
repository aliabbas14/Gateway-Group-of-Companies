USE [master]
GO
/****** Object:  Database [WebApiFinalAssignment]    Script Date: 14-01-2021 07:33:40 PM ******/
CREATE DATABASE [WebApiFinalAssignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebApiFinalAssignment', FILENAME = N'C:\Users\aliabbas\WebApiFinalAssignment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WebApiFinalAssignment_log', FILENAME = N'C:\Users\aliabbas\WebApiFinalAssignment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [WebApiFinalAssignment] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WebApiFinalAssignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WebApiFinalAssignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WebApiFinalAssignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WebApiFinalAssignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WebApiFinalAssignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WebApiFinalAssignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WebApiFinalAssignment] SET  MULTI_USER 
GO
ALTER DATABASE [WebApiFinalAssignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WebApiFinalAssignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WebApiFinalAssignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WebApiFinalAssignment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WebApiFinalAssignment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WebApiFinalAssignment] SET QUERY_STORE = OFF
GO
USE [WebApiFinalAssignment]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [WebApiFinalAssignment]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 14-01-2021 07:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[RoomId] [int] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 14-01-2021 07:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Pincode] [nvarchar](10) NOT NULL,
	[ContactNumber] [nvarchar](20) NOT NULL,
	[ContactPerson] [nvarchar](50) NOT NULL,
	[Website] [nvarchar](50) NOT NULL,
	[Facebook] [nvarchar](70) NOT NULL,
	[Twitter] [nvarchar](70) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 14-01-2021 07:33:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HotelId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hotels] ADD  CONSTRAINT [DF_Hotels_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Rooms] ADD  CONSTRAINT [DF_Rooms_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Rooms] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Rooms]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Hotels] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotels] ([Id])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Hotels]
GO
USE [master]
GO
ALTER DATABASE [WebApiFinalAssignment] SET  READ_WRITE 
GO
