using FullAdder.Controller;
using FullAdder.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.OldModel
{
    public class Output : Node
    {
        public Output()
            : base()
        {
            numInputs = 1;

            //MainController.Instance.ViewModel.RegisterOutput(this);
        }

        protected override void calculateOutput()
        {
            if (numInputs != currentInput)
            {
                throw new Exception("Niet genoeg inputs");
            }

            bool output = (bool)inputs[0];

            Console.WriteLine("Probe output: " + output);

            broadcastOutput(output);
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("PROBE", typeof(Output));
        }
    }
}
