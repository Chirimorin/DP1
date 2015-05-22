using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public abstract class LogicGate : IOutput
    {
        protected bool?[] inputs;
        protected int numInputs;
        protected int currentInput;

        protected List<IOutput> outputs;
        public List<IOutput> Outputs
        {
            get
            {
                if (outputs == null)
                {
                    outputs = new List<IOutput>();
                }
                return outputs;
            }
        }

        public void addInput(bool input)
        {
            if (currentInput == numInputs)
            {
                throw new Exception("Te veel inputs");
            }
            else
            {
                inputs[currentInput] = input;
                currentInput++;
            }

            if (currentInput == numInputs)
            {
                calculateOutput();
            }
        }

        protected abstract void calculateOutput();

        protected void broadcastOutput(bool value)
        {
            foreach (IOutput output in outputs)
            {
                output.addInput(value);
            }

        }

        public void reset()
        {
            inputs = new bool?[numInputs];
            currentInput = 0;

            foreach (IOutput output in outputs)
            {
                output.reset();
            }
        }
    }
}
