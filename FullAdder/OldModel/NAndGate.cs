using FullAdder.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.OldModel
{
    public class NAndGate : Node
    {
        public static void registerSelf()
        {
            NodeFactory.registerNode("NAND", typeof(NAndGate));
        }

        public NAndGate()
            : base()
        {
            numInputs = 2;
        }

        override
        protected void calculateOutput()
        {
            if (numInputs != currentInput)
            {
                throw new Exception("Niet genoeg inputs");
            }

            bool output = !((bool)inputs[0] && (bool)inputs[1]);

            broadcastOutput(output);
        }
    }
}
