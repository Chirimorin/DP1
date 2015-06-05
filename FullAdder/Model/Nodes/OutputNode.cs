using CircuitSimulator.Controller;
using CircuitSimulator.Factory;
using CircuitSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Model
{
    public class OutputNode : Node, INotifyPropertyChanged
    {
        public OutputNode()
        {
            maxInputs = 1;

            MainWindowViewModel.Instance.RegisterOutput(this);
            MainWindowViewModel.Instance.PropertyChanged += ViewModel_PropertyChanged;
        }

        public override bool calculateInput()
        {
            bool[] inputs = getInputs();

            return inputs[0];
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("PROBE", typeof(OutputNode));
        }

        /// <summary>
        /// Listens to the PropertyChanged event from the ViewModel. 
        /// If the inputs changed, the Value of outputs change as well. 
        /// </summary>
        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Outputs")
            {
                NotifyPropertyChanged("Value");
            }
        }
    }
}
