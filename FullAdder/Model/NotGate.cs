using FullAdder.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public class NotGate : LogicGate
    {
        public static void registerSelf()
        {
            GateFactory.registerGate("NOT", typeof(NotGate));
        }

        public NotGate()
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
