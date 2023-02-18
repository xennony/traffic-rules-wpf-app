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

namespace PDD.pages.questions
{
    /// <summary>
    /// Логика взаимодействия для _2.xaml
    /// </summary>
    public partial class _19 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _19()
        {
            InitializeComponent();
            StartGame();
            NextQuestion();
        }

        private void checkAnswerEvent(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;

            nextBtn.Visibility = Visibility.Visible;

            if (senderButton.Tag.ToString() == "1")
            {
                senderButton.Background = new SolidColorBrush(Color.FromRgb(122, 229, 122));
                if (isFirstAnswer)
                {
                    score++;
                    isFirstAnswer = false;
                    MainWindow.correctAnswers++;
                }

            }
            else
            {
                senderButton.Background = new SolidColorBrush(Color.FromRgb(229, 122, 122));

                if (!MainWindow.globalArray.Contains(19) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(19);
                    isFirstAnswer = false;
                }

                if (isFirstAnswer)
                {
                    MainWindow.wrongAnswers++;
                    isFirstAnswer = false;
                }
            }


            if (questionNumber < 0)
            {
                questionNumber = 0;
            }
            else if (flag)
            {
                flag = false;
                questionNumber++;
            }


            scoreText.Content = "Правильно отвечено: " + score + "/" + questionNumbers.Count;


        }

        private void NextQuestion()
        {
            isFirstAnswer = true;

            resWin.Visibility = Visibility.Hidden;

            if (questionNumber < questionNumbers.Count)
            {
                i = questionNumbers[questionNumber];        
            }
            else
            {
                i = questionNumbers[0];
                //NavigationService.Navigate(new ResultPage());
                //RestartGame();
                resWin.qNum.Text = score.ToString();
                restartButton.Visibility = Visibility.Visible;

                if (score == 20)
                {
                    resWin.WordButton.Text = "Отлично, вы решили все вопросы!";
                    MainWindow.StatisticGlobalArray[18] = 1;
                }
                else if (score <= 10)
                {
                    resWin.WordButton.Text = "Нужно повторить!";
                }
                else
                {
                    resWin.WordButton.Text = "Молодец!";
                }

                if (questionNumber > questionNumbers.Count)
                {
                    resWin.Visibility = Visibility.Visible;
                    nextBtn.Visibility = Visibility.Visible;
                    nextBtn.IsEnabled = false;
                    Statistics.countTickets++;
                    bt1.IsEnabled = false;
                    bt2.IsEnabled = false;
                    bt3.IsEnabled = false;
                    bt4.IsEnabled = false;
                }

            }

            foreach (var x in MyGrid.Children.OfType<Button>())
            {
                x.Tag = "0";
            }

            bt1.Tag = "0";
            bt2.Tag = "0";
            bt3.Tag = "0";
            bt4.Tag = "0";


            switch (i)
            {

                case 1:
                    txtQuestion.Text = "Сколько проезжих частей имеет данная дорога?";

                    ans1.Text = "1. Одну.";
                    ans2.Text = "2. Две.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Четыре.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "В каком направлении Вам можно продолжить движение на легковом автомобиле?";

                    ans1.Text = "1. Только прямо.";
                    ans2.Text = "2. Прямо и направо.";
                    ans3.Text = "3. В любом.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешено ли осуществлять посадку (высадку) пассажиров либо загрузку (разгрузку) транспортного средства в зоне действия этого знака?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено, если это займет не более 5 минут.";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какие из указанных знаков разрешают выполнить разворот?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Б и В.";
                    ans3.Text = "3. Все.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Чем необходимо руководствоваться, если значения дорожных знаков и линий горизонтальной разметки противоречат друг другу?";

                    ans1.Text = "1. Требованиями линий разметки.";
                    ans2.Text = "2. Требованиями дорожных знаков.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Правила эту ситуацию не регламентируют.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Как Вы должны поступить в данной ситуации?";

                    ans1.Text = "1. Продолжить движение, не изменяя скорости.";
                    ans2.Text = "2. Снизить скорость и быть готовым в случае необходимости незамедлительно остановиться.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Остановиться около автомобиля ДПС и продолжить движение только после разрешения сотрудника полиции.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Когда должна быть прекращена подача сигнала указателями поворота?";

                    ans1.Text = "1. Непосредственно перед началом маневра.";
                    ans2.Text = "2. Сразу после начала маневра.";
                    ans3.Text = "3. Сразу после завершения маневра.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Вам можно выполнить поворот налево:";

                    ans1.Text = "1. Только по траектории А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только по траектории Б.";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Водитель случайно проехал нужный въезд во двор. Разрешено ли в этой ситуации использовать задний ход, чтобы затем повернуть направо?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено, если водитель управляет легковым такси.";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "С какой скоростью Вы имеете право продолжить движение в населенном пункте по левой полосе?";

                    ans1.Text = "1. Не более 40 км/ч.";
                    ans2.Text = "2. Не более 60 км/ч.";
                    ans3.Text = "3. Не менее 40 км/ч и не более 60 км/ч.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "По какой полосе Вам можно продолжить движение в населенном пункте после опережения грузового автомобиля?";

                    ans1.Text = "1. Только по правой.";
                    ans2.Text = "2. Только по левой.";
                    ans3.Text = "3. По любой.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Кто из водителей нарушил правила стоянки?";

                    ans1.Text = "1. Оба.";
                    ans2.Text = "2. Только водитель автомобиля А.";
                    ans3.Text = "3. Только водитель автомобиля Б.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Никто не нарушил.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "Вы намерены проехать перекресток в прямом направлении. Ваши действия?";

                    ans1.Text = "1. Остановитесь перед стоп-линией.";
                    ans2.Text = "2. Продолжите движение, уступая дорогу легковому автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Продолжите движение, имея преимущество перед легковым автомобилем.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Как Вам следует поступить при повороте направо?";

                    ans1.Text = "1. Проехать перекресток первым.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Уступить дорогу только легковому автомобилю.";
                    ans3.Text = "3. Уступить дорогу легковому автомобилю и мотоциклу.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Если невозможно определить наличие покрытия на дороге (тёмное время суток, грязь, снег и тому подобное), а знаков приоритета нет, то:";

                    ans1.Text = "1. Вы имеете право считать, что находитесь на главной дороге.";
                    ans2.Text = "2. Вам следует считать, что находитесь на равнозначной дороге.";
                    ans3.Text = "3. Вы должны считать, что находитесь на второстепенной дороге.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "В данной ситуации Вы:";

                    ans1.Text = "1. Должны уступить дорогу автобусу, начинающему движение от обозначенного места остановки.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Имеете преимущество, так как автобус начинает движение с выездом на левую полосу.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Какие внешние световые приборы должны быть включены в темное время суток и в условиях недостаточной видимости независимо от освещения дороги, а также в тоннелях на буксируемых механических транспортных средствах?";

                    ans1.Text = "1. Дневные ходовые огни.";
                    ans2.Text = "2. Габаритные огни.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Задние противотуманные фонари.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "У водителя, совершившего административное правонарушение, водительское удостоверение изымается:";

                    ans1.Text = "1. При выявлении и пресечении правонарушения.";
                    ans2.Text = "2. Немедленно после вынесения постановления о лишении права управления транспортными средствами.";
                    ans3.Text = "3. После вступления постановления о лишении права управления транспортными средствами в законную силу.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Для прекращения заноса, вызванного торможением, водитель в первую очередь должен:";

                    ans1.Text = "1. Прекратить начатое торможение.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Выключить сцепление.";
                    ans3.Text = "3. Продолжить торможение, не изменяя усилия на педаль тормоза.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Что необходимо сделать для извлечения инородного тела, попавшего в дыхательные пути пострадавшего?";

                    ans1.Text = "1. Уложить пострадавшего на свое колено лицом вниз и ударить кулаком по спине несколько раз.";
                    ans2.Text = "2. Вызвать рвоту, надавив на корень языка. При отрицательном результате ударить ребром ладони по спине пострадавшего либо встать спереди и сильно надавить кулаком на его живот.";
                    ans3.Text = "3. Встать сбоку от пострадавшего, поддерживая его одной рукой под грудь, второй рукой наклонить корпус пострадавшего вперед головой вниз. Нанести пять резких ударов основанием ладони в область между лопаток. При отрицательном результате встать сзади, обхватить его обеими руками чуть выше пупка, сцепить свои руки в замок и пять раз резко надавить на область живота в направлении внутрь и кверху.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/19/20.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

            }
            {
            if (MainWindow.GOD_MOD)
            {
                if (bt1.Tag.ToString() == "1")
                {
                    bt1.Background = new SolidColorBrush(Color.FromRgb(204, 255, 204));
                }
                if (bt2.Tag.ToString() == "1")
                {
                    bt2.Background = new SolidColorBrush(Color.FromRgb(204, 255, 204));
                }
                if (bt3.Tag.ToString() == "1")
                {
                    bt3.Background = new SolidColorBrush(Color.FromRgb(204, 255, 204));
                }
                if (bt4.Tag.ToString() == "1")
                {
                    bt4.Background = new SolidColorBrush(Color.FromRgb(204, 255, 204));
                }
            }
            }

        }

