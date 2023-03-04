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
    public partial class _32 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _32()
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

                if (!MainWindow.globalArray.Contains(32) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(32);
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
                    MainWindow.statisticGlobalArray[31] = 1;
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
                    txtQuestion.Text = "По требованию каких лиц водители обязаны проходить освидетельствование на состояние алкогольного опьянения и медицинское освидетельствование на состояние опьянения?";

                    ans1.Text = "1. Всех регулировщиков.";
                    ans2.Text = "2. Должностных лиц, уполномоченных на осуществление федерального государственного надзора в области безопасности дорожного движения.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Любых сотрудников полиции.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Какие из указанных знаков информируют о том, что на перекрестке необходимо уступить дорогу транспортным средствам, приближающимся слева?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. А и Б.";
                    ans4.Text = "4. Все.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешено ли Вам при управлении легковым автомобилем с прицепом продолжить движение в прямом направлении?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено, если Вы проживаете в обозначенной знаком зоне.";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Вам разрешается движение:";

                    ans1.Text = "1. Только в направлении Б.";
                    ans2.Text = "2. В направлениях А и Б.";
                    ans3.Text = "3. В направлениях Б и В.";
                    ans4.Text = "4. В любом направлении из указанных.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 5:
                    txtQuestion.Text = "О чем информирует Вас увеличение длины штриха прерывистой линии разметки?";

                    ans1.Text = "1. О начале зоны, где запрещены любые маневры.";
                    ans2.Text = "2. О начале опасного участка дороги.";
                    ans3.Text = "3. О приближении к сплошной линии разметки, разделяющей транспортные потоки попутных направлений.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Можно ли Вам перестроиться на соседнюю полосу?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если грузовой автомобиль движется со скоростью 30 км/час.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Обязаны ли Вы включить указатели правого поворота перед въездом на этот перекресток?";

                    ans1.Text = "1. Обязаны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Обязаны только при наличии движущихся сзади транспортных средств.";
                    ans3.Text = "3. Не обязаны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Выезжая с прилегающей территории, необходимо уступить дорогу:";

                    ans1.Text = "1. Только маршрутным транспортным средствам.";
                    ans2.Text = "2. Всем механическим транспортным средствам.";
                    ans3.Text = "3. Любым транспортным средствам и пешеходам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешено ли выполнить разворот на участке дороги, обозначенном этим знаком?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено только в населенном пункте.";
                    ans3.Text = "3. Разрешено только при видимости дороги не менее 100 м.";
                    ans4.Text = "4. Запрещено.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 10:
                    txtQuestion.Text = "В каких случаях водителю запрещается движение со скоростью более 50 км/ч?";

                    ans1.Text = "1. При управлении мопедом.";
                    ans2.Text = "2. При буксировке механического транспортного средства.";
                    ans3.Text = "3. Если соответствующий запрет установлен дорожным знаком «Ограничение максимальной скорости».";
                    ans4.Text = "4. Во всех перечисленных случаях.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешается ли выполнить обгон на пешеходном переходе?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Запрещается только при наличии на нем пешеходов.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "В каком месте Вам можно остановиться?";

                    ans1.Text = "1. Только В.";
                    bt1.Tag = "1";
                    ans2.Text = "2. А и В.";
                    ans3.Text = "3. Б и В.";
                    ans4.Text = "4. В любом из указанных.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "Как Вам следует поступить при повороте налево?";

                    ans1.Text = "1. Проехать перекресток первым.";
                    ans2.Text = "2. Уступить дорогу только грузовому автомобилю с включенным проблесковым маячком.";
                    ans3.Text = "3. Уступить дорогу только автобусу.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены развернуться. Ваши действия?";

                    ans1.Text = "1. Развернетесь первым.";
                    ans2.Text = "2. Выедете на перекресток и, уступив дорогу легковому автомобилю, завершите разворот.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Будете действовать по взаимной договоренности с водителем легкового автомобиля.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при движении прямо?";

                    ans1.Text = "1. Только трамваю.";
                    ans2.Text = "2. Только легковому автомобилю.";
                    ans3.Text = "3. Трамваю и легковому автомобилю.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Всем транспортным средствам.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 16:
                    txtQuestion.Text = "Разрешается ли движение по автомагистрали на транспортном средстве, скорость которого по техническому состоянию менее 40 км/ч?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только по крайней правой полосе.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Перевозка груза запрещена, если он:";

                    ans1.Text = "1. Выступает более чем на 1 м за габариты транспортного средства спереди или сзади.";
                    ans2.Text = "2. Закрывает внешние световые приборы, световозвращатели, регистрационные и опознавательные знаки.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Установлен на сиденье для пассажиров.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Разрешено ли движение транспортного средства до места ремонта или стоянки в темное время суток с негорящими (из-за неисправности) фарами и задними габаритными огнями?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено только на дорогах с искусственным освещением.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "При повороте налево обеспечение безопасности движения достигается путем выполнения поворота по траектории, которая показана:";

                    ans1.Text = "1. На левом рисунке.";
                    bt1.Tag = "1";
                    ans2.Text = "2. На правом рисунке.";
                    ans3.Text = "3. На обоих рисунках.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Как обеспечить восстановление проходимости дыхательных путей пострадавшего при подготовке его к проведению сердечно-легочной реанимации?";

                    ans1.Text = "1. Уложить пострадавшего на спину на твердую поверхность, запрокинуть ему голову, положить одну руку на лоб, приподняв подбородок двумя пальцами другой руки.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Уложить пострадавшего на бок, наклонить его голову к груди. При наличии слизи и рвотных масс очистить от них ротовую полость.";
                    ans3.Text = "3. Уложить пострадавшего на спину и, не запрокидывая ему голову, сжать щеки, чтобы раздвинуть губы и раскрыть рот. При наличии слизи и рвотных масс очистить от них ротовую полость.";
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
