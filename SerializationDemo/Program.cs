using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace SerializationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass(2,"Pradeep");

            try
            {
                /*BinarySerializer*/
                //Serialization
                BinarySerializer<MyClass>.Serialize(obj, @"Files\data.bin");

                //Desrialization
                MyClass obj_des1 = BinarySerializer<MyClass>.Deserialize(@"Files\data.bin");

                Console.WriteLine("Binary Serialization: " + obj_des1.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }


            try
            {
                /*XMLSerializer*/
                //Serialization
                XMLSerializer<MyClass>.Serialize(obj, @"Files\data.xml");

                //Desrialization
                MyClass obj_des2 = XMLSerializer<MyClass>.Deserialize(@"Files\data.xml");

                Console.WriteLine("XML Serialization: " + obj_des2.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            try
            {
                /*JSSerializer*/
                //Serialization
                JSSerializer<MyClass>.Serialize(obj, @"Files\data.json");

                //Desrialization
                MyClass obj_des3 = JSSerializer<MyClass>.Deserialize(@"Files\data.json");

                Console.WriteLine("JS Serialization: " + obj_des3.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            try
            {
                /*DCSerializer*/
                /*
                 * DCS can serialize any .net type.
                 * If Serializable, it will do deep serialization
                 * If DataContract, it will only serialize DataMember fields
                 * If Both, it will give preference to DataContract
                 * If None, it will behave like XMLSerializer (serializes all public fields)
                 */

                //Serialization
                DCSerializer<MyClass>.Serialize(obj, @"Files\data-dc.xml");

                //Desrialization
                MyClass obj_des4 = DCSerializer<MyClass>.Deserialize(@"Files\data-dc.xml");

                Console.WriteLine("DC Serialization: " + obj_des4.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            try
            {
                /*DCJsonSerializer*/

                //Serialization
                DCJsonSerializer<MyClass>.Serialize(obj, @"Files\data-dc.json");

                //Desrialization
                MyClass obj_des5 = DCJsonSerializer<MyClass>.Deserialize(@"Files\data-dc.json");

                Console.WriteLine("DCJson Serialization: " + obj_des5.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            

        }
    }
}