        private void RestartGame()
        {
             nextBtn.Visibility = Visibility.Hidden;
            bt1.Background = Brushes.White;
            bt2.Background = Brushes.White;
            bt3.Background = Brushes.White;
            bt4.Background = Brushes.White;
            flag = true;

            isFirstAnswer = true;

            nextBtn.IsEnabled = true;

            bt1.IsEnabled = true;
            bt2.IsEnabled = true;
            bt3.IsEnabled = true;
            bt4.IsEnabled = true;

            InitializeComponent();
            score = 0;
            questionNumber = 1;
            i = 0;
            StartGame();
            NextQuestion();
        }
        private void StartGame()
        {
            var randomList = questionNumbers.OrderBy(a => Guid.NewGuid()).ToList();

            questionNumbers = randomList;

            questionOrder.Content = "Вопрос 1";

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            nextBtn.Visibility = Visibility.Hidden;
            bt1.Background = Brushes.White;
            bt2.Background = Brushes.White;
            bt3.Background = Brushes.White;
            bt4.Background = Brushes.White;
            //senderButton.Background = new SolidColorBrush(Color.FromRgb(122, 229, 122));
            if (questionNumber <= questionNumbers.Count)
            {
                questionOrder.Content = "Вопрос " + questionNumber.ToString();
            }
            flag = true;
            NextQuestion();


        }

        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            restartButton.Visibility = Visibility.Hidden;
            scoreText.Content = "Правильно отвечено: " + 0 + "/" + questionNumbers.Count;
            RestartGame();
        }


    }
}
