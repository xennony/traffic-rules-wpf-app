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
    public partial class _30 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _30()
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

                if (!MainWindow.globalArray.Contains(30) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(30);
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
                    MainWindow.StatisticGlobalArray[29] = 1;
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
                    txtQuestion.Text = "На каком рисунке изображен перекресток?";

                    ans1.Text = "1. Только на левом.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только на правом.";
                    ans3.Text = "3. На обоих.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Вам можно выполнить разворот:";

                    ans1.Text = "1. Только по траектории А.";
                    ans2.Text = "2. Только по траектории Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешено ли Вам ставить автомобиль на стоянку в этом месте по нечетным числам месяца?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено только после 19 часов.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какие из указанных знаков обозначают участки, на которых водитель обязан уступать дорогу пешеходам, находящимся на проезжей части?";

                    ans1.Text = "1. Только Б.";
                    ans2.Text = "2. Б и В.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Все.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Что обозначает разметка А 100, нанесенная на проезжую часть дороги?";

                    ans1.Text = "1. Расстояние до ближайшего перекрестка.";
                    ans2.Text = "2. Расстояние до ближайшего населенного пункта.";
                    ans3.Text = "3. Номер дороги.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Вам можно продолжить движение:";

                    ans1.Text = "1. Только прямо.";
                    ans2.Text = "2. Прямо или направо.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только направо.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Как следует действовать, выполняя поворот налево на двухполосной дороге?";

                    ans1.Text = "1. Приступить к маневру, одновременно включив указатели левого поворота.";
                    ans2.Text = "2. Включить указатели левого поворота, затем приступить к маневру.";
                    ans3.Text = "3. Убедиться в безопасности выполнения маневра, затем включить указатели левого поворота и приступить к маневру.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Вы намерены начать движение от тротуара. Должны ли Вы уступить дорогу мотоциклу, выполняющему разворот?";

                    ans1.Text = "1. Должны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Не должны, если Вы управляете легковым такси.";
                    ans3.Text = "3. Не должны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешено ли водителю легкового автомобиля движение задним ходом для посадки пассажира в тоннеле?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если при этом не будут созданы помехи другим участникам движения.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "В данной ситуации Вам разрешается движение:";

                    ans1.Text = "1. Только по правой полосе.";
                    ans2.Text = "2. По правой или средней полосе.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой полосе.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешено ли выполнить обгон в тоннеле?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено только при наличии искусственного освещения.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Можно ли водителю поставить автомобиль на стоянку указанным способом?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если при этом не будут созданы помехи для движения других транспортных средств.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "В каком случае Вы обязаны уступить дорогу грузовому автомобилю?";

                    ans1.Text = "1. При повороте налево.";
                    ans2.Text = "2. При развороте.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены продолжить движение прямо при желтом мигающем сигнале светофора. Ваши действия?";

                    ans1.Text = "1. Остановитесь и продолжите движение только после включения зеленого сигнала светофора.";
                    ans2.Text = "2. Уступите дорогу гужевой повозке.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Проедете перекресток первым вместе со встречным автомобилем.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Вы намерены повернуть налево. Кому Вы обязаны уступить дорогу?";

                    ans1.Text = "1. Легковому автомобилю и автобусу.";
                    ans2.Text = "2. Только автобусу.";
                    ans3.Text = "3. Только мотоциклу.";
                    ans4.Text = "4. Никому.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 16:
                    txtQuestion.Text = "В каком случае водитель транспортного средства, приближающегося к нерегулируемому пешеходному переходу, обязан уступить дорогу пешеходам?";

                    ans1.Text = "1. Если пешеходы переходят дорогу.";
                    ans2.Text = "2. Если пешеходы вступили на проезжую часть (трамвайные пути) для осуществления перехода.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Должны ли Вы переключить дальний свет на ближний, если водитель встречного транспортного средства периодическим переключением света фар покажет необходимость этого?";

                    ans1.Text = "1. Должны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Должны, только если расстояние до встречного транспортного средства менее 150 м.";
                    ans3.Text = "3. Не должны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Какое административное наказание может быть назначено водителю транспортного средства за оставление в нарушение Правил места дорожно-транспортного происшествия, участником которого он является?";

                    ans1.Text = "1. Только штраф в размере от 1000 до 1500 рублей.";
                    ans2.Text = "2. Штраф в размере от 1000 до 1500 рублей или лишение права управления транспортными средствами на срок от 1 года до 1,5 лет.";
                    ans3.Text = "3. Лишение права управления транспортными средствами на срок от 1 года до 1,5 лет или административный арест на срок до 15 суток.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Для предупреждения скатывания автомобиля с механической трансмиссией при кратковременной остановке на подъеме следует:";

                    ans1.Text = "1. Привести в действие стояночный тормоз.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Включить первую передачу или передачу заднего хода.";
                    ans3.Text = "3. Перевести рычаг переключения передач в нейтральное положение.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Зависит ли выбор бокового интервала от скорости движения?";

                    ans1.Text = "1. Выбор бокового интервала от скорости движения не зависит.";
                    ans2.Text = "2. При увеличении скорости движения боковой интервал необходимо увеличить.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/30/20.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

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
