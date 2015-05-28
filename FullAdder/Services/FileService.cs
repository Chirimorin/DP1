using FullAdder.Controller;
using FullAdder.Factory;
using FullAdder.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FullAdder.Services
{
    public abstract class FileService
    {
        /// <summary>
        /// Reads the given file and builds the corresponding circuit.
        /// </summary>
        /// <param name="path">The path to the file to read</param>
        /// <returns>A circuit with all ndoes as described in the chosen file.</returns>
        public static Circuit ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Circuit file not found", path);
            }

            Circuit output = new Circuit();

            using (StreamReader file = new StreamReader(path))
            {
                string line;
                int lineNumber = 0;
                
                while ((line = file.ReadLine()) != null)
                {
                    lineNumber++;

                    // Empty lines and comments should be ignored. 
                    if (!line.StartsWith("#") && !String.IsNullOrWhiteSpace(line))
                    {
                        // Remove all whitespace
                        line = Regex.Replace(line, @"\s+", "");

                        if (!line.EndsWith(";"))
                        {
                            throw new Exception("Error on line " + lineNumber + ", Line does not end with ;.");
                        }
                        else
                        {
                            line = line.Replace(";", "");
                        }

                        string[] splitLine = line.Split(':');

                        if (splitLine.Length != 2)
                        {
                            throw new Exception("Error on line " + lineNumber + ", expected 1 ':' got " + (splitLine.Length - 1) + ".");
                        }

                        output = processNode(output, splitLine[0], splitLine[1]);
                    }
                }
            }

            if (!output.checkCircuit())
            {
                throw new Exception("circuit not valid!");
            }

            return output;
        }

        /// <summary>
        /// Proceses a node name with parameters into a Circuit
        /// </summary>
        /// <param name="circuit">The circuit the node should be added to (or already exist in)</param>
        /// <param name="nodeName">The name of the node to add.</param>
        /// <param name="parameter">The parameters. Either the node type or names of nodes to connect to.</param>
        /// <returns></returns>
        private static Circuit processNode(Circuit circuit, string nodeName, string parameter)
        {
            if (circuit.hasNode(nodeName))
            {
                // Node exists, so this should add outputs
                string[] nodes = parameter.Split(',');

                Node currentNode = circuit.getNode(nodeName);

                foreach(string node in nodes)
                {
                    if (!circuit.hasNode(node))
                    {
                        throw new Exception("Node \"" + node + "\" bestaaat niet!");
                    }
                    else
                    {
                        circuit.getNode(node).addInput(currentNode);
                    }
                }
                
            }
            else
            {
                // Create node.
                circuit.addNode(nodeName, NodeFactory.createNode(parameter));
            }

            return circuit;
        }
    }
}
