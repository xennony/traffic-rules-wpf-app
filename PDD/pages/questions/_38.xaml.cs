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
    public partial class _38 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _38()
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

                if (!MainWindow.globalArray.Contains(38) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(38);
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
                    MainWindow.StatisticGlobalArray[37] = 1;
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
                    txtQuestion.Text = "Сколько пересечений проезжих частей имеет этот перекресток?";

                    ans1.Text = "1. Одно.";
                    ans2.Text = "2. Два.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Четыре.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Данные знаки предупреждают о приближении:";

                    ans1.Text = "1. К месту производства работ на дороге.";
                    ans2.Text = "2. К железнодорожному переезду со шлагбаумом.";
                    bt2.Tag = "1";
                    ans3.Text = "3. К железнодорожному переезду без шлагбаума.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Действие каких из указанных знаков не распространяется на транспортные средства, управляемые инвалидами I и II групп, перевозящие таких инвалидов или детей-инвалидов, если на транспортных средствах установлен опознавательный знак «Инвалид»?";

                    ans1.Text = "1. А и Б.";
                    ans2.Text = "2. Б и Г.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Б, В и Г.";
                    ans4.Text = "4. Всех.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 4:
                    txtQuestion.Text = "Вы можете продолжить движение по крайней левой полосе:";

                    ans1.Text = "1. Только налево.";
                    ans2.Text = "2. Только в обратном направлении.";
                    ans3.Text = "3. Налево или в обратном направлении.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Разрешается ли Вам остановка в этом месте?";

                    ans1.Text = "1. Разрешается.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешается только с заездом на тротуар.";
                    ans3.Text = "3. Разрешается, если при этом не будут созданы помехи маршрутным транспортным средствам.";
                    ans4.Text = "4. Запрещается.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 6:
                    txtQuestion.Text = "Преимущество перед другими участниками движения имеет водитель автомобиля:";

                    ans1.Text = "1. Только с включенным проблесковым маячком синего или бело-лунного цвета.";
                    ans2.Text = "2. Только с включенным проблесковым маячком оранжевого или желтого цвета.";
                    ans3.Text = "3. Только с включенными проблесковым маячком синего (синего и красного) цвета и специальным звуковым сигналом.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Любого из перечисленных.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 7:
                    txtQuestion.Text = "Вы намерены остановиться сразу за перекрестком. В каком месте необходимо включить указатели правого поворота?";

                    ans1.Text = "1. До въезда на перекресток, чтобы заблаговременно предупредить других водителей об остановке.";
                    ans2.Text = "2. Только после въезда на перекресток.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Место включения указателей поворота не имеет значения, так как поворот направо запрещен.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "При съезде с дороги на прилегающую справа территорию Вы:";

                    ans1.Text = "1. Пользуетесь преимуществом перед другими участниками движения.";
                    ans2.Text = "2. Должны уступить дорогу только пешеходам.";
                    ans3.Text = "3. Должны уступить дорогу только велосипедисту.";
                    ans4.Text = "4. Должны уступить дорогу пешеходам и велосипедисту.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешено ли Вам выполнить разворот при движении на подъеме?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено только при видимости дороги 100 метров и более.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "С какой максимальной скоростью разрешается продолжить движение при буксировке неисправного механического транспортного средства?";

                    ans1.Text = "1. 50 км/ч.";
                    bt1.Tag = "1";
                    ans2.Text = "2. 70 км/ч.";
                    ans3.Text = "3. 90 км/ч.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Можно ли Вам начать обгон?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если обгон будет завершен до перекрестка.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Водители каких автомобилей нарушили правила остановки?";

                    ans1.Text = "1. Только автомобиля В.";
                    ans2.Text = "2. Автомобилей А и В.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Автомобилей Б и В.";
                    ans4.Text = "4. Всех перечисленных автомобилей.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "Как Вам следует поступить при повороте налево?";

                    ans1.Text = "1. Проехать перекресток первым.";
                    ans2.Text = "2. Уступить дорогу только автомобилю с включенными проблесковым маячком и специальным звуковым сигналом.";
                    ans3.Text = "3. Уступить дорогу обоим транспортным средствам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "При движении в каком направлении Вы обязаны уступить дорогу трамваю?";

                    ans1.Text = "1. Только налево.";
                    ans2.Text = "2. Только прямо.";
                    ans3.Text = "3. В обоих перечисленных.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Вы намерены повернуть направо. Можете ли Вы приступить к повороту?";

                    ans1.Text = "1. Можете.";
                    ans2.Text = "2. Можете после того, как грузовой автомобиль начнет выполнять поворот налево.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Не можете.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Подъехав к трамваю попутного направления, остановившемуся у посадочной площадки, которая расположена посередине дороги, водитель должен:";

                    ans1.Text = "1. Уступить дорогу пешеходам, идущим к трамваю или от него.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Остановиться и продолжить движение только после закрытия дверей трамвая.";
                    ans3.Text = "3. Остановиться и продолжить движение только после начала движения трамвая.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "В каких случаях запрещена перевозка детей в легковом автомобиле без использования соответствующих детских удерживающих систем(устройств):";

                    ans1.Text = "1. Если они перевозятся в возрасте младше 7 лет.";
                    ans2.Text = "2. Если они перевозятся в возрасте от 7 до 11 лет (включительно) на переднем сиденье.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Владелец транспортного средства обязан возместить вред, причиненный этим транспортным средством, если не докажет, что вред возник:";

                    ans1.Text = "1. Исключительно вследствие непреодолимой силы.";
                    ans2.Text = "2. Исключительно вследствие умысла потерпевшего.";
                    ans3.Text = "3. Вследствие непреодолимой силы или умысла потерпевшего.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "При движении ночью во время сильной метели наилучшую видимость дороги обеспечивает включение:";

                    ans1.Text = "1. Только противотуманных фар.";
                    ans2.Text = "2. Противотуманных фар совместно с ближним светом фар.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Противотуманных фар совместно с дальним светом фар.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "В каких случаях пострадавшего следует извлекать из салона автомобиля?";

                    ans1.Text = "1. При высокой вероятности опрокидывания автомобиля, пожара, взрыва или при потере потерпевшим сознания.";
                    ans2.Text = "2. При высокой вероятности опрокидывания автомобиля, пожара, взрыва, переохлаждения потерпевшего, при отсутствии у него сознания и дыхания, а также невозможности оказания первой помощи непосредственно в салоне автомобиля.";
                    bt2.Tag = "1";
                    ans3.Text = "3. При высокой вероятности опрокидывания автомобиля, пожара, взрыва или при обильном кровотечении либо черепно-мозговой травме.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/38/20.jpg"));

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
