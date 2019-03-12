using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMOSimu.Classes
{
    public class Situation
    {
        public string Sit_Name { get; set; }
        public string Sit_Info { get; set; }  //Informationen zur Situation die genauer Beschreibt was abgeht
        public List<Output> lst_outputs; //Liste die Output Objekte enthält

        public Situation()
        {
            
        }
       
        public Situation(string Name, string Info)
        {
            Sit_Name = Name;
            Sit_Info = Info;
            lst_outputs = new List<Output>();

        }
    }
}
