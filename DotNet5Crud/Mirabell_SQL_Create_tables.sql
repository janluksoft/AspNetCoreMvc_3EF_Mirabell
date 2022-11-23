USE [dbMark]
/**** Object: Table [dbo].[CTasks] Script Date: 01.12.2022 ****/
/**** Creates a new database table in MS SQL Server ****/
/**** File: Mirabell_SQL_Create_tables.sql          ****/ 
GO
    CREATE TABLE [dbo].[CTasks](
    [CTaskId] [int] IDENTITY(1,1) NOT NULL,
    [Nazwa] [varchar](50) NOT NULL,
    [DataW] [datetime] NOT NULL,
    [Status] [varchar](50) NOT NULL,
    [EmployeeId] [int] NOT NULL,
    PRIMARY KEY CLUSTERED
    (
    [CTaskId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

/**** Object: Table [dbo].[Pracownicy] Script Date: 01.12.2022 ****/
/**** Creates a new database table in MS SQL Server ****/ 
GO
    CREATE TABLE [dbo].[Pracownicy](
    [EmployeeId] [int] IDENTITY(1,1) NOT NULL,
    [Imie] [varchar](50) NOT NULL,
    [Nazwisko] [varchar](50) NOT NULL,
    [Adres] [varchar](50) NOT NULL,
    [Email] [varchar](50) NOT NULL,
    [Stanowisko] [varchar](50) NOT NULL,
    PRIMARY KEY CLUSTERED
    (
    [EmployeeId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]

