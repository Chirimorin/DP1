using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public class Input
    {
        protected List<LogicGate> outputs;
        public List<LogicGate> Outputs
        {
            get
            {
                if (outputs == null)
                {
                    outputs = new List<LogicGate>();
                }
                return outputs;
            }
        }

        public void setInput(bool value)
        {
            foreach (LogicGate output in outputs)
            {
                output.addInput(value);
            }
        }

        public void reset()
        {
            foreach (LogicGate output in outputs)
            {
                output.reset();
            }
        }
    }
}
