USE [master]
GO
/****** Object:  Database [NguyenThiThanhNgaDB]    Script Date: 6/20/2021 9:12:12 PM ******/
CREATE DATABASE [NguyenThiThanhNgaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NguyenThiThanhNgaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\NguyenThiThanhNgaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NguyenThiThanhNgaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\NguyenThiThanhNgaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NguyenThiThanhNgaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET  MULTI_USER 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET QUERY_STORE = OFF
GO
USE [NguyenThiThanhNgaDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/20/2021 9:12:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [nchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/20/2021 9:12:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[UnitCost] [int] NOT NULL,
	[Quantity] [int] NULL,
	[Image] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [bit] NULL,
	[CategoryID] [nvarchar](10) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 6/20/2021 9:12:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[pr_Account]    Script Date: 6/20/2021 9:12:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pr_Account]

@UserName nvarchar(max),
@Password nvarchar(50)

as
begin
	declare @count int
	declare @res bit
	select @count= count(*) from UserAccount where UserName = @UserName and Password= @Password
	if @count >0
		set @res =1
	else 
		set @res= 0
		select @res
end
GO
/****** Object:  StoredProcedure [dbo].[pr_Product_Insert]    Script Date: 6/20/2021 9:12:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pr_Product_Insert]
	@Name nvarchar(max),
	@UnitCost int,
	@Quantity int,
	@Image nvarchar(max),
	@Description nvarchar(max),
	@Status nvarchar(10),
	@CategoryID nvarchar(10) 
as
begin
	Insert into Product([Name],[UnitCost],[Quantity],[Image],[Description],[Status],[CategoryID])
	values(@Name,@UnitCost,@Quantity,@Image,@Description,@Status,@CategoryID)
end
GO
/****** Object:  StoredProcedure [dbo].[pr_Product_ListAll]    Script Date: 6/20/2021 9:12:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[pr_Product_ListAll]
as
select * from Product where Status =1
order by[Quantity] desc
GO
USE [master]
GO
ALTER DATABASE [NguyenThiThanhNgaDB] SET  READ_WRITE 
GO
