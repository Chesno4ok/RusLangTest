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

namespace RussianLangTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Excercise> Tasks { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Tasks = new List<Excercise>();
            
        }

        private void GenButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Tasks.Add(new Excercise(i + 1, "Тест", "Тест", "Тест"));
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        public static void GenerateField(int rows)
        {
            
        }
    }
    
}
