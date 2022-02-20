using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    [DataContract(Name = "Customer", Namespace = "http://www.contoso.com")]
    public class Department : IExtensibleDataObject
    {
        [DataMember()]
        public string DepartmentName { get; set; }

        [JsonPropertyName("Workers")]
        [DataMember()]
        public List<Employee> Employees { get; set; }

        private ExtensionDataObject extensionData_Value;
        public ExtensionDataObject ExtensionData 
        { 
            get => extensionData_Value;
            set => extensionData_Value = value;
        }
    }
}
