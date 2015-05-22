using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public class Circuit
    {
        private List<KeyValuePair<string, Input>> inputs;
        public List<KeyValuePair<string, Input>> Inputs 
        { 
            get 
            {
                if (inputs == null)
                {
                    inputs = new List<KeyValuePair<string, Input>>();
                }

                return inputs;
            } 
        }

        public void addInput(string name, Input input)
        {
            Inputs.Add(new KeyValuePair<string, Input>(name, input));
        }

        private List<Output> outputs;
        public List<Output> Outputs
        {
            get
            {
                if (outputs == null)
                {
                    outputs = new List<Output>();
                }

                return outputs;
            }
        }

        private List<KeyValuePair<string, LogicGate>> logicGates;
        public List<KeyValuePair<string, LogicGate>> LogicGates
        {
            get
            {
                if (logicGates == null)
                {
                    logicGates = new List<KeyValuePair<string, LogicGate>>();
                }

                return logicGates;
            }
        }

        public void addLogicGate(string name, LogicGate gate)
        {
            LogicGates.Add(new KeyValuePair<string, LogicGate>(name, gate));
        }

        public LogicGate getLogicGate(string name)
        {
            return LogicGates.Where(g => g.Key == name).FirstOrDefault().Value;
        }
    }
}
