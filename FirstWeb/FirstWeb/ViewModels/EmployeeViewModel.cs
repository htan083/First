using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstWeb.ViewModels
{
    public class EmployeeViewModel
    {
        public string EmployeeName { get; set; }
        public string Salary { get; set; }
        public string SalaryColor { get; set; }
        //logged in user name
        public string UserName { get; set; }
    }
}