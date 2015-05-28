using FullAdder.Controller;
using FullAdder.Factory;
using FullAdder.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public abstract class InputNode : Node
    {
        public override bool? Value
        {
            get 
            {
                return (bool)value;
            }
            set
            {
                this.value = value;

                MainWindowViewModel.Instance.NotifyInputChanged(); 
            }
        }

        public InputNode()
        {
            maxInputs = 0;

            MainWindowViewModel.Instance.RegisterInput(this);
        }

        protected override void Instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // do nothing
        }

        public override bool calculateInput()
        {
            return (bool)Value;
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
