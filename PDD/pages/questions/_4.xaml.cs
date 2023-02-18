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
    public partial class _4 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;

        ResultWindow resWin = new ResultWindow();

        public _4()
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

                if (!MainWindow.globalArray.Contains(4) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(4);
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
                    MainWindow.StatisticGlobalArray[3] = 1;
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
                    txtQuestion.Text = "Сколько полос для движения имеет проезжая часть данной дороги?";

                    ans1.Text = "1. Одну полосу.";
                    ans2.Text = "2. Две полосы.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Три полосы.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Эти знаки предупреждают Вас:";

                    ans1.Text = "1. О наличии через 500 м опасных поворотов.";
                    ans2.Text = "2. О том, что на расстоянии 150-300 м за дорожным знаком начнется участок дороги протяженностью 500 м с опасными поворотами.";
                    bt2.Tag = "1";
                    ans3.Text = "3. О том, что сразу за знаком начнется участок протяженностью 500 м с опасными поворотами.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Какой из указанных знаков распространяет свое действие только на ту полосу, над которой он установлен?";

                    ans1.Text = "1. Только А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только Б.";
                    ans3.Text = "3. Б и В.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Вы буксируете неисправный автомобиль. По какой полосе Вам можно продолжить движение в населенном пункте?";

                    ans1.Text = "1. Только по правой.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только по левой.";
                    ans3.Text = "3. По любой.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Что означает разметка в виде надписи «СТОП» на проезжей части?";

                    ans1.Text = "1. Предупреждает о приближении к стоп-линии перед регулируемым перекрестком.";
                    ans2.Text = "2. Предупреждает о приближении к стоп-линии и знаку «Движение без остановки запрещено».";
                    bt2.Tag = "1";
                    ans3.Text = "3. Предупреждает о приближении к знаку «Уступите дорогу».";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Каким транспортным средствам разрешено движение прямо?";

                    ans1.Text = "1. Только грузовому автомобилю.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Легковому и грузовому автомобилям.";
                    ans3.Text = "3. Грузовому автомобилю и автобусу.";
                    ans4.Text = "4. Всем перечисленным транспортным средствам.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 7:
                    txtQuestion.Text = "Вы намерены продолжить движение по главной дороге. Обязаны ли Вы при этом включить указатели правого поворота?";

                    ans1.Text = "1. Обязаны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Обязаны только при наличии движущегося сзади транспортного средства.";
                    ans3.Text = "3. Не обязаны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Кто должен уступить дорогу?";

                    ans1.Text = "1. Водитель грузового автомобиля.";
                    ans2.Text = "2. Водитель легкового автомобиля.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Вам можно выполнить разворот:";

                    ans1.Text = "1. Только по траектории А.";
                    ans2.Text = "2. Только по траектории Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "По какой полосе проезжей части разрешено движение в населенном пункте, если по техническим причинам транспортное средство не может развивать скорость более 40 км/ч?";

                    ans1.Text = "1. Только по крайней правой.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Не далее второй полосы.";
                    ans3.Text = "3. По любой, кроме крайней левой.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешено ли Вам обогнать мотоцикл?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено только после проезда перекрестка.";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Разрешается ли Вам остановка для посадки пассажира в этом месте?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается, если при этом не будут созданы помехи для движения маршрутных транспортных средств.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Вы намерены проехать перекресток в прямом направлении. Ваши действия?";

                    ans1.Text = "1. Проедете перекресток первым.";
                    ans2.Text = "2. Уступите дорогу только встречному автомобилю.";
                    ans3.Text = "3. Уступите дорогу только автомобилю с включенными проблесковым маячком и специальным звуковым сигналом.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Уступите дорогу обоим транспортным средствам.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 14:
                    txtQuestion.Text = "Кому Вы должны уступить дорогу при повороте направо?";

                    ans1.Text = "1. Только пешеходу, переходящему проезжую часть по нерегулируемому пешеходному переходу.";
                    ans2.Text = "2. Только пешеходам, переходящим проезжую часть, на которую Вы поворачиваете.";
                    ans3.Text = "3. Всем пешеходам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Как Вам следует поступить при выполнении разворота?";

                    ans1.Text = "1. Проехать перекресток первым.";
                    ans2.Text = "2. Уступить дорогу только легковому автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Уступить дорогу обоим транспортным средствам.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Какие из перечисленных действий запрещены водителям транспортных средств в жилой зоне?";

                    ans1.Text = "1. Сквозное движение.";
                    ans2.Text = "2. Учебная езда.";
                    ans3.Text = "3. Стоянка с работающим двигателем.";
                    ans4.Text = "4. Все перечисленные действия.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 17:
                    txtQuestion.Text = "Какое расстояние должно быть обеспечено между буксирующим и буксируемым транспортными средствами при буксировке на жесткой сцепке?";

                    ans1.Text = "1. Не более 4 м.";
                    bt1.Tag = "1";
                    ans2.Text = "2. От 4 до 6 м.";
                    ans3.Text = "3. От 6 до 8 м.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "В каком случае разрешается эксплуатация транспортного средства?";

                    ans1.Text = "1. Загрязнены внешние световые приборы.";
                    ans2.Text = "2. Регулировка фар не соответствует установленным требованиям.";
                    ans3.Text = "3. На световых приборах используются рассеиватели и лампы, не соответствующие типу данного светового прибора.";
                    ans4.Text = "4. На транспортном средстве спереди установлены световые приборы с огнями оранжевого цвета.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 19:
                    txtQuestion.Text = "Что следует предпринять водителю для предотвращения опасных последствий заноса автомобиля при резком повороте рулевого колеса на скользкой дороге?";

                    ans1.Text = "1. Быстро, но плавно повернуть рулевое колесо в сторону заноса, затем опережающим воздействием на рулевое колесо выровнять траекторию движения автомобиля.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Выключить сцепление и повернуть рулевое колесо в сторону заноса.";
                    ans3.Text = "3. Нажать на педаль тормоза и воздействием на рулевое колесо выровнять траекторию движения.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 20:
                    txtQuestion.Text = "Как следует расположить руки на грудной клетке пострадавшего при проведении сердечно-легочной реанимации?";

                    ans1.Text = "1. Основания ладоней обеих кистей, взятых в «замок», должны располагаться на грудной клетке на два пальца выше мечевидного отростка так, чтобы большой палец одной руки указывал в сторону левого плеча пострадавшего, а другой – в сторону правого плеча. Руки выпрямляются в локтевых суставах.";
                    ans2.Text = "2. Основание ладони одной руки накладывают на середину грудной клетки на два пальца выше мечевидного отростка, вторую руку накладывают сверху, пальцы рук берут в замок. Руки выпрямляются в локтевых суставах, большие пальцы рук указывают на подбородок и живот. Надавливания должны проводиться без резких движений.";
                    ans3.Text = "3. Давление руками на грудину выполняют основанием ладони одной руки, расположенной на грудной клетке на два пальца выше мечевидного отростка. Рука выпрямлена в локтевом суставе. Направление большого пальца не имеет значения.";

                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/4/white.jpg"));

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
