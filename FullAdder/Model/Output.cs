using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public class Output : IOutput
    {
        public bool? output;

        public void addInput(bool value)
        {
            output = value;
        }

        public void reset()
        {
            output = null;
        }
    }
}
