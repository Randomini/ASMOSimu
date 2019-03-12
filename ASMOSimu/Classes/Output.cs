using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMOSimu.Classes
{
    public class Output
    {
        public List<Input> lst_inputs;
        public string OutputText { get; set; }

        public Output()
        {

        }

        public Output(string Text)
        {
            OutputText = Text;

            lst_inputs = new List<Input>();
        }

    }
}
