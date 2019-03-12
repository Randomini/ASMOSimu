using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMOSimu.Classes;
using System.Xml.Serialization;
using System.IO;

namespace ASMOSimu.Classes
{
    class LoadSitu
    {
        public static void Loadsitu(object obj, string filename)
        {
            using (var stream = new FileStream("Situationen.xml", FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(List<Situation>));
                CreateSituation.lst_situ = (List<Situation>)XML.Deserialize(stream);
            }
        }

    }
}
