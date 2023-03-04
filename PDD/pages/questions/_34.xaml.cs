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
    public partial class _34 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _34()
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

                if (!MainWindow.globalArray.Contains(34) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(34);
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
                    MainWindow.statisticGlobalArray[33] = 1;
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
                    txtQuestion.Text = "Главная дорога показана:";

                    ans1.Text = "1. Только на левом верхнем рисунке.";
                    ans2.Text = "2. Только на правом верхнем рисунке.";
                    ans3.Text = "3. На обоих верхних рисунках.";
                    bt3.Tag = "1";
                    ans4.Text = "4. На всех рисунках.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 2:
                    txtQuestion.Text = "На каком расстоянии до скользкого участка дороги устанавливается данный знак в населенном пункте?";

                    ans1.Text = "1. 150-300 м.";
                    ans2.Text = "2. 50-100 м.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Непосредственно перед началом скользкого участка.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Остановка в зоне действия этого знака разрешена:";

                    ans1.Text = "1. Только такси с включенным таксометром.";
                    ans2.Text = "2. Только автомобилям, на которых установлен опознавательный знак «Инвалид».";
                    bt2.Tag = "1";
                    ans3.Text = "3. Всем перечисленным транспортным средствам.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Какие из указанных знаков используются для обозначения кемпинга?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. Только Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Только В.";
                    ans4.Text = "4. Б и В.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 5:
                    txtQuestion.Text = "Если реверсивные светофоры выключились, Вам следует:";

                    ans1.Text = "1. Немедленно перестроиться вправо на соседнюю полосу.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Продолжить движение по полосе только до перекрестка.";
                    ans3.Text = "3. При отсутствии встречных транспортных средств продолжить движение по полосе.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Вам разрешено продолжить движение:";

                    ans1.Text = "1. Только налево.";
                    ans2.Text = "2. Только в обратном направлении.";
                    ans3.Text = "3. Налево и в обратном направлении.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Как необходимо обозначить буксируемый автомобиль при отсутствии или неисправности аварийной сигнализации?";

                    ans1.Text = "1. Установить на задней части буксируемого автомобиля знак аварийной остановки.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Включить габаритные огни.";
                    ans3.Text = "3. Включить задний противотуманный фонарь.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "Можно ли водителю легкового автомобиля в данной ситуации начать движение от тротуара?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если при этом не будут созданы помехи грузовому автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Нельзя.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Водитель случайно проехал нужный въезд во двор. Разрешается ли ему в этой ситуации использовать задний ход, чтобы затем повернуть направо?";

                    ans1.Text = "1. Разрешается.";
                    ans2.Text = "2. Разрешается, если при этом не будут созданы помехи движению маршрутных транспортных средств.";
                    ans3.Text = "3. Запрещается.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Кто из водителей мопедов занял правильное положение на полосе движения?";

                    ans1.Text = "1. Только водитель мопеда А.";
                    ans2.Text = "2. Только водитель мопеда Б.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Оба.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Можно ли Вам продолжить движение по средней полосе после опережения автомобиля, движущегося по правой полосе?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно только при отсутствии встречного транспорта.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Водители каких автомобилей нарушили правила остановки?";

                    ans1.Text = "1. Только автомобиля А.";
                    ans2.Text = "2. Автомобилей А и Б.";
                    ans3.Text = "3. Автомобилей А и В.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Всех автомобилей.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "Как Вам следует поступить при движении в прямом направлении?";

                    ans1.Text = "1. Проехать перекресток первым.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Уступить дорогу трамваю.";
                    ans3.Text = "3. Дождаться другого сигнала регулировщика.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только мотоциклу.";
                    ans2.Text = "2. Только легковому автомобилю.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Никому.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Вы намерены повернуть налево. Ваши действия?";

                    ans1.Text = "1. Уступите дорогу обоим транспортным средствам.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Уступите дорогу только легковому автомобилю.";
                    ans3.Text = "3. Уступите дорогу только автобусу.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Сигналом остановки для машиниста поезда служит следующее расположение руки или рук (днем с лоскутом яркой материи либо каким-нибудь хорошо видимым предметом, ночью — с факелом или фонарем):";

                    ans1.Text = "1. Вытянутые в стороны руки.";
                    ans2.Text = "2. Круговое движение руки.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Поднятая вверх правая рука.";
                    ans4.Text = "4. Поднятые вверх обе руки.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 17:
                    txtQuestion.Text = "В тоннеле с искусственным освещением должны быть включены:";

                    ans1.Text = "1. Фары ближнего света или габаритные огни.";
                    ans2.Text = "2. Фары ближнего света или дневные ходовые огни.";
                    ans3.Text = "3. Фары ближнего или дальнего света.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Уголовная ответственность предусмотрена за управление транспортным средством, не повлекшее причинение тяжкого вреда здоровью или смерть человека, лицом, находящимся в состоянии опьянения, если оно ранее было подвергнуто административному наказанию:";

                    ans1.Text = "1. За управление транспортным средством в состоянии опьянения.";
                    ans2.Text = "2. За невыполнение законного требования уполномоченного должностного лица о прохождении медицинского освидетельствования на состояние опьянения.";
                    ans3.Text = "3. За совершение любого из перечисленных правонарушений.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "При движении по двухполосной дороге за грузовым автомобилем у Вас появилась возможность совершить обгон. Ваши действия?";

                    ans1.Text = "1. Максимально приблизитесь к обгоняемому автомобилю, затем перестроитесь на полосу встречного движения и завершите маневр.";
                    ans2.Text = "2. Перестроитесь на полосу встречного движения, после чего произведете сближение с обгоняемым транспортным средством и завершите маневр.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Допустимы оба варианта действий.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Каким образом проводится сердечно-легочная реанимация пострадавшего?";

                    ans1.Text = "1. Искусственное дыхание и давление руками на грудину пострадавшего: вначале 1 вдох методом «Рот ко рту», затем 15 надавливаний на грудину.";
                    ans2.Text = "2. Давление руками на грудину пострадавшего и искусственное дыхание: вначале 15 надавливаний на грудину, затем 1 вдох методом «Рот ко рту».";
                    ans3.Text = "3. Давление руками на грудину пострадавшего и искусственное дыхание: вначале 30 надавливаний на грудину, затем 2 вдоха методом «Рот ко рту».";
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
