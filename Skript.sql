USE [master]
GO
/****** Object:  Database [MedicalLaboratory]    Script Date: 07.05.2024 22:49:17 ******/
CREATE DATABASE [MedicalLaboratory]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MedicalLaboratory', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MedicalLaboratory.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MedicalLaboratory_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MedicalLaboratory_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MedicalLaboratory] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MedicalLaboratory].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MedicalLaboratory] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET ARITHABORT OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MedicalLaboratory] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MedicalLaboratory] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MedicalLaboratory] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MedicalLaboratory] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MedicalLaboratory] SET  MULTI_USER 
GO
ALTER DATABASE [MedicalLaboratory] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MedicalLaboratory] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MedicalLaboratory] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MedicalLaboratory] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MedicalLaboratory] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MedicalLaboratory] SET QUERY_STORE = OFF
GO
USE [MedicalLaboratory]
GO
/****** Object:  Table [dbo].[add_inform]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[add_inform](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[date_of_birth] [date] NULL,
	[passport_series] [int] NOT NULL,
	[passport_number] [int] NOT NULL,
	[phone] [nvarchar](50) NULL,
	[photo] [binary](50) NULL,
	[email] [nvarchar](50) NOT NULL,
	[ins_policy_number] [nvarchar](20) NULL,
	[ins_policy_type] [int] NULL,
	[ins_company_id] [int] NULL,
 CONSTRAINT [PK__patients__3213E83F40E540ED] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[authorization]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authorization](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[ip] [nvarchar](50) NULL,
	[last_date_of_entry] [date] NULL,
	[last_time_of_entry] [time](7) NOT NULL,
 CONSTRAINT [PK_authorization] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[biomaterial]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[biomaterial](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[cost] [money] NOT NULL,
 CONSTRAINT [PK_biomaterial] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ins_company]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ins_company](
	[id] [int] NOT NULL,
	[company_name] [nvarchar](225) NOT NULL,
	[address] [nvarchar](225) NULL,
	[inn] [bigint] NULL,
	[r/s] [nvarchar](50) NULL,
	[bik] [nvarchar](50) NULL,
 CONSTRAINT [PK__ins_comp__3213E83FA8B5B5F2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ins_policy_type]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ins_policy_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ins_policy_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] NOT NULL,
	[creation_date] [date] NOT NULL,
	[status_order] [int] NULL,
	[status_servic] [int] NULL,
	[execution_time(day)] [int] NOT NULL,
	[user_id] [int] NULL,
	[biomaterial_id] [int] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment_servic]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_servic](
	[id] [int] NOT NULL,
	[order_id] [int] NOT NULL,
	[price] [money] NOT NULL,
 CONSTRAINT [PK_payment_servic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[performed_service]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[performed_service](
	[id] [int] NOT NULL,
	[service_id] [int] NOT NULL,
	[execution_date] [date] NOT NULL,
	[executor_id] [int] NOT NULL,
	[analyzer_id] [int] NOT NULL,
	[patient_id] [int] NOT NULL,
	[result] [nvarchar](max) NULL,
 CONSTRAINT [PK_performed_service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[service]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service](
	[id] [int] NOT NULL,
	[service_name] [nvarchar](100) NOT NULL,
	[cost] [money] NOT NULL,
	[code] [bigint] NULL,
	[execution_time(day)] [int] NULL,
	[mean_deviation] [float] NULL,
 CONSTRAINT [PK__Servic__3213E83F649D267E] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[service_order]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[service_order](
	[id] [int] NOT NULL,
	[id_service] [int] NOT NULL,
	[id_order] [int] NOT NULL,
 CONSTRAINT [PK_servic_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status_order]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status_order](
	[id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[status_service]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status_service](
	[id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_status_servic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[lastname] [nvarchar](100) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](100) NULL,
	[role] [int] NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[work_analyzer]    Script Date: 07.05.2024 22:49:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[work_analyzer](
	[id] [int] NOT NULL,
	[order_received_date] [date] NOT NULL,
	[order_received_time] [time](7) NOT NULL,
	[order_execution_time(sec)] [bigint] NOT NULL,
 CONSTRAINT [PK_Analyzer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[add_inform] ([id], [user_id], [date_of_birth], [passport_series], [passport_number], [phone], [photo], [email], [ins_policy_number], [ins_policy_type], [ins_company_id]) VALUES (1, 1, CAST(N'1990-01-01' AS Date), 1234, 567890, N'89123456789', NULL, N'ivanov@example.com', N'1234567890', 1, 1)
INSERT [dbo].[add_inform] ([id], [user_id], [date_of_birth], [passport_series], [passport_number], [phone], [photo], [email], [ins_policy_number], [ins_policy_type], [ins_company_id]) VALUES (2, 3, CAST(N'1991-02-02' AS Date), 2345, 678901, N'89998887766', NULL, N'petrov@example.com', N'2345678901', 2, 2)
INSERT [dbo].[add_inform] ([id], [user_id], [date_of_birth], [passport_series], [passport_number], [phone], [photo], [email], [ins_policy_number], [ins_policy_type], [ins_company_id]) VALUES (3, 5, CAST(N'1992-03-03' AS Date), 3456, 789012, N'89997776655', NULL, N'sidorov@example.com', N'3456789012', 3, 3)
INSERT [dbo].[add_inform] ([id], [user_id], [date_of_birth], [passport_series], [passport_number], [phone], [photo], [email], [ins_policy_number], [ins_policy_type], [ins_company_id]) VALUES (4, 6, CAST(N'1993-04-04' AS Date), 4567, 890123, N'89996665544', NULL, N'kuznecov@example.com', N'4567890123', 1, 4)
INSERT [dbo].[add_inform] ([id], [user_id], [date_of_birth], [passport_series], [passport_number], [phone], [photo], [email], [ins_policy_number], [ins_policy_type], [ins_company_id]) VALUES (5, 7, CAST(N'1994-05-05' AS Date), 5678, 901234, N'89995554433', NULL, N'sokolov@example.com', N'5678901234', 2, 5)
GO
INSERT [dbo].[biomaterial] ([id], [name], [cost]) VALUES (1, N'Кровь', 500.0000)
INSERT [dbo].[biomaterial] ([id], [name], [cost]) VALUES (2, N'Моча', 300.0000)
INSERT [dbo].[biomaterial] ([id], [name], [cost]) VALUES (3, N'Слюна', 200.0000)
INSERT [dbo].[biomaterial] ([id], [name], [cost]) VALUES (4, N'Кал', 400.0000)
INSERT [dbo].[biomaterial] ([id], [name], [cost]) VALUES (5, N'Ликвор', 600.0000)
GO
INSERT [dbo].[ins_company] ([id], [company_name], [address], [inn], [r/s], [bik]) VALUES (1, N'АльфаСтрахование', N'Москва, ул. Большая Татарская, д. 30, стр. 1', 1234567890, N'40702810900000000001', N'044525555')
INSERT [dbo].[ins_company] ([id], [company_name], [address], [inn], [r/s], [bik]) VALUES (2, N'Росгосстрах', N'Москва, ул. Новослободская, д. 14, стр. 1', 2345678901, N'40702810900000000002', N'044525666')
INSERT [dbo].[ins_company] ([id], [company_name], [address], [inn], [r/s], [bik]) VALUES (3, N'Ингосстрах', N'Москва, ул. Тверская, д. 11, стр. 1', 3456789012, N'40702810900000000003', N'044525777')
INSERT [dbo].[ins_company] ([id], [company_name], [address], [inn], [r/s], [bik]) VALUES (4, N'РЕСО-Гарантия', N'Москва, ул. Большая Дмитровка, д. 13, стр. 2', 4567890123, N'40702810900000000004', N'044525888')
INSERT [dbo].[ins_company] ([id], [company_name], [address], [inn], [r/s], [bik]) VALUES (5, N'ВТБ Страхование', N'Москва, ул. Большая Тульская, д. 15, стр. 1', 5678901234, N'40702810900000000005', N'044525999')
GO
SET IDENTITY_INSERT [dbo].[ins_policy_type] ON 

INSERT [dbo].[ins_policy_type] ([id], [name]) VALUES (1, N'electronic')
INSERT [dbo].[ins_policy_type] ([id], [name]) VALUES (2, N'paper')
INSERT [dbo].[ins_policy_type] ([id], [name]) VALUES (3, N'plastic')
SET IDENTITY_INSERT [dbo].[ins_policy_type] OFF
GO
INSERT [dbo].[order] ([id], [creation_date], [status_order], [status_servic], [execution_time(day)], [user_id], [biomaterial_id]) VALUES (1, CAST(N'2024-05-05' AS Date), 1, 1, 1, 1, NULL)
INSERT [dbo].[order] ([id], [creation_date], [status_order], [status_servic], [execution_time(day)], [user_id], [biomaterial_id]) VALUES (2, CAST(N'2024-05-05' AS Date), 2, 2, 2, 1, NULL)
INSERT [dbo].[order] ([id], [creation_date], [status_order], [status_servic], [execution_time(day)], [user_id], [biomaterial_id]) VALUES (3, CAST(N'2024-05-05' AS Date), 3, 3, 3, 1, NULL)
INSERT [dbo].[order] ([id], [creation_date], [status_order], [status_servic], [execution_time(day)], [user_id], [biomaterial_id]) VALUES (4, CAST(N'2024-05-05' AS Date), 2, 1, 2, 1, NULL)
INSERT [dbo].[order] ([id], [creation_date], [status_order], [status_servic], [execution_time(day)], [user_id], [biomaterial_id]) VALUES (5, CAST(N'2024-05-05' AS Date), 3, 2, 5, 1, NULL)
GO
INSERT [dbo].[payment_servic] ([id], [order_id], [price]) VALUES (1, 1, 500.0000)
INSERT [dbo].[payment_servic] ([id], [order_id], [price]) VALUES (2, 2, 300.0000)
INSERT [dbo].[payment_servic] ([id], [order_id], [price]) VALUES (3, 3, 1000.0000)
INSERT [dbo].[payment_servic] ([id], [order_id], [price]) VALUES (4, 4, 1500.0000)
INSERT [dbo].[payment_servic] ([id], [order_id], [price]) VALUES (5, 5, 2000.0000)
GO
INSERT [dbo].[performed_service] ([id], [service_id], [execution_date], [executor_id], [analyzer_id], [patient_id], [result]) VALUES (1, 1, CAST(N'2024-05-06' AS Date), 6, 1, 1, NULL)
INSERT [dbo].[performed_service] ([id], [service_id], [execution_date], [executor_id], [analyzer_id], [patient_id], [result]) VALUES (2, 2, CAST(N'2023-05-06' AS Date), 6, 2, 1, NULL)
INSERT [dbo].[performed_service] ([id], [service_id], [execution_date], [executor_id], [analyzer_id], [patient_id], [result]) VALUES (3, 3, CAST(N'2023-05-07' AS Date), 6, 3, 1, NULL)
INSERT [dbo].[performed_service] ([id], [service_id], [execution_date], [executor_id], [analyzer_id], [patient_id], [result]) VALUES (4, 4, CAST(N'2023-05-07' AS Date), 7, 4, 1, NULL)
INSERT [dbo].[performed_service] ([id], [service_id], [execution_date], [executor_id], [analyzer_id], [patient_id], [result]) VALUES (5, 5, CAST(N'2023-05-07' AS Date), 7, 5, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([id], [name]) VALUES (1, N'Пациент')
INSERT [dbo].[role] ([id], [name]) VALUES (2, N'Админ')
INSERT [dbo].[role] ([id], [name]) VALUES (3, N'Бухгалтер')
INSERT [dbo].[role] ([id], [name]) VALUES (4, N'Лаборант')
INSERT [dbo].[role] ([id], [name]) VALUES (5, N'Лаборант-исследователь')
SET IDENTITY_INSERT [dbo].[role] OFF
GO
INSERT [dbo].[service] ([id], [service_name], [cost], [code], [execution_time(day)], [mean_deviation]) VALUES (1, N'Общий анализ крови', 500.0000, 1000, 1, 0.1)
INSERT [dbo].[service] ([id], [service_name], [cost], [code], [execution_time(day)], [mean_deviation]) VALUES (2, N'Общий анализ мочи', 300.0000, 1001, 1, 0.05)
INSERT [dbo].[service] ([id], [service_name], [cost], [code], [execution_time(day)], [mean_deviation]) VALUES (3, N'Биохимический анализ крови', 1000.0000, 1002, 2, 0.15)
INSERT [dbo].[service] ([id], [service_name], [cost], [code], [execution_time(day)], [mean_deviation]) VALUES (4, N'Иммунологическое исследование', 1500.0000, 1003, 3, 0.2)
INSERT [dbo].[service] ([id], [service_name], [cost], [code], [execution_time(day)], [mean_deviation]) VALUES (5, N'Генетическое исследование', 2000.0000, 1004, 5, 0.25)
GO
INSERT [dbo].[service_order] ([id], [id_service], [id_order]) VALUES (1, 1, 1)
INSERT [dbo].[service_order] ([id], [id_service], [id_order]) VALUES (2, 1, 2)
INSERT [dbo].[service_order] ([id], [id_service], [id_order]) VALUES (3, 2, 2)
INSERT [dbo].[service_order] ([id], [id_service], [id_order]) VALUES (4, 2, 5)
INSERT [dbo].[service_order] ([id], [id_service], [id_order]) VALUES (5, 3, 3)
INSERT [dbo].[service_order] ([id], [id_service], [id_order]) VALUES (6, 4, 2)
INSERT [dbo].[service_order] ([id], [id_service], [id_order]) VALUES (7, 5, 5)
GO
INSERT [dbo].[status_order] ([id], [name]) VALUES (1, N'Обрабатывается')
INSERT [dbo].[status_order] ([id], [name]) VALUES (2, N'В работе')
INSERT [dbo].[status_order] ([id], [name]) VALUES (3, N'Отказ')
GO
INSERT [dbo].[status_service] ([id], [name]) VALUES (1, N'Новая')
INSERT [dbo].[status_service] ([id], [name]) VALUES (2, N'В исполнении')
INSERT [dbo].[status_service] ([id], [name]) VALUES (3, N'выданая')
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [lastname], [name], [surname], [role], [login], [password]) VALUES (1, N'Белова', N'Карина', NULL, 1, N'Kar6', N'4tzqHdkqzo4')
INSERT [dbo].[user] ([id], [lastname], [name], [surname], [role], [login], [password]) VALUES (3, N'Иванов', N'Иван', NULL, 2, N'ivanov0', N'ukM0e6')
INSERT [dbo].[user] ([id], [lastname], [name], [surname], [role], [login], [password]) VALUES (5, N'Ильин', N'Мирон', NULL, 3, N'Miron2', N'7QpCwac0yi')
INSERT [dbo].[user] ([id], [lastname], [name], [surname], [role], [login], [password]) VALUES (6, N'Сидорова', N'София', NULL, 4, N'Sofa3', N'5Ydp2mz')
INSERT [dbo].[user] ([id], [lastname], [name], [surname], [role], [login], [password]) VALUES (7, N'Комарова', N'Анастасия', NULL, 5, N'Anast4', N'fsyehb56')
SET IDENTITY_INSERT [dbo].[user] OFF
GO
INSERT [dbo].[work_analyzer] ([id], [order_received_date], [order_received_time], [order_execution_time(sec)]) VALUES (1, CAST(N'2024-05-06' AS Date), CAST(N'10:00:00' AS Time), 3600)
INSERT [dbo].[work_analyzer] ([id], [order_received_date], [order_received_time], [order_execution_time(sec)]) VALUES (2, CAST(N'2023-05-06' AS Date), CAST(N'11:00:00' AS Time), 4200)
INSERT [dbo].[work_analyzer] ([id], [order_received_date], [order_received_time], [order_execution_time(sec)]) VALUES (3, CAST(N'2023-05-07' AS Date), CAST(N'08:00:00' AS Time), 4800)
INSERT [dbo].[work_analyzer] ([id], [order_received_date], [order_received_time], [order_execution_time(sec)]) VALUES (4, CAST(N'2023-05-07' AS Date), CAST(N'13:00:00' AS Time), 5400)
INSERT [dbo].[work_analyzer] ([id], [order_received_date], [order_received_time], [order_execution_time(sec)]) VALUES (5, CAST(N'2023-05-07' AS Date), CAST(N'17:00:00' AS Time), 6000)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__patients__4B468677CCF445F8]    Script Date: 07.05.2024 22:49:18 ******/
ALTER TABLE [dbo].[add_inform] ADD  CONSTRAINT [UQ__patients__4B468677CCF445F8] UNIQUE NONCLUSTERED 
(
	[ins_policy_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__patients__AB6E6164D217B0FF]    Script Date: 07.05.2024 22:49:18 ******/
ALTER TABLE [dbo].[add_inform] ADD  CONSTRAINT [UQ__patients__AB6E6164D217B0FF] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__ins_comp__B8A38827E4E7E0D6]    Script Date: 07.05.2024 22:49:18 ******/
ALTER TABLE [dbo].[ins_company] ADD  CONSTRAINT [UQ__ins_comp__B8A38827E4E7E0D6] UNIQUE NONCLUSTERED 
(
	[r/s] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__ins_comp__DC51F2CBC8467EDD]    Script Date: 07.05.2024 22:49:18 ******/
