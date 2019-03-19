using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ASMOSimu.Classes
{
    class LoadMedia
    {

        public static void LoadMedi(object obj, string filename)
        {
            using (var stream = new FileStream("Media.xml", FileMode.Open))
            {
                var XML = new XmlSerializer(typeof(List<Musiker>));
                MediaControl.lst_media = (List<Musiker>)XML.Deserialize(stream);
            }
        }
    }
}
