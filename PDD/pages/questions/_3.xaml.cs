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
    public partial class _3 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;

        ResultWindow resWin = new ResultWindow();


        public _3()
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

                if (!MainWindow.globalArray.Contains(3) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(3);
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
                    MainWindow.StatisticGlobalArray[2] = 1;
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
                    txtQuestion.Text = "Выезжая с грунтовой дороги на перекресток, Вы попадаете:";

                    ans1.Text = "1. На главную дорогу.";
                    bt1.Tag = "1";
                    ans2.Text = "2. На равнозначную дорогу, поскольку отсутствуют знаки приоритета.";
                    ans3.Text = "3. На равнозначную дорогу, поскольку проезжая часть имеет твердое покрытие перед перекрестком.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Где Вы должны остановиться?";

                    ans1.Text = "1. Перед знаком (А).";
                    ans2.Text = "2. Перед перекрестком (Б).";
                    ans3.Text = "3. Перед краем пересекаемой проезжей части (В).";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Вам необходимо двигаться со скоростью не более 40 км/ч:";

                    ans1.Text = "1. Только во время дождя.";
                    ans2.Text = "2. Во время выпадения осадков (дождя, града, снега).";
                    ans3.Text = "3. Во всех случаях, когда покрытие проезжей части влажное.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какой из указанных знаков устанавливается в начале дороги с односторонним движением?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Б или Г.";
                    ans4.Text = "4. Б или В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 5:
                    txtQuestion.Text = "Можно ли Вам остановиться в этом месте для посадки или высадки пассажиров?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если при этом не будут созданы помехи движению маршрутных транспортных средств.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "При повороте направо Вы:";

                    ans1.Text = "1. Имеете право проехать перекресток первым.";
                    ans2.Text = "2. Должны уступить дорогу только пешеходам.";
                    ans3.Text = "3. Должны уступить дорогу автомобилю с включенными проблесковым маячком и специальным звуковым сигналом, а также пешеходам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "В каких случаях водитель не должен подавать сигнал указателями поворота?";

                    ans1.Text = "1. Только при отсутствии на дороге других участников движения.";
                    ans2.Text = "2. Только если сигнал может ввести в заблуждение других участников движения.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Вам разрешено выполнить поворот направо:";

                    ans1.Text = "1. Только по траектории А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только по траектории Б.";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешается ли Вам выполнить разворот на перекрестке по указанной траектории?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается, если видимость дороги не менее 100 м.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "По какой полосе Вы имеете право двигаться с максимально разрешенной скоростью вне населенных пунктов?";

                    ans1.Text = "1. Только по правой.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только по левой.";
                    ans3.Text = "3. По любой.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "В каком случае водитель может начать обгон, если такой маневр на данном участке дороги не запрещен?";

                    ans1.Text = "1. Только если полоса, предназначенная для встречного движения, свободна на достаточном для обгона расстоянии.";
                    ans2.Text = "1. Только если полоса, предназначенная для встречного движения, свободна на достаточном для обгона расстоянии.";
                    ans3.Text = "2. Только если его транспортное средство никто не обгоняет.";
                    ans4.Text = "3. В случае, если выполнены оба условия.";

                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 12:
                    txtQuestion.Text = "Кто из водителей нарушил правила стоянки?";

                    ans1.Text = "1. Оба.";
                    ans2.Text = "2. Только водитель автомобиля.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только водитель мотоцикла.";
                    ans4.Text = "4. Никто не нарушил.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "При движении прямо Вы:";

                    ans1.Text = "1. Должны остановиться перед стоп-линией.";
                    ans2.Text = "2. Можете продолжить движение через перекресток без остановки.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Должны уступить дорогу транспортным средствам, движущимся с других направлений.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены повернуть направо. Ваши действия?";

                    ans1.Text = "1. Проедете перекресток первым.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Уступите дорогу легковому автомобилю.";
                    ans3.Text = "3. Уступите дорогу обоим транспортным средствам.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Трамваям А и Б.";
                    ans2.Text = "2. Трамваю А и легковому автомобилю.";
                    ans3.Text = "3. Только трамваю А.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Никому.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 16:
                    txtQuestion.Text = "Кто из водителей нарушил правила остановки?";

                    ans1.Text = "1. Только водитель легкового автомобиля.";
                    ans2.Text = "2. Только водитель грузового автомобиля.";
                    ans3.Text = "3. Оба.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Какое оборудование должно иметь механическое транспортное средство, используемое для обучения вождению?";

                    ans1.Text = "1. Дополнительные педали привода сцепления (кроме транспортных средств с автоматической трансмиссией) и тормоза.";
                    ans2.Text = "2. Зеркало заднего вида для обучающего вождению.";
                    ans3.Text = "3. Опознавательные знаки «Учебное транспортное средство».";
                    ans4.Text = "4. Все перечисленное оборудование.";
                    bt4.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 18:
                    txtQuestion.Text = "Какие из перечисленных транспортных средств разрешается эксплуатировать без огнетушителя?";

                    ans1.Text = "1. Только мотоциклы без бокового прицепа.";
                    ans2.Text = "2. Любые мотоциклы.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Все мотоциклы и легковые автомобили.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "На повороте возник занос задней оси переднеприводного автомобиля. Ваши действия?";

                    ans1.Text = "1. Уменьшите подачу топлива, рулевым колесом стабилизируете движение.";
                    ans2.Text = "2. Притормозите и повернете рулевое колесо в сторону заноса.";
                    ans3.Text = "3. Слегка увеличите подачу топлива, корректируя направление движения рулевым колесом.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Значительно увеличите подачу топлива, не меняя положения рулевого колеса.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 20:
                    txtQuestion.Text = "Какие сведения необходимо сообщить диспетчеру для вызова скорой медицинской помощи при дорожно-транспортном происшествии (ДТП)?";

                    ans1.Text = "1. Указать общеизвестные ориентиры, ближайшие к месту ДТП. Сообщить о количестве пострадавших, указать их пол и возраст.";
                    ans2.Text = "2. Указать улицу и номер дома, ближайшего к месту ДТП. Сообщить, кто пострадал в ДТП (пешеход, водитель автомобиля или пассажиры), и описать травмы, которые они получили.";
                    ans3.FontSize = 10;
                    ans3.Text = "3. Указать место ДТП (назвать улицу, номер дома и общеизвестные ориентиры, ближайшие к месту ДТП). Сообщить: количество пострадавших, их пол, примерный возраст, наличие у них сознания, дыхания, кровообращения, а также сильного кровотечения, переломов и других травм. Дождаться сообщения диспетчера о том, что вызов принят.";

                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/3/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

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
