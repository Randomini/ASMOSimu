using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASMOSimu.Classes
{
    public class Person
    {
        public string Anrede;
        public DateTime birthday;
        public string vorname;
        public string nachname;
        public string spitzname;
        public List<string> Lst_MusikerString;
        
       // public bool geschlecht; // wenn false weiblich wenn true männlcih
                                // public List<Musiker> musikFav;

        public Person()
        {
            //if (geschlecht == true)
            //{
            //    Anrede = "Herr " + nachname;
            //}
            //else
            //{
            //    Anrede = "Frau " + nachname;
            //}
        }

    }
}
