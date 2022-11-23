using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* Creates a new database table  in MS SQL Server 
    Table [dbo].[CTasks]

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
    GO
 */

#nullable disable

namespace DotNet5Crud.Models
{
    public partial class CTask
    {
        public int CTaskId { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataW { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
