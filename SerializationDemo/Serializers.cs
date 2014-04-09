using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Xml;

namespace SerializationDemo
{
    public class BinarySerializer<T> where T : class
    {
        public static void Serialize(T obj, string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate,FileAccess.Write);
            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public static T Deserialize(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            T obj = formatter.Deserialize(fs) as T;
            fs.Close();

            return obj;
        }
    }

    public class XMLSerializer<T> where T : class
    {
        public static void Serialize(T obj, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            serializer.Serialize(fs, obj);
            fs.Close();
        }

        public static T Deserialize(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            T obj = serializer.Deserialize(fs) as T;
            fs.Close();

            return obj;
        }
    }

    public class JSSerializer<T> where T : class
    {
        public static void Serialize(T obj, string filePath)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            File.WriteAllText(filePath, serializer.Serialize(obj));
        }

        public static T Deserialize(string filePath)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string data = File.ReadAllText(filePath);

            T obj = serializer.Deserialize<T>(data);

            return obj;
        }
    }

    public class DCSerializer<T> where T : class
    {
        public static void Serialize(T obj, string filePath)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            serializer.WriteObject(fs, obj);
            fs.Close();
        }

        public static T Deserialize(string filePath)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            XmlDictionaryReader reader =  XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());

            T obj = serializer.ReadObject(reader, true) as T;
            reader.Close();
            fs.Close();

            return obj;
        }
    }

    public class DCJsonSerializer<T> where T : class
    {
        public static void Serialize(T obj, string filePath)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            serializer.WriteObject(fs, obj);
            fs.Close();
        }

        public static T Deserialize(string filePath)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            T obj = serializer.ReadObject(fs) as T;
            fs.Close();

            return obj;
        }
    }
}
