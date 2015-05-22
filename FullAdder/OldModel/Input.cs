using FullAdder.Controller;
using FullAdder.Factory;
using FullAdder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.OldModel
{
    public class Input : Node
    {
        public bool CurrentValue
        {
            get
            {
                return (bool)inputs.FirstOrDefault();
            }
            set
            {
                addInput(value);
            }
        }

        public Input() : base()
        {
            numInputs = 1;

            MainController.Instance.OnInput += OnInput;
            //MainController.Instance.ViewModel.RegisterInput(this);
        }

        private void OnInput(object source, EventArgs e)
        {
            calculateOutput();
        }

        protected override void calculateOutput()
        {
            if (numInputs != currentInput)
            {
                throw new Exception("Niet genoeg inputs");
            }

            bool output = (bool)inputs[0];

            broadcastOutput(output);
        }
    }

    public class InputHigh : Input
    {
        public InputHigh() : base()
        {
            addInput(true);
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("INPUT_HIGH", typeof(InputHigh));
        }
    }

    public class InputLow : Input
    {
        public InputLow() : base()
        {
            addInput(false);
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("INPUT_LOW", typeof(InputLow));
        }
    }
}
