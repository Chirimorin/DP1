using FullAdder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Factory
{
    public class NodeFactory
    {
        private static bool initialized = false;
        private static Dictionary<string, Type> nodes;

        public static Node createNode(string name)
        {
            try
            {
                Type nodeType;

                nodes.TryGetValue(name, out nodeType);

                Node output =  (Node)Activator.CreateInstance(nodeType);
                
                return output;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public static void registerNode(string name, Type type) 
        {
            nodes.Add(name, type);
        }

        public static void init()
        {
            if (!initialized)
            {
                nodes = new Dictionary<string,Type>();

                AndNode.registerSelf();
                NAndNode.registerSelf();
                NotNode.registerSelf();
                NOrNode.registerSelf();
                OrNode.registerSelf();
                XOrNode.registerSelf();
                InputHigh.registerSelf();
                InputLow.registerSelf();
                OutputNode.registerSelf();

                initialized = true;
            }
            // If already initialized, no need to intialize again.
        }
    }
}
