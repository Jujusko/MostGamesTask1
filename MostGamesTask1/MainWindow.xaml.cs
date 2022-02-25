using MostGamesTask1.Logic;
using System;
using System.Windows;
using System.Windows.Input;

namespace MostGamesTask1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AnaliseArgs _validator = new();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ButtonAnaliseText_Click(object sender, RoutedEventArgs e)
        {
            string args = TextBoxIds.Text;
            var ids = _validator.GetNumberOfLines(args);
            //crunch to detect bar symbols
            if (ids[0] == -1)
            {
                TextBoxContent.Text = "Only digits allowed";
                return;
            }
            GetText textToOutput = new();
            var lines = textToOutput.GetLines(ids);
            TextBoxContent.Text = "";
            TextBoxWordCount.Text = "";
            TextBoxCountVowels.Text = "";
            foreach (var line in lines)
            {
                TextBoxContent.Text += $"{line}\n\n\n";
                TextBoxWordCount.Text += $"{textToOutput.CountWords(line)}\n\n\n";
                TextBoxCountVowels.Text += $"{textToOutput.CountVowels(line)}\n\n\n";
            }
        }

        //helper inputTextBox which allows to input only digits and oemcomma
        private void TextBoxIds_KeyDown(object sender, KeyEventArgs e)
        {
            //have one mistake: cant handle 'б' and !@#$%^&*() chars
            int c = (Char)e.Key;
            if ((((Char)e.Key >= 34 && (Char)e.Key <= 43)) || e.Key == Key.OemComma)
                e.Handled = false;
            else if (((Char)e.Key >= 74 && (Char)e.Key <= 83))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
