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

namespace WpfTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //viewModel.People.Add(new Person() { Name = "Sombre perof", Occupation = "Prelnatrik" });
            //viewModel.People.Add(new Person() { Name = "4eombrwewe pweweerof", Occupation = "wawer" });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         //   viewModel.SelectedPerson = viewModel.PeopleList[0];
        }

    }
}
