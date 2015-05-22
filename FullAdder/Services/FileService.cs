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
        public static async Task<Circuit> ReadFile(string path)
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

                        
                    }
                }
            }

            return output;
        }
    }
}
