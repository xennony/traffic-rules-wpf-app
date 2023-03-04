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
    public partial class _10 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _10()
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

                if (!MainWindow.globalArray.Contains(10) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(10);
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
                    MainWindow.statisticGlobalArray[9] = 1;
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
                    txtQuestion.Text = "Главная дорога показана:";

                    ans1.Text = "1. Только на левом верхнем рисунке.";
                    ans2.Text = "2. На левом верхнем и нижнем рисунках.";
                    bt2.Tag = "1";
                    ans3.Text = "3. На всех рисунках.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Какие из указанных знаков распространяют свое действие только на период времени, когда покрытие проезжей части влажное?";

                    ans1.Text = "1. Только А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. А и Б.";
                    ans3.Text = "3. Все.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешается ли Вам поставить автомобиль на стоянку в указанном месте?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается, если Вы проживаете рядом с этим местом.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Вы управляете грузовым автомобилем с разрешенной максимальной массой не более 3,5 т. В каком направлении Вам разрешено дальнейшее движение?";

                    ans1.Text = "1. Только направо.";
                    ans2.Text = "2. Направо, налево и в обратном направлении.";
                    ans3.Text = "3. В любом.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Такой вертикальной разметкой обозначают:";

                    ans1.Text = "1. Все вертикальные элементы дорожных сооружений.";
                    ans2.Text = "2. Только вертикальные элементы дорожных сооружений, представляющие опасность для движущихся транспортных средств.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Каким транспортным средствам разрешено продолжить движение?";

                    ans1.Text = "1. Легковому автомобилю и маломестному автобусу.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только автобусу.";
                    ans3.Text = "3. Только легковому автомобилю.";
                    ans4.Text = "4. Обоим транспортным средствам движение запрещено.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 7:
                    txtQuestion.Text = "Вы намерены произвести разворот на перекрестке. Какие указатели поворота необходимо включить перед въездом на перекресток?";

                    ans1.Text = "1. Правого поворота.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Левого поворота.";
                    ans3.Text = "3. Включать указатели поворота нет необходимости.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "По какой траектории Вам разрешается выполнить поворот налево?";

                    ans1.Text = "1. Только по А.";
                    ans2.Text = "2. Только по Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Водитель легкового автомобиля в данной ситуации:";

                    ans1.Text = "1. Должен уступить дорогу, поскольку он двигается по полосе разгона.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Имеет преимущество, поскольку он двигается по полосе разгона.";
                    ans3.Text = "3. Имеет преимущество, поскольку он находится справа от грузового автомобиля.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Что должно иметь решающее значение при выборе водителем скорости движения в темное время суток?";

                    ans1.Text = "1. Предельные ограничения скорости, установленные Правилами.";
                    ans2.Text = "2. Максимальная конструктивная скорость, установленная технической характеристикой используемого транспортного средства.";
                    ans3.Text = "3. Условия видимости.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Можно ли Вам обогнать трактор?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если обгон будет завершен не ближе чем за 100 м до переезда.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Где разрешается стоянка в целях длительного отдыха или ночлега на дорогах вне населенного пункта?";

                    ans1.Text = "1. Только на хорошо просматриваемом месте на обочине.";
                    ans2.Text = "2. Только на предусмотренных для этого площадках или за пределами дороги.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В любом из перечисленных мест.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "При включении зеленого сигнала светофора Вам следует:";

                    ans1.Text = "1. Сразу начать движение.";
                    ans2.Text = "2. Начать движение, убедившись в отсутствии только пешеходов, завершающих переход проезжей части.";
                    ans3.Text = "3. Начать движение, убедившись в отсутствии пешеходов и транспортных средств, завершающих движение после смены сигнала светофора.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены проехать перекресток в прямом направлении. Кому Вы обязаны уступить дорогу?";

                    ans1.Text = "1. Только трамваю.";
                    ans2.Text = "2. Только грузовому автомобилю.";
                    ans3.Text = "3. Обоим транспортным средствам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы должны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только автобусу.";
                    ans2.Text = "2. Только легковому автомобилю.";
                    ans3.Text = "3. Никому.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Разрешен ли Вам въезд на железнодорожный переезд в данной ситуации?";

                    ans1.Text = "1. Разрешен.";
                    ans2.Text = "2. Разрешен, если отсутствует приближающийся поезд.";
                    ans3.Text = "3. Запрещен.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "При движении в условиях недостаточной видимости можно использовать противотуманные фары:";

                    ans1.Text = "1. Только отдельно от ближнего или дальнего света фар.";
                    ans2.Text = "2. Только совместно с ближним или дальним светом фар.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Как отдельно, так и совместно с ближним или дальним светом фар.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Какие из перечисленных транспортных средств разрешается эксплуатировать без медицинской аптечки?";

                    ans1.Text = "1. Автомобили.";
                    ans2.Text = "2. Автобусы.";
                    ans3.Text = "3. Все мотоциклы.";
                    ans4.Text = "4. Только мотоциклы без бокового прицепа.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 19:
                    txtQuestion.Text = "При приближении к вершине подъема в темное время суток водителю следует:";

                    ans1.Text = "1. Не переключать дальний свет фар на ближний.";
                    ans2.Text = "2. Переключать дальний свет фар на ближний только при появлении встречного транспортного средства.";
                    ans3.Text = "3. Всегда переключать дальний свет фар на ближний.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Какова первая помощь при черепно-мозговой травме, сопровождающейся ранением волосистой части головы?";

                    ans1.Text = "1. Остановить кровотечение прямым давлением на рану и наложить давящую повязку. При потере сознания придать устойчивое боковое положение. По возможности, приложить к голове холод.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Фиксировать шейный отдел позвоночника с помощью импровизированной шейной шины(воротника). На рану наложить стерильный ватный тампон, пострадавшего уложить на спину, приподняв ноги. По возможности, к голове приложить холод.";
                    ans3.Text = "3. Шейную шину не накладывать, рану заклеить медицинским пластырем, пострадавшего уложить на бок.";
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
