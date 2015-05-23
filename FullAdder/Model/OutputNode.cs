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
    public class OutputNode : Node, INotifyPropertyChanged
    {
        public override bool Value
        {
            get 
            {
                bool[] inputs = getInputs();

                return inputs[0];
            }
            set { }
        }

        public OutputNode()
        {
            maxInputs = 1;

            MainWindowViewModel.Instance.RegisterOutput(this);
            MainWindowViewModel.Instance.PropertyChanged += ViewModel_PropertyChanged;
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("PROBE", typeof(OutputNode));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Listens to the PropertyChanged event from the ViewModel. 
        /// If the inputs changed, the Value of outputs change as well. 
        /// </summary>
        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Inputs" && PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }
    }
}
