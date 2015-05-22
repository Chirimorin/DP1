using FullAdder.Controller;
using FullAdder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FullAdder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainController mainController;

        private List<LogicGate> _logicGates;

        private Input _Cin;
        private Input _A;
        private Input _B;

        private Output _Sum;
        private Output _Cout;

        public MainWindow()
        {
            InitializeComponent();

            mainController = new MainController();

            _logicGates = new List<LogicGate>();

            _Cin = new Input();
            _A = new Input();
            _B = new Input();

            _Sum = new Output();
            _Cout = new Output();

            _logicGates.Add(new OrGate());
            _logicGates.Add(new AndGate());
            _logicGates.Add(new AndGate());
            _logicGates.Add(new NotGate());
            _logicGates.Add(new AndGate());
            _logicGates.Add(new OrGate());
            _logicGates.Add(new NotGate());
            _logicGates.Add(new NotGate());
            _logicGates.Add(new AndGate());
            _logicGates.Add(new AndGate());
            _logicGates.Add(new OrGate());

            _Cin.Outputs.Add(_logicGates.ElementAt(2));
            _Cin.Outputs.Add(_logicGates.ElementAt(6));
            _Cin.Outputs.Add(_logicGates.ElementAt(9));

            _A.Outputs.Add(_logicGates.ElementAt(0));
            _A.Outputs.Add(_logicGates.ElementAt(1));

            _B.Outputs.Add(_logicGates.ElementAt(0));
            _B.Outputs.Add(_logicGates.ElementAt(1));

            _logicGates.ElementAt(0).Outputs.Add(_logicGates.ElementAt(2));
            _logicGates.ElementAt(0).Outputs.Add(_logicGates.ElementAt(4));

            _logicGates.ElementAt(1).Outputs.Add(_logicGates.ElementAt(3));
            _logicGates.ElementAt(1).Outputs.Add(_logicGates.ElementAt(5));

            _logicGates.ElementAt(2).Outputs.Add(_logicGates.ElementAt(5));

            _logicGates.ElementAt(3).Outputs.Add(_logicGates.ElementAt(4));

            _logicGates.ElementAt(4).Outputs.Add(_logicGates.ElementAt(7));
            _logicGates.ElementAt(4).Outputs.Add(_logicGates.ElementAt(8));

            _logicGates.ElementAt(5).Outputs.Add(_Cout);

            _logicGates.ElementAt(6).Outputs.Add(_logicGates.ElementAt(8));

            _logicGates.ElementAt(7).Outputs.Add(_logicGates.ElementAt(9));

            _logicGates.ElementAt(8).Outputs.Add(_logicGates.ElementAt(10));

            _logicGates.ElementAt(9).Outputs.Add(_logicGates.ElementAt(10));

            _logicGates.ElementAt(10).Outputs.Add(_Sum);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _Cin.reset();
            _A.reset();
            _B.reset();

            _Cin.setInput((bool)Cin.IsChecked);
            _A.setInput((bool)A.IsChecked);
            _B.setInput((bool)B.IsChecked);


            Sum.IsChecked = _Sum.output;
            Cout.IsChecked = _Cout.output;
            Console.WriteLine("Sum: " + _Sum.output);
            Console.WriteLine("Cout: " + _Cout.output);
        }
    }
}

