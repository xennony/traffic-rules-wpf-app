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
    public partial class _14 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _14()
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

                if (!MainWindow.globalArray.Contains(14) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(14);
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
                    MainWindow.statisticGlobalArray[13] = 1;
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
                    txtQuestion.Text = "Что означает термин «Ограниченная видимость»?";

                    ans1.Text = "1. Видимость водителем дороги, ограниченная рельефом местности, геометрическими параметрами дороги, растительностью, строениями, сооружениями или другими объектами.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Видимость водителем дороги менее 300 м в условиях тумана, дождя, снегопада, а также в сумерки.";
                    ans3.Text = "3. Видимость водителем дороги менее 150 м в ночное время.";
                    ans4.Text = "4. Видимость водителем дороги во всех перечисленных случаях.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 2:
                    txtQuestion.Text = "О чем предупреждают Вас эти знаки?";

                    ans1.Text = "1. Остановка транспортных средств на обочине запрещена.";
                    ans2.Text = "2. Съезд на обочину опасен в связи с проведением на ней дорожных работ.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В месте производства дорожных работ стоянка запрещена.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Какие из указанных знаков разрешают движение грузовым автомобилям с разрешенной максимальной массой не более 3,5 т?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. А и В.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Все.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Вам можно продолжить движение по крайней левой полосе на легковом автомобиле:";

                    ans1.Text = "1. Только налево.";
                    ans2.Text = "2. Прямо или налево.";
                    ans3.Text = "3. Прямо, налево или в обратном направлении.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "В каком из указанных мест Вам разрешено пересечь сплошную линию разметки и остановиться?";

                    ans1.Text = "1. А и Б.";
                    ans2.Text = "2. Только Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В указанных местах пересекать сплошную линию разметки запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Должны ли Вы остановиться по требованию регулировщика в указанном им месте?";

                    ans1.Text = "1. Должны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Должны только с заездом на тротуар.";
                    ans3.Text = "3. Не должны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Такой сигнал рукой, подаваемый водителем мотоцикла, информирует Вас:";

                    ans1.Text = "1. О его намерении повернуть налево или выполнить разворот.";
                    bt1.Tag = "1";
                    ans2.Text = "2. О его намерении продолжить движение прямо или налево.";
                    ans3.Text = "3. О наличии транспортного средства, приближающегося слева.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "По какой траектории Вам разрешается выполнить поворот налево?";

                    ans1.Text = "1. Только по А.";
                    ans2.Text = "2. Только по Б.";
                    ans3.Text = "3. По любой из указанных.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Можно ли Вам развернуться в этом месте?";

                    ans1.Text = "1. Можно.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Можно только в светлое время суток.";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Допускается ли движение автомобилей по тротуарам или пешеходным дорожкам?";

                    ans1.Text = "1. Допускается.";
                    ans2.Text = "2. Допускается только при доставке грузов к торговым и другим предприятиям, расположенным непосредственно у тротуаров или пешеходных дорожек, если отсутствуют другие возможности подъезда.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Не допускается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "В данной ситуации Вы:";

                    ans1.Text = "1. Должны уступить дорогу, так как встречный автомобиль движется на подъем.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Имеете право проехать первым, так как Вы движетесь на спуск.";
                    ans3.Text = "3. Имеете право проехать первым, так как препятствие находится на полосе движения встречного автомобиля.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Разрешено ли Вам остановиться на мосту в этом месте?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено только для высадки пассажиров.";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "При включении зеленого сигнала светофора Вы должны уступить дорогу:";

                    ans1.Text = "1. Только грузовому автомобилю, завершающему разворот на перекрестке.";
                    ans2.Text = "2. Только легковому автомобилю.";
                    ans3.Text = "3. Обоим автомобилям.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены проехать перекресток в прямом направлении. Кому Вы обязаны уступить дорогу?";

                    ans1.Text = "1. Только трамваю А.";
                    ans2.Text = "2. Только трамваю Б.";
                    ans3.Text = "3. Обоим трамваям.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "При повороте налево Вы:";

                    ans1.Text = "1. Имеете преимущество.";
                    ans2.Text = "2. Должны уступить дорогу только автобусу.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Должны уступить дорогу легковому автомобилю и автобусу.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Кто из водителей нарушает правила разворота на автомагистрали?";

                    ans1.Text = "1. Оба.";
                    ans2.Text = "2. Только водитель легкового автомобиля.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только водитель грузового автомобиля, выполняющего работы по ремонту или содержанию дорог.";
                    ans4.Text = "4. Никто не нарушает.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 17:
                    txtQuestion.Text = "Буксировка двухколесного мотоцикла разрешается:";

                    ans1.Text = "1. Только если мотоцикл с боковым прицепом, а водитель соответствующего буксирующего транспортного средства имеет право на управление транспортными средствами в течение двух и более лет.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Если мотоцикл с боковым прицепом.";
                    ans3.Text = "3. Если водитель соответствующего буксирующего транспортного средства имеет право на управление транспортными средствами в течение двух и более лет.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "В каком из перечисленных случаев разрешается эксплуатация автомобиля?";

                    ans1.Text = "1. Шины имеют отслоения протектора или боковины.";
                    ans2.Text = "2. Шины имеют порезы, обнажающие корд.";
                    ans3.Text = "3. На задней оси автомобиля установлены шины с восстановленным рисунком протектора.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Как влияет длительный разгон транспортного средства с включенной первой передачей на расход топлива?";

                    ans1.Text = "1. Расход топлива увеличивается.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Расход топлива не изменяется.";
                    ans3.Text = "3. Расход топлива уменьшается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Является ли безопасным движение вне населенного пункта на легковом автомобиле в темное время суток с включенным ближним светом фар по неосвещенному участку дороги со скоростью 90 км/ч?";

                    ans1.Text = "1. Является безопасным, поскольку предельная допустимая скорость соответствует требованиям Правил.";
                    ans2.Text = "2. Является безопасным при малой интенсивности движения.";
                    ans3.Text = "3. Не является безопасным, поскольку остановочный путь превышает расстояние видимости.";
                    bt3.Tag = "1";
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
