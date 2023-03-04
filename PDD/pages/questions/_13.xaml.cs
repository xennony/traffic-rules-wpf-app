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
    public partial class _13 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _13()
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

                if (!MainWindow.globalArray.Contains(13) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(13);
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
                    MainWindow.statisticGlobalArray[12] = 1;
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
                    txtQuestion.Text = "Соответствуют ли действия водителя Правилам, если он движется посередине дороги?";

                    ans1.Text = "1. Соответствуют.";
                    ans2.Text = "2. Соответствуют, если отсутствуют встречные транспортные средства.";
                    ans3.Text = "3. Не соответствуют.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Как следует поступить, если Вам необходимо развернуться?";

                    ans1.Text = "1. Развернуться на этом перекрестке при отсутствии на нем других транспортных средств.";
                    ans2.Text = "2. Проехать прямо и развернуться за перекрестком.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Проехать прямо и развернуться только на следующем перекрестке.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешена ли Вам стоянка в указанном месте?";

                    ans1.Text = "1. Разрешена.";
                    ans2.Text = "2. Разрешена только с включенной аварийной сигнализацией.";
                    ans3.Text = "3. Запрещена.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Эта табличка распространяет действие установленного с ней знака:";

                    ans1.Text = "1. Только на легковые автомобили.";
                    ans2.Text = "2. На легковые автомобили, а также на грузовые автомобили с разрешенной максимальной массой не более 3,5 т.";
                    bt2.Tag = "1";
                    ans3.Text = "3. На легковые автомобили и мотоциклы.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Какой пешеходный переход обозначает данная разметка?";

                    ans1.Text = "1. Только регулируемый.";
                    ans2.Text = "2. Только нерегулируемый.";
                    ans3.Text = "3. Любой.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Ваши действия в данной ситуации?";

                    ans1.Text = "1. Проедете переезд, убедившись в отсутствии приближающегося поезда.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Остановитесь у светофора, а затем проедете переезд.";
                    ans3.Text = "3. Дождетесь выключения бело-лунного мигающего сигнала и проедете переезд.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Когда может быть прекращена подача сигнала рукой о повороте?";

                    ans1.Text = "1. Непосредственно перед началом маневра.";
                    bt1.Tag = "1";
                    ans2.Text = "2. После начала маневра.";
                    ans3.Text = "3. Только после окончания маневра.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Из какой полосы разрешено въехать на данный перекресток?";

                    ans1.Text = "1. Только из правой.";
                    ans2.Text = "2. Только из левой.";
                    ans3.Text = "3. Из любой.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешается ли Вам выполнить разворот на этом участке дороги?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только при видимости дороги не менее 100 м.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "С какой максимальной скоростью Вы имеете право продолжить движение на легковом автомобиле?";

                    ans1.Text = "1. 60 км/ч.";
                    ans2.Text = "2. 70 км/ч.";
                    ans3.Text = "3. 90 км/ч.";
                    bt3.Tag = "1";
                    ans4.Text = "4. 110 км/ч.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 11:
                    txtQuestion.Text = "Сколько транспортных средств Вам можно обогнать одновременно после проезда пешеходного перехода?";

                    ans1.Text = "1. Только одно.";
                    ans2.Text = "2. Только два.";
                    ans3.Text = "3. Все три.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Разрешено ли Вам остановиться на мосту для посадки пассажира?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, только если Вы управляете такси.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Вы намерены проехать перекресток в прямом направлении. Ваши действия?";

                    ans1.Text = "1. Проедете перекресток первым.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Уступите дорогу трамваю.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Кто из водителей, выполняющих поворот, должен уступить дорогу пешеходам?";

                    ans1.Text = "1. Только водитель легкового автомобиля.";
                    ans2.Text = "2. Только водитель грузового автомобиля.";
                    ans3.Text = "3. Оба.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Можете ли Вы в данной ситуации приступить к повороту налево?";

                    ans1.Text = "1. Можете.";
                    ans2.Text = "2. Можете, только убедившись в том, что не создадите помех встречному автомобилю, выполняющему поворот налево.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Не можете.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Разрешается ли Вам на легковом автомобиле перестроиться вправо, чтобы продолжить движение в прямом направлении?";

                    ans1.Text = "1. Разрешается, если не создадите помех движению маршрутных транспортных средств.";
                    ans2.Text = "2. Разрешается, если Вы управляете легковым такси.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Задние противотуманные фонари можно использовать:";

                    ans1.Text = "1. Только в условиях недостаточной видимости.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только при движении в темное время суток.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "При возникновении какой неисправности запрещено дальнейшее движение транспортного средства даже до места ремонта или стоянки?";

                    ans1.Text = "1. Не работает стеклоподъемник.";
                    ans2.Text = "2. Неисправно рулевое управление.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Неисправен глушитель.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Двигаясь в прямом направлении, Вы внезапно попали на небольшой участок скользкой дороги. Что следует предпринять?";

                    ans1.Text = "1. Плавно затормозить.";
                    ans2.Text = "2. Повернуть, руль, чтобы съехать с этого участка дороги.";
                    ans3.Text = "3. Не менять траектории и скорости движения.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "На какой срок может быть наложен кровоостанавливающий жгут?";

                    ans1.Text = "1. Не более получаса в теплое время года и не более одного часа в холодное время года.";
                    ans2.Text = "2. Не более одного часа в теплое время года и не более получаса в холодное время года.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Время наложения жгута не ограничено.";
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
