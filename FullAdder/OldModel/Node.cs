using FullAdder.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.OldModel
{
    public abstract class Node
    {
        public string Name { get; set; }

        protected bool?[] inputs;
        protected int numInputs;
        protected int currentInput;

        protected List<Node> outputs;
        public List<Node> Outputs
        {
            get
            {
                if (outputs == null)
                {
                    outputs = new List<Node>();
                }
                return outputs;
            }
        }

        public Node()
        {
            
        }

        private void OnReset(object source, EventArgs e)
        {
            inputs = new bool?[numInputs];
            currentInput = 0;
        }

        public void addInput(bool input)
        {
            if (currentInput == numInputs)
            {
                throw new Exception("Te veel inputs");
            }
            else
            {
                if (inputs == null)
                {
                    inputs = new bool?[numInputs];
                }
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
            foreach (Node output in Outputs)
            {
                output.addInput(value);
            }
        }
    }
}
