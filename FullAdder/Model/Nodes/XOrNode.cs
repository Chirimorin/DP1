using CircuitSimulator.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Model
{
    class XOrNode : Node
    {
        public XOrNode()
        {
            maxInputs = 2;
        }

        public override bool calculateInput()
        {
            bool[] inputs = getInputs();

            return inputs[0] ^ inputs[1];
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("XOR", typeof(XOrNode));
        }
    }
}
