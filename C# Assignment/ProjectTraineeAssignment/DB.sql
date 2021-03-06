USE [master]
GO
/****** Object:  Database [ProjectTraineeAssignment]    Script Date: 12-01-2021 11:55:39 AM ******/
CREATE DATABASE [ProjectTraineeAssignment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectTraineeAssignment', FILENAME = N'C:\Users\aliabbas\ProjectTraineeAssignment.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjectTraineeAssignment_log', FILENAME = N'C:\Users\aliabbas\ProjectTraineeAssignment_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ProjectTraineeAssignment] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectTraineeAssignment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectTraineeAssignment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectTraineeAssignment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjectTraineeAssignment] SET QUERY_STORE = OFF
GO
USE [ProjectTraineeAssignment]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [ProjectTraineeAssignment]
GO
/****** Object:  Table [dbo].[tbl_category]    Script Date: 12-01-2021 11:55:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](200) NULL,
	[is_deleted] [bit] NOT NULL,
	[created_by] [int] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [int] NOT NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_category] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_product]    Script Date: 12-01-2021 11:55:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[category_id] [int] NOT NULL,
	[price] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[short_description] [varchar](150) NOT NULL,
	[long_description] [varchar](700) NULL,
	[small_image] [varchar](150) NULL,
	[large_image] [varchar](150) NULL,
	[is_deleted] [bit] NOT NULL,
	[created_by] [int] NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [int] NOT NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 12-01-2021 11:55:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[phone] [varchar](15) NULL,
	[pwd] [binary](64) NOT NULL,
	[is_deleted] [bit] NOT NULL,
	[created_by] [int] NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [int] NULL,
	[updated_date] [datetime] NOT NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_category] ON 

INSERT [dbo].[tbl_category] ([category_id], [name], [description], [is_deleted], [created_by], [created_date], [updated_by], [updated_date]) VALUES (7, N'Category 1', NULL, 0, 1, CAST(N'2020-12-12T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[tbl_category] ([category_id], [name], [description], [is_deleted], [created_by], [created_date], [updated_by], [updated_date]) VALUES (1005, N'Category 2', NULL, 0, 1, CAST(N'2020-12-12T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[tbl_category] ([category_id], [name], [description], [is_deleted], [created_by], [created_date], [updated_by], [updated_date]) VALUES (2002, N'Category 3', NULL, 0, 1, CAST(N'2020-12-12T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[tbl_category] ([category_id], [name], [description], [is_deleted], [created_by], [created_date], [updated_by], [updated_date]) VALUES (2003, N'Category 4', NULL, 0, 1, CAST(N'2020-12-12T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[tbl_category] ([category_id], [name], [description], [is_deleted], [created_by], [created_date], [updated_by], [updated_date]) VALUES (2004, N'Category 5', NULL, 0, 1, CAST(N'2020-12-12T00:00:00.000' AS DateTime), 1, CAST(N'2020-12-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_category] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Table_1]    Script Date: 12-01-2021 11:55:40 AM ******/
ALTER TABLE [dbo].[tbl_user] ADD  CONSTRAINT [UQ_Table_1] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ2_Table_1]    Script Date: 12-01-2021 11:55:40 AM ******/
ALTER TABLE [dbo].[tbl_user] ADD  CONSTRAINT [UQ2_Table_1] UNIQUE NONCLUSTERED 
(
	[phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_category] ADD  CONSTRAINT [DF_tbl_category_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[tbl_product] ADD  CONSTRAINT [DF_tbl_product_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[tbl_user] ADD  CONSTRAINT [DF_tbl_user_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[tbl_product]  WITH CHECK ADD  CONSTRAINT [FK_tbl_product_tbl_category] FOREIGN KEY([category_id])
REFERENCES [dbo].[tbl_category] ([category_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_product] CHECK CONSTRAINT [FK_tbl_product_tbl_category]
GO
USE [master]
GO
ALTER DATABASE [ProjectTraineeAssignment] SET  READ_WRITE 
GO
