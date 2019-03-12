using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ASMOSimu.Classes;

namespace ASMOSimu.Classes
{
    class Load : PersonInfo
    {
        public static void Loaddata(object obj, string filename)
        {
            using (var stream = new FileStream("Bewohner.xml", FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(List<Person>));
                lst_Person = (List<Person>)XML.Deserialize(stream);
            }
        }

     
    }
}
