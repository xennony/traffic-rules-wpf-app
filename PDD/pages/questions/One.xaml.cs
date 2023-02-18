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
    public partial class _1 : Page
    {
        #region Variables
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        #endregion


        ResultWindow resWin = new ResultWindow();


        public _1()
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

                if (!MainWindow.globalArray.Contains(1) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(1);
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
                    MainWindow.StatisticGlobalArray[0] = 1;

                    MainWindow.globalArray.Remove(1);

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
                    txtQuestion.Text = "В каком случае водитель совершит вынужденную остановку?";

                    ans1.Text = "1. Остановившись непосредственно перед пешеходным переходом, чтобы уступить дорогу пешеходу.";
                    ans2.Text = "2. Остановившись на проезжей части из-за технической неисправности транспортного средства.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Разрешен ли Вам съезд на дорогу с грунтовым покрытием?";

                    ans1.Text = "1. Разрешен.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешен только при технической неисправности транспортного средства.";
                    ans3.Text = "3. Запрещен.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/5.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Можно ли Вам остановиться в указанном месте для посадки пассажира?";

                    ans1.Text = "1. Можно.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Можно, если Вы управляете такси.";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/6.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какие из указанных знаков запрещают движение водителям мопедов?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    ans3.Text = "3. В и Г.";
                    ans4.Text = "4. Все.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/7.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 5:
                    txtQuestion.Text = "Вы намерены повернуть налево. Где следует остановиться, чтобы уступить дорогу легковому автомобилю?";

                    ans1.Text = "1. Перед знаком.";
                    ans2.Text = "2. Перед перекрестком у линии разметки.";
                    bt2.Tag = "1";
                    ans3.Text = "3. На перекрестке перед прерывистой линией разметки.";
                    ans4.Text = "4. В любом месте по усмотрению водителя.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/8.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 6:
                    txtQuestion.Text = "Что означает мигание зеленого сигнала светофора?";

                    ans1.Text = "1. Предупреждает о неисправности светофора.";
                    ans2.Text = "2. Разрешает движение и информирует о том, что вскоре будет включен запрещающий сигнал.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещает дальнейшее движение.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Водитель обязан подавать сигналы световыми указателями поворота (рукой):";

                    ans1.Text = "1. Перед началом движения или перестроением.";
                    ans2.Text = "2. Перед поворотом или разворотом.";
                    ans3.Text = "3. Перед остановкой.";
                    ans4.Text = "4. Во всех перечисленных случаях.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 8:
                    txtQuestion.Text = "Как Вам следует поступить при повороте направо?";

                    ans1.Text = "1. Перестроиться на правую полосу, затем осуществить поворот.";
                    ans2.Text = "2. Продолжить движение по второй полосе до перекрестка, затем повернуть.";
                    ans3.Text = "3. Возможны оба варианта действий.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/11.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "По какой траектории Вам разрешено выполнить разворот?";

                    ans1.Text = "1. Только по А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только по Б.";
                    ans3.Text = "3. По любой из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/12.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "С какой скоростью Вы можете продолжить движение вне населенного пункта по левой полосе на легковом автомобиле?";

                    ans1.Text = "1. Не более 50 км/ч.";
                    ans2.Text = "2. Не менее 50 км/ч и не более 70 км/ч.";
                    ans3.Text = "3. Не менее 50 км/ч и не более 90 км/ч.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/13.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Можно ли водителю легкового автомобиля выполнить опережение грузовых автомобилей вне населенного пункта по такой траектории?";

                    ans1.Text = "1. Можно.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Можно, если скорость грузовых автомобилей менее 30 км/ч.";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/14.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "В каком случае водителю разрешается поставить автомобиль на стоянку в указанном месте?";

                    ans1.Text = "1. Только если расстояние до сплошной линии разметки не менее 3 м.";
                    ans2.Text = "2. Только если расстояние до края пересекаемой проезжей части не менее 5 м.";
                    ans3.Text = "3. При соблюдении обоих перечисленных условий.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/15.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "При повороте направо Вы должны уступить дорогу:";

                    ans1.Text = "1. Только велосипедисту.";
                    ans2.Text = "2. Только пешеходам.";
                    ans3.Text = "3. Пешеходам и велосипедисту.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Никому.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/16.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены проехать перекресток в прямом направлении. Кому Вы должны уступить дорогу?";

                    ans1.Text = "1. Обоим трамваям.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только трамваю А.";
                    ans3.Text = "3. Только трамваю Б.";
                    ans4.Text = "4. Никому.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/17.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только автобусу.";
                    ans2.Text = "2. Только легковому автомобилю.";
                    ans3.Text = "3. Никому.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/18.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "С какой максимальной скоростью можно продолжить движение за знаком?";

                    ans1.Text = "1. 60 км/ч.";
                    ans2.Text = "2. 50 км/ч.";
                    ans3.Text = "3. 30 км/ч.";
                    ans4.Text = "4. 20 км/ч.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/19.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 17:
                    txtQuestion.Text = "Для перевозки людей на мотоцикле водитель должен иметь водительское удостоверение на право управления транспортными средствами:";

                    ans1.Text = "1. Категории «A» или подкатегории «A1».";
                    ans2.Text = "2. Любой категории или подкатегории в течение 2 и более лет.";
                    ans3.Text = "3. Только категории «A» или подкатегории «A1» в течение 2 и более лет.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "При какой неисправности разрешается эксплуатация транспортного средства?";

                    ans1.Text = "1. Не работают пробки топливных баков.";
                    ans2.Text = "2. Не работает механизм регулировки положения сиденья водителя.";
                    ans3.Text = "3. Не работают устройства обогрева и обдува стекол.";
                    ans4.Text = "4. Не работает стеклоподъемник.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 19:
                    txtQuestion.Text = "В случае, когда правые колеса автомобиля наезжают на неукрепленную влажную обочину, рекомендуется:";

                    ans1.Text = "1. Затормозить и полностью остановиться.";
                    ans2.Text = "2. Затормозить и плавно направить автомобиль на проезжую часть.";
                    ans3.Text = "3. Не прибегая к торможению, плавно направить автомобиль на проезжую часть.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Что понимается под временем реакции водителя?";

                    ans1.Text = "1. Время с момента обнаружения водителем опасности до полной остановки транспортного средства.";
                    ans2.Text = "2. Время с момента обнаружения водителем опасности до начала принятия мер по ее избежанию.";
                    bt2.Tag = "1";
                    ans3.Text = "2. Время с момента обнаружения водителем опасности до начала принятия мер по ее избежанию.";
                    ans4.Text = "3. Время, необходимое для переноса ноги с педали управления подачей топлива на педаль тормоза.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/images/1/white.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

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
