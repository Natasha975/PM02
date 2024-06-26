USE [master]
GO
/****** Object:  Database [MedicalLaboratory]    Script Date: 14.05.2024 9:32:39 ******/
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
/****** Object:  Table [dbo].[add_inform]    Script Date: 14.05.2024 9:32:39 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__patients__4B468677CCF445F8] UNIQUE NONCLUSTERED 
(
	[ins_policy_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__patients__AB6E6164D217B0FF] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[analyzer]    Script Date: 14.05.2024 9:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[analyzer](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_analyzer_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[authorization]    Script Date: 14.05.2024 9:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authorization](
	[id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[ip] [nvarchar](50) NULL,
	[last_date_of_entry] [date] NOT NULL,
	[last_time_of_entry] [time](7) NULL,
 CONSTRAINT [PK_authorization] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[biomaterial]    Script Date: 14.05.2024 9:32:39 ******/
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
/****** Object:  Table [dbo].[ins_company]    Script Date: 14.05.2024 9:32:39 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__ins_comp__B8A38827E4E7E0D6] UNIQUE NONCLUSTERED 
(
	[r/s] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__ins_comp__DC51F2CBC8467EDD] UNIQUE NONCLUSTERED 
(
	[inn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ins_policy_type]    Script Date: 14.05.2024 9:32:39 ******/
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
/****** Object:  Table [dbo].[order]    Script Date: 14.05.2024 9:32:39 ******/
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
/****** Object:  Table [dbo].[payment_servic]    Script Date: 14.05.2024 9:32:39 ******/
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
/****** Object:  Table [dbo].[performed_service]    Script Date: 14.05.2024 9:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[performed_service](
	[id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[role]    Script Date: 14.05.2024 9:32:39 ******/
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
/****** Object:  Table [dbo].[service]    Script Date: 14.05.2024 9:32:39 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Servic__357D4CF97D58E573] UNIQUE NONCLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[service_order]    Script Date: 14.05.2024 9:32:39 ******/
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
/****** Object:  Table [dbo].[status_order]    Script Date: 14.05.2024 9:32:39 ******/
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
/****** Object:  Table [dbo].[status_service]    Script Date: 14.05.2024 9:32:39 ******/
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
/****** Object:  Table [dbo].[user]    Script Date: 14.05.2024 9:32:39 ******/
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
/****** Object:  Table [dbo].[work_analyzer]    Script Date: 14.05.2024 9:32:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[work_analyzer](
	[id] [int] NOT NULL,
	[analyzer_id] [int] NULL,
	[order_received_date] [date] NOT NULL,
	[order_received_time] [time](7) NOT NULL,
	[order_execution_time(sec)] [bigint] NOT NULL,
	[service_id] [int] NULL,
	[result] [int] NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Analyzer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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
ALTER TABLE [dbo].[service_order]  WITH CHECK ADD  CONSTRAINT [FK_service_order_performed_service] FOREIGN KEY([id_service])
REFERENCES [dbo].[performed_service] ([id])
GO
ALTER TABLE [dbo].[service_order] CHECK CONSTRAINT [FK_service_order_performed_service]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_role] FOREIGN KEY([role])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_role]
GO
ALTER TABLE [dbo].[work_analyzer]  WITH CHECK ADD  CONSTRAINT [FK_work_analyzer_analyzer] FOREIGN KEY([analyzer_id])
REFERENCES [dbo].[analyzer] ([id])
GO
ALTER TABLE [dbo].[work_analyzer] CHECK CONSTRAINT [FK_work_analyzer_analyzer]
GO
ALTER TABLE [dbo].[work_analyzer]  WITH CHECK ADD  CONSTRAINT [FK_work_analyzer_service] FOREIGN KEY([service_id])
REFERENCES [dbo].[service] ([id])
GO
ALTER TABLE [dbo].[work_analyzer] CHECK CONSTRAINT [FK_work_analyzer_service]
GO
USE [master]
GO
ALTER DATABASE [MedicalLaboratory] SET  READ_WRITE 
GO
