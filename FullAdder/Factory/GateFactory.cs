using FullAdder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Factory
{
    public class GateFactory
    {
        private static bool initialized = false;
        private static Dictionary<string, Type> logicGates;

        public static LogicGate createGate(string name)
        {
            try
            {
                Type gateType;

                logicGates.TryGetValue(name, out gateType);

                return (LogicGate)Activator.CreateInstance(gateType);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        public static void registerGate(string name, Type type) 
        {
            logicGates.Add(name, type);
        }

        public static void init()
        {
            if (!initialized)
            {
                logicGates = new Dictionary<string,Type>();

                AndGate.registerSelf();
                NAndGate.registerSelf();
                NotGate.registerSelf();
                NOrGate.registerSelf();
                OrGate.registerSelf();
                XOrGate.registerSelf();

                initialized = true;
            }
            // If already initialized, no need to intialize again.
        }
    }
}
