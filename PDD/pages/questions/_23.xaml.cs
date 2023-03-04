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
    public partial class _23 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _23()
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

                if (!MainWindow.globalArray.Contains(23) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(23);
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
                    MainWindow.statisticGlobalArray[22] = 1;
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
                    txtQuestion.Text = "Сколько пересечений проезжих частей имеет этот перекресток?";

                    ans1.Text = "1. Одно.";
                    ans2.Text = "2. Два.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Четыре.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Данный дорожный знак:";

                    ans1.Text = "1. Предупреждает о приближении к месту пересечения с трамвайной линией.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Предупреждает о приближении к трамвайной остановке.";
                    ans3.Text = "3. Обязывает Вас остановиться непосредственно перед пересечением с трамвайной линией.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Эти знаки обязывают соблюдать дистанцию:";

                    ans1.Text = "1. Менее 70 м на протяжении 100 м.";
                    ans2.Text = "2. Не менее 70 м на протяжении 100 м.";
                    bt2.Tag = "1";
                    ans3.Text = "3. От 70 м до 100 м.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "В каких направлениях Вам разрешено продолжить движение?";

                    ans1.Text = "1. Только прямо.";
                    ans2.Text = "2. Прямо или налево.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Прямо, налево или в обратном направлении.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Разрешается ли Вам поставить автомобиль на стоянку в этом месте?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только с частичным заездом на тротуар.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Вам можно продолжить движение:";

                    ans1.Text = "1. Только по траектории А.";
                    ans2.Text = "2. Только по траектории Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Обязан ли водитель подавать сигналы указателями поворота при начале движения в жилой зоне, обозначенной соответствующим знаком?";

                    ans1.Text = "1. Обязан.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Обязан только при наличии в непосредственной близости пешеходов.";
                    ans3.Text = "3. Не обязан.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "По какой траектории Вам разрешено продолжить движение?";

                    ans1.Text = "1. Только по А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. По А или Б.";
                    ans3.Text = "3. По любой из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "На этом участке дороги Вам запрещается:";

                    ans1.Text = "1. Только разворот.";
                    ans2.Text = "2. Только обгон или объезд.";
                    ans3.Text = "3. Только перестроение на левую полосу с последующей остановкой на обочине.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Любой маневр из перечисленных.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 10:
                    txtQuestion.Text = "Разрешается ли Вам выехать на трамвайные пути встречного направления в данной ситуации?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только при отсутствии встречного трамвая.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "В данной ситуации Вы:";

                    ans1.Text = "1. Должны уступить дорогу, так как препятствие находится на Вашей полосе движения.";
                    ans2.Text = "2. Должны уступить дорогу, так как встречный автомобиль движется на спуск.";
                    ans3.Text = "3. Имеете право проехать первым, так как Вы движетесь на подъем.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "На каком расстоянии от знака Вам разрешено поставить автомобиль на стоянку?";

                    ans1.Text = "1. Не менее 5 м.";
                    ans2.Text = "2. Не менее 10 м.";
                    ans3.Text = "3. Не менее 15 м.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Как следует поступить в этой ситуации, если Вам необходимо повернуть направо?";

                    ans1.Text = "1. Остановиться и дождаться другого сигнала регулировщика.";
                    ans2.Text = "2. Повернуть направо, уступив дорогу пешеходам.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Повернуть направо, имея преимущество в движении перед пешеходами.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Вы намерены проехать перекресток в прямом направлении. В данной ситуации:";

                    ans1.Text = "1. Вы обязаны уступить дорогу легковому автомобилю.";
                    ans2.Text = "2. Вы имеете право проехать перекресток первым.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Обоим транспортным средствам.";
                    ans2.Text = "2. Только автобусу.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только легковому автомобилю.";
                    ans4.Text = "4. Никому.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 16:
                    txtQuestion.Text = "Кто из водителей правильно остановился для высадки пассажиров?";

                    ans1.Text = "1. Только водитель автомобиля А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только водитель автомобиля В.";
                    ans3.Text = "3. Водители автомобилей А и Б.";
                    ans4.Text = "4. Водители автомобилей А и В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 17:
                    txtQuestion.Text = "В каком случае при движении в светлое время суток недостаточно включения дневных ходовых огней?";

                    ans1.Text = "1. Только при видимости дороги менее 300 м в условиях тумана, дождя или снегопада.";
                    ans2.Text = "2. Только при движении в тоннелях.";
                    ans3.Text = "3. В обоих перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Что требуется для возврата водительского удостоверения после истечения срока лишения права управления, назначенного за оставление водителем в нарушение Правил дорожного движения места дорожно-транспортного происшествия, участником которого он являлся?";

                    ans1.Text = "1. Только проверка знания водителем Правил дорожного движения.";
                    ans2.Text = "2. Проверка знания водителем Правил дорожного движения и уплата наложенных на него штрафов за административные правонарушения в области дорожного движения.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Проверка знания водителем Правил дорожного движения и медицинское освидетельствование его на наличие медицинских противопоказаний к управлению транспортным средством.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Чем опасно длительное торможение с выключенными передачей или сцеплением на крутом спуске?";

                    ans1.Text = "1. Значительно увеличивается износ протектора шин.";
                    ans2.Text = "2. Повышается износ деталей тормозных механизмов.";
                    ans3.Text = "3. Перегреваются тормозные механизмы и уменьшается эффективность торможения.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Как изменяется поле зрения водителя с увеличением скорости движения?";

                    ans1.Text = "1. Расширяется.";
                    ans2.Text = "2. Не изменяется.";
                    ans3.Text = "3. Сужается.";
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
