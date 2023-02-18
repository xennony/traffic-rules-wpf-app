using PDD.pages;
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

namespace PDD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<int> globalArray = new List<int>();

        public static int[] StatisticGlobalArray = new int[40];

        public static bool GOD_MOD = false;

        public static int correctAnswers = 0;
        public static int wrongAnswers = 0;


        public MainWindow()
        {
            InitializeComponent();

           

            for (int i = 0; i < StatisticGlobalArray.Length; i++)
            {
                StatisticGlobalArray[i] = 0;
            }
        }

        private void LearnButton_Click(object sender, RoutedEventArgs e)
        {
            //Frame frame = new Frame();

            //Current.Content = frame;
            frame.Navigate(new Learn());
        }

        private void TheoryButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Theory());
        }

        private void myFrame_ContentRendered(object sender, EventArgs e)
        {
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            //HelpBtn_Click(null, null);
            string commandText = "help.chm";
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }

        private void MistakeButton_Click(object sender, RoutedEventArgs e)
        {
            Learn learn = new Learn();



            string[] arr = 
                {
                    "OneButton",
                    "TwoButton",
                    "ThreeButton",
                    "FourButton",
                    "FiveButton",
                    "SixButton",
                    "SevenButton",
                    "EightButton",
                    "NineButton",
                    "TenButton",
                    "ElevenButton",
                    "TwelveButton",
                    "ThirteenButton",
                    "FourteenButton",
                    "FifteenButton",
                    "SixteenButton",
                    "SeventeenButton",
                    "EighteenButton",
                    "NineteenButton",
                    "TwentyButton",
                    "TwentyOneButton",
                    "TwentyTwoButton",
                    "TwentyThreeButton",
                    "TwentyFourButton",
                    "TwentyFiveButton",
                    "TwentySixButton",
                    "TwentySevenButton",
                    "TwentyEightButton",
                    "TwentyNineButton",
                    "ThirtyButton",
                    "ThirtyOneButton",
                    "ThirtyTwoButton",
                    "ThirtyThreeButton",
                    "ThirtyFourButton",
                    "ThirtyFiveButton",
                    "ThirtySixButton",
                    "ThirtySevenButton",
                    "ThirtyEightButton",
                    "ThirtyNineButton",
                    "FortyButton"                
            };

            for (int i = 0; i < 40; i++)
            {
                Button b = (Button)learn.MainStackPanel.FindName(arr[i]);
                b.Visibility = Visibility.Hidden;
                learn.labelVis.Visibility = Visibility.Visible;


            }

            foreach (int number in MainWindow.globalArray)
            {
                Button b = (Button)learn.MainStackPanel.FindName(arr[number - 1]);
                b.Visibility = Visibility.Visible;
                learn.labelVis.Visibility = Visibility.Hidden;

            }
            frame.Navigate(learn);


        }

        private void StatisticButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Statistics());
        }

        private void ExamButton_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Exam());
        }


        private void Current_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Current_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.G)
            {
                if (GOD_MOD == false)
                {
                    GOD_MOD = true;
                }
                else
                {
                    GOD_MOD = false;
                }
            }  
        }
    }
}
