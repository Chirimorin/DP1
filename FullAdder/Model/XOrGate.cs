using FullAdder.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public class XOrGate : LogicGate
    {
        public static void registerSelf()
        {
            GateFactory.registerGate("XOR", typeof(XOrGate));
        }

        public XOrGate()
        {
            numInputs = 2;
        }

        override protected void calculateOutput()
        {
            if (numInputs != currentInput)
            {
                throw new Exception("Niet genoeg inputs");
            }

            bool output = (bool)inputs[0] ^ (bool)inputs[1];

            broadcastOutput(output);
        }
    }
}
