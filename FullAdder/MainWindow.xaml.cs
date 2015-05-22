using FullAdder.Controller;
using FullAdder.OldModel;
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

        public MainWindow()
        {
            InitializeComponent();

            mainController = new MainController(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //_Cin.reset();
            //_A.reset();
            //_B.reset();

            //_Cin.setInput((bool)Cin.IsChecked);
            //_A.setInput((bool)A.IsChecked);
            //_B.setInput((bool)B.IsChecked);


            //Sum.IsChecked = _Sum.output;
            //Cout.IsChecked = _Cout.output;
            //Console.WriteLine("Sum: " + _Sum.output);
            //Console.WriteLine("Cout: " + _Cout.output);
        }
    }
}

