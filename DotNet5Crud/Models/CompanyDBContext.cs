using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

/*
 * Create a new database named CompanyDB in sql-server and execute the below SQL query to create Pracownicy table.
 * 
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
    public partial class CompanyDBContext : DbContext
    {
        public CompanyDBContext(DbContextOptions<CompanyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Pracownicy { get; set; }
        public virtual DbSet<CTask> CTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Imie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Adres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stanowisko)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
