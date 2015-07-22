using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWeb.ViewModels
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
        public string UserName { get; set; }

        public int NumberOfEmployeesAbove15000 { get; set; }
    }
}