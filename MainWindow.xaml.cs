using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public DateTime start;
        public MainWindow()
        {
            InitializeComponent();

            Tasks = new List<Excercise>();
            TableManager.RefreshTable(table);
        }

        private void GenButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            int rows = 0;

            if (!Int32.TryParse(RowInput.Text, out rows))
            {
                return;
            }
            if (rows < 0)
            {
                return;
            }

            

            start = DateTime.Now;
            string rx = GenerateRx();
            if(rx == null)
            {
                return;
            }

            Tasks.Clear();
            Tasks = TableManager.GenerateTasks(new Regex(rx), rows);


            TableManager.FillTable(table, Tasks);
            CheckButton.IsEnabled = true;
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            int correct = 0;
            
            foreach(Excercise i in Tasks)
            {
                i.correct.Visibility = Visibility.Visible;
                i.answer.IsEnabled = false;
                CheckButton.IsEnabled = false;

                if(i.answer.Text == i.correct.Text)
                {
                    i.correct.Background = new SolidColorBrush(Colors.Green);
                    correct++;
                }
                else
                {
                    i.correct.Background = new SolidColorBrush(Colors.Red);
                }

            }

            MessageBox.Show($"Вы выполнили {correct} заданий из {Tasks.Count} \n Это заняло {(DateTime.Now - start).Minutes} минут, {(DateTime.Now - start).Seconds} секунд", "Вы выполнили задание!");
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        public static void GenerateField(int rows)
        {
            
        }

        public string GenerateRx()
        {
            string? rx = @"";

            if((bool)RB_1.IsChecked)
            {
                rx += "|безударная гласная";
            }
            if ((bool)RB_2.IsChecked)
            {
                rx += "|словарное слово";
            }
            if ((bool)RB_3.IsChecked)
            {
                rx += "|окончания склонений";
            }
            if ((bool)RB_4.IsChecked)
            {
                rx += "|глухие согласные";
            }

            if(rx.Length > 0)
            {
                if (rx[0] == '|')
                {
                    rx = rx.Remove(0, 1);
                }
            }
            else
            {
                rx = null;
            }
            

            return rx;
        }
    }
    
}
