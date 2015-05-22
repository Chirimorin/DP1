using FullAdder.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public class AndNode : Node
    {
        public override bool Value
        {
            get 
            {
                bool[] inputs = getInputs();

                return inputs[0] && inputs[1];
            }
            set { }
        }

        public AndNode()
        {
            maxInputs = 2;
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("AND", typeof(AndNode));
        }

    }
}
