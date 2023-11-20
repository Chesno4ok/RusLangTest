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

namespace RussianLangTest
{

    public class Excercise
    {
        public string? row;
        public string? task;
        public string? answer;
        public string? correct;
        public Excercise(int row, string task, string answer, string correct)
        {
            this.row = row.ToString();
            this.task = task;
            this.answer = answer;
            this.correct = correct;
        }

        public Excercise()
        {

        }
    }

    
}

    
