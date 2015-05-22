using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public abstract class Node
    {
        public abstract bool Value { get; set; }
        public string Name { get; set; }

        private Node[] inputs;
        protected Node[] Inputs
        {
            get
            {
                if (inputs == null)
                    inputs = new Node[maxInputs];
                return inputs;
            }
        }

        protected int maxInputs;
        protected int currentInput;

        public void addInput(Node node)
        {
            if (currentInput == maxInputs)
            {
                throw new Exception("Te veel inputs");
            }
            else
            {
                Inputs[currentInput] = node;
                currentInput++;
            }
        }

        protected bool[] getInputs()
        {
            bool[] result = new bool[maxInputs];

            for (int i = 0; i < maxInputs; i++)
            {
                if (Inputs[i] != null)
                    result[i] = Inputs[i].Value;
                else
                    result[i] = false;
            }

            return result;
        }

    }
}
