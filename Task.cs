using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;

namespace RussianLangTest
{

    public class Excercise
    {
        public TextBlock row = new TextBlock();
        public TextBlock task = new TextBlock();
        public TextBox answer = new TextBox();
        public TextBlock correct = new TextBlock();


        public Excercise(int row, string task, string correct)
        {
            this.row.Text = row.ToString();
            this.task.Text = task;
            this.correct.Text = correct;
            this.correct.Visibility = Visibility.Hidden;

            this.task.TextWrapping = TextWrapping.Wrap;
        }
    }

    public class Root
    {
        public List<Task> Tasks { get; set; }
    }

    public class Task
    {
        public string task { get; set; }
        public string type { get; set; }
        public string correct { get; set; }
    }


    public static class TableManager
    {
        public static void FillTable(UniformGrid table, List<Excercise> tasks)
        {
            RefreshTable(table);

            foreach(Excercise i in tasks)
            {
                table.Children.Add(i.row);
                table.Children.Add(i.task);
                table.Children.Add(i.answer);
                table.Children.Add(i.correct);
            }
        }

        public static void RefreshTable(UniformGrid table)
        {
            table.Children.Clear();

            var id = new TextBlock();
            id.Text = "ID";
            table.Children.Add(id);

            var task = new TextBlock();
            task.Text = "Задание";
            table.Children.Add(task);

            var answer = new TextBlock();
            answer.Text = "Ответ";
            table.Children.Add(answer);

            var correct = new TextBlock();
            correct.Text = "Правильный ответ";
            table.Children.Add(correct);
        }
        public static List<Excercise> GenerateTasks(Regex rx, int rows)
        {
            List<Excercise> res = new List<Excercise>();

            Root? value = (Root?)JsonSerializer.Deserialize(File.ReadAllText("tasks.json"), typeof(Root));
            
            List<Task> lst = value.Tasks.Where(i => rx.IsMatch(i.type)).ToList();
            Shuffle(lst);

            int x = 0;
            for (int i = 0; i < rows; i++)
            {
                if(x > lst.Count - 1)
                {
                    Shuffle(lst);
                    x = 0;
                }

                res.Add(new Excercise(i + 1, lst[x].task, lst[x].correct));

                x++;
            }

                
            return res;
        }

        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    
}

    
