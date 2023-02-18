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
    public partial class _7 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _7()
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

                if (!MainWindow.globalArray.Contains(7) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(7);
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
                    MainWindow.StatisticGlobalArray[6] = 1;
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
                    txtQuestion.Text = "Может ли владелец мотоцикла с рабочим объемом двигателя внутреннего сгорания, не превышающим 125 см3 , и максимальной мощностью, не превышающей 11 квт, передавать управление этим транспортным средством в своем присутствии другому лицу, имея страховой полис обязательного страхования гражданской ответственности на бумажном носителе или в виде электронного документа либо его копии на бумажном носителе?";

                    ans1.Text = "1. Может при наличии у этого лица водительского удостоверения на право управления транспортным средством категории «А» или подкатегории «А1».";
                    bt1.Tag = "1";
                    ans2.Text = "2. Может при наличии у этого лица водительского удостоверения на право управления транспортным средством подкатегории «B1»";
                    ans3.Text = "3. Может при наличии у этого лица водительского удостоверения на право управления транспортным средством категории «M»";
                    ans4.Text = "4. Может во всех перечисленных случаях.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/1.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 2:
                    txtQuestion.Text = "О чем информируют Вас эти дорожные знаки?";

                    ans1.Text = "1. О приближении к перекрестку, где установлен знак «Уступите дорогу».";
                    ans2.Text = "2. О приближении к перекрестку, где установлен знак «Движение без остановки запрещено».";
                    bt2.Tag = "1";
                    ans3.Text = "3. О приближении к таможне.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/2.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешено ли Вам произвести остановку в указанном месте?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено только для посадки или высадки пассажиров.";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/3.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Действие каких знаков из указанных распространяется только до ближайшего по ходу движения перекрестка?";

                    ans1.Text = "1. А и В.";
                    ans2.Text = "2. Б и Г.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В и Г.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/4.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Что обозначают прерывистые линии разметки на перекрестке?";

                    ans1.Text = "1. Обязательное направление движения на перекрестке.";
                    ans2.Text = "2. Полосы движения в пределах перекрестка.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Вам разрешается движение:";

                    ans1.Text = "1. Только прямо.";
                    ans2.Text = "2. Прямо и направо.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В любом направлении.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Когда следует выключить указатели левого поворота, выполняя обгон?";

                    ans1.Text = "1. Сразу же после перестроения на полосу, предназначенную для встречного движения.";
                    bt1.Tag = "1";
                    ans2.Text = "2. После опережения обгоняемого транспортного средства.";
                    ans3.Text = "3. По усмотрению водителя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Обязан ли водитель легкового автомобиля уступить дорогу водителю грузового автомобиля?";

                    ans1.Text = "1. Обязан.";
                    ans2.Text = "2. Обязан, если водитель грузового автомобиля начнет смещаться вправо.";
                    ans3.Text = "3. Не обязан.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешен ли Вам разворот на этом участке дороги?";

                    ans1.Text = "1. Разрешен.";
                    ans2.Text = "2. Разрешен только при видимости дороги не менее 100 м.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещен.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/9.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "С какой скоростью мотоциклам разрешается движение вне населенных пунктов на автомагистралях?";

                    ans1.Text = "1. Не более 90 км/час.";
                    ans2.Text = "2. Не более 110 км/час.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Не более 130 км/час.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/10.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешается ли Вам в конце подъема перестроиться на среднюю полосу для опережения грузового автомобиля?";

                    ans1.Text = "1. Разрешается.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешается только при видимости дороги не менее 100 м.";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "В каком из указанных мест Вам можно поставить на стоянку легковой автомобиль?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только В.";
                    ans3.Text = "3. А или В.";
                    bt3.Tag = "1";
                    ans4.Text = "4. В любом.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "Как Вам следует поступить при повороте налево?";

                    ans1.Text = "1. Проехать перекресток первым.";
                    ans2.Text = "2. Выехать за стоп-линию и остановиться на перекрестке, чтобы уступить дорогу встречному автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Остановиться перед стоп-линией и после проезда легкового автомобиля повернуть налево.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Разрешено ли Вам выехать на перекресток, за которым образовался затор?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если Вы намерены выполнить поворот.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Вы намерены продолжить движение прямо. Кому Вы обязаны уступить дорогу?";

                    ans1.Text = "1. Только мотоциклу.";
                    ans2.Text = "2. Мотоциклу и легковому автомобилю.";
                    ans3.Text = "3. Никому.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Где могут двигаться пешеходы в жилой зоне?";

                    ans1.Text = "1. Только по тротуарам.";
                    ans2.Text = "2. По тротуарам и в один ряд по краю проезжей части.";
                    ans3.Text = "3. По тротуарам и по всей ширине проезжей части.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "На каком рисунке изображен автомобиль, водитель которого не нарушает правил перевозки грузов?";

                    ans1.Text = "1. Только на А.";
                    ans2.Text = "2. Только на Б.";
                    ans3.Text = "3. На обоих.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "В каких случаях разрешается эксплуатация транспортного средства?";

                    ans1.Text = "1. Содержание вредных веществ в отработавших газах или их дымность превышают установленные нормы.";
                    ans2.Text = "2. Нарушена герметичность системы питания (топливной системы).";
                    ans3.Text = "3. Не работает указатель температуры охлаждающей жидкости.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Уровень внешнего шума превышает установленные нормы.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 19:
                    txtQuestion.Text = "Двигаться по глубокому снегу на грунтовой дороге следует:";

                    ans1.Text = "1. Изменяя скорость движения и передачу в зависимости от состояния дороги.";
                    ans2.Text = "2. На заранее выбранной пониженной передаче, без резких поворотов и остановок.";
                    bt2.Tag = "1";
                    ans3.Text = "3. На заранее выбранной повышенной передаче, без резких поворотов и остановок.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Какую оптимальную позу следует придать пострадавшему, находящемуся в сознании, при подозрении на травму позвоночника?";

                    ans1.Text = "1. Уложить пострадавшего на бок.";
                    ans2.Text = "2. Уложить пострадавшего на спину на твердой ровной поверхности, без необходимости его не перемещать, позу не менять.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Уложить пострадавшего на спину, подложить под шею валик из одежды и приподнять ноги.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/7/20.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;
            }
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
