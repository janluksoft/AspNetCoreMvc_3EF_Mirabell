using System;
using System.Collections.Generic;

/* Creates a new database table in MS SQL Server: 
    Table [dbo].[Pracownicy]

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
    GO
 */

#nullable disable

namespace DotNet5Crud.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Stanowisko { get; set; }
        public ICollection<CTask> CTasks { get; set; }
        //imię, nazwisko, adres email, stanowisko
    }

}
