using FullAdder.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public abstract class Node : INotifyPropertyChanged
    {
        protected bool? value = null;
        public virtual bool? Value 
        { 
            get
            {
                if (value == null)
                {
                    if (visited)
                    {
                        IsValid = false;
                        return null;
                    }
                    else
                    {
                        visited = true;
                        value = calculateInput();
                    }
                }

                if (!IsValid)
                    return null;

                return (bool)value;
            } 
            set {}
        }

        private bool isValid = true;
        public bool IsValid
        {
            get
            {
                return isValid;
            }
            set
            {
                isValid = value;
                NotifyPropertyChanged("IsValid");
            }
        }

        public string Name { get; set; }

        private Node[] inputs;
        public Node[] Inputs
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

        protected bool visited = false;

        public Node()
        {
            MainWindowViewModel.Instance.PropertyChanged += Instance_PropertyChanged;
        }

        protected virtual void Instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Inputs")
            {
                value = null;
                visited = false;
            }
        }

        public abstract bool calculateInput();

        /// <summary>
        /// Adds an input to the node. The maximum amount of inputs is determined by the node type. 
        /// </summary>
        /// <param name="node">The node to add as input.</param>
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

        /// <summary>
        /// Gets all inputs for the node. Missing connections will get a false result. 
        /// </summary>
        /// <returns>An array of bools with the inputs.</returns>
        protected bool[] getInputs()
        {
            bool[] result = new bool[maxInputs];

            for (int i = 0; i < maxInputs; i++)
            {
                if (Inputs[i] != null)
                {
                    bool? value = Inputs[i].Value;
                    if (value == null)
                    {
                        IsValid = false;
                        result[i] = false;
                    }
                    else
                    {
                        result[i] = (bool)value;
                    }
                }
                else
                {
                    // Missing connection
                    IsValid = false;
                    result[i] = false;
                }
            }

            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
