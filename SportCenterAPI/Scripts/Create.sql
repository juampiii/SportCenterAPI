USE [master]
GO
/****** Object:  Database [SportCenter]    Script Date: 21/01/2019 15:45:29 ******/
CREATE DATABASE [SportCenter]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SportCenter', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SportCenter.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SportCenter_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SportCenter_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SportCenter].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SportCenter] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SportCenter] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SportCenter] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SportCenter] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SportCenter] SET ARITHABORT OFF 
GO
ALTER DATABASE [SportCenter] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SportCenter] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SportCenter] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SportCenter] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SportCenter] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SportCenter] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SportCenter] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SportCenter] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SportCenter] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SportCenter] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SportCenter] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SportCenter] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SportCenter] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SportCenter] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SportCenter] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SportCenter] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SportCenter] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SportCenter] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SportCenter] SET  MULTI_USER 
GO
ALTER DATABASE [SportCenter] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SportCenter] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SportCenter] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SportCenter] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [SportCenter]
GO
/****** Object:  User [SportCenter]    Script Date: 21/01/2019 15:45:29 ******/
CREATE USER [SportCenter] FOR LOGIN [SportCenter] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [SportCenter]
GO
ALTER ROLE [db_datareader] ADD MEMBER [SportCenter]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [SportCenter]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 21/01/2019 15:45:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 21/01/2019 15:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberForeignKey] [int] NOT NULL,
	[CourtForeignKey] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[BookingDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Bookings_CourtForeignKey_MemberForeignKey_BookingDate] UNIQUE NONCLUSTERED 
(
	[CourtForeignKey] ASC,
	[MemberForeignKey] ASC,
	[BookingDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courts]    Script Date: 21/01/2019 15:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[SportForeignKey] [int] NOT NULL,
 CONSTRAINT [PK_Courts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 21/01/2019 15:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sports]    Script Date: 21/01/2019 15:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Sports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21/01/2019 15:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Bookings_MemberForeignKey]    Script Date: 21/01/2019 15:45:30 ******/
CREATE NONCLUSTERED INDEX [IX_Bookings_MemberForeignKey] ON [dbo].[Bookings]
(
	[MemberForeignKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Courts_SportForeignKey]    Script Date: 21/01/2019 15:45:30 ******/
CREATE NONCLUSTERED INDEX [IX_Courts_SportForeignKey] ON [dbo].[Courts]
(
	[SportForeignKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Courts_CourtForeignKey] FOREIGN KEY([CourtForeignKey])
REFERENCES [dbo].[Courts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Courts_CourtForeignKey]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Members_MemberForeignKey] FOREIGN KEY([MemberForeignKey])
REFERENCES [dbo].[Members] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Members_MemberForeignKey]
GO
ALTER TABLE [dbo].[Courts]  WITH CHECK ADD  CONSTRAINT [FK_Courts_Sports_SportForeignKey] FOREIGN KEY([SportForeignKey])
REFERENCES [dbo].[Sports] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courts] CHECK CONSTRAINT [FK_Courts_Sports_SportForeignKey]
GO
USE [master]
GO
ALTER DATABASE [SportCenter] SET  READ_WRITE 
GO
