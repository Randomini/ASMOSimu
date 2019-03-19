using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMOSimu.Classes
{
    public class YoutubeLink
    {
        public string YtName { get; set; }
        public string YtLink { get; set; }

        public YoutubeLink(string x, string y)
        {
            YtName = x;
            YtLink = y;
        }

        public YoutubeLink()
        {

        }
    }
}
