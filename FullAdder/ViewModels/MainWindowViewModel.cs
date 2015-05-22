using FullAdder.Controller;
using FullAdder.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.ViewModels
{
    public class MainWindowViewModel
    {
        private List<InputNode> inputs;
        public List<InputNode> Inputs
        {
            get
            {
                if (inputs == null)
                    inputs = new List<InputNode>();
                return inputs;
            }
        }

        public void RegisterInput(InputNode input)
        {
            Inputs.Add(input);
        }

        private List<OutputNode> outputs;
        public List<OutputNode> Outputs
        {
            get
            {
                if (outputs == null)
                    outputs = new List<OutputNode>();
                return outputs;
            }
        }

        public void RegisterOutput(OutputNode output)
        {
            Outputs.Add(output);
        }

        public void logOutput()
        {
            foreach(InputNode input in Inputs)
            {
                Console.WriteLine("Input " + input.Name + ": " + input.Value);
            }

            foreach (OutputNode output in Outputs)
            {
                Console.WriteLine("Output " + output.Name + ": " + output.Value);
            }
        }

        public void NotifyPropertyChanged()
        {
            MainController.Instance.MainWindow.DataContext = null;
            MainController.Instance.MainWindow.DataContext = this;
        }

    }
}
