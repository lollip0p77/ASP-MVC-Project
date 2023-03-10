USE [master]
GO
/****** Object:  Database [LesPetitsPandas]    Script Date: 2023-03-10 14:08:37 ******/
CREATE DATABASE [LesPetitsPandas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LesPetitsPandas', FILENAME = N'D:\Programation\SQL\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LesPetitsPandas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LesPetitsPandas_log', FILENAME = N'D:\Programation\SQL\SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LesPetitsPandas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LesPetitsPandas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LesPetitsPandas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LesPetitsPandas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET ARITHABORT OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LesPetitsPandas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LesPetitsPandas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LesPetitsPandas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LesPetitsPandas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LesPetitsPandas] SET  MULTI_USER 
GO
ALTER DATABASE [LesPetitsPandas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LesPetitsPandas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LesPetitsPandas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LesPetitsPandas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LesPetitsPandas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LesPetitsPandas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LesPetitsPandas] SET QUERY_STORE = OFF
GO
USE [LesPetitsPandas]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2023-03-10 14:08:37 ******/
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
/****** Object:  Table [dbo].[Allergies]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allergies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Allergies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AllergiesEnfant]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllergiesEnfant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EnfantID] [int] NOT NULL,
	[AllergieID] [int] NOT NULL,
	[Intervention] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_AllergiesEnfant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2023-03-10 14:08:37 ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2023-03-10 14:08:37 ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2023-03-10 14:08:37 ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2023-03-10 14:08:37 ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2023-03-10 14:08:37 ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2023-03-10 14:08:37 ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2023-03-10 14:08:37 ******/
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
/****** Object:  Table [dbo].[DocumentsGenerales]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentsGenerales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](450) NOT NULL,
	[DocumentLien] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_DocumentsGenerales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentsParent]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentsParent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](255) NOT NULL,
	[RepondantID] [int] NOT NULL,
	[DocumentLien] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_DocumentsParent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Educatrices]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Educatrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Prenom] [nvarchar](50) NOT NULL,
	[Sexe] [varchar](1) NOT NULL,
	[Adresse] [nvarchar](450) NOT NULL,
	[Ville] [nvarchar](255) NOT NULL,
	[CodePostal] [nvarchar](7) NOT NULL,
	[DateDeNaissance] [date] NOT NULL,
	[DateDembauche] [date] NOT NULL,
	[DateDeFinDemploi] [date] NULL,
	[Salaire] [money] NULL,
	[Telephone] [nvarchar](14) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Educatrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enfants]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enfants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Prenom] [nvarchar](50) NOT NULL,
	[Sexe] [varchar](1) NOT NULL,
	[DateDeNaissance] [date] NOT NULL,
	[DateInscription] [date] NOT NULL,
	[ProblemeSante] [nvarchar](150) NULL,
	[ProblemeComportement] [nvarchar](450) NULL,
	[InformationSupplementaire] [varchar](2000) NULL,
	[RepondantID] [int] NOT NULL,
 CONSTRAINT [PK_Enfants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evenements]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evenements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titre] [varchar](50) NOT NULL,
	[Description] [nvarchar](125) NOT NULL,
	[Cout] [money] NULL,
	[HeureDebut] [datetime] NOT NULL,
	[HeureFin] [datetime] NOT NULL,
	[TypeID] [int] NOT NULL,
 CONSTRAINT [PK_Evenements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Garderie]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Garderie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Adresse] [nvarchar](255) NOT NULL,
	[Ville] [nvarchar](100) NOT NULL,
	[CodePostal] [varchar](7) NOT NULL,
	[Telephone] [nvarchar](14) NOT NULL,
	[Description] [varchar](4000) NULL,
 CONSTRAINT [PK_Garderie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListeDattente]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListeDattente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Prenom] [nvarchar](50) NOT NULL,
	[Telephone] [nvarchar](14) NOT NULL,
	[Couriel] [nvarchar](255) NOT NULL,
	[NombreEnfants] [int] NOT NULL,
	[Description] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_ListeDattente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicaments]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicaments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](450) NOT NULL,
	[Description] [varchar](2000) NOT NULL,
	[EnfantID] [int] NOT NULL,
 CONSTRAINT [PK_Medicaments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EducatriceID] [int] NOT NULL,
	[RepondantID] [int] NOT NULL,
	[Message] [nvarchar](2000) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Actif] [bit] NOT NULL,
	[Envoyeur] [char](1) NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonnesAutoriser]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonnesAutoriser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Prenom] [nvarchar](50) NOT NULL,
	[Telephone] [nvarchar](14) NOT NULL,
	[ContactUrgence] [varchar](5) NOT NULL,
	[LienEnfant] [varchar](50) NOT NULL,
	[EnfantID] [int] NOT NULL,
 CONSTRAINT [PK_PersonnesAutoriser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presences]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presences](
	[EnfantID] [int] NOT NULL,
	[EvenementID] [int] NOT NULL,
	[Present] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[EnfantID] ASC,
	[EvenementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repondant]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repondant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Prenom] [nvarchar](50) NOT NULL,
	[Sexe] [varchar](1) NOT NULL,
	[Adresse] [nvarchar](255) NOT NULL,
	[Ville] [nvarchar](100) NOT NULL,
	[CodePostal] [varchar](7) NOT NULL,
	[Courriel] [nvarchar](255) NOT NULL,
	[Telephone] [nvarchar](14) NOT NULL,
	[CreationDeCompte] [date] NOT NULL,
	[Lien] [nvarchar](50) NOT NULL,
	[UserID] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Repondant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeEvenement]    Script Date: 2023-03-10 14:08:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeEvenement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeEvenement] [varchar](20) NULL,
 CONSTRAINT [PK_TypeEvenement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'6.0.12')
GO
SET IDENTITY_INSERT [dbo].[Allergies] ON 

INSERT [dbo].[Allergies] ([Id], [Nom]) VALUES (2, N'Allergie au arachides')
INSERT [dbo].[Allergies] ([Id], [Nom]) VALUES (3, N'Allergie au gluten')
INSERT [dbo].[Allergies] ([Id], [Nom]) VALUES (4, N'Allergie au chat')
INSERT [dbo].[Allergies] ([Id], [Nom]) VALUES (6, N'Allergie au chien')
SET IDENTITY_INSERT [dbo].[Allergies] OFF
GO
SET IDENTITY_INSERT [dbo].[AllergiesEnfant] ON 

INSERT [dbo].[AllergiesEnfant] ([Id], [EnfantID], [AllergieID], [Intervention]) VALUES (1, 6, 3, N'fsdfgs')
INSERT [dbo].[AllergiesEnfant] ([Id], [EnfantID], [AllergieID], [Intervention]) VALUES (1002, 4, 2, N'wjnfuwe')
SET IDENTITY_INSERT [dbo].[AllergiesEnfant] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'52cefe77-7819-4788-9485-d1bc4d5115c0', N'Admin', N'ADMIN', N'75544c79-89bb-4cda-bb05-f54991150371')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6346457689567985fsdwef', N'User', N'USER', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8790285d-caa3-4f96-81e2-7902d49eddf6', N'52cefe77-7819-4788-9485-d1bc4d5115c0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d783a9f-c7b8-4c94-8927-434623d17014', N'52cefe77-7819-4788-9485-d1bc4d5115c0')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ad5ab299-9747-4ca5-a50c-cbc794d42fdd', N'6346457689567985fsdwef')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8790285d-caa3-4f96-81e2-7902d49eddf6', N'LauFourn', N'LAUFOURN', N'kevbeaulieu@gmail.com', N'KEVBEAULIEU@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEO+c81FlM6YGzKpSD4YiRGzfRte7z0/WatP9JVZd9MA8E/1fWI+iwwno621f6UsrwA==', N'M6H7PZSJ72Q5JBZQ7N5CNRVD6QTED2BV', N'bde2914c-71e3-4bd5-b34b-872813fac750', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9318284b-6fd3-42be-9a3c-05ddd40a5f1a', N'JoLevesque', N'JOLEVESQUE', N'123@gmail.com', N'123@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEL0xcTITqzI1Svfk4bg2BO6ONxbaOWm0+tuQ8KA0jI02LZoC0DHtObaO6Z4NoMUiCA==', N'NFW4WXXBQVUYT6L72TCS2CFO6FO74TMZ', N'b3b091b7-578a-408b-9d44-73915b6021da', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9d783a9f-c7b8-4c94-8927-434623d17014', N'Admin', N'ADMIN', N'Admin@test.com', N'ADMIN@TEST.COM', 1, N'AQAAAAEAACcQAAAAELd6Qvkfg9kFgQZv538LV9pr4zpF9CgP/5XB8u/wxJntrvsVgplVpeFKNT2IZ398nQ==', N'3XLB5G466QNTQVPPQBRHKJSNKH7DZJTQ', N'556094fd-4483-4483-8f38-d557cee376f2', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ad5ab299-9747-4ca5-a50c-cbc794d42fdd', N'kevbeau', N'KEVBEAULIEU94@GMAIL.COM', N'kevbeaulieu94@gmail.com', N'KEVBEAULIEU94@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAELdg5I9HkTBQVLODs9CsjTceyI2XDh/MX5Fy2NTGxnFMbHZY/z6rNbqruDcx+hhy9w==', N'AYAJZ35SJJ6XQQXOAPUXH6F5I7YOKYDK', N'7f331b13-a619-4aea-8a28-29a0c16164f1', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[DocumentsGenerales] ON 

INSERT [dbo].[DocumentsGenerales] ([Id], [Nom], [DocumentLien]) VALUES (3, N'impot-2023', N'a6427e28-436c-4924-94ee-3548df559d30_P44-2.pdf')
SET IDENTITY_INSERT [dbo].[DocumentsGenerales] OFF
GO
SET IDENTITY_INSERT [dbo].[DocumentsParent] ON 

INSERT [dbo].[DocumentsParent] ([Id], [Nom], [RepondantID], [DocumentLien]) VALUES (5, N'Facture-1', 4, N'09546c77-1c3f-4d67-8a24-7f854f5e71da_ChangementCompteDepot.pdf')
INSERT [dbo].[DocumentsParent] ([Id], [Nom], [RepondantID], [DocumentLien]) VALUES (6, N'Facture-2', 4, N'8976a8e7-8e6d-400f-ad68-0f13b95b82ef_ChangementCompteDepot.pdf')
INSERT [dbo].[DocumentsParent] ([Id], [Nom], [RepondantID], [DocumentLien]) VALUES (7, N'Facture-3', 4, N'768f1b2c-4338-4acd-b0bd-54e4c5a91e0b_ChangementCompteDepot.pdf')
SET IDENTITY_INSERT [dbo].[DocumentsParent] OFF
GO
SET IDENTITY_INSERT [dbo].[Educatrices] ON 

INSERT [dbo].[Educatrices] ([Id], [Nom], [Prenom], [Sexe], [Adresse], [Ville], [CodePostal], [DateDeNaissance], [DateDembauche], [DateDeFinDemploi], [Salaire], [Telephone], [UserId]) VALUES (1, N'Fournier', N'Laurianne', N'F', N'1122 des orme', N'quebec', N'g1j4g6', CAST(N'1998-06-17' AS Date), CAST(N'2023-02-20' AS Date), CAST(N'2027-05-20' AS Date), 90000.0000, N'3334445555', N'8790285d-caa3-4f96-81e2-7902d49eddf6')
SET IDENTITY_INSERT [dbo].[Educatrices] OFF
GO
SET IDENTITY_INSERT [dbo].[Enfants] ON 

INSERT [dbo].[Enfants] ([Id], [Nom], [Prenom], [Sexe], [DateDeNaissance], [DateInscription], [ProblemeSante], [ProblemeComportement], [InformationSupplementaire], [RepondantID]) VALUES (4, N'Beaulieu', N'Elyana', N'F', CAST(N'2023-01-01' AS Date), CAST(N'2023-02-02' AS Date), N'oui', N'non', N'non', 4)
INSERT [dbo].[Enfants] ([Id], [Nom], [Prenom], [Sexe], [DateDeNaissance], [DateInscription], [ProblemeSante], [ProblemeComportement], [InformationSupplementaire], [RepondantID]) VALUES (6, N'Blanchette', N'Will', N'M', CAST(N'2023-01-01' AS Date), CAST(N'2023-02-02' AS Date), N'non', N'non', N'non', 4)
INSERT [dbo].[Enfants] ([Id], [Nom], [Prenom], [Sexe], [DateDeNaissance], [DateInscription], [ProblemeSante], [ProblemeComportement], [InformationSupplementaire], [RepondantID]) VALUES (8, N'Gingras', N'Samuel', N'M', CAST(N'2019-06-12' AS Date), CAST(N'2023-02-25' AS Date), N'non', N'Obstineux', N'aucune', 4)
SET IDENTITY_INSERT [dbo].[Enfants] OFF
GO
SET IDENTITY_INSERT [dbo].[Evenements] ON 

INSERT [dbo].[Evenements] ([Id], [Titre], [Description], [Cout], [HeureDebut], [HeureFin], [TypeID]) VALUES (2, N'Fête Elyana', N'Souper hot-dog', 0.0000, CAST(N'2023-04-23T00:00:00.000' AS DateTime), CAST(N'2023-04-23T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Evenements] ([Id], [Titre], [Description], [Cout], [HeureDebut], [HeureFin], [TypeID]) VALUES (3, N'Fin de l''ecole', N'Dernière journée', 0.0000, CAST(N'2023-03-02T00:00:00.000' AS DateTime), CAST(N'2023-03-02T00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Evenements] OFF
GO
SET IDENTITY_INSERT [dbo].[ListeDattente] ON 

INSERT [dbo].[ListeDattente] ([Id], [Nom], [Prenom], [Telephone], [Couriel], [NombreEnfants], [Description]) VALUES (1, N'Beaulieu', N'Keven', N'5814439368', N'kevbeaulieu94@gmail.com', 1, N'test')
INSERT [dbo].[ListeDattente] ([Id], [Nom], [Prenom], [Telephone], [Couriel], [NombreEnfants], [Description]) VALUES (3, N'Gagnon', N'Simon-Pierre', N'3334445555', N'spg@hotmail.com', 1, N'test')
SET IDENTITY_INSERT [dbo].[ListeDattente] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicaments] ON 

INSERT [dbo].[Medicaments] ([Id], [Nom], [Description], [EnfantID]) VALUES (3, N'Rytalin', N'Prendre des prcaution', 6)
INSERT [dbo].[Medicaments] ([Id], [Nom], [Description], [EnfantID]) VALUES (4, N'Concerta', N'Lui donner après le diner', 8)
SET IDENTITY_INSERT [dbo].[Medicaments] OFF
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (1, 1, 4, N'Allo es tu dispo', CAST(N'2023-02-20T11:12:35.527' AS DateTime), 1, N'R')
INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (2, 1, 4, N'Allo es tu dispo', CAST(N'2023-02-20T11:13:01.737' AS DateTime), 1, N'R')
INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (3, 1, 4, N'oui je suis dispo', CAST(N'2023-02-20T11:14:15.923' AS DateTime), 1, N'E')
INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (4, 1, 4, N'allo', CAST(N'2023-02-22T08:57:09.310' AS DateTime), 1, N'E')
INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (5, 1, 4, N'Allo', CAST(N'2023-02-22T15:03:12.930' AS DateTime), 1, N'E')
INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (6, 1, 4, N'allo sa va', CAST(N'2023-02-22T15:03:23.693' AS DateTime), 1, N'R')
INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (7, 1, 4, N'allo', CAST(N'2023-02-25T09:46:42.793' AS DateTime), 1, N'E')
INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (1007, 1, 4, N'allo', CAST(N'2023-02-25T17:30:03.973' AS DateTime), 1, N'E')
INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (1008, 1, 4, N'Allo', CAST(N'2023-02-25T21:13:10.077' AS DateTime), 1, N'R')
INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (1009, 1, 4, N'Allo es tu dispo', CAST(N'2023-03-01T11:26:19.397' AS DateTime), 1, N'R')
INSERT [dbo].[Messages] ([Id], [EducatriceID], [RepondantID], [Message], [Date], [Actif], [Envoyeur]) VALUES (1010, 1, 4, N'Oui je suis dispo', CAST(N'2023-03-01T11:26:29.457' AS DateTime), 1, N'E')
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonnesAutoriser] ON 

INSERT [dbo].[PersonnesAutoriser] ([Id], [Nom], [Prenom], [Telephone], [ContactUrgence], [LienEnfant], [EnfantID]) VALUES (2, N'Gagnon', N'Simon', N'1234434545', N'Oui', N'Menoncle', 6)
INSERT [dbo].[PersonnesAutoriser] ([Id], [Nom], [Prenom], [Telephone], [ContactUrgence], [LienEnfant], [EnfantID]) VALUES (1003, N'Migneault', N'Claudine', N'5814439368', N'True', N'Grand-Mere', 6)
INSERT [dbo].[PersonnesAutoriser] ([Id], [Nom], [Prenom], [Telephone], [ContactUrgence], [LienEnfant], [EnfantID]) VALUES (1004, N'Gagnon', N'Simon-Pierre', N'3334445555', N'False', N'Menoncle', 4)
INSERT [dbo].[PersonnesAutoriser] ([Id], [Nom], [Prenom], [Telephone], [ContactUrgence], [LienEnfant], [EnfantID]) VALUES (1005, N'Lesveque', N'Ginette', N'1231234444', N'True', N'matante', 8)
SET IDENTITY_INSERT [dbo].[PersonnesAutoriser] OFF
GO
SET IDENTITY_INSERT [dbo].[Repondant] ON 

INSERT [dbo].[Repondant] ([Id], [Nom], [Prenom], [Sexe], [Adresse], [Ville], [CodePostal], [Courriel], [Telephone], [CreationDeCompte], [Lien], [UserID]) VALUES (4, N'Beaulieu', N'Keven', N'M', N'1122 des ormes', N'Quebec', N'G1J4G6', N'KEVBEAULIEU94@GMAIL.COM', N'5814431443', CAST(N'2022-01-01' AS Date), N'Pere', N'ad5ab299-9747-4ca5-a50c-cbc794d42fdd')
SET IDENTITY_INSERT [dbo].[Repondant] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeEvenement] ON 

INSERT [dbo].[TypeEvenement] ([Id], [TypeEvenement]) VALUES (1, N'Noel')
INSERT [dbo].[TypeEvenement] ([Id], [TypeEvenement]) VALUES (2, N'Semaine de relache')
SET IDENTITY_INSERT [dbo].[TypeEvenement] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2023-03-10 14:08:38 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2023-03-10 14:08:38 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2023-03-10 14:08:38 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2023-03-10 14:08:38 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2023-03-10 14:08:38 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2023-03-10 14:08:38 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2023-03-10 14:08:38 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AllergiesEnfant]  WITH CHECK ADD  CONSTRAINT [FK_AllergiesEnfant_Allergies] FOREIGN KEY([AllergieID])
REFERENCES [dbo].[Allergies] ([Id])
GO
ALTER TABLE [dbo].[AllergiesEnfant] CHECK CONSTRAINT [FK_AllergiesEnfant_Allergies]
GO
ALTER TABLE [dbo].[AllergiesEnfant]  WITH CHECK ADD  CONSTRAINT [FK_AllergiesEnfant_Enfants] FOREIGN KEY([EnfantID])
REFERENCES [dbo].[Enfants] ([Id])
GO
ALTER TABLE [dbo].[AllergiesEnfant] CHECK CONSTRAINT [FK_AllergiesEnfant_Enfants]
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
ALTER TABLE [dbo].[DocumentsParent]  WITH CHECK ADD  CONSTRAINT [FK_DocumentsParent_Repondant] FOREIGN KEY([RepondantID])
REFERENCES [dbo].[Repondant] ([Id])
GO
ALTER TABLE [dbo].[DocumentsParent] CHECK CONSTRAINT [FK_DocumentsParent_Repondant]
GO
ALTER TABLE [dbo].[Educatrices]  WITH NOCHECK ADD  CONSTRAINT [FK_Educatrices_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Educatrices] NOCHECK CONSTRAINT [FK_Educatrices_AspNetUsers]
GO
ALTER TABLE [dbo].[Enfants]  WITH NOCHECK ADD  CONSTRAINT [FK_Enfants_Repondant] FOREIGN KEY([RepondantID])
REFERENCES [dbo].[Repondant] ([Id])
GO
ALTER TABLE [dbo].[Enfants] NOCHECK CONSTRAINT [FK_Enfants_Repondant]
GO
ALTER TABLE [dbo].[Evenements]  WITH CHECK ADD  CONSTRAINT [FK_Evenements_TypeEvenement] FOREIGN KEY([TypeID])
REFERENCES [dbo].[TypeEvenement] ([Id])
GO
ALTER TABLE [dbo].[Evenements] CHECK CONSTRAINT [FK_Evenements_TypeEvenement]
GO
ALTER TABLE [dbo].[Medicaments]  WITH NOCHECK ADD  CONSTRAINT [FK_Medicaments_Enfants] FOREIGN KEY([EnfantID])
REFERENCES [dbo].[Enfants] ([Id])
GO
ALTER TABLE [dbo].[Medicaments] NOCHECK CONSTRAINT [FK_Medicaments_Enfants]
GO
ALTER TABLE [dbo].[Messages]  WITH NOCHECK ADD  CONSTRAINT [FK_Messages_Educatrices1] FOREIGN KEY([EducatriceID])
REFERENCES [dbo].[Educatrices] ([Id])
GO
ALTER TABLE [dbo].[Messages] NOCHECK CONSTRAINT [FK_Messages_Educatrices1]
GO
ALTER TABLE [dbo].[Messages]  WITH NOCHECK ADD  CONSTRAINT [FK_Messages_Repondant] FOREIGN KEY([RepondantID])
REFERENCES [dbo].[Repondant] ([Id])
GO
ALTER TABLE [dbo].[Messages] NOCHECK CONSTRAINT [FK_Messages_Repondant]
GO
ALTER TABLE [dbo].[PersonnesAutoriser]  WITH NOCHECK ADD  CONSTRAINT [FK_PersonnesAutoriser_Enfants] FOREIGN KEY([EnfantID])
REFERENCES [dbo].[Enfants] ([Id])
GO
ALTER TABLE [dbo].[PersonnesAutoriser] NOCHECK CONSTRAINT [FK_PersonnesAutoriser_Enfants]
GO
ALTER TABLE [dbo].[Presences]  WITH CHECK ADD  CONSTRAINT [FK__Presences__Enfan__33D4B598] FOREIGN KEY([EnfantID])
REFERENCES [dbo].[Enfants] ([Id])
GO
ALTER TABLE [dbo].[Presences] CHECK CONSTRAINT [FK__Presences__Enfan__33D4B598]
GO
ALTER TABLE [dbo].[Presences]  WITH CHECK ADD  CONSTRAINT [FK__Presences__Evene__34C8D9D1] FOREIGN KEY([EvenementID])
REFERENCES [dbo].[Evenements] ([Id])
GO
ALTER TABLE [dbo].[Presences] CHECK CONSTRAINT [FK__Presences__Evene__34C8D9D1]
GO
ALTER TABLE [dbo].[Repondant]  WITH CHECK ADD  CONSTRAINT [FK_Repondant_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Repondant] CHECK CONSTRAINT [FK_Repondant_AspNetUsers]
GO
USE [master]
GO
ALTER DATABASE [LesPetitsPandas] SET  READ_WRITE 
GO
