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
        public MainWindowViewModel ViewModel { get; set; }
        public MainWindow MainWindow { get; set; }

        public MainController(MainWindow view)
        {
            Instance = this;
            NodeFactory.init();

            ViewModel = new MainWindowViewModel();
            view.DataContext = ViewModel;
            MainWindow = view;

            currentCircuit = FileService.ReadFile(Directory.GetCurrentDirectory() + @"\Circuits\FullAdder.txt");
            ViewModel.NotifyPropertyChanged();
            ViewModel.logOutput();
        }
    }
}
