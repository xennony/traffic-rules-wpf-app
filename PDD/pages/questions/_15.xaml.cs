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
    public partial class _15 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _15()
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

                if (!MainWindow.globalArray.Contains(15) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(15);
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
                    MainWindow.statisticGlobalArray[14] = 1;
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
                    txtQuestion.Text = "Какой неподвижный объект, не позволяющий продолжить движение по полосе, не относится к понятию «Препятствие»?";

                    ans1.Text = "1. Дефект проезжей части.";
                    ans2.Text = "2. Посторонний предмет.";
                    ans3.Text = "3. Неисправное или поврежденное транспортное средство.";
                    ans4.Text = "4. Транспортное средство, остановившееся на этой полосе из-за образования затора.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 2:
                    txtQuestion.Text = "Вам можно продолжить движение на перекрестке:";

                    ans1.Text = "1. Только в направлении Б.";
                    ans2.Text = "2. В направлениях А и Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В направлениях Б и В.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Этот дорожный знак:";

                    ans1.Text = "1. Рекомендует двигаться со скоростью 40 км/ч.";
                    ans2.Text = "2. Требует двигаться со скоростью не менее 40 км/ч.";
                    ans3.Text = "3. Запрещает движение со скоростью более 40 км/ч.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какие из указанных табличек указывают протяженность зоны действия знаков, с которыми они применяются?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    ans3.Text = "3. Б и В.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Разрешен ли Вам такой маневр при выключенных реверсивных светофорах?";

                    ans1.Text = "1. Разрешен.";
                    ans2.Text = "2. Разрешен, если нет встречных транспортных средств.";
                    ans3.Text = "3. Разрешен только для обгона.";
                    ans4.Text = "4. Запрещен.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 6:
                    txtQuestion.Text = "При таких сигналах светофора и жесте регулировщика Вы должны:";

                    ans1.Text = "1. Остановиться у стоп-линии.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Продолжить движение только прямо.";
                    ans3.Text = "3. Продолжить движение прямо или направо.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Обязан ли в этой ситуации водитель, остановившийся из-за неисправности, выставить знак аварийной остановки?";

                    ans1.Text = "1. Обязан.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Обязан, если неисправна аварийная сигнализация.";
                    ans3.Text = "3. Не обязан.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "По какой траектории Вам разрешено продолжить движение налево?";

                    ans1.Text = "1. Только по А.";
                    ans2.Text = "2. Только по Б.";
                    ans3.Text = "3. По любой из указанных.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Как Вам следует действовать, выезжая с места стоянки одновременно с другим автомобилем?";

                    ans1.Text = "1. Уступить дорогу.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Проехать первым.";
                    ans3.Text = "3. По взаимной договоренности с водителем этого автомобиля.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "К резкому торможению можно прибегнуть:";

                    ans1.Text = "1. Для остановки перед перекрестком или пешеходным переходом, когда зеленый сигнал светофора сменился на желтый.";
                    ans2.Text = "2. Для предотвращения дорожно-транспортного происшествия.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешается ли на двухполосной дороге выполнять обгон на перекрестках?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только на нерегулируемых перекрестках.";
                    ans3.Text = "3. Разрешается только на перекрестках неравнозначных дорог при движении по главной дороге.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Запрещается.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 12:
                    txtQuestion.Text = "Кто из водителей нарушил правила остановки?";

                    ans1.Text = "1. Оба.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только водитель автомобиля.";
                    ans3.Text = "3. Только водитель мотоцикла.";
                    ans4.Text = "4. Никто не нарушил.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "В каком случае Вы обязаны уступить дорогу трамваю?";

                    ans1.Text = "1. При повороте налево.";
                    ans2.Text = "2. При движении прямо.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "При движении в прямом направлении Вам следует:";

                    ans1.Text = "1. Проехать перекресток первым.";
                    ans2.Text = "2. Уступить дорогу только трамваю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Уступить дорогу трамваю и легковому автомобилю.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы должны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только автобусу.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только легковому автомобилю.";
                    ans3.Text = "3. Никому.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Вам разрешено продолжить движение:";

                    ans1.Text = "1. Только по траектории А.";
                    ans2.Text = "2. Только по траектории Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По траекториям А или Б.";
                    ans4.Text = "4. По траекториям Б или В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 17:
                    txtQuestion.Text = "Привлечь внимание водителя обгоняемого автомобиля при движении вне населенного пункта в светлое время суток можно:";

                    ans1.Text = "1. Только подачей звукового сигнала.";
                    ans2.Text = "2. Только кратковременным переключением фар с ближнего света на дальний.";
                    ans3.Text = "3. Только совместной подачей указанных сигналов.";
                    ans4.Text = "4. Любым из перечисленных способов.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 18:
                    txtQuestion.Text = "Эксплуатация мотоцикла запрещается:";

                    ans1.Text = "1. Только при отсутствии предусмотренных конструкцией подножек, поперечных рукояток для пассажиров на седле.";
                    ans2.Text = "2. Только при отсутствии предусмотренных конструкцией дуг безопасности.";
                    ans3.Text = "3. При отсутствии всего перечисленного оборудования.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Как следует выбирать передачу при торможении двигателем с учетом крутизны спуска?";

                    ans1.Text = "1. Чем круче спуск, тем выше передача.";
                    ans2.Text = "2. Чем круче спуск, тем ниже передача.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Выбор передачи не зависит от крутизны спуска.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "О каких травмах у пострадавшего может свидетельствовать поза «лягушки» (ноги согнуты в коленях и разведены, а стопы развернуты подошвами друг к другу) и какую первую помощь необходимо при этом оказать?";

                    ans1.Text = "1. У пострадавшего могут быть ушиб брюшной стенки, перелом лодыжки, перелом костей стопы. При первой помощи вытянуть ноги, наложить шины на обе ноги от голеностопного сустава до подмышки.";
                    ans2.Text = "2. У пострадавшего могут быть переломы шейки бедра, костей таза, перелом позвоночника, повреждение внутренних органов малого таза, внутреннее кровотечение. Позу ему не менять, ноги не вытягивать, шины не накладывать. При первой помощи подложить под колени валик из мягкой ткани, к животу по возможности приложить холод.";
                    bt2.Tag = "1";
                    ans3.Text = "3. У пострадавшего могут быть переломы костей голени и нижней трети бедра. При первой помощи наложить шины только на травмированную ногу от голеностопного до коленного сустава, не вытягивая ногу.";
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
