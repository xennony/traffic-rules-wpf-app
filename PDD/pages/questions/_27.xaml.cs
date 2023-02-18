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
    public partial class _27 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _27()
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

                if (!MainWindow.globalArray.Contains(27) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(27);
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
                    MainWindow.StatisticGlobalArray[26] = 1;
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
                    txtQuestion.Text = "Если в результате дорожно-транспортного происшествия (ДТП) вред причинен только имуществу, то, предварительно зафиксировав положение транспортных средств по отношению друг другу и объектам дорожной инфраструктуры, следы и предметы, относящиеся к ДТП, повреждения транспортных средств, водитель, причастный к ДТП:";

                    ans1.Text = "1. Обязан освободить проезжую часть.";
                    ans2.Text = "2. Обязан освободить проезжую часть, если движению других транспортных средств создается препятствие.";
                    ans3.Text = "3. Имеет право по своему усмотрению освободить проезжую часть.";
                    bt2.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Какие из указанных знаков используются для обозначения границ искусственной неровности?";

                    ans1.Text = "1. Только А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только Б.";
                    ans3.Text = "3. Б и В.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "В данной ситуации остановка:";

                    ans1.Text = "1. Запрещена.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешена только маршрутным транспортным средствам, используемым в качестве легкового такси.";
                    ans3.Text = "3. Разрешена только транспортным средствам, управляемым инвалидом или перевозящим инвалидов, в том числе детей-инвалидов.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Управляя каким автомобилем, можно осуществить опережение в данной ситуации?";

                    ans1.Text = "1. Только легковым.";
                    ans2.Text = "2. Легковым или грузовым с разрешенной максимальной массой не более 2,5 т.";
                    ans3.Text = "3. Легковым или грузовым с разрешенной максимальной массой не более 3,5 т.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Что обозначает эта разметка?";

                    ans1.Text = "1. Номер дороги или маршрута.";
                    ans2.Text = "2. Рекомендуемую скорость движения на данном участке дороги.";
                    ans3.Text = "3. Разрешенную максимальную скорость движения на данном участке дороги.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Чем должны руководствоваться водители, если указания регулировщика противоречат значениям сигналов светофоров и требованиям дорожных знаков?";

                    ans1.Text = "1. Требованиями дорожных знаков.";
                    ans2.Text = "2. Значениями сигналов светофора.";
                    ans3.Text = "3. Указаниями регулировщика.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Такой сигнал рукой, подаваемый водителем мотоцикла, который движется по левой полосе, информирует о его намерении:";

                    ans1.Text = "1. Продолжить движение прямо.";
                    ans2.Text = "2. Повернуть направо.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Остановиться.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "При перестроении на правую полосу в данной ситуации Вы:";

                    ans1.Text = "1. Должны уступить дорогу автомобилю, движущемуся по соседней полосе.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Имеете преимущество в движении.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "По какой траектории Вам разрешается выполнить разворот?";

                    ans1.Text = "1. Только по А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только по Б.";
                    ans3.Text = "3. По указанным траекториям разворот запрещен.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Каковы Ваши действия в данной ситуации?";

                    ans1.Text = "1. Объедете грузовой автомобиль справа по обочине.";
                    ans2.Text = "2. Продолжите движение только после того, как грузовой автомобиль освободит полосу движения.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Допускаются оба варианта действий.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Запрещено ли выполнить обгон на подъеме?";

                    ans1.Text = "1. Запрещено.";
                    ans2.Text = "2. Запрещено только в конце подъема.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Разрешено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Разрешается ли водителям транспортных средств остановка в указанных местах?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только водителю мотоцикла.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Как Вам следует поступить при повороте направо?";

                    ans1.Text = "1. Остановиться и дождаться другого сигнала регулировщика.";
                    ans2.Text = "2. Проехать перекресток, уступив дорогу трамваю.";
                    ans3.Text = "3. Проехать перекресток первым.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Как Вам следует поступить, двигаясь по перекрестку с круговым движением?";

                    ans1.Text = "1. Уступить дорогу грузовому автомобилю.";
                    ans2.Text = "2. Проехать перекресток первым.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Действовать по взаимной договоренности с водителем грузового автомобиля.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только легковому автомобилю.";
                    ans2.Text = "2. Легковому автомобилю и автобусу.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Всем транспортным средствам.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "На каком наименьшем расстоянии до ближайшего рельса Вы должны остановиться?";

                    ans1.Text = "1. 5 м.";
                    ans2.Text = "2. 10 м.";
                    bt2.Tag = "1";
                    ans3.Text = "3. 15 м.";
                    ans4.Text = "4. 20 м.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 17:
                    txtQuestion.Text = "При буксировке на гибкой сцепке между буксирующим и буксируемым транспортными средствами должно быть обеспечено расстояние:";

                    ans1.Text = "1. Не более 4 м.";
                    ans2.Text = "2. От 4 до 6 м.";
                    bt2.Tag = "1";
                    ans3.Text = "3. От 6 до 8 м.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Какие административные правонарушения, совершенные водителем, который лишен права управления транспортными средствами, влекут административный арест?";

                    ans1.Text = "1. Управление транспортным средством; оставление водителем в нарушение Правил места дорожно-транспортного происшествия, участником которого он являлся.";
                    ans2.Text = "2. Управление транспортным средством в состоянии опьянения, невыполнение законного требования уполномоченного должностного лица о прохождении медицинского освидетельствования на состояние опьянения.";
                    ans3.Text = "3. Все перечисленные действия.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Устранение заноса задней оси путем увеличения скорости возможно:";

                    ans1.Text = "1. Только на переднеприводном автомобиле.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только на заднеприводном автомобиле.";
                    ans3.Text = "3. На любом автомобиле из перечисленных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "На каком рисунке показано правильное положение рук на рулевом колесе?";

                    ans1.Text = "1. На левом.";
                    ans2.Text = "2. На среднем.";
                    ans3.Text = "3. На правом.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/27/20.jpg"));

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
