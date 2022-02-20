using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model
{
    [Serializable]
    public class ModelForCustom : ISerializable
    {
        public string CustomString { get; set; }
        public int CustomInt { get; set; }

        public ModelForCustom()
        {
        }

        public ModelForCustom(SerializationInfo info, StreamingContext context)
        {
            CustomString = (string)info.GetValue("CustomStringProp", typeof(string));
            CustomInt = (int)info.GetValue("CustomIntProp", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CustomStringProp", CustomString, typeof(string));
            info.AddValue("CustomIntProp", CustomInt, typeof(int));
        }
    }
}
