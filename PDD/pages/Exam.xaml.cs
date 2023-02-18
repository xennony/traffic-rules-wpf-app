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
    /// Логика взаимодействия для Exam.xaml
    /// </summary>
    public partial class Exam : Page
    {
        public Exam()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

        private void ExamStartButton_Click(object sender, RoutedEventArgs e)
        {
            frameExam.Navigate(new ExamStartButton());
        }
    }
}
