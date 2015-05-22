using FullAdder.Controller;
using FullAdder.Factory;
using FullAdder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public abstract class InputNode : Node
    {
        private bool value;
        public override bool Value
        {
            get 
            {
                return value;
            }
            set
            {
                this.value = value;

                MainWindowViewModel.Instance.NotifyPropertyChanged(); 
            }
        }

        public InputNode()
        {
            maxInputs = 1;

            MainWindowViewModel.Instance.RegisterInput(this);
        }
    }

    public class InputHigh : InputNode
    {
        public InputHigh()
        {
            Value = true;
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("INPUT_HIGH", typeof(InputHigh));
        }
    }

    public class InputLow : InputNode
    {
        public InputLow()
        {
            Value = false;
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("INPUT_LOW", typeof(InputLow));
        }
    }
}
