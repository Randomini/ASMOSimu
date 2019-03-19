using System.Collections.Generic;

namespace ASMOSimu.Classes
{
    public class Musiker
    {
        public string MusikerName { get; set; }
        public List<YoutubeLink> ytLinks; 

        public Musiker(string name)
        {
            MusikerName = name;
            ytLinks = new List<YoutubeLink>();
        }

        public Musiker()
        {

        }
    }
}
