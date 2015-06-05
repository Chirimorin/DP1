using CircuitSimulator.Factory;
using CircuitSimulator.Model;
using CircuitSimulator.Services;
using CircuitSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Controller
{
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

        private Circuit currentCircuit;
        public MainWindow MainWindow { get; set; }

        public MainController(MainWindow view)
        {
            MainWindowViewModel.Instance.Status = "Loading...";

            Instance = this;
            NodeFactory.init();

            view.DataContext = MainWindowViewModel.Instance;
            MainWindow = view;

            MainWindowViewModel.Instance.Status = "Done";
        }

        public void OpenFile(string path)
        {
            try
            {
                MainWindowViewModel viewModel = MainWindowViewModel.Instance;

                viewModel.Status = "Opening file: " + path;
                viewModel.WindowTitle = "";

                viewModel.ResetNodes();
                currentCircuit = FileService.ReadFile(path);
                viewModel.NotifyInputChanged();

                viewModel.Status = "Done";
                viewModel.WindowTitle = path.Split('\\').LastOrDefault();
            }
            catch (FileNotFoundException e)
            {
                MainWindowViewModel.Instance.Status = "Circuit file not found! (" + e.FileName + ")";
            }
            catch (Exception e)
            {
                MainWindowViewModel.Instance.Status = "Could not load circuit: " + e.Message;
            }
        }
    }
}
