using CircuitSimulator.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Model
{
    public class NotNode : Node
    {
        public NotNode()
        {
            maxInputs = 1;
        }

        public override bool calculateInput()
        {
            bool[] inputs = getInputs();

            return !inputs[0];
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("NOT", typeof(NotNode));
        }
    }
}
