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
    public partial class _24 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _24()
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

                if (!MainWindow.globalArray.Contains(24) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(24);
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
                    MainWindow.statisticGlobalArray[23] = 1;
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
                    txtQuestion.Text = "При движении на легковом автомобиле, оборудованном ремнями безопасности, должны быть пристегнуты:";

                    ans1.Text = "1. Только водитель.";
                    ans2.Text = "2. Водитель и пассажир на переднем сиденье.";
                    ans3.Text = "3. Все лица, находящиеся в автомобиле.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Эти знаки предупреждают Вас:";

                    ans1.Text = "1. О приближении к железнодорожному переезду с тремя путями.";
                    ans2.Text = "2. О наличии через 150-300 м железнодорожного переезда без шлагбаума.";
                    bt2.Tag = "1";
                    ans3.Text = "3. О наличии через 50-100 м железнодорожного переезда.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешено ли Вам поставить автомобиль на стоянку в этом месте?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено, если Вы проживаете рядом с этим местом.";
                    ans3.Text = "3. Запрещено.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какие из указанных знаков обязывают водителя грузового автомобиля с разрешенной максимальной массой не более 3,5 т повернуть направо?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. А и Б.";
                    ans4.Text = "4. Б и В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 5:
                    txtQuestion.Text = "Данная разметка обозначает:";

                    ans1.Text = "1. Место, где начинается (заканчивается) жилая зона.";
                    ans2.Text = "2. Искусственную неровность на проезжей части.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Место, где начинается (заканчивается) зона с ограничением стоянки.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Что означает мигание желтого сигнала светофора?";

                    ans1.Text = "1. Предупреждает о неисправности светофора.";
                    ans2.Text = "2. Разрешает движение и информирует о наличии нерегулируемого перекрестка или пешеходного перехода.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещает дальнейшее движение.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Какую ошибку совершает водитель, въезжающий во двор?";

                    ans1.Text = "1. Поворачивает в зоне действия знака «Движение прямо».";
                    ans2.Text = "2. Поворачивает, не включив указатели поворота.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Совершает обе перечисленные ошибки.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Должны ли Вы уступить дорогу грузовому автомобилю в данной ситуации?";

                    ans1.Text = "1. Должны.";
                    ans2.Text = "2. Должны, если он намерен повернуть направо.";
                    ans3.Text = "3. Не должны.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешается ли Вам выполнить разворот?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только по траектории А.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Разрешается только по траектории Б.";
                    ans4.Text = "4. Запрещается.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 10:
                    txtQuestion.Text = "С какой максимальной скоростью Вы имеете право продолжить движение вне населенных пунктов на грузовом автомобиле с разрешенной максимальной массой не более 3,5 т?";

                    ans1.Text = "1. 60 км/ч.";
                    ans2.Text = "2. 70 км/ч.";
                    ans3.Text = "3. 90 км/ч.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Разрешено ли Вам выполнить обгон?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если скорость грузового автомобиля менее 30 км/ч.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Кто из водителей нарушил правила стоянки?";

                    ans1.Text = "1. Оба.";
                    ans2.Text = "2. Только водитель автомобиля А.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только водитель автомобиля Б.";
                    ans4.Text = "4. Никто не нарушил.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "При повороте налево Вы:";

                    ans1.Text = "1. Должны уступить дорогу обоим транспортным средствам.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Должны уступить дорогу только легковому автомобилю.";
                    ans3.Text = "3. Имеете право проехать перекресток первым.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Кто имеет право проехать перекресток первым, если все намерены двигаться прямо?";

                    ans1.Text = "1. Водитель троллейбуса.";
                    ans2.Text = "2. Вы вместе с водителем троллейбуса.";
                    ans3.Text = "3. В данной ситуации очередность проезда определяется по взаимной договоренности водителей.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "В каком случае Вы обязаны уступить дорогу пешеходам?";

                    ans1.Text = "1. Только при повороте налево.";
                    ans2.Text = "2. Только при повороте направо.";
                    ans3.Text = "3. В обоих случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "В данной ситуации Вы:";

                    ans1.Text = "1. Можете объехать шлагбаум, так как светофор не запрещает движение.";
                    ans2.Text = "2. Должны остановиться и можете продолжить движение только при открытом шлагбауме.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "На каком расстоянии до встречного транспортного средства следует переключать дальний свет фар на ближний?";

                    ans1.Text = "1. Не менее чем за 150 м.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Не менее чем за 300 м.";
                    ans3.Text = "3. По усмотрению водителя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "В каком случае разрешается эксплуатация легкового автомобиля?";

                    ans1.Text = "1. Не работает спидометр.";
                    ans2.Text = "2. Не работает указатель температуры охлаждающей жидкости.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Не работает предусмотренное конструкцией противоугонное устройство.";
                    ans4.Text = "4. Отсутствуют опознавательные знаки, которые должны быть на нем установлены.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 19:
                    txtQuestion.Text = "Что следует сделать водителю, чтобы предотвратить возникновение заноса при проезде крутого поворота?";

                    ans1.Text = "1. Перед поворотом снизить скорость и выжать педаль сцепления, чтобы дать возможность автомобилю двигаться накатом на повороте.";
                    ans2.Text = "2. Перед поворотом снизить скорость, при необходимости включить пониженную передачу, а при проезде поворота не увеличивать резко скорость и не тормозить.";
                    ans3.Text = "3. Допускаются любые из перечисленных действий.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Разрешено ли давать пострадавшему лекарственные средства при оказании ему первой помощи?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено в случае крайней необходимости.";
                    ans3.Text = "3. Запрещено.";
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
