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
    public partial class _6 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;

        ResultWindow resWin = new ResultWindow();


        public _6()
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

                if (!MainWindow.globalArray.Contains(6) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(6);
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
                resWin.qNum.Text = score.ToString();
                restartButton.Visibility = Visibility.Visible;

                if (score == 20)
                {
                    resWin.WordButton.Text = "Отлично, вы решили все вопросы!";
                    MainWindow.StatisticGlobalArray[5] = 1;
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
                    txtQuestion.Text = "Что называется разрешенной максимальной массой транспортного средства?";

                    ans1.Text = "1. Максимально допустимая для перевозки масса груза, установленная предприятием-изготовителем.";
                    ans2.Text = "2. Масса снаряженного транспортного средства без учета массы водителя, пассажиров и груза, установленная предприятием-изготовителем.";
                    ans3.Text = "3. Масса снаряженного транспортного средства с грузом, водителем и пассажирами, установленная предприятием-изготовителем в качестве максимально допустимой.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Вам разрешено продолжить движение:";

                    ans1.Text = "1. Только прямо.";
                    ans2.Text = "2. Прямо или в обратном направлении.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Во всех направлениях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Какие из указанных знаков разрешают проезд на автомобиле к месту проживания или работы?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только В.";
                    ans3.Text = "3. А и В.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Все.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 4:
                    txtQuestion.Text = "Что обозначают эти дорожные знаки?";

                    ans1.Text = "1. Парковочное место только для автобусов.";
                    ans2.Text = "2. Парковочное место для автобусов и троллейбусов.";
                    ans3.Text = "3. Парковочное место, где возможна пересадка на маршрутное транспортное средство (автобус или троллейбус).";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Разметка в виде треугольника на полосе движения:";

                    ans1.Text = "1. Обозначает опасный участок дороги.";
                    ans2.Text = "2. Предупреждает Вас о приближении к месту, где нужно уступить дорогу.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Указывает место, где Вам необходимо остановиться.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Разрешается ли продолжить движение, если регулировщик поднял руку вверх после того, как Вы въехали на перекресток?";

                    ans1.Text = "1. Разрешается.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешается, если Вы поворачиваете направо.";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Вы намерены продолжить движение по главной дороге. Обязаны ли Вы включить указатели левого поворота?";

                    ans1.Text = "1. Обязаны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Обязаны, если с других направлений приближаются транспортные средства.";
                    ans3.Text = "3. Не обязаны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Кто должен уступить дорогу при взаимном перестроении?";

                    ans1.Text = "1. Водитель легкового автомобиля.";
                    ans2.Text = "2. Водитель грузового автомобиля.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Водителям следует действовать по взаимной договоренности.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "В каких направлениях Вам можно продолжить движение?";

                    ans1.Text = "1. Только прямо.";
                    ans2.Text = "2. Прямо и налево.";
                    ans3.Text = "3. Прямо, налево и в обратном направлении.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "С какой максимальной скоростью Вы имеете право продолжить движение на легковом автомобиле?";

                    ans1.Text = "1. 70 км/ч.";
                    ans2.Text = "2. 90 км/ч.";
                    ans3.Text = "3. 110 км/ч.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Как Вам следует поступить в данной ситуации?";

                    ans1.Text = "1. Уступить дорогу встречному автомобилю.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Проехать первым.";
                    ans3.Text = "3. Действовать по взаимной договоренности с водителем встречного автомобиля.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Разрешено ли Вам поставить автомобиль на стоянку в этом месте?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если при этом не будут созданы помехи для движения маршрутных транспортных средств.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Вы намерены повернуть налево. Ваши действия?";

                    ans1.Text = "1. Уступите дорогу трамваю.";
                    ans2.Text = "2. Дождетесь разрешающего сигнала специального светофора и, пропустив трамвай, повернете налево.";
                    ans3.Text = "3. Проедете перекресток первым.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только пешеходам.";
                    ans2.Text = "2. Пешеходам и велосипедисту.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Никому.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "В каком случае Вы должны будете уступить дорогу автомобилю ДПС?";

                    ans1.Text = "1. Если на автомобиле ДПС будут включены проблесковые маячки синего цвета.";
                    ans2.Text = "2. Если на автомобиле ДПС одновременно будут включены проблесковые маячки синего цвета и специальный звуковой сигнал.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В любом.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "При приближении к остановившемуся транспортному средству с включенной аварийной сигнализацией, которое имеет опознавательные знаки «Перевозка детей», водитель должен:";

                    ans1.Text = "1. Снизить скорость.";
                    ans2.Text = "2. При необходимости остановиться и пропустить детей.";
                    ans3.Text = "3. Осуществить все перечисленные действия.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "В каких случаях водители мопедов нарушают Правила?";

                    ans1.Text = "1. Только если управляют мопедом, не держась за руль хотя бы одной рукой.";
                    ans2.Text = "2. Только если двигаются по дороге без застегнутого мотошлема.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Эксплуатировать грузовой автомобиль с разрешенной максимальной массой не более 3,5 т можно при отсутствии:";

                    ans1.Text = "1. Аптечки.";
                    ans2.Text = "2. Огнетушителя.";
                    ans3.Text = "3. Знака аварийной остановки.";
                    ans4.Text = "4. Противооткатных упоров.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 19:
                    txtQuestion.Text = "В случае остановки на подъеме(спуске) при наличии обочины можно предотвратить самопроизвольное скатывание автомобиля на проезжую часть, повернув его передние колеса в положение:";

                    ans1.Text = "1. А и Г.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Б и В.";
                    ans3.Text = "3. А и В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Установленный факт употребления водителем вызывающих алкогольное опьянение веществ определяется наличием в его организме абсолютного этилового спирта в концентрации, превышающей:";

                    ans1.Text = "1. 0,10 миллиграмма на один литр выдыхаемого воздуха.";
                    ans2.Text = "2. 0,16 миллиграмма на один литр выдыхаемого воздуха.";
                    bt2.Tag = "1";
                    ans3.Text = "3. 0,25 миллиграмма на один литр выдыхаемого воздуха.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/6/20.jpg"));

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
