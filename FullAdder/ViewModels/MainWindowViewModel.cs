using CircuitSimulator.Controller;
using CircuitSimulator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool loading = false;
        public bool Loading 
        { 
            get
            {
                return loading;
            }
            set
            {
                loading = value;
                NotifyInputChanged();
            }
        }

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

        private string windowTitle;
        public string WindowTitle
        {
            get
            {
                return (String.IsNullOrEmpty(windowTitle) ? "" : windowTitle + " - ") + "Circuit Simulator";
            }
            set
            {
                windowTitle = value;
                NotifyPropertyChanged("WindowTitle");
            }
        }

        private ObservableCollection<InputNode> inputs;
        public ObservableCollection<InputNode> Inputs
        {
            get
            {
                if (inputs == null)
                    inputs = new ObservableCollection<InputNode>();
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

        private ObservableCollection<OutputNode> outputs;
        public ObservableCollection<OutputNode> Outputs
        {
            get
            {
                if (outputs == null)
                    outputs = new ObservableCollection<OutputNode>();
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

        public void NotifyInputChanged()
        {
            NotifyPropertyChanged("Inputs");
            NotifyPropertyChanged("Outputs");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
