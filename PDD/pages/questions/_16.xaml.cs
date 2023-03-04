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
    public partial class _16 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _16()
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

                if (!MainWindow.globalArray.Contains(16) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(16);
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
                    MainWindow.statisticGlobalArray[15] = 1;
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
                    txtQuestion.Text = "При наличии каких условий в случаях вынужденной остановки транспортного средства или дорожно-транспортного происшествия водитель обязан быть одетым в куртку, жилет или жилет-накидку с полосами световозвращающего материала?";

                    ans1.Text = "1. Если это произошло вне населенных пунктов.";
                    ans2.Text = "2. Если это произошло в темное время суток либо в условиях ограниченной видимости.";
                    ans3.Text = "3. Если водитель находится на проезжей части или обочине.";
                    ans4.Text = "4. При наличии всех перечисленных условий.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 2:
                    txtQuestion.Text = "В какой из дворов Вам можно въехать в данной ситуации?";

                    ans1.Text = "1. Повороты во дворы запрещены.";
                    ans2.Text = "2. Только во двор направо.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только во двор налево.";
                    ans4.Text = "4. В любой.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 3:
                    txtQuestion.Text = "Какой из указанных знаков запрещает дальнейшее движение всех без исключения транспортных средств?";

                    ans1.Text = "1. А.";
                    ans2.Text = "2. Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "О чем информируют эти знаки?";

                    ans1.Text = "1. Разрешенная скорость не более 40 км/ч при влажном покрытии.";
                    ans2.Text = "2. Рекомендуемая скорость 40 км/ч при влажном покрытии.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Рекомендуемая скорость не более 40 км/ч только во время дождя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Разрешена ли Вам остановка в этом месте?";

                    ans1.Text = "1. Разрешена.";
                    ans2.Text = "2. Разрешена без заезда на тротуар.";
                    ans3.Text = "3. Запрещена.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Как следует поступить водителю при переключении такого сигнала светофора?";

                    ans1.Text = "1. При включении красного сигнала повернуть направо, уступая дорогу другим участникам движения.";
                    ans2.Text = "2. При включении зеленого сигнала продолжить движение только направо.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Указанные действия являются правильными в обоих случаях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Аварийная сигнализация на буксируемом механическом транспортном средстве должна быть включена:";

                    ans1.Text = "1. Только в условиях недостаточной видимости.";
                    ans2.Text = "2. Только в темное время суток.";
                    ans3.Text = "3. Во всех случаях, когда осуществляется буксировка.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Обязан ли водитель автомобиля, который движется по левой полосе, уступить дорогу в данной ситуации?";

                    ans1.Text = "1. Обязан.";
                    ans2.Text = "2. Не обязан.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Можно ли Вам на перекрестке выполнить разворот, двигаясь задним ходом?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если при этом не будут созданы помехи другим участникам движения.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "С какой максимальной скоростью Вы имеете право продолжить движение вне населенных пунктов на легковом автомобиле?";

                    ans1.Text = "1. 60 км/ч.";
                    ans2.Text = "2. 90 км/ч.";
                    bt2.Tag = "1";
                    ans3.Text = "3. 110 км/ч.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешается ли Вам выполнить обгон в данной ситуации?";

                    ans1.Text = "1. Разрешается.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешается, только если скорость трактора менее 30 км/ч.";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "В каком из указанных мест Вы можете поставить автомобиль на стоянку?";

                    ans1.Text = "1. Только В.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Б или В.";
                    ans3.Text = "3. В любом.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Вы намерены проехать перекресток в прямом направлении. Кому Вы должны уступить дорогу?";

                    ans1.Text = "1. Трамваю и автомобилю.";
                    ans2.Text = "2. Только трамваю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Никому.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "При въезде на перекресток Вы:";

                    ans1.Text = "1. Должны уступить дорогу обоим транспортным средствам.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Должны уступить дорогу только автомобилю.";
                    ans3.Text = "3. Имеете преимущество перед обоими транспортными средствами.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только автобусу.";
                    ans2.Text = "2. Только легковому автомобилю.";
                    ans3.Text = "3. Обоим транспортным средствам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Разрешено ли Вам остановиться на автомагистрали правее линии, обозначающей край проезжей части?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено только в случае вынужденной остановки.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Какие из перечисленных требований являются обязательными при перевозке детей?";

                    ans1.Text = "1. Перевозка детей в возрасте до 11 лет(включительно) на переднем сиденье легкового автомобиля должна осуществляться только с использованием соответствующих детских удерживающих систем(устройств)";
                    ans2.Text = "2. Запрещается перевозка детей в возрасте младше 12 лет на заднем сиденье мотоцикла.";
                    ans3.Text = "3. Оба требования являются обязательными.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Запрещается эксплуатация легкового автомобиля, если стояночная тормозная система не обеспечивает неподвижное состояние автомобиля в снаряженном состоянии на уклоне:";

                    ans1.Text = "1. До 16% включительно.";
                    ans2.Text = "2. До 23% включительно.";
                    bt2.Tag = "1";
                    ans3.Text = "3. До 31% включительно.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "При повороте направо обеспечение безопасности движения достигается путем выполнения поворота по траектории, которая показана:";

                    ans1.Text = "1. На левом рисунке.";
                    bt1.Tag = "1";
                    ans2.Text = "2. На правом рисунке.";
                    ans3.Text = "3. На обоих рисунках.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Как определить наличие дыхания у потерявшего сознание пострадавшего?";

                    ans1.Text = "1. Взять пострадавшего за подбородок, запрокинуть голову и в течение 10 секунд проследить за движением его грудной клетки.";
                    ans2.Text = "2. Положить одну руку на лоб пострадавшего, двумя пальцами другой поднять подбородок и, запрокинув голову, наклониться к его лицу и в течение 10 секунд прислушаться к дыханию, постараться ощутить выдыхаемый воздух своей щекой, проследить за движением грудной клетки.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Не запрокидывая головы пострадавшего, наклониться к его лицу и в течение 10 секунд прислушаться к дыханию, почувствовать его своей щекой, проследить за движением его грудной клетки.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

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
