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
    public partial class _21 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _21()
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

                if (!MainWindow.globalArray.Contains(21) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(21);
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
                    MainWindow.statisticGlobalArray[20] = 1;
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
                    txtQuestion.Text = "Разрешается ли водителю пользоваться телефоном во время движения?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только при использовании технического устройства, позволяющего вести переговоры без использования рук.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Разрешается только при движении со скоростью менее 20 км/ч.";
                    ans4.Text = "4. Запрещается.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 2:
                    txtQuestion.Text = "Этот знак предупреждает о приближении к перекрестку, на котором Вы:";

                    ans1.Text = "1. Имеете право преимущественного проезда.";
                    ans2.Text = "2. Должны уступить дорогу всем транспортным средствам, движущимся по пересекаемой дороге.";
                    ans3.Text = "3. Должны уступить дорогу только транспортным средствам, приближающимся справа.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Продолжить буксировку можно:";

                    ans1.Text = "1. Только в направлении А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только в направлении Б.";
                    ans3.Text = "3. В любом направлении из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какой из указанных знаков информирует о начале дороги с реверсивным движением?";

                    ans1.Text = "1. А.";
                    ans2.Text = "2. Б.";
                    ans3.Text = "3. В.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Данная вертикальная разметка:";

                    ans1.Text = "1. Запрещает стоянку транспортных средств.";
                    ans2.Text = "2. Запрещает остановку транспортных средств.";
                    ans3.Text = "3. Обозначает бордюры на опасных участках дорог.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Разрешено ли Вам за перекрестком выехать на полосу с реверсивным движением?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если Вы управляете легковым такси.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Такой сигнал рукой, подаваемый водителем легкового автомобиля, информирует Вас:";

                    ans1.Text = "1. О его намерении повернуть налево или выполнить разворот.";
                    bt1.Tag = "1";
                    ans2.Text = "2. О его намерении остановиться и уступить дорогу грузовому автомобилю.";
                    ans3.Text = "3. О приближающемся слева транспортном средстве.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "При повороте налево для въезда во двор Вы обязаны уступить дорогу:";

                    ans1.Text = "1. Только велосипедисту.";
                    ans2.Text = "2. Только пешеходам.";
                    ans3.Text = "3. Пешеходам и велосипедисту.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Движение транспортных средств задним ходом разрешается:";

                    ans1.Text = "1. На перекрестках.";
                    ans2.Text = "2. На дорогах с односторонним движением.";
                    bt2.Tag = "1";
                    ans3.Text = "3. На пешеходных переходах.";
                    ans4.Text = "4. В местах остановок маршрутных транспортных средств.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 10:
                    txtQuestion.Text = "Разрешается ли Вам, управляя легковым автомобилем, продолжить движение по трамвайным путям попутного направления?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только для поворота налево и разворота.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Вы можете начать обгон:";

                    ans1.Text = "1. На переезде.";
                    ans2.Text = "2. Непосредственно после переезда.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Через 100 м после переезда.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "В каком месте Вам следует поставить автомобиль на стоянку с правой стороны дороги?";

                    ans1.Text = "1. Непосредственно перед пересечением проезжих частей.";
                    ans2.Text = "2. Непосредственно после пересечения проезжих частей.";
                    ans3.Text = "3. Не ближе 5 м от края пересекаемой проезжей части.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Кому Вы должны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только мотоциклу.";
                    ans2.Text = "2. Только автомобилю с включенными проблесковым маячком и специальным звуковым сигналом.";
                    ans3.Text = "3. Обоим транспортным средствам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены повернуть налево. Ваши действия?";

                    ans1.Text = "1. Проедете перекресток первым.";
                    ans2.Text = "2. Проедете перекресток одновременно со встречным автомобилем до проезда мотоцикла.";
                    ans3.Text = "3. Проедете перекресток последним.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Как Вам следует поступить при движении в прямом направлении?";

                    ans1.Text = "1. Уступить дорогу грузовому автомобилю, выезжающему с грунтовой дороги.";
                    ans2.Text = "2. Проехать перекресток первым.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "При выезде из жилой зоны необходимо уступить дорогу:";

                    ans1.Text = "1. Только транспортным средствам с включенным проблесковым маячком.";
                    ans2.Text = "2. Только транспортным средствам, приближающимся слева.";
                    ans3.Text = "3. Только транспортным средствам, приближающимся справа.";
                    ans4.Text = "4. Всем транспортным средствам.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 17:
                    txtQuestion.Text = "В зоне действия каких знаков Правила разрешают подачу звуковых сигналов только для предотвращения дорожно-транспортного происшествия?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    ans3.Text = "3. А и Б.";
                    bt3.Tag = "1";
                    ans4.Text = "4. А и В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 18:
                    txtQuestion.Text = "Какие административные наказания предусмотрены за управление транспортным средством, если обязательное страхование гражданской ответственности владельца этого транспортного средства заведомо отсутствует?";

                    ans1.Text = "1. Предупреждение или штраф в размере 500 рублей.";
                    ans2.Text = "2. Штраф в размере 800 рублей.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Штраф в размере 1000 рублей или лишение права управления транспортными средствами на срок от 1 до 3 месяцев.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "В месте выезда из лесистого участка, где установлен знак «Боковой ветер», Вам следует:";

                    ans1.Text = "1. Уменьшить скорость и быть готовым к возможному отклонению автомобиля от заданного курса.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Не изменяя скорости, сместиться ближе к центру дороги.";
                    ans3.Text = "3. Не изменяя скорости, сместиться ближе к обочине.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Каковы признаки кровотечения из крупной артерии и с чего начинается первая помощь при ее ранении?";

                    ans1.Text = "1. Кровь темного цвета вытекает из раны медленно. На рану накладывается давящая повязка, с указанием в записке времени наложения повязки.";
                    ans2.Text = "2. Кровь ярко-алого цвета вытекает из раны пульсирующей или фонтанирующей струей. Артерия прижимается пальцами, затем в точках прижатия выше раны, максимально близко к ней, накладывается кровоостанавливающий жгут с указанием в записке времени наложения жгута";
                    bt2.Tag = "1";
                    ans3.Text = "3. Кровь вытекает из раны медленно. Накладывается кровоостанавливающий жгут ниже места ранения, с указанием в записке времени наложения жгута.";
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
