using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
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

            Serialize(department, "file.bin");
            var deserializedObj = Deserialize("file.bin");

            Console.WriteLine(
                $"Binary serialization\n" +
                $"Deserialized department: DepName - {deserializedObj.DepartmentName}\n" +
                $"Count of employee - {deserializedObj.Employees.Count}\n");
        }

        static void Serialize(Department department, string fileName)
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(stream, department);
            stream.Close();
        }

        static Department Deserialize(string fileName)
        {
            var formatter = new BinaryFormatter();
            var stream = new FileStream(fileName, FileMode.Open);
            var department = (Department)formatter.Deserialize(stream);
            stream.Close();
            return department;
        }
    }
}
