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

                    if (!line.StartsWith("#") && !String.IsNullOrWhiteSpace(line))
                    {
                        line = Regex.Replace(line, @"\s+", "");
                        Console.WriteLine(line);

                        if (!line.EndsWith(";"))
                        {
                            throw new Exception("Error on line " + lineNumber + ", Line does not end with ;.");
                        }

                        line = line.Replace(";","");

                        string[] splitLine = line.Split(':');

                        if (splitLine.Length != 2)
                        {
                            throw new Exception("Error on line " + lineNumber + ", expected 1 ':' got " + (splitLine.Length - 1) + ".");
                        }


                        output = processNode(output, splitLine[0], splitLine[1]);


                    }
                }
            }

            MainController.Instance.onInput();

            return output;
        }

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
                        //currentNode.Outputs.Add(circuit.getNode(node));
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
