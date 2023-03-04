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
    public partial class _17 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _17()
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

                if (!MainWindow.globalArray.Contains(17) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(17);
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
                    MainWindow.statisticGlobalArray[16] = 1;
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
                    txtQuestion.Text = "Являются ли тротуары и обочины частью дороги?";

                    ans1.Text = "1. Являются.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Являются только обочины.";
                    ans3.Text = "3. Не являются.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "На каком расстоянии до неровного участка дороги устанавливается этот знак вне населенного пункта?";

                    ans1.Text = "1. 150-300 м.";
                    bt1.Tag = "1";
                    ans2.Text = "2. 50-100 м.";
                    ans3.Text = "3. Непосредственно перед неровным участком дороги.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Требования каких знаков из указанных вступают в силу непосредственно в том месте, где они установлены?";

                    ans1.Text = "1. Только Б.";
                    ans2.Text = "2. А и Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Всех.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Вам разрешено продолжить движение:";

                    ans1.Text = "1. По траекториям Б или В.";
                    ans2.Text = "2. По траекториям А или В.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Можно ли Вам выполнить обгон при наличии данной разметки?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если скорость трактора менее 30 км/ч.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "В каком месте Вам следует остановиться?";

                    ans1.Text = "1. Перед светофором.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Перед пересекаемой проезжей частью.";
                    ans3.Text = "3. В любом из перечисленных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "На каком расстоянии от транспортного средства должен быть выставлен знак аварийной остановки в данной ситуации?";

                    ans1.Text = "1. Не менее 10 м.";
                    ans2.Text = "2. Не менее 15 м.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Не менее 20 м.";
                    ans4.Text = "4. Не менее 30 м.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 8:
                    txtQuestion.Text = "Разрешено ли Вам выполнить поворот направо в данной ситуации?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если при этом не будут созданы помехи транспортным средствам, движущимся с других направлений.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Можно ли Вам выполнить разворот по данной траектории?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если ширина проезжей части недостаточна для выполнения маневра из крайнего левого положения.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Разрешается ли водителю движение со слишком малой скоростью?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается, если при этом не создаются помехи другим транспортным средствам.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Можно ли Вам начать обгон в населенном пункте?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если обгон будет завершен до переезда.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "В каком месте на данном участке дороги Вам разрешено поставить автомобиль на длительную стоянку?";

                    ans1.Text = "1. В любом месте на обочине.";
                    ans2.Text = "2. Только через 500 м на специальной площадке.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Во всех перечисленных местах.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Обязаны ли Вы уступить дорогу автобусу?";

                    ans1.Text = "1. Обязаны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Не обязаны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены повернуть налево. Ваши действия?";

                    ans1.Text = "1. Уступите дорогу обоим грузовым автомобилям.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Выехав на перекресток, уступите дорогу встречному грузовому автомобилю и завершите поворот.";
                    ans3.Text = "3. Проедете перекресток первым.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "После въезда на этот перекресток:";

                    ans1.Text = "1. Вы должны уступить дорогу легковому автомобилю, въезжающему на него";
                    ans2.Text = "2. Вы будете иметь преимущество перед легковым автомобилем, въезжающим на него.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Вам следует действовать по взаимной договоренности с водителем легкового автомобиля.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Кто из водителей должен уступить дорогу трамваю?";

                    ans1.Text = "1. Оба.";
                    ans2.Text = "2. Только водитель грузового автомобиля.";
                    ans3.Text = "3. Только водитель легкового автомобиля.";
                    ans4.Text = "4. Никто из водителей.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 17:
                    txtQuestion.Text = "Можно ли буксировать автомобиль с недействующей тормозной системой, если фактическая масса этого автомобиля превышает половину фактической массы Вашего автомобиля?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно только при скорости буксировки не более 30 км/ч.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "При совершении административного правонарушения, влекущего задержание транспортного средства, оно задерживается до:";

                    ans1.Text = "1. Составления протокола об административном правонарушении.";
                    ans2.Text = "2. Устранения причины задержания.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Рассмотрения дела об административном правонарушении.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Как изменяется длина тормозного пути легкового автомобиля при движении с прицепом, не имеющим тормозной системы?";

                    ans1.Text = "1. Уменьшается, так как прицеп оказывает дополнительное сопротивление движению.";
                    ans2.Text = "2. Не изменяется.";
                    ans3.Text = "3. Увеличивается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "В темное время суток и в пасмурную погоду скорость встречного автомобиля воспринимается:";

                    ans1.Text = "1. Ниже, чем в действительности.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Восприятие скорости не меняется.";
                    ans3.Text = "3. Выше, чем в действительности.";
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