ALTER TABLE [dbo].[ins_company] ADD  CONSTRAINT [UQ__ins_comp__DC51F2CBC8467EDD] UNIQUE NONCLUSTERED 
(
	[inn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Servic__357D4CF97D58E573]    Script Date: 07.05.2024 22:49:18 ******/
ALTER TABLE [dbo].[service] ADD  CONSTRAINT [UQ__Servic__357D4CF97D58E573] UNIQUE NONCLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[add_inform]  WITH CHECK ADD  CONSTRAINT [FK_add_inform_ins_companie] FOREIGN KEY([ins_company_id])
REFERENCES [dbo].[ins_company] ([id])
GO
ALTER TABLE [dbo].[add_inform] CHECK CONSTRAINT [FK_add_inform_ins_companie]
GO
ALTER TABLE [dbo].[add_inform]  WITH CHECK ADD  CONSTRAINT [FK_add_inform_ins_policy_type] FOREIGN KEY([ins_policy_type])
REFERENCES [dbo].[ins_policy_type] ([id])
GO
ALTER TABLE [dbo].[add_inform] CHECK CONSTRAINT [FK_add_inform_ins_policy_type]
GO
ALTER TABLE [dbo].[add_inform]  WITH CHECK ADD  CONSTRAINT [FK_add_inform_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[add_inform] CHECK CONSTRAINT [FK_add_inform_user]
GO
ALTER TABLE [dbo].[authorization]  WITH CHECK ADD  CONSTRAINT [FK_authorization_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[authorization] CHECK CONSTRAINT [FK_authorization_user]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_biomaterial] FOREIGN KEY([biomaterial_id])
REFERENCES [dbo].[biomaterial] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_biomaterial]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_status] FOREIGN KEY([status_order])
REFERENCES [dbo].[status_order] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_status]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_status_servic] FOREIGN KEY([status_servic])
REFERENCES [dbo].[status_service] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_status_servic]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_user]
GO
ALTER TABLE [dbo].[payment_servic]  WITH CHECK ADD  CONSTRAINT [FK_payment_servic_order] FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[payment_servic] CHECK CONSTRAINT [FK_payment_servic_order]
GO
ALTER TABLE [dbo].[performed_service]  WITH CHECK ADD  CONSTRAINT [FK_performed_service_servic] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
GO
ALTER TABLE [dbo].[performed_service] CHECK CONSTRAINT [FK_performed_service_servic]
GO
ALTER TABLE [dbo].[performed_service]  WITH CHECK ADD  CONSTRAINT [FK_performed_service_user] FOREIGN KEY([patient_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[performed_service] CHECK CONSTRAINT [FK_performed_service_user]
GO
ALTER TABLE [dbo].[performed_service]  WITH CHECK ADD  CONSTRAINT [FK_performed_service_work_analyzer] FOREIGN KEY([analyzer_id])
REFERENCES [dbo].[work_analyzer] ([id])
GO
ALTER TABLE [dbo].[performed_service] CHECK CONSTRAINT [FK_performed_service_work_analyzer]
GO
ALTER TABLE [dbo].[service_order]  WITH CHECK ADD  CONSTRAINT [FK_per_servic_order_order] FOREIGN KEY([id_order])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[service_order] CHECK CONSTRAINT [FK_per_servic_order_order]
GO
ALTER TABLE [dbo].[service_order]  WITH CHECK ADD  CONSTRAINT [FK_per_servic_order_servic] FOREIGN KEY([id_service])
REFERENCES [dbo].[service] ([id])
GO
ALTER TABLE [dbo].[service_order] CHECK CONSTRAINT [FK_per_servic_order_servic]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_role] FOREIGN KEY([role])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_role]
GO
USE [master]
GO
ALTER DATABASE [MedicalLaboratory] SET  READ_WRITE 
GO
