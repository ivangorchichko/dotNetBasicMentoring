using System;
using System.Collections.Generic;
using DeepClone.Model;

namespace DeepClone
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    EmployeeName = "Employee1"
                },
                new Employee()
                {
                    EmployeeName = "Employee2"
                }
            };
            var department = new Department
            {
                DepartmentName = "Department",
                Employees = employees
            };

            var deepClone = (Department) department.Clone();
            deepClone.DepartmentName = "CloneDepartment";
            deepClone.Employees[0].EmployeeName = "CloneEmployee1";
            deepClone.Employees[1].EmployeeName = "CloneEmployee2";

            Console.WriteLine(
                $"Original object\n" +
                $"DepName - {department.DepartmentName}\n" +
                $"Employees - {department.Employees[0].EmployeeName} and {department.Employees[1].EmployeeName}\n");

            Console.WriteLine(
                $"Clone object\n" +
                $"DepName - {deepClone.DepartmentName}\n" +
                $"Employees - {deepClone.Employees[0].EmployeeName} and {deepClone.Employees[1].EmployeeName}\n");
        }
    }
}
