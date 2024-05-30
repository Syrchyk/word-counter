using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace WpfApp20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string path;
        private string word;
        private string[] text;
        private int counter = 0;

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            path = tbP.Text;
            word = tbW.Text;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    int i = 0;
                    text = new string[sr.Peek()];
                    while(sr.Peek() > 0)
                    {
                        text[i] = await sr.ReadLineAsync();
                        string[] strings = text[i].Split(' ');
                        for (int j = 0; j < strings.Length; j++)
                        {
                            if (strings[j] == word)
                            {
                                counter++;
                            }
                        }
                        i++;
                    }
                }
                fs.Close();
            }
            tbC.Text = counter.ToString();
        }
    }
}
