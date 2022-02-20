using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;

namespace DeepClone.Model
{
    [Serializable]
    public class Department : ICloneable
    {
        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }

        public object Clone()
        {
            using var stream = new MemoryStream();
            if (this.GetType().IsSerializable)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return formatter.Deserialize(stream);
            }

            return null;
        }
    }
}