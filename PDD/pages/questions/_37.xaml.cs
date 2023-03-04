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
    public partial class _37 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _37()
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

                if (!MainWindow.globalArray.Contains(37) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(37);
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
                    MainWindow.statisticGlobalArray[36] = 1;
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
                    txtQuestion.Text = "К категории «В» относятся автомобили:";

                    ans1.Text = "1. С разрешенной максимальной массой не более 2,5 т и числом сидячих мест, помимо сидения водителя, не более 8.";
                    ans2.Text = "2. С разрешенной максимальной массой не более 3,5 т и числом сидячих мест, помимо сидения водителя, не более 8.";
                    bt2.Tag = "1";
                    ans3.Text = "3. С разрешенной максимальной массой не более 3,5 т и числом сидячих мест, помимо сидения водителя, не более 16.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Какие из указанных знаков устанавливают непосредственно перед железнодорожным переездом?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    ans3.Text = "3. Только В.";
                    bt3.Tag = "1";
                    ans4.Text = "4. А и В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 3:
                    txtQuestion.Text = "Вам разрешено выполнить разворот:";

                    ans1.Text = "1. Только по траектории А.";
                    ans2.Text = "2. Только по траектории Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Можно ли Вам поставить автомобиль на стоянку за путепроводом?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно не ближе 5 м от опоры путепровода.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Разрешается ли Вам перестроиться на полосу с реверсивным движением в данной ситуации?";

                    ans1.Text = "1. Разрешается.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешается только для поворота налево или разворота.";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Вам разрешено движение:";

                    ans1.Text = "1. Только в направлении А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. В направлениях А и Б.";
                    ans3.Text = "3. В любом направлении из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Какие указатели поворота Вы обязаны включить при выполнении разворота по такой траектории?";

                    ans1.Text = "1. Только правого поворота.";
                    ans2.Text = "2. Только левого поворота.";
                    ans3.Text = "3. Сначала правого поворота, а при движении от тротуара - левого поворота.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Ситуация, в которой водитель транспортного средства, движущегося по правой полосе, обязан уступить дорогу при перестроении, показана:";

                    ans1.Text = "1. На левом рисунке.";
                    bt1.Tag = "1";
                    ans2.Text = "2. На правом рисунке.";
                    ans3.Text = "3. На обоих рисунках.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешено ли водителю легкового автомобиля движение задним ходом для посадки пассажира?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если при этом не будут созданы помехи маршрутным транспортным средствам.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "В данной ситуации для того, чтобы продолжить движение в прямом направлении, Вы имеете право:";

                    ans1.Text = "1. Объехать грузовой автомобиль справа.";
                    ans2.Text = "2. Продолжить движение только после того, как грузовой автомобиль выполнит поворот налево.";
                    ans3.Text = "3. Выполнить любое из перечисленных действий.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Запрещается ли выполнять обгон на мостах, путепроводах, эстакадах и под ними?";

                    ans1.Text = "1. Запрещается.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Запрещается только под мостами, путепроводами и эстакадами.";
                    ans3.Text = "3. Запрещается только при наличии сплошной линии разметки.";
                    ans4.Text = "4. Разрешается.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 12:
                    txtQuestion.Text = "Можно ли Вам остановиться в тоннеле для посадки пассажира?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если Вы управляете легковым такси.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Как Вам следует поступить при повороте направо?";

                    ans1.Text = "1. Остановиться перед стоп-линией и, пропустив пешеходов, повернуть направо.";
                    ans2.Text = "2. Выехав на перекресток, остановиться перед пешеходным переходом, чтобы пропустить пешеходов.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Продолжить движение без остановки на перекрестке.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "При движении в каком направлении Вы будете иметь преимущество?";

                    ans1.Text = "1. Только при повороте направо.";
                    ans2.Text = "2. Только при повороте налево.";
                    ans3.Text = "3. В любом направлении из перечисленных.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Вы намерены продолжить движение прямо. Ваши действия?";

                    ans1.Text = "1. Проедете перекресток первым.";
                    ans2.Text = "2. Уступите дорогу трамваю.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "На каких участках автомагистрали запрещается движение задним ходом?";

                    ans1.Text = "1. Только в местах въезда или выезда с нее.";
                    ans2.Text = "2. Только в местах остановок маршрутных транспортных средств.";
                    ans3.Text = "3. На всем протяжении дороги.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Водителям мопедов запрещается поворачивать налево или разворачиваться:";

                    ans1.Text = "1. Только при движении по дороге с трамвайным движением.";
                    ans2.Text = "2. Только при движении по дороге, имеющей более одной полосы для движения в данном направлении.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "При какой неисправности запрещено дальнейшее движение на автомобиле во время дождя или снегопада?";

                    ans1.Text = "1. Не работают в установленном режиме стеклоочистители.";
                    ans2.Text = "2. Не действует стеклоочиститель со стороны водителя.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Не работают предусмотренные конструкцией транспортного средства стеклоомыватели.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "С увеличением скорости движения на повороте величина центробежной силы:";

                    ans1.Text = "1. Не изменяется.";
                    ans2.Text = "2. Увеличивается пропорционально скорости.";
                    ans3.Text = "3. Увеличивается пропорционально квадрату скорости.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Как оказывается первая помощь при переломах конечностей, если отсутствуют транспортные шины и подручные средства для их изготовления?";

                    ans1.Text = "1. Верхнюю конечность, вытянутую вдоль тела, прибинтовывают к туловищу. Нижние конечности прибинтовывают друг к другу, проложив между ними мягкую ткань.";
                    ans2.Text = "2. Верхнюю конечность, согнутую в локте, подвешивают на косынке и прибинтовывают к туловищу. Нижние конечности прибинтовывают друг к другу, обязательно проложив между ними мягкую ткань.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Верхнюю конечность, согнутую в локте, подвешивают на косынке и прибинтовывают к туловищу. Нижние конечности плотно прижимают друг к другу и прибинтовывают.";
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
