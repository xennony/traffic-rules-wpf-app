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
    public partial class _2 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _2()
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

                if (!MainWindow.globalArray.Contains(2) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(2);
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
            else if(flag)
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
                    MainWindow.statisticGlobalArray[1] = 1;

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
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    txtQuestion.Text = "Сколько полос для движения имеет данная дорога?";

                    ans1.Text = "1. Две.";
                    ans2.Text = "2. Четыре.";
                    ans3.Text = "3. Пять.";
                    bt1.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));


                    break;

                case 2:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Можно ли Вам въехать на мост первым?";

                    ans1.Text = "1. Можно.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Можно, если Вы не затрудните движение встречному автомобилю.";
                    ans3.Text = "3. Нельзя.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 3:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;
                    txtQuestion.Text = "Разрешено ли Вам произвести остановку для посадки пассажира?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено только по четным числам месяца.";
                    ans3.Text = "3. Разрешено только по нечетным числам месяца.";
                    ans4.Text = "4. Запрещено.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 4:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Что запрещено в зоне действия этого знака?";

                    ans1.Text = "1. Движение любых транспортных средств.";
                    ans2.Text = "2. Движение всех транспортных средств со скоростью не более 20 км/ч.";
                    ans3.Text = "3. Движение механических транспортных средств.";
                    bt3.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 5:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Разрешен ли Вам выезд на полосу с реверсивным движением, если реверсивный светофор выключен?";

                    ans1.Text = "1. Разрешен.";
                    ans2.Text = "2. Разрешен, если скорость автобуса менее 30 км/ч.";
                    ans3.Text = "3. Запрещен.";
                    bt3.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 6:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "В каких направлениях Вам разрешается продолжить движение?";

                    ans1.Text = "1. Только налево.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Прямо и налево.";
                    ans3.Text = "3. Налево и в обратном направлении.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 7:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Поднятая вверх рука водителя легкового автомобиля является сигналом, информирующим Вас о его намерении:";

                    ans1.Text = "1. Повернуть направо.";
                    ans2.Text = "2. Продолжить движение прямо.";
                    ans3.Text = "3. Снизить скорость, чтобы остановиться и уступить дорогу мотоциклу.";
                    bt3.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 8:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Двигаясь по левой полосе, водитель намерен перестроиться на правую. На каком из рисунков показана ситуация, в которой он обязан уступить дорогу?";

                    ans1.Text = "1. На левом.";
                    ans2.Text = "2. На правом.";
                    ans3.Text = "3. На обоих.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 9:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Можно ли Вам выполнить разворот в этом месте?";

                    ans1.Text = "1. Можно.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Можно только при отсутствии приближающегося поезда.";
                    ans3.Text = "3. Нельзя.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 10:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;
                    txtQuestion.Text = "В каких случаях разрешается наезжать на прерывистые линии разметки, разделяющие проезжую часть на полосы движения?";

                    ans1.Text = "1. Только если на дороге нет других транспортных средств.";
                    ans2.Text = "2. Только при движении в темное время суток.";
                    ans3.Text = "3. Только при перестроении.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Во всех перечисленных случаях.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/2/white.jpg"));

                    break;

                case 11:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Разрешено ли Вам обогнать мотоцикл?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если водитель мотоцикла снизил скорость.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 12:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Разрешается ли Вам остановиться в указанном месте?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается, если автомобиль будет находиться не ближе 5 м от края пересекаемой проезжей части.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещается.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 13:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Вы намерены повернуть налево. Кому Вы должны уступить дорогу?";

                    ans1.Text = "1. Только пешеходам.";
                    ans2.Text = "2. Только автобусу.";
                    ans3.Text = "3. Автобусу и пешеходам.";
                    bt3.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 14:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "В каком случае Вы имеете преимущество?";

                    ans1.Text = "1. Только при повороте направо.";
                    ans2.Text = "2. Только при повороте налево.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 15:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;
                    txtQuestion.Text = "Обязан ли водитель мотоцикла уступить Вам дорогу?";

                    ans1.Text = "1. Обязан.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Не обязан.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 16:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Разрешается ли водителю выполнить объезд грузового автомобиля?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается, если между шлагбаумом и остановившимся грузовым автомобилем расстояние более 5 м.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    break;

                case 17:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;
                    txtQuestion.Text = "В каких из перечисленных случаев запрещена буксировка на гибкой сцепке?";

                    ans1.Text = "1. Только на горных дорогах.";
                    ans2.Text = "2. Только в гололедицу.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только в темное время суток и в условиях недостаточной видимости.";
                    ans4.Text = "4. Во всех перечисленных случаях.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/2/white.jpg"));

                    break;

                case 18:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;
                    txtQuestion.Text = "Запрещается эксплуатация мототранспортных средств (категории L), если остаточная глубина рисунка протектора шин (при отсутствии индикаторов износа) составляет не более:";

                    ans1.Text = "1. 0,8 мм.";
                    bt1.Tag = "1";
                    ans2.Text = "2. 1,0 мм.";
                    ans3.Text = "3. 1,6 мм.";
                    ans4.Text = "4. 2,0 мм.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/2/white.jpg"));

                    break;

                case 19:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "Исключает ли антиблокировочная тормозная система возможность возникновения заноса или сноса при прохождении поворота?";

                    ans1.Text = "1. Полностью исключает возможность возникновения только заноса.";
                    ans2.Text = "2. Полностью исключает возможность возникновения только сноса.";
                    ans3.Text = "3. Не исключает возможность возникновения сноса или заноса.";
                    bt3.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/2/white.jpg"));

                    break;

                case 20:
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;
                    txtQuestion.Text = "В каких случаях следует начинать сердечно-легочную реанимацию пострадавшего?";

                    ans1.Text = "1. При наличии болей в области сердца и затрудненного дыхания.";
                    ans2.Text = "2. При отсутствии у пострадавшего сознания, независимо от наличия дыхания.";
                    ans3.Text = "3. При отсутствии у пострадавшего сознания, дыхания и кровообращения.";
                    bt3.Tag = "1";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/2/white.jpg"));

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
