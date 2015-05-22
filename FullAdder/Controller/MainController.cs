using FullAdder.Factory;
using FullAdder.Model;
using FullAdder.Services;
using FullAdder.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Controller
{
    public delegate void OnInputHandler(object source, EventArgs e);

    public class MainController
    {
        private static MainController instance;
        public static MainController Instance
        {
            get
            {
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public event OnInputHandler OnInput;

        private Circuit currentCircuit;
        public MainWindowViewModel ViewModel { get; set; }

        public MainController(MainWindow view)
        {
            Instance = this;
            NodeFactory.init();

            ViewModel = new MainWindowViewModel();

            currentCircuit = FileService.ReadFile(Directory.GetCurrentDirectory() + @"\Circuits\FullAdder.txt");
            ViewModel.logOutput();
        }

        public void onInput()
        {
            //OnInput(null, EventArgs.Empty);
        }
    }
}
