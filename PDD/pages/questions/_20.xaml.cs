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
    public partial class _20 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _20()
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

                if (!MainWindow.globalArray.Contains(20) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(20);
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
                    MainWindow.statisticGlobalArray[19] = 1;
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
                    txtQuestion.Text = "Какие условия являются обязательными для оформления документа о дорожно-транспортном происшествии (ДТП) без участия уполномоченных на то сотрудников полиции?";

                    ans1.Text = "1. В результате взаимодействия (столкновения) двух транспортных средств (в том числе с прицепами к ним) вред причинен только им.";
                    ans2.Text = "2. Гражданская ответственность владельцев транспортных средств застрахована в соответствии с законодательством.";
                    ans3.Text = "3. Обстоятельства причинения вреда в связи с повреждением транспортных средств, характер и перечень видимых повреждений зафиксированы в соответствии с правилами обязательного страхования.";
                    ans4.Text = "4. Все перечисленные условия.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 2:
                    txtQuestion.Text = "Можно ли Вам за перекрестком въехать во двор?";

                    ans1.Text = "1. Можно.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Можно, если Вы проживаете в этом доме.";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Разрешается ли Вам остановка за знаком?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается только для посадки (высадки) пассажира.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какие из указанных знаков запрещают дальнейшее движение без остановки?";

                    ans1.Text = "1. А и Г.";
                    ans2.Text = "2. Б и В.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В и Г.";
                    ans4.Text = "4. Все.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 5:
                    txtQuestion.Text = "Чем необходимо руководствоваться, если нанесенные на проезжей части белые и оранжевые линии разметки противоречат друг другу?";

                    ans1.Text = "1. Белыми линиями разметки.";
                    ans2.Text = "2. Оранжевыми линиями разметки.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Правила эту ситуацию не регламентируют.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Вы намеревались проехать перекресток в прямом направлении. Как следует поступить, если Вы не успели заранее перестроиться на левую полосу?";

                    ans1.Text = "1. Остановиться перед стоп-линией и дождаться зеленого сигнала светофора.";
                    ans2.Text = "2. Выехать за стоп-линию, перестроиться на левую полосу и остановиться перед пересекаемой проезжей частью.";
                    ans3.Text = "3. Повернуть направо.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Какой знак используется для обозначения транспортного средства при вынужденной остановке в местах, где с учетом условий видимости оно не может быть своевременно замечено другими водителями?";

                    ans1.Text = "1. А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Б.";
                    ans3.Text = "3. В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Вам можно выполнить поворот налево:";

                    ans1.Text = "1. Только по траектории А.";
                    ans2.Text = "2. Только по траектории Б.";
                    ans3.Text = "3. По любой траектории из указанных.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Разрешается ли Вам выполнить разворот с заездом во двор задним ходом?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается, если при этом не будут созданы помехи другим участникам движения.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Укажите расстояние, под которым в Правилах понимается дистанция:";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только В.";
                    ans4.Text = "4. А и В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 11:
                    txtQuestion.Text = "Можно ли Вам начать обгон грузового автомобиля в данной ситуации?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, только после проезда дорожного знака.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Какой автомобиль разрешено поставить на стоянку указанным на табличке способом?";

                    ans1.Text = "1. Только легковой.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Легковой и грузовой с разрешенной максимальной массой не более 3,5 т.";
                    ans3.Text = "3. Любой.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только встречному автомобилю.";
                    ans2.Text = "2. Только пешеходам.";
                    ans3.Text = "3. Встречному автомобилю и пешеходам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "При повороте направо Вам следует:";

                    ans1.Text = "1. Уступить дорогу легковому автомобилю.";
                    ans2.Text = "2. Проехать перекресток первым.";
                    bt2.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу?";

                    ans1.Text = "1. Автобусу и мотоциклу.";
                    ans2.Text = "2. Легковому автомобилю и автобусу.";
                    ans3.Text = "3. Всем транспортным средствам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "В данной ситуации Вы должны остановиться:";

                    ans1.Text = "1. У знака «Движение без остановки запрещено».";
                    bt1.Tag = "1";
                    ans2.Text = "2. У знака «Однопутная железная дорога».";
                    ans3.Text = "3. За 5 м до ближайшего рельса.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Противотуманные фары и задние противотуманные фонари могут быть включены одновременно:";

                    ans1.Text = "1. Только в тумане.";
                    ans2.Text = "2. В условиях недостаточной видимости.";
                    bt2.Tag = "1";
                    ans3.Text = "3. В условиях ограниченной видимости.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Какие меры административного принуждения предусмотрены за управление транспортным средством, на котором установлены стекла (в том числе покрытые прозрачными цветными пленками), светопропускание которых не соответствует требованиям технического регламента о безопасности колесных транспортных средств?";

                    ans1.Text = "1. Штраф в размере 500 рублей.";
                    ans2.Text = "2. Задержание транспортного средства и штраф в размере 1000 рублей.";
                    bt1.Tag = "1";
                    ans3.Text = "3. Штраф в размере 1500 рублей или лишение права управления транспортными средствами на срок от 1 до 3 месяцев.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "Как правильно произвести экстренное торможение, если автомобиль оборудован антиблокировочной тормозной системой?";

                    ans1.Text = "1. Путем прерывистого нажатия на педаль тормоза.";
                    ans2.Text = "2. Путем нажатия на педаль тормоза до упора и удерживания ее до полной остановки.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Путем использования стояночной тормозной системы.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "При движении по какому участку дороги действие сильного бокового ветра наиболее опасно?";

                    ans1.Text = "1. По закрытому деревьями.";
                    ans2.Text = "2. При выезде с закрытого участка на открытый.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По открытому.";
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
