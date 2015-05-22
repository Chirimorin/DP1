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
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private static MainWindowViewModel instance;
        public static MainWindowViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainWindowViewModel();
                return instance;
            }
        }

        private string status;
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                NotifyPropertyChanged("Status");
            }
        }

        private List<InputNode> inputs;
        public List<InputNode> Inputs
        {
            get
            {
                if (inputs == null)
                    inputs = new List<InputNode>();
                return inputs;
            }
            private set
            {
                inputs = value;
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
            private set
            {
                outputs = value;
            }
        }

        public void RegisterOutput(OutputNode output)
        {
            Outputs.Add(output);
        }

        public void ResetNodes()
        {
            Inputs = null;
            Outputs = null;
        }

        public void NotifyPropertyChanged()
        {
            MainController.Instance.MainWindow.DataContext = null;
            MainController.Instance.MainWindow.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
