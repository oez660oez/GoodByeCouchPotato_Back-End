USE [master]
GO
/****** Object:  Database [goodbyepotato]    Script Date: 2024/11/14 下午 02:18:12 ******/
CREATE DATABASE [goodbyepotato]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [goodbyepotato].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [goodbyepotato] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [goodbyepotato] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [goodbyepotato] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [goodbyepotato] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [goodbyepotato] SET ARITHABORT OFF 
GO
ALTER DATABASE [goodbyepotato] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [goodbyepotato] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [goodbyepotato] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [goodbyepotato] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [goodbyepotato] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [goodbyepotato] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [goodbyepotato] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [goodbyepotato] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [goodbyepotato] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [goodbyepotato] SET  DISABLE_BROKER 
GO
ALTER DATABASE [goodbyepotato] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [goodbyepotato] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [goodbyepotato] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [goodbyepotato] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [goodbyepotato] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [goodbyepotato] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [goodbyepotato] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [goodbyepotato] SET RECOVERY FULL 
GO
ALTER DATABASE [goodbyepotato] SET  MULTI_USER 
GO
ALTER DATABASE [goodbyepotato] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [goodbyepotato] SET DB_CHAINING OFF 
GO
ALTER DATABASE [goodbyepotato] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [goodbyepotato] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [goodbyepotato] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [goodbyepotato] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'goodbyepotato', N'ON'
GO
ALTER DATABASE [goodbyepotato] SET QUERY_STORE = ON
GO
ALTER DATABASE [goodbyepotato] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200)
GO
USE [goodbyepotato]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2024/11/14 下午 02:18:12 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccessoriesList]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessoriesList](
	[P_Code] [int] IDENTITY(1000,1) NOT NULL,
	[P_Class] [nvarchar](10) NOT NULL,
	[P_Name] [nvarchar](30) NOT NULL,
	[P_Price] [int] NULL,
	[P_Level] [int] NULL,
	[P_ImageShop] [nvarchar](50) NULL,
	[P_ImageAll] [nvarchar](50) NULL,
	[P_Active] [bit] NOT NULL,
	[P_ReviewStatus] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK__Accessor__F54C4371D7490299] PRIMARY KEY CLUSTERED 
(
	[P_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[A_Account] [nvarchar](30) NOT NULL,
	[A_Password] [nvarchar](30) NOT NULL,
	[M_DailyTask] [bit] NOT NULL,
	[M_Product] [bit] NOT NULL,
	[M_Administrator] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[A_Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Character]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Character](
	[C_ID] [int] IDENTITY(10000,1) NOT NULL,
	[Account] [nvarchar](30) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Level] [int] NOT NULL,
	[Experience] [int] NOT NULL,
	[Weight] [decimal](4, 1) NULL,
	[Height] [decimal](4, 1) NULL,
	[Environment] [int] NULL,
	[LivingStatus] [nvarchar](10) NULL,
	[MoveInDate] [datetime] NULL,
	[MoveOutDate] [datetime] NULL,
	[StandardWater] [int] NULL,
	[StandardStep] [int] NULL,
	[Coins] [int] NULL,
	[TargetWater] [int] NULL,
	[TargetStep] [int] NULL,
	[GetEnvironment] [int] NULL,
	[GetExperience] [int] NULL,
	[GetCoins] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[C_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CharacterAccessorie]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterAccessorie](
	[C_ID] [int] NOT NULL,
	[Head] [int] NULL,
	[Upper] [int] NULL,
	[Lower] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[C_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CharacterItem]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CharacterItem](
	[Account] [nvarchar](30) NOT NULL,
	[P_Code] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Account] ASC,
	[P_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailyHealthRecord]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyHealthRecord](
	[C_ID] [int] NOT NULL,
	[HRecordDate] [date] NOT NULL,
	[Water] [int] NULL,
	[Steps] [int] NULL,
	[Sleep] [datetime] NULL,
	[Mood] [nvarchar](10) NULL,
	[Vegetables] [int] NULL,
	[Snacks] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[C_ID] ASC,
	[HRecordDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailyTask]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyTask](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](50) NOT NULL,
	[Reward] [int] NOT NULL,
	[TaskActive] [bit] NOT NULL,
	[T_ReviewStatus] [nvarchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DailyTaskRecord]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyTaskRecord](
	[C_ID] [int] NOT NULL,
	[TRecordDate] [date] NOT NULL,
	[T1Name] [nvarchar](50) NULL,
	[T1Completed] [bit] NULL,
	[T2Name] [nvarchar](50) NULL,
	[T2Completed] [bit] NULL,
	[T3Name] [nvarchar](50) NULL,
	[T3Completed] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[C_ID] ASC,
	[TRecordDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackNO] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](80) NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
	[Submitted] [datetime] NOT NULL,
	[Pro_Active] [bit] NOT NULL,
	[Pro_Date] [datetime] NULL,
	[Pro_Content] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordResetRequests]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordResetRequests](
	[Id] [nvarchar](450) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[Token] [nvarchar](512) NULL,
	[CreatedAt] [datetime] NULL,
 CONSTRAINT [PK_PasswordResetRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[Account] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](80) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[Playerstatus] [bit] NOT NULL,
	[token] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomAccessories]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomAccessories](
	[C_ID] [int] NOT NULL,
	[Bookcase] [int] NULL,
	[Bed] [int] NULL,
	[Desk] [int] NULL,
	[Chair] [int] NULL,
	[Plant] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[C_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeeklyHealthRecord]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeeklyHealthRecord](
	[C_ID] [int] NOT NULL,
	[WRecordDate] [date] NOT NULL,
	[Exercise] [bit] NOT NULL,
	[Cleaning] [bit] NOT NULL,
 CONSTRAINT [PK__WeeklyHe__8BF6176FC3B7D468] PRIMARY KEY CLUSTERED 
(
	[C_ID] ASC,
	[WRecordDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeightRecord]    Script Date: 2024/11/14 下午 02:18:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeightRecord](
	[C_ID] [int] NOT NULL,
	[W_RecordDate] [date] NOT NULL,
	[Weight] [decimal](4, 1) NOT NULL,
 CONSTRAINT [PK__WeightRe__2CF18179E87F755E] PRIMARY KEY CLUSTERED 
(
	[C_ID] ASC,
	[W_RecordDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'8.0.8')
GO
SET IDENTITY_INSERT [dbo].[AccessoriesList] ON 

INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1044, N'飾品', N'飾品6', 700, 6, N'accessoryShop06-1.png', N'accessory06-1.png', 0, N'未通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1045, N'飾品', N'飾品7', 1000, 11, N'accessoryShop07-1.png', N'accessory07-1.png', 0, N'未通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1046, N'飾品', N'飾品8', 900, 10, N'accessoryShop08-1.png', N'accessory08-1.png', 0, N'未通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1047, N'飾品', N'飾品9', 1800, 18, N'accessoryShop09-1.png', N'accessory09-1.png', 0, N'未通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1048, N'飾品', N'飾品10', 1500, 15, N'accessoryShop10-1.png', N'accessory10-1.png', 0, N'未通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1049, N'飾品', N'飾品11', 1700, 9, N'accessoryShop11-1.png', N'accessory11-1.png', 0, N'未通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1051, N'衣服', N'學生服', 2800, 34, N'outfitShop_28_01.png', N'outfit_28_01.png', 0, N'未通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1052, N'衣服', N'間諜裝', 4000, 29, N'outfitShop_30_01.png', N'outfit_30_01.png', 0, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1053, N'髮型', N'褐色短髮', 500, 1, N'ShopHairstyle_01_01.png', N'Hairstyle_01_01.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1054, N'髮型', N'咖啡色短髮', 500, 5, N'ShopHairstyle_01_02.png', N'Hairstyle_01_02.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1055, N'髮型', N'黑色短髮', 500, 3, N'ShopHairstyle_01_03.png', N'Hairstyle_01_03.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1056, N'飾品', N'紅色瓢蟲套裝', 700, 1, N'ShopAccessory_01_Ladybug_01.png', N'Accessory_01_Ladybug_01.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1057, N'飾品', N'黃色瓢蟲套裝', 700, 5, N'ShopAccessory_01_Ladybug_02.png', N'Accessory_01_Ladybug_02.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1058, N'飾品', N'綠色瓢蟲套裝', 700, 7, N'ShopAccessory_01_Ladybug_03.png', N'Accessory_01_Ladybug_03.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1059, N'衣服', N'跩酷套裝', 380, 1, N'ShopOutfit_01_01.png', N'Outfit_01_01.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1060, N'衣服', N'藍色條紋套裝', 520, 5, N'ShopOutfit_01_02.png', N'Outfit_01_02.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1061, N'衣服', N'工作裝', 380, 1, N'ShopOutfit_01_03.png', N'Outfit_01_03.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1062, N'飾品', N'綠色恐龍帽', 1000, 15, N'accessoryShop_05_Dino_Snapback_01.png', N'accessory_05_Dino_Snapback_01.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1063, N'飾品', N'藍色恐龍帽', 1200, 10, N'accessoryShop_05_Dino_Snapback_02.png', N'accessory_05_Dino_Snapback_02.png', 1, N'通過')
INSERT [dbo].[AccessoriesList] ([P_Code], [P_Class], [P_Name], [P_Price], [P_Level], [P_ImageShop], [P_ImageAll], [P_Active], [P_ReviewStatus]) VALUES (1064, N'飾品', N'紅色恐龍帽', 500, 1, N'accessoryShop_05_Dino_Snapback_03.png', N'accessory_05_Dino_Snapback_03.png', 1, N'通過')
SET IDENTITY_INSERT [dbo].[AccessoriesList] OFF
GO
INSERT [dbo].[Administrator] ([A_Account], [A_Password], [M_DailyTask], [M_Product], [M_Administrator]) VALUES (N'adam', N'pass789', 0, 1, 0)
INSERT [dbo].[Administrator] ([A_Account], [A_Password], [M_DailyTask], [M_Product], [M_Administrator]) VALUES (N'admin1', N'password123', 1, 1, 1)
INSERT [dbo].[Administrator] ([A_Account], [A_Password], [M_DailyTask], [M_Product], [M_Administrator]) VALUES (N'Alice', N'admin456', 1, 0, 0)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'48daf0b3-d934-46dc-91f1-bf37a18cea04', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7f76a963-e347-4f20-adf0-51a67d8e08e3', N'PermiGuard', N'PERMIGUARD', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b01743dd-a743-4987-8ae1-3977f4e14021', N'User', N'USER', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0078bcae-5783-462e-959d-6078c87d898e', N'b01743dd-a743-4987-8ae1-3977f4e14021')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0e363060-ed4e-4ba4-869f-bcde984979ca', N'7f76a963-e347-4f20-adf0-51a67d8e08e3')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1f0b6ae5-71d8-48f5-bcb3-e48aac9e1564', N'b01743dd-a743-4987-8ae1-3977f4e14021')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b68fb98b-c658-4844-bded-021979c9d313', N'48daf0b3-d934-46dc-91f1-bf37a18cea04')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0078bcae-5783-462e-959d-6078c87d898e', N'oez666oez@gmail.com', N'OEZ666OEZ@GMAIL.COM', N'oez666oez@gmail.com', N'OEZ666OEZ@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAENCpNwCRSLG1moP7loLbFAOtROUG89YQFYROYUR+7DdXJbouS0x5rXOuoJpTK+SxAQ==', N'MOPTDGTBIAJ7SHVQXRMHI4N3YNZQSCSV', N'7d205cb6-456e-4a6a-96fb-89a7acd074cb', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0e363060-ed4e-4ba4-869f-bcde984979ca', N'Crythics@gmail.com', N'CRYTHICS@GMAIL.COM', N'Crythics@gmail.com', N'CRYTHICS@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEIC3F4TzK3BqOSEYG+bPjx2Z4abNjX248JF6OoGo2fYeSY622ZLDHYp/dtjpwp+Q7w==', N'XL5XBVZXV72ZRSAQ7KCIWMTSPFPDORKG', N'0343943c-8e2e-425f-9c7f-2f81dd1868b9', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1f0b6ae5-71d8-48f5-bcb3-e48aac9e1564', N'uo12354@gmail.com', N'UO12354@GMAIL.COM', N'uo12354@gmail.com', N'UO12354@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEB+bCxvDFYCAexwGhj1knJ3dQB7UzvQz9P510duXMWoad60qYg7ZSff1QEs8Li6Jxw==', N'U3QIOGBGU4IL6PVKONTCJJXMBPBVXCWL', N'fbb66624-99d6-42fc-919d-c25de3c283eb', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b68fb98b-c658-4844-bded-021979c9d313', N'leo555555@gmail.com', N'LEO555555@GMAIL.COM', N'leo555555@gmail.com', N'LEO555555@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEF5zJykC82JxBAPY3Ie4MM1nqJ7/hDqV/l4Jz9ED2pN4uloguR4PTNqL7LlN/gl7MA==', N'FQVDYBCPHRTDKJR456ZD46KLGVGINUON', N'ca3f60d4-4e78-4b7a-8edf-304a47e5a9be', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Character] ON 

INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10000, N'tiger123', N'Tiger King', 15, 75, CAST(70.5 AS Decimal(4, 1)), CAST(175.2 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-08-01T00:00:00.000' AS DateTime), CAST(N'2024-08-05T00:00:00.000' AS DateTime), 1700, 3000, 700, 2100, 5000, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10001, N'sunny234', N'Sunny Shine', 8, 60, CAST(60.2 AS Decimal(4, 1)), CAST(165.0 AS Decimal(4, 1)), 23, N'居住', CAST(N'2024-08-02T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1200, 6000, 365, 1800, 7500, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10002, N'mystic789', N'Mystic Sage', 12, 90, CAST(65.0 AS Decimal(4, 1)), CAST(170.3 AS Decimal(4, 1)), 8, N'居住', CAST(N'2024-08-02T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1200, 6000, 225, 2000, 7500, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10003, N'dragon567', N'Dragon Slayer', 18, 85, CAST(85.1 AS Decimal(4, 1)), CAST(180.0 AS Decimal(4, 1)), 68, N'居住', CAST(N'2024-08-03T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 2200, 8000, 350, 2600, 10000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10004, N'shadow999', N'Shadow Ninja', 4, 50, CAST(55.5 AS Decimal(4, 1)), CAST(160.4 AS Decimal(4, 1)), 0, N'居住', CAST(N'2024-08-05T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1200, 3000, 780, 1700, 5000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10005, N'hunter432', N'Hunter Wolf', 10, 95, CAST(78.0 AS Decimal(4, 1)), CAST(172.5 AS Decimal(4, 1)), 53, N'居住', CAST(N'2024-08-05T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 6000, 1505, 2300, 7500, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10006, N'hero891', N'英雄', 20, 99, CAST(88.9 AS Decimal(4, 1)), CAST(182.7 AS Decimal(4, 1)), 83, N'居住', CAST(N'2024-08-05T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 2200, 3000, 380, 2700, 5000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10007, N'joker321', N'Joker Fool', 6, 45, CAST(72.3 AS Decimal(4, 1)), CAST(169.8 AS Decimal(4, 1)), 18, N'居住', CAST(N'2024-08-07T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 10000, 650, 2200, 12500, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10008, N'wizard007', N'Wizard Master', 14, 70, CAST(68.0 AS Decimal(4, 1)), CAST(178.1 AS Decimal(4, 1)), 48, N'居住', CAST(N'2024-08-08T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 8000, 750, 2000, 10000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10009, N'storm456', N'龍捲風', 25, 55, CAST(75.0 AS Decimal(4, 1)), CAST(179.2 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-08-15T00:00:00.000' AS DateTime), CAST(N'2024-08-20T00:00:00.000' AS DateTime), 1700, 10000, 5, 2300, 6000, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10010, N'knight245', N'Knight Champion', 11, 80, CAST(82.0 AS Decimal(4, 1)), CAST(176.5 AS Decimal(4, 1)), 73, N'居住', CAST(N'2024-08-18T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 3000, 550, 2500, 5000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10011, N'rogue654', N'今天很愉快', 7, 65, CAST(60.5 AS Decimal(4, 1)), CAST(166.9 AS Decimal(4, 1)), 13, N'居住', CAST(N'2024-08-18T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1200, 6000, 50, 1800, 7500, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10012, N'prince357', N'Prince Noble', 5, 40, CAST(70.0 AS Decimal(4, 1)), CAST(168.0 AS Decimal(4, 1)), 3, N'居住', CAST(N'2024-08-18T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 3000, 15, 2100, 5000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10013, N'phoenix763', N'Phoenix Flame', 13, 85, CAST(68.2 AS Decimal(4, 1)), CAST(174.3 AS Decimal(4, 1)), 38, N'居住', CAST(N'2024-08-19T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 8000, 65, 2000, 10000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10014, N'warrior123', N'Warrior Brave', 3, 30, CAST(85.3 AS Decimal(4, 1)), CAST(183.0 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-08-20T00:00:00.000' AS DateTime), CAST(N'2024-08-31T00:00:00.000' AS DateTime), 2200, 8000, 780, 2600, 10000, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10015, N'samurai678', N'夏天好熱！', 19, 98, CAST(77.7 AS Decimal(4, 1)), CAST(181.0 AS Decimal(4, 1)), 78, N'居住', CAST(N'2024-08-21T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 3000, 175, 2300, 5000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10016, N'ranger987', N'!!!!', 16, 89, CAST(73.4 AS Decimal(4, 1)), CAST(177.8 AS Decimal(4, 1)), 58, N'居住', CAST(N'2024-08-21T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 8000, 655, 2200, 10000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10017, N'pirate876', N'Pirate Captain', 17, 95, CAST(80.5 AS Decimal(4, 1)), CAST(179.9 AS Decimal(4, 1)), 73, N'居住', CAST(N'2024-08-22T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 3000, 725, 2400, 5000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10018, N'ninja321', N'小豬', 2, 20, CAST(65.0 AS Decimal(4, 1)), CAST(167.2 AS Decimal(4, 1)), 0, N'居住', CAST(N'2024-08-24T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1200, 3000, 655, 2000, 5000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10019, N'warrior123', N'Warrior Brave', 3, 30, CAST(85.3 AS Decimal(4, 1)), CAST(183.0 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-08-31T00:00:00.000' AS DateTime), CAST(N'2024-09-05T00:00:00.000' AS DateTime), 2200, 3000, 350, 2600, 5000, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10020, N'guardian555', N'Guardian Shield', 1, 10, CAST(90.1 AS Decimal(4, 1)), CAST(185.4 AS Decimal(4, 1)), 3, N'居住', CAST(N'2024-09-02T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 2200, 6000, 355, 2700, 7500, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10021, N'tiger123', N'Tiger King', 15, 75, CAST(70.5 AS Decimal(4, 1)), CAST(175.2 AS Decimal(4, 1)), 13, N'居住', CAST(N'2024-09-02T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1200, 6000, 635, 1500, 7500, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10022, N'storm456', N'颶風', 9, 55, CAST(75.4 AS Decimal(4, 1)), CAST(179.2 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-09-02T00:00:00.000' AS DateTime), CAST(N'2024-09-09T00:00:00.000' AS DateTime), 1700, 6000, 275, 2300, 7500, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10023, N'warrior123', N'Warrior Brave', 3, 30, CAST(85.3 AS Decimal(4, 1)), CAST(183.0 AS Decimal(4, 1)), 3, N'居住', CAST(N'2024-09-05T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 2200, 3000, 150, 2600, 5000, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10024, N'storm456', N'颱風', 9, 55, CAST(75.7 AS Decimal(4, 1)), CAST(179.2 AS Decimal(4, 1)), 0, N'居住', CAST(N'2024-09-09T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 6000, 625, 2300, 7500, -12, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10026, N'leo555554', N'我是老大', 1, 0, CAST(55.0 AS Decimal(4, 1)), CAST(180.0 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-10-19T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 6000, 9000, 2300, 7500, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10027, N'leo555555', N'不太健康的馬鈴薯', 20, 76, CAST(83.5 AS Decimal(4, 1)), CAST(166.7 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-01-01T00:00:00.000' AS DateTime), CAST(N'2024-01-20T00:00:00.000' AS DateTime), 1834, 6046, 31787, 2324, 9209, 91, 416, 624)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10028, N'leo555555', N'努力的馬鈴薯', 5, 60, CAST(71.0 AS Decimal(4, 1)), CAST(159.0 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-01-30T03:01:30.000' AS DateTime), CAST(N'2024-02-10T00:00:00.000' AS DateTime), 2078, 7710, 88455, 1312, 12002, 100, 700, 335)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10029, N'leo555555', N'希望健康的馬鈴薯', 37, 53, CAST(68.8 AS Decimal(4, 1)), CAST(182.0 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-02-11T00:00:00.000' AS DateTime), CAST(N'2024-02-23T00:00:00.000' AS DateTime), 1917, 5317, 94614, 1730, 12127, 17, 698, 643)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10030, N'leo555555', N'逐漸健康的馬鈴薯', 25, 56, CAST(83.9 AS Decimal(4, 1)), CAST(171.6 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-02-25T00:00:00.000' AS DateTime), CAST(N'2024-03-10T00:00:00.000' AS DateTime), 1902, 8633, 24698, 1693, 14893, 65, 648, 813)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10031, N'leo555555', N'最近不太健康的馬鈴薯', 21, 67, CAST(65.5 AS Decimal(4, 1)), CAST(175.2 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-03-15T00:00:00.000' AS DateTime), CAST(N'2024-03-31T00:00:00.000' AS DateTime), 2444, 8613, 83221, 1931, 14659, 87, 836, 793)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10032, N'leo555555', N'狀況不太好的馬鈴薯', 15, 13, CAST(75.2 AS Decimal(4, 1)), CAST(178.3 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-04-01T00:00:00.000' AS DateTime), CAST(N'2024-04-28T00:00:00.000' AS DateTime), 2010, 9294, 43561, 1720, 10540, 44, 523, 445)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10033, N'leo555555', N'再次健康的馬鈴薯', 30, 34, CAST(70.1 AS Decimal(4, 1)), CAST(169.8 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-05-02T00:00:00.000' AS DateTime), CAST(N'2024-05-20T00:00:00.000' AS DateTime), 2273, 5002, 50938, 2154, 12876, 72, 815, 917)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10034, N'leo555555', N'在健康路上奔走的馬鈴薯', 19, 12, CAST(78.4 AS Decimal(4, 1)), CAST(181.5 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-05-20T00:00:00.000' AS DateTime), CAST(N'2024-05-30T00:00:00.000' AS DateTime), 2002, 6870, 65982, 2387, 14095, 51, 687, 804)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10035, N'leo555555', N'看到自己成長的馬鈴薯', 8, 32, CAST(84.3 AS Decimal(4, 1)), CAST(162.2 AS Decimal(4, 1)), 0, N'搬離', CAST(N'2024-05-01T00:00:00.000' AS DateTime), CAST(N'2024-09-30T00:00:00.000' AS DateTime), 1802, 8589, 28871, 2009, 11672, 30, 422, 312)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (10036, N'leo555555', N'健康馬鈴薯', 10, 50, CAST(68.9 AS Decimal(4, 1)), CAST(176.4 AS Decimal(4, 1)), 45, N'居住', CAST(N'2024-10-01T00:00:00.000' AS DateTime), CAST(N'1900-07-14T03:04:37.000' AS DateTime), 2700, 5472, 3949, 3100, 13520, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (11031, N'oez660oez', N'牢師', 50, 0, CAST(56.0 AS Decimal(4, 1)), CAST(166.0 AS Decimal(4, 1)), 90, N'居住', CAST(N'2024-11-03T21:19:13.563' AS DateTime), CAST(N'2024-11-06T11:14:59.957' AS DateTime), 1200, 3000, 9005, 1600, 5000, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (11032, N'oez660oez', N'大八貓', 1, 0, CAST(26.3 AS Decimal(4, 1)), CAST(134.6 AS Decimal(4, 1)), 80, N'搬離', CAST(N'2024-11-05T12:04:45.080' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 500, 6000, 0, 800, 7500, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (11035, N'chun00', N'mama', 1, 0, CAST(600.0 AS Decimal(4, 1)), CAST(180.0 AS Decimal(4, 1)), 80, N'居住', CAST(N'2024-11-12T16:45:07.747' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 10000, 3000, 0, 18000, 5000, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (11036, N'mama', N'mama', 1, 0, CAST(400.0 AS Decimal(4, 1)), CAST(200.0 AS Decimal(4, 1)), 80, N'居住', CAST(N'2024-11-12T16:46:58.890' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 10000, 6000, 0, 12000, 7500, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (11037, N'1212', N'mama', 1, 0, CAST(600.0 AS Decimal(4, 1)), CAST(180.0 AS Decimal(4, 1)), 80, N'居住', CAST(N'2024-11-12T16:48:33.807' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 10000, 3000, 0, 18000, 5000, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (11038, N'yaya', N'mama', 1, 0, CAST(50.0 AS Decimal(4, 1)), CAST(150.0 AS Decimal(4, 1)), 80, N'居住', CAST(N'2024-11-12T16:50:04.873' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 700, 6000, 40, 1500, 7500, 0, 0, 0)
INSERT [dbo].[Character] ([C_ID], [Account], [Name], [Level], [Experience], [Weight], [Height], [Environment], [LivingStatus], [MoveInDate], [MoveOutDate], [StandardWater], [StandardStep], [Coins], [TargetWater], [TargetStep], [GetEnvironment], [GetExperience], [GetCoins]) VALUES (11039, N'122', N'mama', 1, 0, CAST(80.0 AS Decimal(4, 1)), CAST(180.0 AS Decimal(4, 1)), 80, N'居住', CAST(N'2024-11-12T16:54:07.130' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), 1700, 3000, 0, 2400, 5000, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Character] OFF
GO
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10001, 1000, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10002, 1000, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10003, 1000, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10004, 1000, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10005, 0, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10006, 1000, 1001, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10007, 1000, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10008, 1000, 1001, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10009, 1000, 1001, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10010, 1000, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10011, 1000, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10012, 1000, 1001, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10013, 1000, 1001, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10014, 1000, 1001, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10015, 0, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10016, 1000, 1001, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10017, 1000, 1001, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10018, 1000, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10019, 1000, 1001, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10020, 0, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10021, 0, 1001, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10022, 1000, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10023, 1000, 0, 1003)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10024, 0, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10025, 0, 1001, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10026, 0, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (10036, 1063, 1054, 1059)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (11031, 1064, 0, 1059)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (11032, 0, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (11033, 0, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (11034, 0, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (11035, 0, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (11036, 0, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (11037, 0, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (11038, 0, 0, 0)
INSERT [dbo].[CharacterAccessorie] ([C_ID], [Head], [Upper], [Lower]) VALUES (11039, 0, 0, 0)
GO
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'dragon567', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'dragon567', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'dragon567', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'guardian555', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'guardian555', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'guardian555', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'hero891', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'hero891', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'hero891', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'hunter432', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'hunter432', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'hunter432', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'joker321', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'joker321', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'joker321', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'knight245', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'knight245', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'knight245', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'leo555555', 1054)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'leo555555', 1055)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'leo555555', 1056)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'leo555555', 1057)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'leo555555', 1058)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'leo555555', 1059)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'leo555555', 1060)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'leo555555', 1061)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'leo555555', 1063)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'leo555555', 1064)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'mystic789', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'mystic789', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'mystic789', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'ninja321', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'ninja321', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'ninja321', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1053)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1054)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1055)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1056)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1057)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1058)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1059)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1061)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1062)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1063)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'oez660oez', 1064)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'phoenix763', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'phoenix763', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'phoenix763', 1004)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'pirate876', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'pirate876', 1002)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'pirate876', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'prince357', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'prince357', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'prince357', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'ranger987', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'ranger987', 1004)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'ranger987', 1005)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'rogue654', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'rogue654', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'rogue654', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'samurai678', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'samurai678', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'samurai678', 1007)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'shadow999', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'shadow999', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'shadow999', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'storm456', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'storm456', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'storm456', 1004)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'storm456', 1008)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'storm456', 1009)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'sunny234', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'sunny234', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'sunny234', 1008)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'tiger123', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'tiger123', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'tiger123', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'warrior123', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'warrior123', 1001)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'warrior123', 1004)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'wizard007', 1000)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'wizard007', 1003)
INSERT [dbo].[CharacterItem] ([Account], [P_Code]) VALUES (N'wizard007', 1004)
GO
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2023-08-17' AS Date), 5039, 7025, CAST(N'2023-08-17T03:01:30.000' AS DateTime), N'普通', 7, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2023-08-18' AS Date), 5049, 7045, CAST(N'2023-08-18T03:31:30.000' AS DateTime), N'不透露', 8, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2023-08-19' AS Date), 5059, 7065, CAST(N'2023-08-19T04:01:30.000' AS DateTime), N'開心', 9, 6)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2023-08-20' AS Date), 5069, 7085, CAST(N'2023-08-20T04:31:30.000' AS DateTime), N'非常開心', 0, 7)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2023-08-21' AS Date), 5079, 7105, CAST(N'2023-08-21T05:01:30.000' AS DateTime), N'開心', 1, 8)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2023-08-22' AS Date), 5089, 7125, CAST(N'2023-08-22T05:31:30.000' AS DateTime), N'不開心', 2, 9)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2023-08-23' AS Date), 5099, 7145, CAST(N'2023-08-23T06:01:30.000' AS DateTime), N'開心', 3, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2023-08-24' AS Date), 5109, 7165, CAST(N'2023-08-24T06:31:30.000' AS DateTime), N'普通', 4, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2023-08-25' AS Date), 5119, 7185, CAST(N'2023-08-25T07:01:30.000' AS DateTime), N'普通', 5, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-04' AS Date), 1683, 2428, CAST(N'2024-05-04T23:24:00.000' AS DateTime), N'有點不開心', 5, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-05' AS Date), 1516, 14395, CAST(N'2024-05-05T02:02:00.000' AS DateTime), N'不開心', 0, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-06' AS Date), 2861, 243, CAST(N'2024-05-06T23:10:00.000' AS DateTime), N'普通', 3, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-07' AS Date), 35, 13317, CAST(N'2024-05-07T04:05:00.000' AS DateTime), N'有點不開心', 1, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-08' AS Date), 3755, 16695, CAST(N'2024-05-08T00:04:00.000' AS DateTime), N'開心', 3, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-11' AS Date), 3022, 9191, CAST(N'2024-05-11T20:18:00.000' AS DateTime), N'非常開心', 0, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-12' AS Date), 1340, 3552, CAST(N'2024-05-12T21:53:00.000' AS DateTime), N'不透露', 1, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-13' AS Date), 2819, 16505, CAST(N'2024-05-13T00:51:00.000' AS DateTime), N'有點不開心', 2, 3)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-14' AS Date), 2575, 4161, CAST(N'2024-05-14T04:27:00.000' AS DateTime), N'普通', 4, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-15' AS Date), 525, 10668, CAST(N'2024-05-15T21:19:00.000' AS DateTime), N'有點不開心', 5, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-16' AS Date), 1879, 12881, CAST(N'2024-05-16T00:10:00.000' AS DateTime), N'不透露', 1, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-19' AS Date), 1462, 13247, CAST(N'2024-05-19T03:22:00.000' AS DateTime), N'非常開心', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-21' AS Date), 2040, 5168, CAST(N'2024-05-21T20:35:00.000' AS DateTime), N'開心', 3, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-22' AS Date), 1050, 8390, CAST(N'2024-05-22T23:59:00.000' AS DateTime), N'不透露', 1, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-25' AS Date), 161, 2457, CAST(N'2024-05-25T00:26:00.000' AS DateTime), N'開心', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-28' AS Date), 784, 13529, CAST(N'2024-05-28T00:58:00.000' AS DateTime), N'開心', 1, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-29' AS Date), 3541, 4147, CAST(N'2024-05-29T21:49:00.000' AS DateTime), N'普通', 2, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-05-30' AS Date), 1140, 17757, CAST(N'2024-05-30T21:53:00.000' AS DateTime), N'非常開心', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-01' AS Date), 2828, 19969, CAST(N'2024-06-01T23:25:00.000' AS DateTime), N'不開心', 5, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-04' AS Date), 3652, 10291, CAST(N'2024-06-04T00:39:00.000' AS DateTime), N'不透露', 1, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-06' AS Date), 1415, 13772, CAST(N'2024-06-06T00:26:00.000' AS DateTime), N'開心', 1, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-08' AS Date), 3199, 17344, CAST(N'2024-06-08T21:38:00.000' AS DateTime), N'不透露', 3, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-10' AS Date), 3524, 3338, CAST(N'2024-06-10T01:07:00.000' AS DateTime), N'開心', 3, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-11' AS Date), 1826, 6992, CAST(N'2024-06-11T00:15:00.000' AS DateTime), N'不開心', 3, 3)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-16' AS Date), 3823, 2885, CAST(N'2024-06-16T00:22:00.000' AS DateTime), N'有點不開心', 1, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-17' AS Date), 284, 6966, CAST(N'2024-06-17T00:02:00.000' AS DateTime), N'不透露', 0, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-18' AS Date), 138, 11487, CAST(N'2024-06-18T03:05:00.000' AS DateTime), N'不透露', 4, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-19' AS Date), 971, 11800, CAST(N'2024-06-19T04:40:00.000' AS DateTime), N'普通', 5, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-20' AS Date), 1972, 15569, CAST(N'2024-06-20T23:06:00.000' AS DateTime), N'有點不開心', 1, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-22' AS Date), 2087, 8300, CAST(N'2024-06-22T03:38:00.000' AS DateTime), N'不透露', 1, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-26' AS Date), 3996, 15948, CAST(N'2024-06-26T00:03:00.000' AS DateTime), N'不開心', 0, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-27' AS Date), 812, 8260, CAST(N'2024-06-27T01:55:00.000' AS DateTime), N'非常開心', 5, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-28' AS Date), 3277, 12599, CAST(N'2024-06-28T20:36:00.000' AS DateTime), N'有點不開心', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-06-30' AS Date), 3318, 2062, CAST(N'2024-06-30T02:10:00.000' AS DateTime), N'不透露', 1, 3)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-01' AS Date), 2423, 17436, CAST(N'2024-07-01T22:52:00.000' AS DateTime), N'不透露', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-02' AS Date), 3201, 11433, CAST(N'2024-07-02T00:56:00.000' AS DateTime), N'不透露', 4, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-05' AS Date), 2961, 16904, CAST(N'2024-07-05T21:57:00.000' AS DateTime), N'不開心', 4, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-06' AS Date), 3696, 3247, CAST(N'2024-07-06T22:50:00.000' AS DateTime), N'開心', 3, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-07' AS Date), 1034, 11752, CAST(N'2024-07-07T03:10:00.000' AS DateTime), N'不透露', 3, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-08' AS Date), 1349, 956, CAST(N'2024-07-08T00:31:00.000' AS DateTime), N'不透露', 1, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-10' AS Date), 2913, 11156, CAST(N'2024-07-10T02:04:00.000' AS DateTime), N'不開心', 0, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-17' AS Date), 349, 17232, CAST(N'2024-07-17T01:18:00.000' AS DateTime), N'不透露', 1, 3)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-19' AS Date), 2604, 9256, CAST(N'2024-07-19T21:38:00.000' AS DateTime), N'不開心', 1, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-20' AS Date), 1769, 20043, CAST(N'2024-07-20T22:48:00.000' AS DateTime), N'不透露', 3, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-24' AS Date), 490, 14637, CAST(N'2024-07-24T03:26:00.000' AS DateTime), N'普通', 1, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-27' AS Date), 498, 18379, CAST(N'2024-07-27T04:23:00.000' AS DateTime), N'不透露', 3, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-29' AS Date), 166, 18102, CAST(N'2024-07-29T01:24:00.000' AS DateTime), N'不透露', 4, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-07-30' AS Date), 663, 4279, CAST(N'2024-07-30T04:39:00.000' AS DateTime), N'開心', 5, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-03' AS Date), 1704, 2142, CAST(N'2024-08-03T22:55:00.000' AS DateTime), N'非常開心', 0, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-04' AS Date), 1601, 5779, CAST(N'2024-08-04T02:54:00.000' AS DateTime), N'非常開心', 2, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-07' AS Date), 838, 913, CAST(N'2024-08-07T00:13:00.000' AS DateTime), N'普通', 3, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-09' AS Date), 3386, 13783, CAST(N'2024-08-09T03:52:00.000' AS DateTime), N'普通', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-11' AS Date), 118, 18967, CAST(N'2024-08-11T21:34:00.000' AS DateTime), N'不透露', 3, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-14' AS Date), 82, 10425, CAST(N'2024-08-14T01:01:00.000' AS DateTime), N'不透露', 1, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-15' AS Date), 2742, 12427, CAST(N'2024-08-15T21:43:00.000' AS DateTime), N'不透露', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-17' AS Date), 100, 20325, CAST(N'2024-08-17T04:29:00.000' AS DateTime), N'不透露', 1, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-18' AS Date), 2820, 16652, CAST(N'2024-08-18T03:03:00.000' AS DateTime), N'開心', 1, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-19' AS Date), 3788, 627, CAST(N'2024-08-19T03:32:00.000' AS DateTime), N'不透露', 2, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-20' AS Date), 476, 12610, CAST(N'2024-08-20T21:10:00.000' AS DateTime), N'不透露', 2, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-21' AS Date), 1271, 11867, CAST(N'2024-08-21T02:17:00.000' AS DateTime), N'開心', 1, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-22' AS Date), 3187, 5918, CAST(N'2024-08-22T02:56:00.000' AS DateTime), N'開心', 1, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-23' AS Date), 2094, 8530, CAST(N'2024-08-23T00:02:00.000' AS DateTime), N'非常開心', 5, 3)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-08-27' AS Date), 3005, 14772, CAST(N'2024-08-27T02:13:00.000' AS DateTime), N'不開心', 3, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-01' AS Date), 685, 5302, CAST(N'2024-09-01T01:55:00.000' AS DateTime), N'開心', 2, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-02' AS Date), 2879, 1292, CAST(N'2024-09-02T20:11:00.000' AS DateTime), N'不透露', 0, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-04' AS Date), 2461, 5746, CAST(N'2024-09-04T01:28:00.000' AS DateTime), N'不透露', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-07' AS Date), 3646, 1752, CAST(N'2024-09-07T02:55:00.000' AS DateTime), N'不透露', 5, 3)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-11' AS Date), 3026, 7475, CAST(N'2024-09-11T00:48:00.000' AS DateTime), N'不透露', 1, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-16' AS Date), 2136, 11049, CAST(N'2024-09-16T23:51:00.000' AS DateTime), N'不透露', 1, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-18' AS Date), 2361, 7306, CAST(N'2024-09-18T02:59:00.000' AS DateTime), N'不透露', 4, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-19' AS Date), 1641, 15850, CAST(N'2024-09-19T00:19:00.000' AS DateTime), N'有點不開心', 0, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-22' AS Date), 3090, 5932, CAST(N'2024-09-22T20:20:00.000' AS DateTime), N'非常開心', 1, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-23' AS Date), 3566, 14694, CAST(N'2024-09-23T22:50:00.000' AS DateTime), N'有點不開心', 3, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-26' AS Date), 2089, 20459, CAST(N'2024-09-26T20:17:00.000' AS DateTime), N'非常開心', 1, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-27' AS Date), 1913, 19334, CAST(N'2024-09-27T02:05:00.000' AS DateTime), N'非常開心', 0, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-28' AS Date), 1168, 937, CAST(N'2024-09-28T01:49:00.000' AS DateTime), N'普通', 0, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-09-30' AS Date), 1210, 10961, CAST(N'2024-09-30T22:13:00.000' AS DateTime), N'普通', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10035, CAST(N'2024-11-12' AS Date), 2550, 6000, CAST(N'2024-11-12T22:30:00.000' AS DateTime), N'不透露', 4, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-01' AS Date), 3705, 9865, CAST(N'2024-10-01T01:31:00.000' AS DateTime), N'普通', 5, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-02' AS Date), 708, 1670, CAST(N'2024-10-02T04:42:00.000' AS DateTime), N'開心', 3, 3)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-03' AS Date), 1883, 16951, CAST(N'2024-10-03T01:21:00.000' AS DateTime), N'不開心', 3, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-05' AS Date), 1607, 15909, CAST(N'2024-10-05T22:00:00.000' AS DateTime), N'有點不開心', 5, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-06' AS Date), 3652, 11548, CAST(N'2024-10-06T01:06:00.000' AS DateTime), N'不透露', 2, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-07' AS Date), 3409, 20299, CAST(N'2024-10-07T23:18:00.000' AS DateTime), N'非常開心', 1, 4)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-08' AS Date), 2034, 3094, CAST(N'2024-10-08T20:50:00.000' AS DateTime), N'有點不開心', 4, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-12' AS Date), 2562, 8486, CAST(N'2024-10-12T22:28:00.000' AS DateTime), N'不透露', 1, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-14' AS Date), 1425, 4200, CAST(N'2024-10-14T20:21:00.000' AS DateTime), N'普通', 3, 3)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-15' AS Date), 1166, 11178, CAST(N'2024-10-15T04:12:00.000' AS DateTime), N'有點不開心', 4, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-16' AS Date), 3508, 13868, CAST(N'2024-10-16T22:35:00.000' AS DateTime), N'不透露', 5, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-19' AS Date), 3720, 15518, CAST(N'2024-10-19T23:29:00.000' AS DateTime), N'普通', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-20' AS Date), 825, 19802, CAST(N'2024-10-20T01:58:00.000' AS DateTime), N'非常開心', 5, 1)
GO
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-21' AS Date), 2407, 6559, CAST(N'2024-10-21T02:30:00.000' AS DateTime), N'非常開心', 3, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-22' AS Date), 0, 11, CAST(N'2024-10-22T20:36:00.000' AS DateTime), N'不開心', 10, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-25' AS Date), 4521, 8004, CAST(N'2024-10-25T09:17:00.000' AS DateTime), N'普通', 0, 7)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-29' AS Date), 13000, 0, CAST(N'2024-10-29T16:46:00.000' AS DateTime), N'不透露', 0, 10)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-30' AS Date), 2893, 16114, CAST(N'2024-10-30T21:58:00.000' AS DateTime), N'有點不開心', 3, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-10-31' AS Date), 3017, 7291, CAST(N'2024-10-31T23:08:00.000' AS DateTime), N'非常開心', 4, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-01' AS Date), 2570, 3124, CAST(N'2024-11-01T04:02:00.000' AS DateTime), N'非常開心', 2, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-02' AS Date), 0, 0, CAST(N'2001-08-13T00:00:00.000' AS DateTime), N'不透露', 0, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-03' AS Date), 3707, 17524, CAST(N'2024-11-03T04:24:00.000' AS DateTime), N'不透露', 5, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-04' AS Date), 500, 5000, CAST(N'2024-11-05T06:00:00.000' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-05' AS Date), 1312, 11289, CAST(N'2024-11-05T00:24:00.000' AS DateTime), N'不透露', 4, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-06' AS Date), 1840, 8876, CAST(N'2024-11-06T22:03:00.000' AS DateTime), N'有點不開心', 2, 5)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-08' AS Date), 2766, 17182, CAST(N'2024-11-08T21:33:00.000' AS DateTime), N'有點不開心', 0, 0)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-10' AS Date), 2230, 5600, CAST(N'2024-11-10T23:13:00.000' AS DateTime), N'非常開心', 2, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-11' AS Date), 3000, 5600, CAST(N'2024-11-11T23:30:00.000' AS DateTime), N'普通', 2, 1)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-12' AS Date), 2200, 8000, CAST(N'2024-11-12T23:00:00.000' AS DateTime), N'不透露', 4, 2)
INSERT [dbo].[DailyHealthRecord] ([C_ID], [HRecordDate], [Water], [Steps], [Sleep], [Mood], [Vegetables], [Snacks]) VALUES (10036, CAST(N'2024-11-13' AS Date), 2500, 7560, CAST(N'2024-11-13T22:45:00.000' AS DateTime), N'普通', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[DailyTask] ON 

INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (1, N'每天攝取30克膳食纖維', 15, 0, N'未通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (2, N'每周吃兩次魚', 5, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (3, N'限制糖分攝取', 15, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (4, N'進行10分鐘伸展運動', 30, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (5, N'每周進行兩次重量訓練', 25, 0, N'未通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (6, N'保持良好的坐姿', 10, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (7, N'早睡早起', 15, 0, N'未通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (8, N'保證7-8小時睡眠', 10, 0, N'未通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (9, N'學習一個新的知識點', 15, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (10, N'保持樂觀的心態', 15, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (11, N'與朋友家人互動', 5, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (12, N'培養一個新的興趣', 20, 0, N'未通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (13, N'記錄一件感恩的事情', 30, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (14, N'10分鐘不使用手機', 25, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (15, N'保持室內空氣流通', 15, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (16, N'開合跳15下', 5, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (17, N'喝一杯水', 15, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (18, N'空中腳踏車3分鐘', 5, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (19, N'抬腿5分鐘', 10, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (20, N'空氣椅1分鐘', 15, 1, N'通過')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (21, N'手機', 15, 0, N'待複核')
INSERT [dbo].[DailyTask] ([TaskID], [TaskName], [Reward], [TaskActive], [T_ReviewStatus]) VALUES (22, N'跳繩1分鐘', 20, 0, N'待複核')
SET IDENTITY_INSERT [dbo].[DailyTask] OFF
GO
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10009, CAST(N'2024-08-15' AS Date), N'限制糖分攝取', 0, N'進行10分鐘伸展運動', 1, N'保持良好的坐姿', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10009, CAST(N'2024-08-16' AS Date), N'空氣椅1分鐘', 1, N'10分鐘不使用手機', 0, N'空中腳踏車3分鐘', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10009, CAST(N'2024-08-17' AS Date), N'空中腳踏車3分鐘', 0, N'抬腿5分鐘', 0, N'學習一個新的知識點', 1)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10009, CAST(N'2024-08-18' AS Date), N'記錄一件感恩的事情', 1, N'喝一杯水', 0, N'空氣椅1分鐘', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10009, CAST(N'2024-08-19' AS Date), N'抬腿5分鐘', 0, N'學習一個新的知識點', 1, N'10分鐘不使用手機', 1)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10009, CAST(N'2024-08-20' AS Date), N'抬腿5分鐘', 0, N'開合跳15下', 1, N'喝一杯水', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10022, CAST(N'2024-09-02' AS Date), N'10分鐘不使用手機', 1, N'空氣椅1分鐘', 1, N'抬腿5分鐘', 1)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10022, CAST(N'2024-09-03' AS Date), N'空氣椅1分鐘', 0, N'學習一個新的知識點', 1, N'10分鐘不使用手機', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10022, CAST(N'2024-09-04' AS Date), N'記錄一件感恩的事情', 0, N'抬腿5分鐘', 0, N'喝一杯水', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10022, CAST(N'2024-09-05' AS Date), N'喝一杯水', 0, N'空氣椅1分鐘', 0, N'10分鐘不使用手機', 1)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10022, CAST(N'2024-09-06' AS Date), N'學習一個新的知識點', 1, N'空中腳踏車3分鐘', 0, N'記錄一件感恩的事情', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10022, CAST(N'2024-09-07' AS Date), N'開合跳15下', 1, N'10分鐘不使用手機', 1, N'喝一杯水', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10022, CAST(N'2024-09-08' AS Date), N'開合跳15下', 1, N'抬腿5分鐘', 0, N'記錄一件感恩的事情', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10022, CAST(N'2024-09-09' AS Date), N'空中腳踏車3分鐘', 0, N'空氣椅1分鐘', 0, N'抬腿5分鐘', 1)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10024, CAST(N'2024-09-09' AS Date), N'10分鐘不使用手機', 0, N'喝一杯水', 0, N'空氣椅1分鐘', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10024, CAST(N'2024-09-10' AS Date), N'喝一杯水', 0, N'抬腿5分鐘', 1, N'開合跳15下', 1)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10028, CAST(N'2024-10-23' AS Date), N'限制糖分攝取', 0, N'空中腳踏車3分鐘', 0, N'保持樂觀的心態', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10029, CAST(N'2024-10-29' AS Date), N'學習一個新的知識點', 1, N'開合跳15下', 1, N'空中腳踏車3分鐘', 1)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10029, CAST(N'2024-10-30' AS Date), N'學習一個新的知識點', 1, N'進行10分鐘伸展運動', 1, N'抬腿5分鐘', 1)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10029, CAST(N'2024-10-31' AS Date), N'學習一個新的知識點', 0, N'抬腿5分鐘', 0, N'限制糖分攝取', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10029, CAST(N'2024-11-01' AS Date), N'限制糖分攝取', 0, N'保持室內空氣流通', 0, N'與朋友家人互動', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10029, CAST(N'2024-11-02' AS Date), N'空中腳踏車3分鐘', 0, N'限制糖分攝取', 0, N'10分鐘不使用手機', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10029, CAST(N'2024-11-03' AS Date), N'空中腳踏車3分鐘', 0, N'記錄一件感恩的事情', 0, N'與朋友家人互動', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10036, CAST(N'2024-11-04' AS Date), N'保持良好的坐姿', 1, N'保持樂觀的心態', 1, N'空中腳踏車3分鐘', 1)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10036, CAST(N'2024-11-08' AS Date), N'空中腳踏車3分鐘', 0, N'喝一杯水', 0, N'空氣椅1分鐘', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10036, CAST(N'2024-11-12' AS Date), N'保持樂觀的心態', 0, N'開合跳15下', 0, N'進行10分鐘伸展運動', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (10036, CAST(N'2024-11-14' AS Date), N'保持良好的坐姿', 0, N'10分鐘不使用手機', 0, N'限制糖分攝取', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (11031, CAST(N'2024-11-05' AS Date), N'每周吃兩次魚', 1, N'保持樂觀的心態', 1, N'抬腿5分鐘', 1)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (11031, CAST(N'2024-11-06' AS Date), N'限制糖分攝取', 1, N'與朋友家人互動', 1, N'保持樂觀的心態', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (11031, CAST(N'2024-11-07' AS Date), N'每周吃兩次魚', 1, N'開合跳15下', 0, N'與朋友家人互動', 0)
INSERT [dbo].[DailyTaskRecord] ([C_ID], [TRecordDate], [T1Name], [T1Completed], [T2Name], [T2Completed], [T3Name], [T3Completed]) VALUES (11038, CAST(N'2024-11-12' AS Date), N'保持良好的坐姿', 1, N'喝一杯水', 1, N'保持室內空氣流通', 1)
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (1, N'uo12354@gmail.com', N'網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢', CAST(N'2024-09-06T16:50:29.000' AS DateTime), 1, CAST(N'2024-10-18T14:03:40.670' AS DateTime), N'48945')
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (2, N'user2@example.com', N'功能A有bug', CAST(N'2024-09-06T16:50:29.857' AS DateTime), 1, CAST(N'2024-09-13T16:50:29.857' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (3, N'user3@example.com', N'介面設計不直覺', CAST(N'2024-09-06T16:50:29.000' AS DateTime), 1, CAST(N'2024-10-18T14:05:05.197' AS DateTime), N'000')
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (4, N'user4@example.com', N'希望增加X功能', CAST(N'2024-09-06T16:50:29.857' AS DateTime), 1, CAST(N'2024-09-09T16:50:29.857' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (5, N'user5@example.com', N'系統常常當機', CAST(N'2024-09-06T16:50:29.000' AS DateTime), 1, CAST(N'2024-10-18T14:07:32.063' AS DateTime), N'9/6/')
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (6, N'user6@example.com', N'建議優化Y流程', CAST(N'2024-09-06T16:50:29.857' AS DateTime), 1, CAST(N'2024-09-11T16:50:29.857' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (7, N'user7@example.com', N'資料庫查詢速度慢', CAST(N'2024-09-06T16:50:29.857' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (8, N'user8@example.com', N'希望增加Z功能', CAST(N'2024-09-06T16:50:29.857' AS DateTime), 1, CAST(N'2024-09-08T16:50:29.857' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (9, N'user9@example.com', N'介面美觀度不足', CAST(N'2024-09-06T16:50:29.857' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (10, N'user10@example.com', N'系統穩定性有待加強', CAST(N'2024-09-06T16:50:29.857' AS DateTime), 1, CAST(N'2024-09-10T16:50:29.857' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (11, N'user1@example.com', N'網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢 網站速度很慢', CAST(N'2024-09-09T16:28:55.967' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (12, N'user2@example.com', N'功能A有bug', CAST(N'2024-08-02T00:00:00.000' AS DateTime), 1, CAST(N'2024-08-07T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (13, N'user3@example.com', N'介面設計不直覺', CAST(N'2024-08-05T00:00:00.000' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (14, N'user4@example.com', N'希望增加X功能', CAST(N'2024-08-10T00:00:00.000' AS DateTime), 1, CAST(N'2024-08-15T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (15, N'user5@example.com', N'系統常常當機', CAST(N'2024-08-17T00:00:00.000' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (16, N'user6@example.com', N'建議優化Y流程', CAST(N'2024-08-31T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-01T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (17, N'user7@example.com', N'資料庫查詢速度慢', CAST(N'2024-09-01T00:00:00.000' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (18, N'user8@example.com', N'希望增加Z功能', CAST(N'2024-09-01T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-05T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (19, N'user9@example.com', N'介面美觀度不足', CAST(N'2024-09-02T00:00:00.000' AS DateTime), 1, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (20, N'user10@example.com', N'系統穩定性有待加強', CAST(N'2024-09-03T00:00:00.000' AS DateTime), 1, CAST(N'2024-09-08T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (21, N'uo12354@gmail.com', N'5656', CAST(N'2024-10-18T14:34:29.000' AS DateTime), 1, CAST(N'2024-10-18T14:35:57.107' AS DateTime), N'5678')
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (22, N'uo12354@gmail.com', N'155482343', CAST(N'2024-10-18T14:36:28.087' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (23, N'uo12354@gmail.com', N'155482343', CAST(N'2024-10-18T14:36:31.523' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (24, N'uo12354@gmail.com', N'155482343', CAST(N'2024-10-18T14:36:33.000' AS DateTime), 1, CAST(N'2024-11-11T13:53:17.757' AS DateTime), N'老闆理我
')
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (25, N'uo12354@gmail.com', N'155482343', CAST(N'2024-10-18T14:37:01.133' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (26, N'uo12354@gmail.com', N'155482343', CAST(N'2024-10-18T14:37:02.000' AS DateTime), 1, CAST(N'2024-11-11T13:50:05.930' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (27, N'uo12354@gmail.com', N'155482343', CAST(N'2024-10-18T14:37:04.000' AS DateTime), 1, CAST(N'2024-11-11T13:48:35.143' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (28, N'uo12354@gmail.com', N'155482343', CAST(N'2024-10-18T14:37:05.000' AS DateTime), 1, CAST(N'2024-11-11T13:46:24.513' AS DateTime), NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (29, N'oez600oez@gmail.comiii', N'iii', CAST(N'2024-11-05T21:50:45.863' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (30, N'oez600oez@gmail.com', N'hhhh', CAST(N'2024-11-06T10:59:39.620' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Feedback] ([FeedbackNO], [Email], [Content], [Submitted], [Pro_Active], [Pro_Date], [Pro_Content]) VALUES (31, N'oe123@sdjfisdjfisdjf', N'asdad', CAST(N'2024-11-06T11:55:52.673' AS DateTime), 0, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
INSERT [dbo].[PasswordResetRequests] ([Id], [Email], [Token], [CreatedAt]) VALUES (N'066f8c81-616f-4c35-b6f4-9a827f9f3122', N'oez666oez@gmail.com', N'Q2ZESjhHSWF0QmRQVGlSRWp0Y2w4bXBMcVFMc1hxOFlPeDM3NEZXVVVCK2JNek4zVlFyK2RZNUtBRjV0dmdoYStPL01IRExXWjNoMzVpRUJ5TXUydXlmVkpUMi9JbXJ6dHZUS1VFOC9wTTJWV2hDQTFBTTdkaHJ0V2U4cUdIb3VUcm5UNlZVRC9QZUI5ZWJVWFJlSE1pajYrZ0x4RUlMYmd0aTd4NWFvWmtVRkVSQnNVQjQwL1MrYkU4R1hRYTVPeFhRSGtNMGpSWWpjSzhiMHdxVVhmK2N1VmdvTU1wc2ZZYVRGclh3SHBUYXl1MWlm', CAST(N'2024-11-06T14:15:52.197' AS DateTime))
INSERT [dbo].[PasswordResetRequests] ([Id], [Email], [Token], [CreatedAt]) VALUES (N'5c543546-e394-4155-9af8-fae81c20beea', N'oez666oez@gmail.com', N'Q2ZESjhHSWF0QmRQVGlSRWp0Y2w4bXBMcVFMTVRLSmFkTHpuc0xtNjhHdXFNN0xiaFJjaGFEanFsS3FVS0JtQ2hmcnNBR3FFNUg4czRLUDNIVWpJRlZNNWM4L1IyMVJkWTZlSGJGMnVtUThNYXgvcUlLbndPbVFVTlVsRFdQUXBmNjJkbWxKN1hDWUtMdjVhaUhBM3YzNXJDc0ZyMkdaSmpMZGFYaGF6Q1hWUTFSQTc3MTJWK0xzaW93alVoRUxxQ3JGaUZWc1NmYVRmZkt5d1JtWTVVaUpucWlaZktrVWtuK0kxTXVQbUFaSGtnNXJi', CAST(N'2024-10-05T02:23:27.107' AS DateTime))
INSERT [dbo].[PasswordResetRequests] ([Id], [Email], [Token], [CreatedAt]) VALUES (N'61dfd11d-f69a-4cf6-bed0-81c3470a9c1a', N'uo12354@gmail.com', N'Q2ZESjhNd2R2S3lHSnAxQnMvdHhrUENJeGcyQUJySjZpSG1sZVRjbVFQU2licEwyMDhrTEVHMTRNQWo3VlNjdmRVcG51N21nR1RHRDF2L2U0ZjdVMDMwSnFYblF3a2FoMDdXdVlaNmJRS0ZsdFM0SnB3NjZ3QkVhRTJjM2VkZEkzSW1xeldXdkNraVdtMHNIWWlrVW5HbzJ0NGthVU51amZnVGNGdWVab2wza2hQSitvaUViRkJBWFNKY29YNnRnaGdEdVRBVWNPVmNJOFVjWk1hemZiUXlETW4rSHE3YkxFT1Z6aGFYZnBjTW9HeWpB', CAST(N'2024-10-14T15:36:04.477' AS DateTime))
INSERT [dbo].[PasswordResetRequests] ([Id], [Email], [Token], [CreatedAt]) VALUES (N'6cd9a4dd-582e-4a6a-bcc1-aabce18fe66d', N'oez666oez@gmail.com', N'Q2ZESjhHSWF0QmRQVGlSRWp0Y2w4bXBMcVFMOVhGaVdNRTNRQ09NNjdBRVlzZkhUV1VMMTFLdlUvU3RPZFJ4clE4RUNVdmpadXJhL1lXL3V0Q3FkUVdJR1IvcGdrVWVEYlh1UllOTVN4TGZXZzhvc2tFRjBsbHdhZ1BDZmVla0NDQm5WTU5VeXBsNzlCVnlGc3FkUG9KanF2UzZDeXlDcG1RUDZwRlp5dVBSUzRvc0hrMGNOSUtOT1dOOUhBVVJiMlF4SEhwV1JrLzJsdUZLZmFFRGZrQlBRc2xDbDNuVTBSdVUvQkJOYVpIeVgzK01C', CAST(N'2024-11-06T16:07:23.797' AS DateTime))
INSERT [dbo].[PasswordResetRequests] ([Id], [Email], [Token], [CreatedAt]) VALUES (N'8bae797d-1e17-4c13-a82f-425d52c27047', N'oez666oez@gmail.com', N'Q2ZESjhHSWF0QmRQVGlSRWp0Y2w4bXBMcVFLaTl1QmVxVlZmVk1JdnJDN1dxTjZoYzhZck1RSVpuYXd0TTNsc0pHMkZSeTNmUUxTTmI0UlA3M0g2MzUzZ25GWmlCTGt5aCtpK2hVd3dyN1ZndDBQOGh3dENqOVJDWHdrMDcrckMzWm14Qy9Wa1NZbmlXdEJ3Y3pSTHI4cTQzdTIrREhENEhzS0plSExJNTVNWU5JYkp3c2lGejVTRFVURVFBV0RjOWVvNVBxbFcwcXpkOEl0bHk0Y1JGNmk0em5FRlR4c01yZnRzeGQrTDNmb2lXNGdI', CAST(N'2024-10-05T15:55:28.410' AS DateTime))
INSERT [dbo].[PasswordResetRequests] ([Id], [Email], [Token], [CreatedAt]) VALUES (N'9934fe98-4162-48ae-acc8-eec04124c9b9', N'oez666oez@gmail.com', N'Q2ZESjhHSWF0QmRQVGlSRWp0Y2w4bXBMcVFJeDQ3NmhTT3lXcTZHT25NNDhoYVhrb3BHKzZ5c3dBTUJkaDVUT2IyNGZENmpEVWxBRkJtY2VJWFowYnA1dEtFUU4zaGJyTzlwaVVHZnh4LytReGZQdGFhOEhyUDhINmJ4VzkyZkF4a1VndVgxdHlCRldjZ0lSZTlkdEE4VXFKUEZEZ1l1TlBhUjRHSWtJMHJtOUV5VmM2M2pXcFM1SXpvVVZzdStFRGdnNHpRU3dIVlJsYzRZd0VEWXJsQXE5aVptQUhMQmZjNUlVSDdoaWJHY0hCTGY4', CAST(N'2024-09-30T02:55:03.850' AS DateTime))
INSERT [dbo].[PasswordResetRequests] ([Id], [Email], [Token], [CreatedAt]) VALUES (N'ba67ac03-f8ec-474f-a5f1-dfa0a8ec9dff', N'oez666oez@gmail.com', N'Q2ZESjhHSWF0QmRQVGlSRWp0Y2w4bXBMcVFKbHBkZXpBR3lHcHJpTGRKblJ1TzB3czk4S1U3YzM2ZnZGZW5NUExkNTNYVHpMNEZFUWZZM25JMEx6TjFDczlOTE5xQ2tycGp6TzdUckNzdHREaWRwZjVDRGRPOWJOSE9jTTZ5c2tnUC91bTEvZTNyS0F3Ylk3THI2U2JmRjJ4bVkvTjU4TnA0MDlSVllzWlF3WjNLOFQ2WmF3ajFCdmpzNVRScUdDenJhVnVXUFJyc2crVlNEa1BuM09rdkNBL1QxMkNybWNTSDVROUVYam1FK0cwSU04', CAST(N'2024-09-30T03:08:14.233' AS DateTime))
INSERT [dbo].[PasswordResetRequests] ([Id], [Email], [Token], [CreatedAt]) VALUES (N'e57cfe50-287c-46b9-923d-dad60aa3b3d6', N'oez666oez@gmail.com', N'Q2ZESjhHSWF0QmRQVGlSRWp0Y2w4bXBMcVFLakJJQXprenNISm8xVUN1c1hRTk4vZVZHZkl5ODJRTnQxeCtGVzJlbFpjblJacXFNVmNuRE9DRHVibVdhMUtzeWUwMFlZYWFqN2s1dzA4OGg1STdiZk03N2xKN3ZaU00yUE5sRGhmQ2w2Wm10TmFWanVYWE5wMEtaejFYakZhalBET2RUNFhoNEdqM0VPQmpWMll1VnZsUnNYWDlrNy9Pd1VsaDJwcE1OU1o0aXhwSG5GOHdpenplWDU0MzNmdlBqbmVoQ2ZYNXk1MFpWL3E0Y2RMUExO', CAST(N'2024-09-30T02:53:50.977' AS DateTime))
GO
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'1212', N'cherry850406@gmail.com', N'$2a$11$8EgI5w3cXt7FSH3yARsxAePIFILZalxF89/R5agjvdw9jwmysleMm', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'122', N'cherry850406@gmail.com', N'$2a$11$FnOfrw1gclKZ3WugdDDSVeBMEo7I1tUdrPbow1zEzQ2kTwmxhibrG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'123123', N'123123@123123', N'$2a$11$ilnOmNZcxXsWYnnMs2LCX.1OAGM2vvUWLzVyuiNTI/YUhNc5YObGK', 0, N'b87242f7-acc4-4ac5-8502-2c89bc570ec4')
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'123123123', N'123@sdfsdf.com', N'$2a$11$Sy5yrmW92WIQ/jJz/4vd1.8n8Fy9seXk9T6NWvAL1Iq8kprVj4qiy', 0, N'f2eee93c-dc82-4f23-8518-384213dc591b')
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'123asdasd', N'123@sdfsdf.cd', N'$2a$11$AAVorWJzozWePdfb2EZYuelQGAZHe4nBvqKAqfjWLXg9tGtJfR/JW', 0, N'040fdb2f-7293-4910-b65b-98e8c0f8f1de')
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'asdasd', N'asdasd@asdasd', N'$2a$11$tclamh4HayZK3SLtwPyV0.bDhs9JYkd1SCZc.po9PNsfYepSkVj6O', 0, N'c8bfb247-167c-4600-bb36-6b9b142ea432')
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'chun', N'cherry850406@gmail.com', N'$2a$11$lzQ68MvTmtRiBVqIeJb2ROQwIjWQbpvB0hBnn0ARnxy.eRXtw5uXu', 0, N'34c58589-aa27-4dc4-bea4-96bbaa23b19a')
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'chun00', N'cherry850406@gmail.com', N'$2a$11$I4PMS8h4/xS/ZGNIRvbqVu3xr8v57DX0DEauTOw23EVWvour1eW0q', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'dragon567', N'dragon567@gmail.com', N'$2a$11$P.pOthPBuqxxkiTqRaf0POljdpRRKQlR9dJaROcEAKGbyGgDWnAeO', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'guardian555', N'guardian555@yahoo.com', N'$2a$11$P.pOthPBuqxxkiTqRaf0POljdpRRKQlR9dJaROcEAKGbyGgDWnAeO', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'hero891', N'hero891@yahoo.com', N'$2a$11$P.pOthPBuqxxkiTqRaf0POljdpRRKQlR9dJaROcEAKGbyGgDWnAeO', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'hunter432', N'hunter432@gmail.com', N'$2a$11$P.pOthPBuqxxkiTqRaf0POljdpRRKQlR9dJaROcEAKGbyGgDWnAeO', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'joker321', N'joker321@outlook.com', N'$2a$11$P.pOthPBuqxxkiTqRaf0POljdpRRKQlR9dJaROcEAKGbyGgDWnAeO', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'knight245', N'knight245@yahoo.com', N'$2a$11$P.pOthPBuqxxkiTqRaf0POljdpRRKQlR9dJaROcEAKGbyGgDWnAeO', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'leo555555', N'uo12354@gmail.com', N'$2a$11$lzOWO0aAnK85bBpYz1Pbt.SDW6WO5775gHcFEIwk9QJnoyke7i29y', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'mama', N'cherry850406@gmail.com', N'$2a$11$ygmomVVRb9hv5IUhZIbEuOU5o3sUAy3XYkY1KaNXfArPvqWs4C6ym', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'mystic789', N'mystic789@yahoo.com', N'$2a$11$P.pOthPBuqxxkiTqRaf0POljdpRRKQlR9dJaROcEAKGbyGgDWnAeO', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'ninja321', N'ninja321@gmail.com', N'$2a$11$P.pOthPBuqxxkiTqRaf0POljdpRRKQlR9dJaROcEAKGbyGgDWnAeO', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'oez103192031039', N'123@sdfsdf.cd', N'$2a$11$nEHNtwtsoX906umWzvEUKuNyPjX1ibkqfln6HFwazp7J0DQiHVnDe', 0, N'eb42d475-a035-4918-8263-bdb6fd7790bf')
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'oez660oez', N'oez600oez@gmail.com', N'$2a$11$ZAsnYIfzugvDq2wGbleXhelb2vjipoURfz5.tXrILyYwhqNosIUsW', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'phoenix763', N'phoenix763@hotmail.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'pirate876', N'pirate876@outlook.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'prince357', N'prince357@outlook.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'qwert4321', N'123456@sdfsdf.com', N'$2a$11$4q5rG3krpATrp.do5nOFceGKqo74AU3HktQ6NhQp7nqRt5qet.uGm', 0, N'bdb2201e-0ac9-4223-826e-c19b8d2c1d25')
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'ranger987', N'ranger987@gmail.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'rogue654', N'rogue654@gmail.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'samurai678', N'samurai678@yahoo.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'sdsdfs', N'oez660oez@sfsfsdf', N'$2a$11$wR9aDIghgNVYT5RcDXHSDOvVfFNAQaTAKDhqTNumJm4yM9XKandTS', 0, N'c46798cd-3696-40d9-b4fe-ea558889fa60')
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'shadow999', N'shadow999@hotmail.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'sser13123', N'123456@sdfsdf.com', N'$2a$11$wvx5NbCe7h4g6mwftCyUSuz8vDVmv0j2PLbsVdpdxfwe2zl.aSc.2', 0, N'1bd436be-8b6e-4a35-91bc-bd080fc55d09')
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'sser13124', N'12349978@sdfsdf.com', N'$2a$11$EviRH1vpFCpzaBXCRlnp8ubvUmN4tG5nLRVQfzZoMzXXRVJraWZEO', 0, N'f4295fa3-c10a-4945-ac0f-1594423fc83c')
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'sssara123', N'oez666oez@gmail.com', N'$2a$11$HvvS8yPvdMezBtjinltuOOid1IvZ/XFQhMIpL9s6hcWcNnByTshbq', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'storm456', N'storm456@live.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'sunny234', N'sunny234@outlook.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'tiger123', N'tiger123@gmail.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'warrior123', N'warrior123@gmail.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'wizard007', N'wizard007@gmail.com', N'$2a$11$TX9pwQkGxLSEkZ2UJtZV5ecJebz/luRA3SR1/3G6fY.4ZiSELw9QG', 1, NULL)
INSERT [dbo].[Player] ([Account], [Email], [Password], [Playerstatus], [token]) VALUES (N'yaya', N'cherry850406@gmail.com', N'$2a$11$EyXslr0eG6gkf3ydKlqJS.0oPeO8x/J1peuTe8j85Ox28FFyKptjq', 1, NULL)
GO
INSERT [dbo].[RoomAccessories] ([C_ID], [Bookcase], [Bed], [Desk], [Chair], [Plant]) VALUES (10009, 1004, 0, 0, 0, 0)
INSERT [dbo].[RoomAccessories] ([C_ID], [Bookcase], [Bed], [Desk], [Chair], [Plant]) VALUES (10022, 1004, 0, 0, 0, 0)
INSERT [dbo].[RoomAccessories] ([C_ID], [Bookcase], [Bed], [Desk], [Chair], [Plant]) VALUES (10024, 1004, 0, 0, 0, 0)
GO
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10027, CAST(N'2024-09-09' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10027, CAST(N'2024-09-10' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-02' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-05' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-07' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-09' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-11' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-14' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-15' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-18' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-24' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-25' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-29' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-05-31' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-02' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-04' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-08' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-09' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-10' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-14' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-18' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-19' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-20' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-25' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-29' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-06-30' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-01' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-03' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-04' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-06' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-07' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-08' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-10' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-11' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-12' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-13' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-14' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-17' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-18' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-19' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-21' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-23' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-24' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-25' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-28' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-30' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-07-31' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-01' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-02' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-05' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-08' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-10' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-12' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-15' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-17' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-18' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-19' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-20' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-23' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-25' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-26' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-08-28' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-06' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-08' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-09' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-10' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-12' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-13' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-15' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-16' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-19' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-20' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-22' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-23' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-27' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-28' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10035, CAST(N'2024-09-30' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-02' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-03' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-07' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-08' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-09' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-10' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-12' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-13' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-14' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-15' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-17' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-18' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-21' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-22' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-23' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-24' AS Date), 1, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-26' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-29' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-30' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-10-31' AS Date), 0, 1)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-11-02' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-11-05' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-11-06' AS Date), 0, 1)
GO
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-11-07' AS Date), 0, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (10036, CAST(N'2024-11-08' AS Date), 1, 0)
INSERT [dbo].[WeeklyHealthRecord] ([C_ID], [WRecordDate], [Exercise], [Cleaning]) VALUES (11038, CAST(N'2024-11-12' AS Date), 1, 0)
GO
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (10029, CAST(N'2024-09-15' AS Date), CAST(60.5 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (10029, CAST(N'2024-10-01' AS Date), CAST(50.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (10036, CAST(N'2024-09-01' AS Date), CAST(68.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (10036, CAST(N'2024-10-01' AS Date), CAST(70.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (10036, CAST(N'2024-11-01' AS Date), CAST(400.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (10036, CAST(N'2024-11-12' AS Date), CAST(75.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (10036, CAST(N'2024-11-14' AS Date), CAST(103.4 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11031, CAST(N'2024-10-01' AS Date), CAST(46.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11031, CAST(N'2024-11-01' AS Date), CAST(52.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11032, CAST(N'2024-11-05' AS Date), CAST(26.3 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11033, CAST(N'2024-11-05' AS Date), CAST(123.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11034, CAST(N'2024-11-06' AS Date), CAST(23.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11034, CAST(N'2024-11-12' AS Date), CAST(600.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11035, CAST(N'2024-11-11' AS Date), CAST(23.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11035, CAST(N'2024-11-12' AS Date), CAST(600.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11036, CAST(N'2024-11-12' AS Date), CAST(400.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11037, CAST(N'2024-11-12' AS Date), CAST(600.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11038, CAST(N'2024-11-12' AS Date), CAST(50.0 AS Decimal(4, 1)))
INSERT [dbo].[WeightRecord] ([C_ID], [W_RecordDate], [Weight]) VALUES (11039, CAST(N'2024-11-12' AS Date), CAST(80.0 AS Decimal(4, 1)))
GO
ALTER TABLE [dbo].[AccessoriesList] ADD  CONSTRAINT [DF__Accessori__P_Act__5DCAEF64]  DEFAULT ((0)) FOR [P_Active]
GO
ALTER TABLE [dbo].[AccessoriesList] ADD  CONSTRAINT [DF__Accessori__P_Rev__5EBF139D]  DEFAULT ('???') FOR [P_ReviewStatus]
GO
ALTER TABLE [dbo].[Administrator] ADD  DEFAULT ((0)) FOR [M_DailyTask]
GO
ALTER TABLE [dbo].[Administrator] ADD  DEFAULT ((0)) FOR [M_Product]
GO
ALTER TABLE [dbo].[Administrator] ADD  DEFAULT ((0)) FOR [M_Administrator]
GO
ALTER TABLE [dbo].[Character] ADD  DEFAULT ((1)) FOR [Level]
GO
ALTER TABLE [dbo].[Character] ADD  CONSTRAINT [DF__Character__Exper__2180FB33]  DEFAULT ((0)) FOR [Experience]
GO
ALTER TABLE [dbo].[Character] ADD  DEFAULT ('??') FOR [LivingStatus]
GO
ALTER TABLE [dbo].[Character] ADD  DEFAULT (getdate()) FOR [MoveInDate]
GO
ALTER TABLE [dbo].[Character] ADD  DEFAULT ('1900/01/01') FOR [MoveOutDate]
GO
ALTER TABLE [dbo].[CharacterAccessorie] ADD  DEFAULT ((0)) FOR [Head]
GO
ALTER TABLE [dbo].[CharacterAccessorie] ADD  DEFAULT ((0)) FOR [Upper]
GO
ALTER TABLE [dbo].[CharacterAccessorie] ADD  DEFAULT ((0)) FOR [Lower]
GO
ALTER TABLE [dbo].[DailyHealthRecord] ADD  DEFAULT (getdate()) FOR [HRecordDate]
GO
ALTER TABLE [dbo].[DailyTask] ADD  DEFAULT ((0)) FOR [TaskActive]
GO
ALTER TABLE [dbo].[DailyTask] ADD  DEFAULT ('???') FOR [T_ReviewStatus]
GO
ALTER TABLE [dbo].[DailyTaskRecord] ADD  DEFAULT (getdate()) FOR [TRecordDate]
GO
ALTER TABLE [dbo].[Feedback] ADD  DEFAULT (getdate()) FOR [Submitted]
GO
ALTER TABLE [dbo].[Feedback] ADD  DEFAULT ((0)) FOR [Pro_Active]
GO
ALTER TABLE [dbo].[Player] ADD  DEFAULT ((0)) FOR [Playerstatus]
GO
ALTER TABLE [dbo].[RoomAccessories] ADD  DEFAULT ((0)) FOR [Bookcase]
GO
ALTER TABLE [dbo].[RoomAccessories] ADD  DEFAULT ((0)) FOR [Bed]
GO
ALTER TABLE [dbo].[RoomAccessories] ADD  DEFAULT ((0)) FOR [Desk]
GO
ALTER TABLE [dbo].[RoomAccessories] ADD  DEFAULT ((0)) FOR [Chair]
GO
ALTER TABLE [dbo].[RoomAccessories] ADD  DEFAULT ((0)) FOR [Plant]
GO
ALTER TABLE [dbo].[WeeklyHealthRecord] ADD  CONSTRAINT [DF__WeeklyHea__WReco__787EE5A0]  DEFAULT (getdate()) FOR [WRecordDate]
GO
ALTER TABLE [dbo].[WeeklyHealthRecord] ADD  CONSTRAINT [DF__WeeklyHea__Exerc__797309D9]  DEFAULT ((0)) FOR [Exercise]
GO
ALTER TABLE [dbo].[WeeklyHealthRecord] ADD  CONSTRAINT [DF__WeeklyHea__Clean__7A672E12]  DEFAULT ((0)) FOR [Cleaning]
GO
ALTER TABLE [dbo].[WeightRecord] ADD  CONSTRAINT [DF__WeightRec__W_Rec__7B5B524B]  DEFAULT (getdate()) FOR [W_RecordDate]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [goodbyepotato] SET  READ_WRITE 
GO
