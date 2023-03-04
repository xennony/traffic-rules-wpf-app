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
    public partial class _25 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _25()
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

                if (!MainWindow.globalArray.Contains(25) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(25);
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
                    MainWindow.statisticGlobalArray[24] = 1;
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
                    txtQuestion.Text = "На каком рисунке изображена дорога с разделительной полосой?";

                    ans1.Text = "1. На обоих.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только на правом.";
                    ans3.Text = "3. На обоих рисунках дорога с разделительной полосой не изображена.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Вам разрешено продолжить движение на грузовом автомобиле с разрешенной максимальной массой не более 3,5 т:";

                    ans1.Text = "1. Только прямо.";
                    ans2.Text = "2. Прямо и направо.";
                    ans3.Text = "3. Во всех направлениях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Какие из указанных знаков отменяют все ограничения, введенные ранее запрещающими знаками?";

                    ans1.Text = "1. Только В.";
                    bt1.Tag = "1";
                    ans2.Text = "2. А и Б.";
                    ans3.Text = "3. В и Г.";
                    ans4.Text = "4. Все.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 4:
                    txtQuestion.Text = "Этот знак указывает, что:";

                    ans1.Text = "1. Вы должны повернуть направо или налево.";
                    ans2.Text = "2. На пересекаемой дороге организовано реверсивное движение.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Вправо и влево от перекрестка организовано одностороннее движение.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Какой маневр Вам запрещается выполнить при наличии данной линии разметки?";

                    ans1.Text = "1. Обгон.";
                    ans2.Text = "2. Объезд.";
                    ans3.Text = "3. Разворот.";
                    ans4.Text = "4. Разрешаются все перечисленные маневры.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 6:
                    txtQuestion.Text = "Сигналы такого светофора распространяются:";

                    ans1.Text = "1. Только на трамваи.";
                    ans2.Text = "2. На трамваи, а также другие маршрутные транспортные средства, движущиеся по выделенной для них полосе.";
                    bt2.Tag = "1";
                    ans3.Text = "3. На все маршрутные транспортные средства.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Обязаны ли Вы включить указатели поворота в данной ситуации?";

                    ans1.Text = "1. Обязаны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Обязаны только при наличии на перекрестке других транспортных средств.";
                    ans3.Text = "3. Не обязаны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Кто должен уступить дорогу?";

                    ans1.Text = "1. Водитель легкового автомобиля.";
                    ans2.Text = "2. Водитель грузового автомобиля.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Водитель случайно проехал перекресток. Разрешено ли ему в этой ситуации использовать задний ход, чтобы затем продолжить движение налево?";

                    ans1.Text = "1. Разрешено.";
                    ans2.Text = "2. Разрешено, если при этом не будут созданы помехи для других участников дорожного движения.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Каким автомобилям и в каких случаях разрешается движение вне населенных пунктов со скоростью не более 90 км/ч?";

                    ans1.Text = "1. Легковым автомобилям при буксировке прицепа на автомагистралях.";
                    ans2.Text = "2. Легковым автомобилям и грузовым автомобилям с разрешенной максимальной массой не более 3,5 т на всех дорогах, кроме автомагистралей.";
                    ans3.Text = "3. Всем перечисленным автомобилям в указанных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Можно ли Вам выполнить обгон?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если скорость грузового автомобиля менее 30 км/ч.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Разрешена ли остановка в этом месте?";

                    ans1.Text = "1. Разрешена.";
                    ans2.Text = "2. Разрешена, если расстояние между транспортным средством и сплошной линией разметки не менее 3 м.";
                    ans3.Text = "3. Запрещена.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Значения каких дорожных знаков отменяются сигналами светофора?";

                    ans1.Text = "1. Знаков приоритета.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Запрещающих знаков.";
                    ans3.Text = "3. Предписывающих знаков.";
                    ans4.Text = "4. Всех перечисленных знаков.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 14:
                    txtQuestion.Text = "При повороте направо Вы должны уступить дорогу:";

                    ans1.Text = "1. Только велосипедисту.";
                    ans2.Text = "2. Только пешеходам.";
                    ans3.Text = "3. Пешеходам и велосипедисту.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Вы намерены повернуть налево. Кому Вы обязаны уступить дорогу?";

                    ans1.Text = "1. Никому.";
                    ans2.Text = "2. Только легковому автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Легковому автомобилю и автобусу.";
                    ans4.Text = "4. Всем транспортным средствам.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 16:
                    txtQuestion.Text = "Как Вам следует поступить в данной ситуации?";

                    ans1.Text = "1. Проехать железнодорожный переезд без остановки перед знаком.";
                    ans2.Text = "2. Остановиться перед знаком и продолжить движение сразу же после проезда поезда.";
                    ans3.Text = "3. Остановиться перед знаком и продолжить движение, убедившись в отсутствии приближающегося поезда.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Привлечь внимание водителя обгоняемого автомобиля при движении в населенном пункте в светлое время суток можно:";

                    ans1.Text = "1. Только звуковым сигналом.";
                    ans2.Text = "2. Только кратковременным переключением фар с ближнего света на дальний.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только совместной подачей звукового и светового сигналов.";
                    ans4.Text = "4. Любым из перечисленных способов.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 18:
                    txtQuestion.Text = "В каком случае запрещается эксплуатация транспортного средства?";

                    ans1.Text = "1. Не работает указатель уровня топлива.";
                    ans2.Text = "2. Нарушена регулировка угла опережения зажигания.";
                    ans3.Text = "3. Затруднен пуск двигателя.";
                    ans4.Text = "4. Не работает звуковой сигнал.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 19:
                    txtQuestion.Text = "Как зависит величина тормозного пути транспортного средства от скорости движения?";

                    ans1.Text = "1. Не зависит.";
                    ans2.Text = "2. Увеличивается пропорционально скорости.";
                    ans3.Text = "3. Увеличивается пропорционально квадрату скорости.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Как остановить кровотечение при ранении вены и некрупных артерий?";

                    ans1.Text = "1. Наложить давящую повязку на место ранения.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Наложить жгут выше места ранения.";
                    ans3.Text = "3. Наложить жгут ниже места ранения.";
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
