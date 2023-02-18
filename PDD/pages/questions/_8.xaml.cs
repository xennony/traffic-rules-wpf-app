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
    public partial class _8 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _8()
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

                if (!MainWindow.globalArray.Contains(8) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(8);
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
                    MainWindow.StatisticGlobalArray[7] = 1;
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
                    txtQuestion.Text = "Какие действия при дорожно-транспортном происшествии должны немедленно осуществить водители, причастные к нему?";

                    ans1.Text = "1. Освободить проезжую часть.";
                    ans2.Text = "2. Остановить (не трогать с места) транспортное средство, включить аварийную сигнализацию и выставить знак аварийной остановки.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Сообщить о случившемся в полицию.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "В чем особенность скоростного режима на этом участке дороги?";

                    ans1.Text = "1. Рекомендуемая скорость движения – 40 км/ч.";
                    ans2.Text = "2. Минимальная допустимая скорость движения – 40 км/ч.";
                    ans3.Text = "3. Минимальная допустимая скорость движения по левой полосе – 40 км/ч.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Какие из указанных знаков запрещают поворот налево?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. А и Б.";
                    ans3.Text = "3. А и В.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Все.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 4:
                    txtQuestion.Text = "Можно ли Вам повернуть направо на этом перекрестке?";

                    ans1.Text = "1. Можно.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Можно, если Вы проживаете или работаете на территории, расположенной справа от перекрестка.";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Разрешается ли Вам перестроиться?";

                    ans1.Text = "1. Разрешается только на соседнюю полосу.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешается, если скорость грузового автомобиля менее 30 км/ч.";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Разрешено ли Вам движение?";

                    ans1.Text = "1. Разрешено только направо.";
                    ans2.Text = "2. Разрешено только для выполнения разворота.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Водитель легкового автомобиля должен выключить указатели левого поворота:";

                    ans1.Text = "1. После перестроения на левую полосу.";
                    bt1.Tag = "1";
                    ans2.Text = "2. После опережения грузового автомобиля.";
                    ans3.Text = "3. После возвращения на правую полосу.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "По какой траектории Вам разрешается выполнить поворот налево?";

                    ans1.Text = "1. Только по А.";
                    ans2.Text = "2. Только по Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Вы имеете право выполнить разворот:";

                    ans1.Text = "1. Только по траектории А.";
                    ans2.Text = "2. Только по траектории Б.";
                    ans3.Text = "3. По любой траектории из указанных.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Вне населенных пунктов Вам можно продолжить движение:";

                    ans1.Text = "1. По любой полосе.";
                    ans2.Text = "2. По правой или средней полосе.";
                    ans3.Text = "3. Только по правой полосе.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешено ли Вам после опережения первого автомобиля продолжить движение по левой полосе вне населенных пунктов?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если Вы намерены опередить второй автомобиль.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Нарушил ли водитель грузового автомобиля правила стоянки?";

                    ans1.Text = "1. Нарушил.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Нарушил, если разрешенная максимальная масса автомобиля более 2,5 т.";
                    ans3.Text = "3. Не нарушил.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Кто из водителей, выполняющих поворот, нарушит Правила?";

                    ans1.Text = "1. Оба.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только водитель легкового автомобиля.";
                    ans3.Text = "3. Только водитель мотоцикла.";
                    ans4.Text = "4. Никто не нарушит.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены продолжить движение в прямом направлении. Ваши действия?";

                    ans1.Text = "1. Проедете перекресток первым.";
                    ans2.Text = "2. Уступите дорогу легковому автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Уступите дорогу легковому автомобилю и мотоциклу.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы должны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только трамваям.";
                    ans2.Text = "2. Трамваю Б и легковому автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Всем транспортным средствам.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Остановка на автомагистрали разрешена:";

                    ans1.Text = "1. В любых местах за пределами проезжей части.";
                    ans2.Text = "2. Только правее линии разметки, обозначающей край проезжей части.";
                    ans3.Text = "3. Только на специальных площадках для стоянки, обозначенных соответствующими знаками.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Какие внешние световые приборы должны использоваться при движении в темное время суток на освещенных участках дорог населенного пункта?";

                    ans1.Text = "1. Только габаритные огни.";
                    ans2.Text = "2. Фары ближнего света.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Габаритные огни или фары ближнего света.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "При возникновении какой неисправности запрещается дальнейшее движение транспортного средства даже до места ремонта или стоянки?";

                    ans1.Text = "1. Неисправна рабочая тормозная система.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Неисправна система выпуска отработавших газов.";
                    ans3.Text = "3. Не работает стеклоомыватель.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Более устойчив против опрокидывания на повороте легковой автомобиль:";

                    ans1.Text = "1. Без пассажиров и груза.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Без пассажиров, но с грузом на верхнем багажнике.";
                    ans3.Text = "3. С пассажирами и грузом.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Как оказать первую помощь при отморожении и переохлаждении?";

                    ans1.Text = "1. Растереть пораженные участки тела снегом или шерстью, затем их утеплить, дать алкоголь, переместить в теплое помещение.";
                    ans2.Text = "2. Утеплить пораженные участки тела и обездвижить их, укутать пострадавшего теплой одеждой или пледом, дать теплое питье, переместить в теплое помещение.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Смазать пораженные участки тела кремом, наложить согревающий компресс и грелку, переместить в теплое помещение, дать теплое питье.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/8/20.jpg"));

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
