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
    public partial class _29 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _29()
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

                if (!MainWindow.globalArray.Contains(29) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(29);
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
                    MainWindow.statisticGlobalArray[28] = 1;
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
                    txtQuestion.Text = "Что означает требование уступить дорогу?";

                    ans1.Text = "1. Вы должны остановиться только при наличии дорожного знака «Уступите дорогу».";
                    ans2.Text = "2. Вы должны обязательно остановиться, чтобы пропустить других участников движения.";
                    ans3.Text = "3. Вы не должны начинать, возобновлять или продолжать движение, осуществлять какой-либо маневр, если это может вынудить других участников движения, имеющих по отношению к Вам преимущество, изменить направление движения или скорость.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Какие из указанных знаков предоставляют право преимущественного проезда нерегулируемых перекрестков?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. А и В.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Все.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешено ли Вам выполнить обгон?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено, если скорость мотоцикла не более 30 км/ч.";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Можно ли водителю поставить грузовой автомобиль на стоянку в этом месте указанным способом?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если разрешенная максимальная масса автомобиля не более 3,5 т.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Такой вертикальной разметкой обозначают:";

                    ans1.Text = "1. Только нижний край пролетного строения тоннелей, мостов и путепроводов.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только въезд в неосвещенные тоннели.";
                    ans3.Text = "3. Любые элементы дорожных сооружений, представляющие опасность.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "В каком месте Вы должны остановиться?";

                    ans1.Text = "1. Перед светофором.";
                    ans2.Text = "2. Перед стоп-линией.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В любом из перечисленных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Должны ли водители подавать сигналы указателями поворота при маневрировании на территории автостоянки или АЗС?";

                    ans1.Text = "1. Должны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Должны только при наличии в непосредственной близости других транспортных средств.";
                    ans3.Text = "3. Не должны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Кто из водителей нарушает правила поворота на перекрестке?";

                    ans1.Text = "1. Оба.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только водитель мотоцикла, поворачивающего налево.";
                    ans3.Text = "3. Только водитель автомобиля.";
                    ans4.Text = "4. Никто не нарушает.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешено ли водителю движение задним ходом при отсутствии других участников движения?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено только до пешеходного перехода.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Можно ли Вам выехать на крайнюю левую полосу в данной ситуации?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если гужевая повозка двигается со скоростью не более 30 км/ч.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешается ли Вам выполнить обгон?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается, если при этом не будут созданы помехи другим участникам движения.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Кто из водителей нарушил правила остановки?";

                    ans1.Text = "1. Оба.";
                    ans2.Text = "2. Только водитель автомобиля А.";
                    ans3.Text = "3. Только водитель автомобиля Б.";
                    ans4.Text = "4. Никто не нарушил.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "При выполнении какого маневра водитель легкового автомобиля имеет преимущество в движении?";

                    ans1.Text = "1. Только при повороте налево.";
                    ans2.Text = "2. Только при развороте.";
                    ans3.Text = "3. При выполнении любого маневра из перечисленных.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены повернуть налево. Ваши действия?";

                    ans1.Text = "1. Уступите дорогу трамваю.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Проедете перекресток первым.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при движении в прямом направлении?";

                    ans1.Text = "1. Только легковому автомобилю.";
                    ans2.Text = "2. Только автобусу.";
                    ans3.Text = "3. Обоим транспортным средствам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Можно ли Вам, управляя грузовым автомобилем, осуществить опережение в данной ситуации?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если разрешенная максимальная масса автомобиля не более 2,5 т.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "При движении в светлое время суток на транспортном средстве должны быть включены:";

                    ans1.Text = "1. Только дневные ходовые огни.";
                    ans2.Text = "2. Только фары ближнего света.";
                    ans3.Text = "3. Только противотуманные фары.";
                    ans4.Text = "4. Любые внешние световые приборы из перечисленных.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 18:
                    txtQuestion.Text = "Запрещается эксплуатация легкового автомобиля (категория М1), если остаточная глубина рисунка протектора шин (при отсутствии индикаторов износа) составляет не более:";

                    ans1.Text = "1. 0,8 мм.";
                    ans2.Text = "2. 1,0 мм.";
                    ans3.Text = "3. 1,6 мм.";
                    bt3.Tag = "1";
                    ans4.Text = "4. 2,0 мм.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 19:
                    txtQuestion.Text = "Что следует предпринять для быстрого восстановления эффективности тормозов транспортного средства после проезда через водную преграду?";

                    ans1.Text = "1. Резко нажать на педаль тормоза, после чего продолжить движение.";
                    ans2.Text = "2. Продолжить движение и просушить тормозные колодки многократными непродолжительными нажатиями на педаль тормоза.";
                    ans3.Text = "3. Продолжить движение с малой скоростью без притормаживания.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Каковы первоначальные действия при оказании первой помощи в случае ранения, полученного в результате ДТП?";

                    ans1.Text = "1. Промыть рану водой, удалить инородные тела, внедрившиеся в рану, приложить стерильную вату, закрепив ее бинтовой повязкой.";
                    ans2.Text = "2. Надеть медицинские перчатки, рану промыть спиртовым раствором йода, смазать лечебной мазью и заклеить сплошным лейкопластырем.";
                    ans3.Text = "3. Надеть медицинские перчатки, рану не промывать, на рану наложить марлевую стерильную салфетку, закрепив ее лейкопластырем по краям или бинтовой повязкой.";
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
