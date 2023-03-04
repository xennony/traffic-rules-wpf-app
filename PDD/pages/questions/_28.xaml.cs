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
    public partial class _28 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _28()
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

                if (!MainWindow.globalArray.Contains(28) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(28);
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
                    MainWindow.statisticGlobalArray[27] = 1;
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
                    txtQuestion.Text = "Обязан ли водитель предоставлять транспортное средство медицинским и фармацевтическим работникам для перевозки граждан в ближайшее лечебно-профилактическое учреждение в случаях, угрожающих их жизни?";

                    ans1.Text = "1. Обязан.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Обязан только при движении в попутном направлении.";
                    ans3.Text = "3. Не обязан.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Вам можно продолжить движение:";

                    ans1.Text = "1. Только по траектории А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только по траектории Б.";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "С какой максимальной скоростью Вы имеете право продолжить движение на грузовом автомобиле с разрешенной максимальной массой не более 3,5 т?";

                    ans1.Text = "1. 60 км/ч.";
                    ans2.Text = "2. 70 км/ч.";
                    ans3.Text = "3. 80 км/ч.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какие из указанных знаков используются для обозначения номера, присвоенного дороге (маршруту)?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    ans3.Text = "3. А и Б.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Все.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 5:
                    txtQuestion.Text = "Движение по предназначенной для велосипедистов полосе проезжей части, которая обозначена данной разметкой, разрешается:";

                    ans1.Text = "1. Только мопедам.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только мотоциклам с рабочим объемом двигателя внутреннего сгорания, не превышающим 125 см3, и максимальной мощностью, не превышающей 11 квт.";
                    ans3.Text = "3. Всем перечисленным транспортным средствам.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Вы имеете право двигаться:";

                    ans1.Text = "1. Только прямо.";
                    ans2.Text = "2. Только направо.";
                    ans3.Text = "3. Прямо или направо.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Как необходимо обозначить свое транспортное средство при дорожно-транспортном происшествии?";

                    ans1.Text = "1. Только с помощью аварийной сигнализации.";
                    ans2.Text = "2. Только с помощью знака аварийной остановки.";
                    ans3.Text = "3. Обоими перечисленными способами.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Кто имеет преимущество в движении?";

                    ans1.Text = "1. Водитель легкового автомобиля.";
                    ans2.Text = "2. Водитель грузового автомобиля.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешено ли водителю движение задним ходом для посадки пассажира на этом участке дороги?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено, если водитель управляет легковым такси.";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Разрешается ли Вам, управляя грузовым автомобилем с разрешенной максимальной массой более 2,5 т, выехать на третью полосу в данной ситуации?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только для поворота налево или разворота.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Разрешается только для опережения.";
                    ans4.Text = "4. Запрещается.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 11:
                    txtQuestion.Text = "Можно ли Вам обогнать трактор, управляя грузовым автомобилем с разрешенной максимальной массой не более 3,5 т?";

                    ans1.Text = "1. Можно.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Можно, если скорость трактора менее 30 км/ч.";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "В каком месте и направлении Вам разрешено остановиться?";

                    ans1.Text = "1. Только В.";
                    ans2.Text = "2. Б и В.";
                    ans3.Text = "3. В любом из указанных.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только автомобилю.";
                    ans2.Text = "2. Только трамваю.";
                    ans3.Text = "3. Автомобилю и трамваю.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Никому.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 14:
                    txtQuestion.Text = "Вы должны уступить дорогу грузовому автомобилю:";

                    ans1.Text = "1. Только при движении прямо.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только при повороте направо.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Вы намерены развернуться. Кому Вам необходимо уступить дорогу?";

                    ans1.Text = "1. Только грузовому автомобилю.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только легковому автомобилю.";
                    ans3.Text = "3. Обоим транспортным средствам.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Где Вам разрешается остановиться при движении по автомагистрали?";

                    ans1.Text = "1. Только через 500 м.";
                    bt1.Tag = "1";
                    ans2.Text = "2. В любом месте правее линии, обозначающей край проезжей части.";
                    ans3.Text = "3. В любом месте у края проезжей части.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Двигаясь в темное время суток вне населенного пункта с включенными фарами дальнего света, Вы догнали движущееся впереди транспортное средство. Ваши действия?";

                    ans1.Text = "1. Оставите включенными габаритные огни, выключив фары дальнего света.";
                    ans2.Text = "2. Переключите дальний свет фар на ближний.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Допускаются оба варианта действий.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Как обязан поступить водитель, если во время движения отказал в работе спидометр?";

                    ans1.Text = "1. Продолжить намеченную поездку с особой осторожностью.";
                    ans2.Text = "2. Попытаться устранить неисправность на месте, а если это невозможно, то следовать к месту стоянки или ремонта с соблюдением необходимых мер предосторожности.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Прекратить дальнейшее движение.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Что следует предпринять, если на повороте возник занос задней оси заднеприводного автомобиля?";

                    ans1.Text = "1. Увеличить подачу топлива, рулевым колесом стабилизировать движение.";
                    ans2.Text = "2. Притормозить и повернуть рулевое колесо в сторону заноса.";
                    ans3.Text = "3. Значительно уменьшить подачу топлива, не меняя положения рулевого колеса.";
                    ans4.Text = "4. Слегка уменьшить подачу топлива и повернуть рулевое колесо в сторону заноса.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 20:
                    txtQuestion.Text = "В каком случае водителю необходимо оценивать обстановку сзади?";

                    ans1.Text = "1. Перед началом или возобновлением движения.";
                    ans2.Text = "2. Перед торможением.";
                    ans3.Text = "3. Перед осуществлением маневра (перестроения или изменения направления движения).";
                    ans4.Text = "4. Во всех перечисленных случаях.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

            }
            {
            if (MainWindow.godMode)
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
