USE [master]
GO
/****** Object:  Database [DotNetAssignment]    Script Date: 15-02-2021 11:40:40 AM ******/
CREATE DATABASE [DotNetAssignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DotNetAssignment', FILENAME = N'C:\Users\aliabbas\DotNetAssignment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DotNetAssignment_log', FILENAME = N'C:\Users\aliabbas\DotNetAssignment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DotNetAssignment] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DotNetAssignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DotNetAssignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DotNetAssignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DotNetAssignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DotNetAssignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DotNetAssignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [DotNetAssignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DotNetAssignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DotNetAssignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DotNetAssignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DotNetAssignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DotNetAssignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DotNetAssignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DotNetAssignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DotNetAssignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DotNetAssignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DotNetAssignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DotNetAssignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DotNetAssignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DotNetAssignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DotNetAssignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DotNetAssignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DotNetAssignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DotNetAssignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DotNetAssignment] SET  MULTI_USER 
GO
ALTER DATABASE [DotNetAssignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DotNetAssignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DotNetAssignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DotNetAssignment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DotNetAssignment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DotNetAssignment] SET QUERY_STORE = OFF
GO
USE [DotNetAssignment]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [DotNetAssignment]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 15-02-2021 11:40:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[HomePhone] [varchar](15) NOT NULL,
	[Pwd] [nvarchar](256) NOT NULL,
	[Address1] [nvarchar](100) NOT NULL,
	[Address2] [nvarchar](100) NOT NULL,
	[Zipcode] [varchar](10) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dealers]    Script Date: 15-02-2021 11:40:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dealers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Pwd] [nvarchar](256) NOT NULL,
	[Address1] [nvarchar](100) NOT NULL,
	[Address2] [nvarchar](100) NOT NULL,
	[Zipcode] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Dealers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mechanics]    Script Date: 15-02-2021 11:40:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mechanics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DealerId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [varchar](15) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Mechanics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 15-02-2021 11:40:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VehicleId] [int] NOT NULL,
	[MechanicId] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[date] [date] NOT NULL,
	[Status] [bit] NOT NULL,
	[Description] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 15-02-2021 11:40:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[LicensePlate] [nvarchar](50) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[RegDate] [date] NOT NULL,
	[ChassisNo] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Mechanics] ADD  CONSTRAINT [DF_Mechanics_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Services] ADD  CONSTRAINT [DF_Services_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Mechanics]  WITH CHECK ADD  CONSTRAINT [FK_Mechanics_Dealers] FOREIGN KEY([DealerId])
REFERENCES [dbo].[Dealers] ([Id])
GO
ALTER TABLE [dbo].[Mechanics] CHECK CONSTRAINT [FK_Mechanics_Dealers]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Mechanics] FOREIGN KEY([MechanicId])
REFERENCES [dbo].[Mechanics] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Mechanics]
GO
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_Services_Vehicles] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
GO
ALTER TABLE [dbo].[Services] CHECK CONSTRAINT [FK_Services_Vehicles]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK_Vehicles_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK_Vehicles_Customers]
GO
USE [master]
GO
ALTER DATABASE [DotNetAssignment] SET  READ_WRITE 
GO
