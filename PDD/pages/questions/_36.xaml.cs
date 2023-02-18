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
    public partial class _36 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _36()
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

                if (!MainWindow.globalArray.Contains(36) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(36);
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
                    MainWindow.StatisticGlobalArray[35] = 1;
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
                    txtQuestion.Text = "Главной на перекрестке является:";

                    ans1.Text = "1. Дорога с твердым покрытием по отношению к грунтовой дороге.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Дорога с асфальтобетонным покрытием по отношению к дороге, покрытой брусчаткой.";
                    ans3.Text = "3. Дорога с тремя или более полосами движения по отношению к дороге с двумя полосами.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Разрешается ли Вам въехать на мост одновременно с водителем мотоцикла?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается, если Вы не затрудните ему движение.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Водители каких автомобилей нарушили правила стоянки?";

                    ans1.Text = "1. Только автомобиля А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только автомобиля Б.";
                    ans3.Text = "3. Автомобилей А и Б.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какие из указанных табличек распространяют действие установленных с ними знаков на грузовые автомобили с разрешенной максимальной массой не более 3,5 т?";

                    ans1.Text = "1. Только Б.";
                    ans2.Text = "2. Только В.";
                    ans3.Text = "3. Б и В.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Все.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 5:
                    txtQuestion.Text = "Правая полоса предназначена для движения:";

                    ans1.Text = "1. Любых автобусов.";
                    ans2.Text = "2. Всех автобусов и троллейбусов.";
                    ans3.Text = "3. Автобусов и троллейбусов, движущихся по установленным маршрутам с обозначенными местами остановок, а также школьных автобусов и легковых такси.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Как следует поступить водителю легкового автомобиля при приближении автомобиля оперативной службы?";

                    ans1.Text = "1. Продолжить движение по левой полосе.";
                    ans2.Text = "2. Перестроиться на правую полосу.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Остановиться справа у тротуара.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Согнутая в локте рука водителя автомобиля является сигналом, информирующим Вас о его намерении:";

                    ans1.Text = "1. Повернуть направо.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Продолжить движение прямо.";
                    ans3.Text = "3. Остановиться, чтобы уступить дорогу мотоциклу.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Вам можно продолжить движение при повороте налево:";

                    ans1.Text = "1. Только по траектории А.";
                    ans2.Text = "2. Только по траектории В.";
                    ans3.Text = "3. По любой траектории из указанных.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Если траектории движения транспортных средств пересекаются, а очередность проезда не оговорена Правилами, следует:";

                    ans1.Text = "1. Уступить дорогу транспортному средству, приближающемуся справа.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Уступить дорогу транспортному средству, приближающемуся слева.";
                    ans3.Text = "3. Действовать по взаимной договоренности водителей.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "В каких случаях на дорогах, проезжая часть которых разделена линиями разметки, водители обязаны двигаться строго по полосам?";

                    ans1.Text = "1. Только при интенсивном движении.";
                    ans2.Text = "2. Только если полосы движения обозначены сплошными линиями разметки.";
                    ans3.Text = "3. Во всех случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Водитель обгоняемого транспортного средства:";

                    ans1.Text = "1. Обязан снизить скорость движения.";
                    ans2.Text = "2. Обязан не повышать скорость движения.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Имеет право действовать по своему усмотрению.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Разрешена ли Вам остановка для высадки пассажиров в указанном месте?";

                    ans1.Text = "1. Разрешена.";
                    ans2.Text = "2. Разрешена, если при этом не будут созданы помехи для движения маpшрутных транспортных средств.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещена.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Вы намерены повернуть направо. Ваши действия?";

                    ans1.Text = "1. Дождетесь другого сигнала регулировщика.";
                    ans2.Text = "2. Уступите дорогу легковому автомобилю, осуществляющему разворот.";
                    ans3.Text = "3. Проедете перекресток первым.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "В каких случаях Вы должны уступить дорогу трамваю?";

                    ans1.Text = "1. При повороте налево.";
                    ans2.Text = "2. При движении прямо.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Как Вам следует поступить при повороте налево?";

                    ans1.Text = "1. Уступить дорогу обоим транспортным средствам.";
                    ans2.Text = "2. Уступить дорогу только грузовому автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Проехать перекресток первым.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Вы обязаны уступить дорогу грузовому автомобилю:";

                    ans1.Text = "1. Только при повороте направо.";
                    ans2.Text = "2. Только при повороте налево.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "В каких случаях необходимо включать фары ближнего света или дневные ходовые огни в светлое время суток?";

                    ans1.Text = "1. Только при движении вне населенного пункта.";
                    ans2.Text = "2. Только при движении в населенном пункте.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Административная ответственность установлена за нарушение Правил дорожного движения или правил эксплуатации транспортного средства, повлекшее причинение:";

                    ans1.Text = "1. Легкого вреда здоровью человека либо незначительного материального ущерба.";
                    ans2.Text = "2. Легкого или средней тяжести вреда здоровью человека.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Легкого или средней тяжести вреда здоровью человека либо материального ущерба.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Как правильно произвести экстренное торможение на скользкой дороге, если автомобиль не оборудован антиблокировочной тормозной системой?";

                    ans1.Text = "1. Нажать на педаль тормоза до упора и удерживать ее до полной остановки.";
                    ans2.Text = "2. Нажать на педаль тормоза с одновременным использованием стояночного тормоза.";
                    ans3.Text = "3. Тормозить прерывистым нажатием на педаль тормоза, не допуская блокировки колес.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Как воспринимается водителем скорость своего автомобиля при длительном движении по равнинной дороге на большой скорости?";

                    ans1.Text = "1. Кажется меньше, чем в действительности.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Восприятие скорости не меняется.";
                    ans3.Text = "3. Кажется больше, чем в действительности.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/36/20.jpg"));

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
