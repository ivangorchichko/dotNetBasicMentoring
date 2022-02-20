using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Model;

namespace XMLSerialization
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

            Serialize(department, "file.xml");
            var deserializedObj = Deserialize("file.xml");

            Console.WriteLine(
                $"XML serialization\n" +
                $"Deserialized department: DepName - {deserializedObj.DepartmentName}\n ," +
                $"Count of employee - {deserializedObj.Employees.Count}\n");
        }

        static void Serialize(Department department, string fileName)
        {
            DataContractSerializer serializer =
                new DataContractSerializer(typeof(Department));
            var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            serializer.WriteObject(stream, department);
            stream.Close();
        }

        static Department Deserialize(string fileName)
        {
            DataContractSerializer serializer =
                new DataContractSerializer(typeof(Department));
            var stream = new FileStream(fileName, FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());

            var departmentObj = (Department)serializer.ReadObject(reader, true);
            stream.Close();
            reader.Close();

            return departmentObj;
        }
    }
}
