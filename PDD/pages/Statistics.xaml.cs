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

namespace PDD.pages
{
    /// <summary>
    /// Логика взаимодействия для Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        public static int countTickets = 0;



        public Statistics()
        {
            InitializeComponent();
            for (int i = 0; i < MainWindow.statisticGlobalArray.Length; i++)
            {
                Console.Write(i + " "); 
                Console.WriteLine(MainWindow.statisticGlobalArray[i]);
            }

            Label2.Content = "Решенно билетов: ";
            ProgressBar1.Maximum = 40;
            label6.Content = MainWindow.statisticGlobalArray.Sum();
            ProgressBar1.Value = MainWindow.statisticGlobalArray.Sum();

            if (MainWindow.wrongAnswers + MainWindow.correctAnswers == 0)
            {
                Label4.Content = "Процент правильных ответов: " + 0 + "%";
            }
            else
            {
                float a = MainWindow.correctAnswers / (float)(MainWindow.correctAnswers + MainWindow.wrongAnswers);
                Label4.Content = "Процент правильных ответов: " + Math.Round(a * 100, 2)+ "%";
            }
        }

        private void backButton1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }
    }
}
