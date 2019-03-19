using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMOSimu.Classes
{
     public class Musiker
    {
        public string MusikerName { get; set; }
        public List<string> ytLinks; 

        public Musiker(string name)
        {
            MusikerName = name;
            ytLinks = new List<string>();
        }

        public Musiker()
        {

        }
    }
}
