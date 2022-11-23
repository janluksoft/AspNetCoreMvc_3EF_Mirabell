using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet5Crud.Models;

namespace DotNet5Crud.ViewModels
{
    public class CTaskCreateVM
    {
        public int CTaskId { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataW { get; set; }
        public string Status { get; set; }

        //to relations
        //public int EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }

        public IEnumerable<Employee> Pracownicy { get; set; }
        public int SelectedEmployeeId { get; set; }
    }
}
