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

        /// <summary>
        /// Creates a node with the given name. These names are registered by the nodes themselves. 
        /// </summary>
        /// <param name="name">The name of the node</param>
        /// <returns>The correct Node object.</returns>
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

        /// <summary>
        /// Registers a node type so it can be created by the factory. 
        /// </summary>
        /// <param name="name">The identifying name of the node</param>
        /// <param name="type">The type of the node</param>
        public static void registerNode(string name, Type type) 
        {
            nodes.Add(name, type);
        }

        /// <summary>
        /// Initializes the factory. This should tell all nodes to register themselves. 
        /// </summary>
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
