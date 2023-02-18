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
    public partial class _12 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _12()
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

                if (!MainWindow.globalArray.Contains(12) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(12);
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
                    MainWindow.StatisticGlobalArray[11] = 1;
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
                    txtQuestion.Text = "В каких случаях владелец легкового автомобиля может передавать управление этим транспортным средством в своем присутствии другому лицу, имея страховой полис обязательного страхования гражданской ответственности на бумажном носителе или в виде электронного документа либо его копии на бумажном носителе?";

                    ans1.Text = "1. При наличии у этого лица водительского удостоверения на право управления транспортным средством подкатегории «B1».";
                    ans2.Text = "2. При наличии у этого лица водительского удостоверения на право управления транспортным средством категории «B».";
                    bt2.Tag = "1";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Этот знак:";

                    ans1.Text = "1. Предупреждает Вас о наличии узкого участка дороги, но не устанавливает очередность движения.";
                    ans2.Text = "2. Запрещает Вам проезд через мост.";
                    ans3.Text = "3. Обязывает Вас уступить дорогу встречному транспортному средству.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "В каких направлениях Вам можно продолжить движение на перекрестке?";

                    ans1.Text = "1. Только налево и в обратном направлении.";
                    ans2.Text = "2. Прямо, налево и в обратном направлении.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В любом направлении.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какие из указанных знаков разрешают движение мопедов?";

                    ans1.Text = "1. Только В.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только Г.";
                    ans3.Text = "3. Б, В и Г.";
                    ans4.Text = "4. Все.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 5:
                    txtQuestion.Text = "Движение разрешается:";

                    ans1.Text = "1. Только по траектории А.";
                    ans2.Text = "2. Только по траектории Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Какое значение имеет сигнал свистком, подаваемый регулировщиком?";

                    ans1.Text = "1. Водитель должен немедленно остановиться.";
                    ans2.Text = "2. Водитель должен ускорить движение.";
                    ans3.Text = "3. Сигнал подается для привлечения внимания участников движения.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Вы намерены повернуть налево на этом перекрестке. В какой момент следует включить указатели левого поворота?";

                    ans1.Text = "1. Заблаговременно, до въезда на перекресток.";
                    ans2.Text = "2. После въезда на первое пересечение проезжих частей.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По Вашему усмотрению.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Кто должен уступить дорогу при одновременном перестроении?";

                    ans1.Text = "1. Водитель легкового автомобиля.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Водитель мотоцикла.";
                    ans3.Text = "3. В данной ситуации водителям следует действовать по взаимной договоренности.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешено ли Вам выполнить разворот на мосту по указанной траектории?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено только при видимости дороги не менее 100 м.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "С какой скоростью Вы имеете право продолжить движение в населенном пункте по правой полосе?";

                    ans1.Text = "1. Не более 40 км/ч.";
                    ans2.Text = "2. Не более 60 км/ч.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Не менее 40 км/ч и не более 60 км/ч.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешено ли Вам выполнить обгон в данной ситуации?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если обгон будет завершен до перекрестка.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Можно ли Вам поставить автомобиль на стоянку в указанном месте?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если Вы проживаете или работаете в обозначенной знаком зоне.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Вы намерены повернуть направо. Ваши действия?";

                    ans1.Text = "1. Повернете направо, не уступая дорогу пешеходам.";
                    ans2.Text = "2. Повернете направо, уступив дорогу пешеходам.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Остановитесь перед перекрестком и дождетесь другого сигнала регулировщика.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "При движении в каком направлении Вы должны уступить дорогу автомобилю с включенными проблесковым маячком и специальным звуковым сигналом?";

                    ans1.Text = "1. Только налево.";
                    ans2.Text = "2. Налево и в обратном направлении.";
                    ans3.Text = "3. В любом.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Вы намерены продолжить движение прямо. Ваши действия при желтом мигающем сигнале светофора?";

                    ans1.Text = "1. Уступите дорогу обоим транспортным средствам.";
                    ans2.Text = "2. Уступите дорогу только трамваю.";
                    ans3.Text = "3. Уступите дорогу только автомобилю.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Проедете первым.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 16:
                    txtQuestion.Text = "Разрешается ли учебная езда на автомагистрали?";

                    ans1.Text = "1. Запрещается.";
                    ans2.Text = "2. Разрешается только по крайней правой полосе.";
                    ans3.Text = "3. Разрешается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "При движении в темное время суток на неосвещенных участках дорог можно использовать противотуманные фары:";

                    ans1.Text = "1. Только отдельно от ближнего или дальнего света фар.";
                    ans2.Text = "2. Только совместно с ближним или дальним светом фар.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Как отдельно, так и совместно с ближним или дальним светом фар.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "При какой неисправности тормозной системы запрещается эксплуатация транспортного средства?";

                    ans1.Text = "1. Не включается контрольная лампа стояночной тормозной системы.";
                    ans2.Text = "2. Стояночная тормозная система не обеспечивает неподвижное состояние транспортного средства с полной нагрузкой на уклоне до 16 % включительно.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Уменьшен свободный ход педали тормоза.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Способ разворота с использованием прилегающей территории справа, обеспечивающий безопасность движения, показан:";

                    ans1.Text = "1. Только на левом рисунке.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только на правом рисунке.";
                    ans3.Text = "3. На обоих рисунках.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Как следует уложить пострадавшего при потере им сознания и наличии дыхания и кровообращения для оказания первой помощи?";

                    ans1.Text = "1. На спину с подложенным под голову валиком.";
                    ans2.Text = "2. На спину с вытянутыми ногами.";
                    ans3.Text = "3. Придать пострадавшему устойчивое боковое положение, чтобы согнутые колени опирались о землю, а верхняя рука находилась под щекой.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/12/20.jpg"));

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
