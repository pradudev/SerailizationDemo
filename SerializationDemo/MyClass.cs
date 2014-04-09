using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{
    [Serializable]
    [DataContract]
    public class MyClass
    {
        [DataMember]
        private int Id;

        public string Name;

        public MyClass()
        {

        }

        public MyClass(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Id, Name);
        }
    }
}
