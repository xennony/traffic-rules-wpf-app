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
    public partial class _26 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _26()
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

                if (!MainWindow.globalArray.Contains(26) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(26);
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
                    MainWindow.statisticGlobalArray[25] = 1;
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
                    txtQuestion.Text = "Выезд из двора или c другой прилегающей территории:";

                    ans1.Text = "1. Считается перекрестком равнозначных дорог.";
                    ans2.Text = "2. Считается перекрестком неравнозначных дорог.";
                    ans3.Text = "3. Не считается перекрестком.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Какие из указанных знаков требуют обязательной остановки?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Б и В.";
                    ans4.Text = "4. Все.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 3:
                    txtQuestion.Text = "В зоне действия этого знака разрешается использовать звуковой сигнал:";

                    ans1.Text = "1. Только для предупреждения об обгоне.";
                    ans2.Text = "2. Только для предотвращения дорожно-транспортного происшествия.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Где начинают действовать требования Правил, относящиеся к населенным пунктам?";

                    ans1.Text = "1. Только с места установки дорожного знака «Начало населенного пункта» на белом фоне.";
                    bt1.Tag = "1";
                    ans2.Text = "2. С места установки дорожного знака с названием населенного пункта на белом или синем фоне.";
                    ans3.Text = "3. В начале застроенной территории, непосредственно прилегающей к дороге.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Такой вертикальной разметкой обозначают боковые поверхности ограждений:";

                    ans1.Text = "1. Только на опасных участках дорог.";
                    ans2.Text = "2. Только на участках дорог, не относящихся к опасным.";
                    bt2.Tag = "1";
                    ans3.Text = "3. На всех участках дорог.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Что означают красный мигающий сигнал или два попеременно мигающих красных сигнала светофора, установленного на железнодорожном переезде?";

                    ans1.Text = "1. Движение разрешается с особой осторожностью.";
                    ans2.Text = "2. Движение запрещено.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Светофорная сигнализация неисправна.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Какие световые сигналы Вы обязаны подать в данной ситуации?";

                    ans1.Text = "1. Включить световые указатели поворота налево.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Осуществить кратковременное переключение фар с ближнего на дальний свет.";
                    ans3.Text = "3. Подать перечисленные световые сигналы одновременно.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "В каких направлениях Вам можно продолжить движение по второй полосе?";

                    ans1.Text = "1. Только налево.";
                    ans2.Text = "2. Налево и в обратном направлении.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Направо, налево и в обратном направлении.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешен ли Вам разворот в этом месте?";

                    ans1.Text = "1. Разрешен.";
                    ans2.Text = "2. Разрешен, если при этом не будут созданы помехи движению маршрутных транспортных средств.";
                    ans3.Text = "3. Запрещен.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "По какой траектории Вы имеете право продолжить движение?";

                    ans1.Text = "1. Только по А.";
                    ans2.Text = "2. Только по Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешается ли обгон на перекрестках?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только на регулируемых перекрестках.";
                    ans3.Text = "3. Разрешается только при движении по главной дороге на нерегулируемых перекрестках.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Запрещается.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 12:
                    txtQuestion.Text = "Водители каких автомобилей нарушили правила остановки?";

                    ans1.Text = "1. Только автомобиля Б.";
                    ans2.Text = "2. Автомобилей Б и В.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Всех автомобилей.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Вы намерены повернуть налево. Ваши действия?";

                    ans1.Text = "1. Выполните маневр без остановки на перекрестке.";
                    ans2.Text = "2. Выехав на перекресток, остановитесь у стоп-линии и, дождавшись зеленого сигнала светофора на разделительной полосе, завершите маневр.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Кому Вы должны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только легковому автомобилю.";
                    ans2.Text = "2. Только грузовому автомобилю.";
                    ans3.Text = "3. Обоим транспортным средствам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "При движении прямо Вы обязаны уступить дорогу:";

                    ans1.Text = "1. Только легковому автомобилю.";
                    ans2.Text = "2. Автобусу и легковому автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Всем транспортным средствам.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Где необходимо остановиться, если сразу за пешеходным переходом образовался затор?";

                    ans1.Text = "1. На пешеходном переходе, если нет пешеходов.";
                    ans2.Text = "2. Непосредственно перед пешеходным переходом.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Не ближе 5 м до пешеходного перехода.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "На каком рисунке изображен автомобиль, водитель которого нарушает правила перевозки грузов?";

                    ans1.Text = "1. Только на А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только на Б.";
                    ans3.Text = "3. На обоих.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "В каком случае запрещается эксплуатация транспортных средств?";

                    ans1.Text = "1. Двигатель не развивает максимальной мощности.";
                    ans2.Text = "2. Двигатель неустойчиво работает на холостых оборотах.";
                    ans3.Text = "3. Имеется неисправность в системе выпуска отработавших газов.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Уменьшение тормозного пути транспортного средства, не оборудованного антиблокировочной тормозной системой, достигается:";

                    ans1.Text = "1. Путем нажатия на педаль тормоза до упора.";
                    ans2.Text = "2. Путем прерывистого нажатия на педаль тормоза.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Путем нажатия на педаль тормоза с одновременным использованием стояночной тормозной системы.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Минимальной величиной необходимой дистанции при движении по сухой дороге на легковом автомобиле принято считать расстояние, которое автомобиль проедет не менее чем за:";

                    ans1.Text = "1. 1 секунду.";
                    ans2.Text = "2. 2 секунды.";
                    bt2.Tag = "1";
                    ans3.Text = "3. 3 секунды.";
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
