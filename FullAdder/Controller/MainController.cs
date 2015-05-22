using FullAdder.Factory;
using FullAdder.Model;
using FullAdder.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Controller
{
    public class MainController
    {
        private Circuit currentCircuit;

        public MainController()
        {
            GateFactory.init();

            currentCircuit = FileService.ReadFile(Directory.GetCurrentDirectory() + @"\Circuits\FullAdder.txt").Result;
        }
    }
}
