using FirstWeb.Business;
using FirstWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWeb.Controllers
{
    public class TestController : Controller
    {
        private EmployeeService service;

        public TestController()
        {
            service = new EmployeeService();
        }

        public ActionResult GetView()
        {
            var listModel = new EmployeeListViewModel();
            listModel.Employees = new List<EmployeeViewModel>();
            var emps = service.GetDBEmployeeUseWebConfig(); 
            foreach(var emp in emps)
            {
                var employee = new EmployeeViewModel();
                employee.EmployeeName = emp.FirstName + " " + emp.LastName;
                employee.Salary = emp.Salary.ToString("c");
                if (emp.Salary > 15000)
                {
                    employee.SalaryColor = "yellow";
                }
                else
                {
                    employee.SalaryColor = "green";
                }
                listModel.Employees.Add(employee);


            }
            listModel.UserName = "Admin";

            listModel.NumberOfEmployeesAbove15000 = service.GetNumberOfEmployeesAbove3000();
            return View("MyView",listModel);
        }
        public ActionResult AddNew()
        {
            return View("FormView", new EmployeeViewModel());
        }
    
    }
}