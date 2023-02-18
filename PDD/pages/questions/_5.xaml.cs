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
    public partial class _5 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;

        ResultWindow resWin = new ResultWindow();


        public _5()
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

                if (!MainWindow.globalArray.Contains(5) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(5);
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
                    MainWindow.StatisticGlobalArray[4] = 1;
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
                    bt1.Tag = "1";
                    ans2.Text = "2. Две.";
                    ans3.Text = "3. Четыре.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "При наличии какого знака водитель должен уступить дорогу, если встречный разъезд затруднен?";

                    ans1.Text = "1. Только В.";
                    ans2.Text = "2. А и В.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Б и В.";
                    ans4.Text = "4. Б и Г.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешена ли Вам стоянка в указанном месте?";

                    ans1.Text = "1. Разрешена.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешена только в светлое время суток.";
                    ans3.Text = "3. Запрещена.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Нарушил ли водитель грузового автомобиля правила стоянки?";

                    ans1.Text = "1. Нарушил.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Не нарушил, если разрешенная максимальная масса автомобиля не более 3,5 т.";
                    ans3.Text = "3. Не нарушил.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "О чем предупреждает Вас вертикальная разметка, нанесенная на ограждение дороги?";

                    ans1.Text = "1. О приближении к железнодорожному переезду.";
                    ans2.Text = "2. О приближении к опасному перекрестку.";
                    ans3.Text = "3. О движении по опасному участку дороги.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Разрешается ли водителю продолжить движение после переключения зеленого сигнала светофора на желтый, если возможно остановиться перед перекрестком, только применив экстренное торможение?";

                    ans1.Text = "1. Разрешается.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешается, если водитель намерен проехать перекресток только в прямом направлении.";
                    ans3.Text = "3. Запрещается.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Поднятая вверх рука водителя мотоцикла является сигналом, информирующим Вас о его намерении:";

                    ans1.Text = "1. Продолжить движение прямо.";
                    ans2.Text = "2. Повернуть направо.";
                    ans3.Text = "3. Снизить скорость, чтобы остановиться и уступить дорогу легковому автомобилю.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "В каких направлениях Вам можно продолжить движение по левой полосе на грузовом автомобиле с разрешенной максимальной массой не более 3,5 т?";

                    ans1.Text = "1. Только прямо.";
                    ans2.Text = "2. Прямо и направо.";
                    ans3.Text = "3. Прямо, налево и в обратном направлении.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Вам необходимо повернуть на примыкающую справа дорогу. Ваши действия?";

                    ans1.Text = "1. Не меняя полосы, снизить скорость, затем перестроиться на полосу торможения.";
                    ans2.Text = "2. Не меняя скорости, перестроиться на полосу торможения, затем снизить скорость.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Возможны оба варианта действий.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "С какой максимальной скоростью Вы имеете право продолжить движение вне населенных пунктов на легковом автомобиле с прицепом?";

                    ans1.Text = "1. 50 км/ч.";
                    ans2.Text = "2. 60 км/ч.";
                    ans3.Text = "3. 70 км/ч.";
                    bt3.Tag = "1";
                    ans4.Text = "4. 80 км/ч.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешен ли Вам обгон?";

                    ans1.Text = "1. Разрешен.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешен, если обгон будет завершен до перекрестка.";
                    ans3.Text = "3. Запрещен.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Кто из водителей нарушил правила стоянки?";

                    ans1.Text = "1. Оба.";
                    ans2.Text = "2. Только водитель автомобиля А.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только водитель автомобиля Б.";
                    ans4.Text = "4. Никто не нарушил.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "Вы намерены развернуться. Ваши действия?";

                    ans1.Text = "1. Проедете перекресток первым.";
                    ans2.Text = "2. Выполните разворот, уступив дорогу легковому автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Дождетесь, когда регулировщик опустит правую руку.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Кому Вы должны уступить дорогу при движении в прямом направлении?";

                    ans1.Text = "1. Только трамваю.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только легковому автомобилю.";
                    ans3.Text = "3. Обоим транспортным средствам.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Как Вам следует поступить при повороте налево?";

                    ans1.Text = "1. Проехать перекресток первым.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Уступить дорогу только грузовому автомобилю с включенным проблесковым маячком.";
                    ans3.Text = "3. Уступить дорогу обоим транспортным средствам.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Разрешено ли Вам проехать железнодорожный переезд?";

                    ans1.Text = "1. Разрешено, поскольку дежурный по переезду запрещает движение только встречному автомобилю.";
                    ans2.Text = "2. Разрешено, если отсутствует приближающийся поезд.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "В каких случаях разрешено применять звуковые сигналы в населенных пунктах?";

                    ans1.Text = "1. Только для предупреждения о намерении произвести обгон.";
                    ans2.Text = "2. Только для предотвращения дорожно-транспортного происшествия.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "При каком максимальном значении суммарного люфта в рулевом управлении допускается эксплуатация легкового автомобиля?";

                    ans1.Text = "1. 10 градусов.";
                    bt1.Tag = "1";
                    ans2.Text = "2. 20 градусов.";
                    ans3.Text = "3. 25 градусов.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Как следует поступить водителю при высадке из автомобиля, стоящего у тротуара или на обочине?";

                    ans1.Text = "1. Обойти автомобиль спереди.";
                    ans2.Text = "2. Обойти автомобиль сзади.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Допустимы оба варианта действий.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "При движении в условиях тумана расстояние до предметов представляется:";

                    ans1.Text = "1. Большим, чем в действительности.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Соответствующим действительности.";
                    ans3.Text = "3. Меньшим, чем в действительности.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/5/20.jpg"));

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
