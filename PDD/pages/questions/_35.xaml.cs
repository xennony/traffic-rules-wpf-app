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
    public partial class _35 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _35()
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

                if (!MainWindow.globalArray.Contains(35) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(35);
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
                    MainWindow.StatisticGlobalArray[34] = 1;
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
                    txtQuestion.Text = "Что означает термин «Недостаточная видимость»?";

                    ans1.Text = "1. Видимость дороги менее 100 м вблизи опасных поворотов и переломов продольного профиля дороги.";
                    ans2.Text = "2. Видимость дороги менее 150 м в ночное время суток.";
                    ans3.Text = "3. Видимость дороги менее 300 м в условиях тумана, дождя, снегопада и т.п., а также в сумерки.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Вы можете продолжить движение на следующем перекрестке:";

                    ans1.Text = "1. Только в направлении Б.";
                    ans2.Text = "2. В направлениях А и Б.";
                    ans3.Text = "3. В любом направлении из указанных.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Какие из указанных знаков разрешают движение со скоростью 60 км/ч?";

                    ans1.Text = "1. Только Б.";
                    ans2.Text = "2. Б и В.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Все.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Кто из водителей нарушил правила стоянки?";

                    ans1.Text = "1. Водители мотоцикла и грузового автомобиля.";
                    ans2.Text = "2. Только водитель мотоцикла.";
                    ans3.Text = "3. Только водитель грузового автомобиля.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Никто не нарушил.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 5:
                    txtQuestion.Text = "Вы можете объехать препятствие:";

                    ans1.Text = "1. Только по траектории А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только по траектории Б.";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Что означает сочетание красного и желтого сигналов светофора?";

                    ans1.Text = "1. Неисправна светофорная сигнализация.";
                    ans2.Text = "2. Вскоре будет включен зеленый сигнал.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Вскоре будет включен красный сигнал.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "На каком расстоянии от транспортного средства должен быть выставлен знак аварийной остановки в данной ситуации?";

                    ans1.Text = "1. Не менее 15 м.";
                    ans2.Text = "2. Не менее 20 м.";
                    ans3.Text = "3. Не менее 30 м.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Кому Вы должны уступить дорогу при повороте во двор?";

                    ans1.Text = "1. Только встречному автомобилю.";
                    ans2.Text = "2. Встречному автомобилю и пешеходам.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Никому.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Для обеспечения безопасности при выезде задним ходом с места стоянки, имеющего ограниченную видимость, необходимо:";

                    ans1.Text = "1. Подать звуковой сигнал.";
                    ans2.Text = "2. Включить аварийную сигнализацию.";
                    ans3.Text = "3. Прибегнуть к помощи других лиц.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "С какой максимальной скоростью Вы имеете право продолжить движение на грузовом автомобиле с разрешенной максимальной массой не более 3,5 т после въезда на примыкающую слева дорогу?";

                    ans1.Text = "1. 60 км/ч.";
                    bt1.Tag = "1";
                    ans2.Text = "2. 70 км/ч.";
                    ans3.Text = "3. 90 км/ч.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Как Вам следует поступить в данной ситуации?";

                    ans1.Text = "1. Уступить дорогу встречному автомобилю.";
                    ans2.Text = "2. Проехать первым.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Действовать по взаимной договоренности с водителем встречного автомобиля.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Водители каких автомобилей не нарушили правила остановки?";

                    ans1.Text = "1. Только автомобиля Б.";
                    ans2.Text = "2. Только автомобиля В.";
                    ans3.Text = "3. Автомобилей А и Б.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Автомобилей А и В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "Вам необходимо уступить дорогу другим участникам движения:";

                    ans1.Text = "1. Только при повороте налево или развороте.";
                    ans2.Text = "2. Только при повороте направо.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены продолжить движение прямо. Ваши действия?";

                    ans1.Text = "1. Проедете перекресток первым.";
                    ans2.Text = "2. Уступите дорогу грузовому автомобилю, так как он приближается справа.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Уступите дорогу грузовому автомобилю, так как он находится на главной дороге.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Обоим транспортным средствам.";
                    ans2.Text = "2. Автомобилю с включенными проблесковым маячком и специальным звуковым сигналом.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Никому.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "При вынужденной остановке на железнодорожном переезде, если в транспортном средстве находятся пассажиры, водитель должен:";

                    ans1.Text = "1. Немедленно высадить людей.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Высадить людей, если принятые меры не позволяют убрать транспортное средство с переезда.";
                    ans3.Text = "3. Высадить людей при появлении поезда.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "При остановке и стоянке на неосвещенных участках дорог в темное время суток необходимо:";

                    ans1.Text = "1. Включить габаритные огни.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Включить фары ближнего света.";
                    ans3.Text = "3. Выставить знак аварийной остановки.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "В каком случае разрешается эксплуатация автомобиля?";

                    ans1.Text = "1. Не работают в установленном режиме стеклоочистители.";
                    ans2.Text = "2. Не работают предусмотренные конструкцией стеклоомыватели.";
                    ans3.Text = "3. Не работает стеклоподъемник.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "По какой траектории двигается прицеп легкового автомобиля при прохождении поворота?";

                    ans1.Text = "1. Дальше от центра поворота, чем траектория движения автомобиля.";
                    ans2.Text = "2. По траектории движения автомобиля.";
                    ans3.Text = "3. Ближе к центру поворота, чем траектория движения автомобиля.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Принято считать, что среднее время реакции водителя составляет:";

                    ans1.Text = "1. Примерно 0,5 секунды.";
                    ans2.Text = "2. Примерно 1 секунду.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Примерно 2 секунды.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/35/20.jpg"));

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
