using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Model
{
    public class Circuit
    {
        private List<KeyValuePair<string, Node>> nodes;
        public List<KeyValuePair<string, Node>> Nodes
        {
            get
            {
                if (nodes == null)
                {
                    nodes = new List<KeyValuePair<string, Node>>();
                }

                return nodes;
            }
        }

        public void addNode(string name, Node gate)
        {
            gate.Name = name;
            Nodes.Add(new KeyValuePair<string, Node>(name, gate));
        }

        public Node getNode(string name)
        {
            return Nodes.Where(n => n.Key == name).FirstOrDefault().Value;
        }

        public bool hasNode(string name)
        {
            return Nodes.Where(n => n.Key == name).Any();
        }
    }
}
