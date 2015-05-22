using FullAdder.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public class NotNode : Node
    {
        public override bool Value
        {
            get 
            {
                bool[] inputs = getInputs();

                return !inputs[0];
            }
            set { }
        }

        public NotNode()
        {
            maxInputs = 1;
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("NOT", typeof(NotNode));
        }
    }
}
