using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml;
using Model;

namespace JsonSerialization
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

            Serialize(department, "file.json");
            var deserializedObj = Deserialize("file.json");

            Console.WriteLine(
                $"JSON serialization\n" +
                $"Deserialized department: DepName - {deserializedObj.DepartmentName}\n" +
                $"Count of employee - {deserializedObj.Employees.Count}\n");
        }

        static void Serialize(Department department, string fileName)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(department, options);
            File.WriteAllText(fileName, jsonString);
        }

        static Department Deserialize(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            var department = JsonSerializer.Deserialize<Department>(jsonString)!;
            return department;
        }
    }
}
