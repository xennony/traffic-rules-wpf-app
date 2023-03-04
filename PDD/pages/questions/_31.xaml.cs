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
    public partial class _31 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _31()
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

                if (!MainWindow.globalArray.Contains(31) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(31);
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
                    MainWindow.statisticGlobalArray[30] = 1;
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
                    txtQuestion.Text = "Водительское удостоверение, подтверждающее право на управление транспортными средствами категории «А», подтверждает также право на управление транспортными средствами:";

                    ans1.Text = "1. Подкатегории «А1».";
                    ans2.Text = "2. Подкатегории «В1» с мотоциклетной посадкой или рулем мотоциклетного типа.";
                    ans3.Text = "3. Категории «М».";
                    ans4.Text = "4. Всеми перечисленными транспортными средствами.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 2:
                    txtQuestion.Text = "Какие из указанных знаков информируют о приближении к началу участка дороги со встречным движением?";

                    ans1.Text = "1. Только А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. А и Б.";
                    ans3.Text = "3. Все.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешено ли Вам подъехать к месту своей работы, расположенному в зоне действия этих знаков?";

                    ans1.Text = "1. Разрешено.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешено только в рабочие дни.";
                    ans3.Text = "3. Разрешено только в нерабочие дни.";
                    ans4.Text = "4. Запрещено.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 4:
                    txtQuestion.Text = "О чем информирует Вас данный дорожный знак с желтым фоном?";

                    ans1.Text = "1. Дальнейшее движение возможно только по второй полосе.";
                    ans2.Text = "2. Дальнейшее движение возможно только по проезжей части встречного направления.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Дальнейшее движение возможно только по другой дороге.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Разрешается ли Вам пересекать двойную сплошную линию горизонтальной разметки?";

                    ans1.Text = "1. Разрешается только при выезде из дворов и других прилегающих территорий.";
                    ans2.Text = "2. Разрешается только при обгоне.";
                    ans3.Text = "3. Разрешается только при интенсивном движении.";
                    ans4.Text = "4. Запрещается.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 6:
                    txtQuestion.Text = "О чем информируют Вас стрелки на зеленом сигнале светофора?";

                    ans1.Text = "1. На этом перекрестке всегда запрещен поворот направо.";
                    ans2.Text = "2. Движение направо регулируется дополнительной секцией.";
                    bt2.Tag = "1";
                    ans3.Text = "3. На этом перекрестке разрешен поворот налево из двух полос.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Такой сигнал рукой, подаваемый водителем легкового автомобиля, информирует Вас:";

                    ans1.Text = "1. О его намерении начать движение.";
                    bt1.Tag = "1";
                    ans2.Text = "2. О его просьбе оказать помощь.";
                    ans3.Text = "3. Об имеющейся опасности за поворотом.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "В каком направлении разрешено продолжить движение водителю легкового автомобиля?";

                    ans1.Text = "1. Только по кругу.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только направо.";
                    ans3.Text = "3. В любом направлении из перечисленных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Вам можно продолжить движение на перекрестке:";

                    ans1.Text = "1. Только налево.";
                    ans2.Text = "2. Налево и в обратном направлении.";
                    ans3.Text = "3. В любом направлении.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Движение в населенном пункте со скоростью более 60 км/ч разрешается:";

                    ans1.Text = "1. Только при выполнении обгона.";
                    ans2.Text = "2. Только если установлены дорожные знаки, разрешающие движение со скоростью более 60 км/ч.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "В данной ситуации преимущество имеет:";

                    ans1.Text = "1. Легковой автомобиль, так как он движется на подъем.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Грузовой автомобиль, так как он движется на спуск.";
                    ans3.Text = "3. Грузовой автомобиль, так как препятствие находится на полосе движения легкового автомобиля.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Можно ли Вам поставить автомобиль на стоянку в указанном месте?";

                    ans1.Text = "1. Можно.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Можно только при видимости дороги не менее 100 м.";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Как Вам следует поступить при повороте налево?";

                    ans1.Text = "1. Остановиться у стоп-линии и дождаться сигнала регулировщика, разрешающего поворот.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Выехав на перекресток, остановиться и дождаться сигнала регулировщика, разрешающего поворот.";
                    ans3.Text = "3. Повернуть, уступив дорогу встречному автомобилю.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены проехать перекресток в прямом направлении. Ваши действия?";

                    ans1.Text = "1. Проедете перекресток вместе с трамваем, не уступая дорогу грузовому автомобилю.";
                    ans2.Text = "2. Проедете перекресток, уступив дорогу грузовому автомобилю.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при движении прямо?";

                    ans1.Text = "1. Только мотоциклу.";
                    ans2.Text = "2. Мотоциклу и легковому автомобилю.";
                    ans3.Text = "3. Автобусу и мотоциклу.";
                    ans4.Text = "4. Всем транспортным средствам.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 16:
                    txtQuestion.Text = "Разрешено ли обучать вождению на этой дороге?";

                    ans1.Text = "1. Запрещено.";
                    ans2.Text = "2. Разрешено только при движении по крайней правой полосе проезжей части.";
                    ans3.Text = "3. Разрешено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Можно ли использовать в светлое время суток противотуманные фары вместо ближнего света фар?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, кроме случаев движения в тоннелях и в условиях недостаточной видимости.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Разрешается ли устанавливать на одну ось легкового автомобиля шины с различными рисунками протектора?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только на заднюю ось.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "В случае потери сцепления колес с дорогой из-за образования «водяного клина» водителю следует:";

                    ans1.Text = "1. Увеличить скорость.";
                    ans2.Text = "2. Снизить скорость резким нажатием на педаль тормоза.";
                    ans3.Text = "3. Снизить скорость, применяя торможение двигателем.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Как влияет утомленное состояние водителя на его внимание и реакцию?";

                    ans1.Text = "1. Внимание ослабляется, время реакции уменьшается.";
                    ans2.Text = "2. Внимание ослабляется, время реакции увеличивается.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Внимание и время реакции не изменяются.";
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
