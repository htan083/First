using FirstWeb.Models;
using FirstWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FirstWeb.Business
{
    public class EmployeeService
    {
        private List<Employee> employees;
         
        public List<Employee> GetEmployees()
        {
            employees = new List<Employee>();
            var emp = new Employee();
            emp.FirstName = "Johnson";
            emp.LastName = "Doe";
            emp.Salary = 40000;
            employees.Add(emp); 

            emp = new Employee();
            emp.FirstName = "michael";
            emp.LastName = "jackson";
            emp.Salary = 16000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "robert";
            emp.LastName = " pattinson";
            emp.Salary = 20000;
            employees.Add(emp);

            return employees;
        }

        public List<Employee> GetDBEmployees()
        {
            employees = new List<Employee>();
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Server=USER-PC\SQLEXPRESS; Database=myDatabase; User Id=hao; Password=1234;";
                conn.Open();
                SqlCommand com = new SqlCommand("select * from mytable", conn);
                using(SqlDataReader reader = com.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var employee = new Employee();
                        employee.ID = (int)reader["id"];
                        employee.FirstName = (string)reader["firstname"];
                        employee.LastName = (string)reader["lastname"];
                        employee.Salary = (int)reader["salary"];
                        employees.Add(employee);
                    }
                }

            }
            return employees;
        }

        public List<Employee> GetDBEmployeeAbove30000()
        {
            employees = new List<Employee>();
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = @"Server=USER-PC\SQLEXPRESS; Database=myDatabase; User Id=hao; Password=1234;";
                conn.Open();
                //create command
                SqlCommand com = new SqlCommand("select * from mytable where salary>=@minium",conn);
                //Creat a parameter
                // Add the parameters
                com.Parameters.Add(new SqlParameter("minium", 3000));
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var employee = new Employee();
                        employee.ID = (int)reader[0];
                        employee.FirstName =(string) reader[1];
                        employee.LastName = (string)reader[2];
                        employee.Salary = (int)reader[3];
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public List<Employee> GetDBEmployeeUseWebConfig()
        {
            employees = new List<Employee>();
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                conn.Open();
                SqlCommand com = new SqlCommand("select * from mytable where salary>=@minium", conn);
                //Creat a parameter
                // Add the parameters
                com.Parameters.Add(new SqlParameter("minium", 3000));
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new Employee();
                        employee.ID = (int)reader[0];
                        employee.FirstName = (string)reader[1];
                        employee.LastName = (string)reader[2];
                        employee.Salary = (int)reader[3];
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public int GetNumberOfEmployeesAbove3000()
        {
            int count = 0;
            using(SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
                conn.Open();
                SqlCommand com = new SqlCommand("select count(*) from mytable where salary>=@minium", conn);
                com.Parameters.Add(new SqlParameter("minium", 3000));
                count = (int)com.ExecuteScalar();
            }
            

            return count;
        }
    }


}