using FullAdder.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.OldModel
{
    public class NotGate : Node
    {
        public static void registerSelf()
        {
            NodeFactory.registerNode("NOT", typeof(NotGate));
        }

        public NotGate()
            : base()
        {
            numInputs = 1;
        }

        override protected void calculateOutput()
        {
            if (numInputs != currentInput)
            {
                throw new Exception("Niet genoeg inputs");
            }

            bool output = !(bool)inputs[0];

            broadcastOutput(output);
        }
    }
}
