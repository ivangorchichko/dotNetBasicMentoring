using Model;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomSerializer
{
    class Program
    {
        static void Main(string[] args)
        {
            IFormatter formatter = new BinaryFormatter();

            SerializeItem("file.bin", formatter);
            DeserializeItem("file.bin", formatter);
        }

        public static void SerializeItem(string fileName, IFormatter formatter)
        {
            ModelForCustom modelForCustom = new ModelForCustom();
            modelForCustom.CustomString = "Hello World";
            modelForCustom.CustomInt = 322;

            FileStream s = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(s, modelForCustom);
            s.Close();
        }

        public static void DeserializeItem(string fileName, IFormatter formatter)
        {
            FileStream s = new FileStream(fileName, FileMode.Open);
            ModelForCustom deserializedObj = (ModelForCustom)formatter.Deserialize(s);
            Console.WriteLine(
                $"Custom binary serialization\n" +
                $"Custom string - {deserializedObj.CustomString}\n" +
                $"Custom int - {deserializedObj.CustomInt}\n");
        }
    }
}
