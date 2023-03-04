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
    public partial class _40 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;



        ResultWindow resWin = new ResultWindow();


        public _40()
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

                if (!MainWindow.globalArray.Contains(40) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(40);
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
                    MainWindow.statisticGlobalArray[39] = 1;
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
                    txtQuestion.Text = "По требованию каких лиц необходимо передавать для проверки водительское удостоверение на право управления транспортным средством соответствующей категории или подкатегории и представлять для проверки страховой полис обязательного страхования гражданской ответственности на бумажном носителе или в виде электронного документа либо его копии на бумажном носителе?";

                    ans1.Text = "1. Сотрудника полиции.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Сотрудника Военной автомобильной инспекции.";
                    ans3.Text = "3. Любого регулировщика.";
                    ans4.Text = "4. Всех перечисленных лиц.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 2:
                    txtQuestion.Text = "Вам разрешено продолжить движение на перекрестке:";

                    ans1.Text = "1. Только прямо.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Прямо и налево.";
                    ans3.Text = "3. Прямо и в обратном направлении.";
                    ans4.Text = "4. В любом направлении.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 3:
                    txtQuestion.Text = "Какие из указанных знаков разрешают разворот?";

                    ans1.Text = "1. Только А.";
                    ans2.Text = "2. А и В.";
                    ans3.Text = "3. Все.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "Поставить на стоянку указанным на табличке способом можно:";

                    ans1.Text = "1. Только легковые автомобили и мотоциклы.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Все транспортные средства, кроме грузовых автомобилей с разрешенной максимальной массой более 3,5 т.";
                    ans3.Text = "3. Любые транспортные средства.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Разметкой в виде буквы «А» обозначают:";

                    ans1.Text = "1. Специальную полосу для любых автобусов.";
                    ans2.Text = "2. Специальную полосу для маршрутных транспортных средств.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Место остановки и стоянки любых автобусов.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Разрешено ли Вам движение?";

                    ans1.Text = "1. Разрешено прямо и направо.";
                    ans2.Text = "2. Разрешено только направо.";
                    ans3.Text = "3. Запрещено.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Какой опознавательный знак должен быть закреплен на задней части буксируемого механического транспортного средства при отсутствии или неисправности аварийной сигнализации?";

                    ans1.Text = "1. А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Б.";
                    ans3.Text = "3. В.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "На перекрестке Вы намерены повернуть направо. Как Вам следует поступить?";

                    ans1.Text = "1. Перестроиться на правую полосу, затем осуществить поворот.";
                    ans2.Text = "2. Продолжить движение по левой полосе до перекрестка, затем повернуть.";
                    ans3.Text = "3. Возможны оба варианта действий.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Кто должен уступить дорогу при одновременном развороте?";

                    ans1.Text = "1. Водитель автобуса.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Водитель легкового автомобиля.";
                    ans3.Text = "3. В данной ситуации водителям следует действовать по взаимной договоренности.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "Кто из водителей занял правильное положение на полосе движения?";

                    ans1.Text = "1. Оба.";
                    ans2.Text = "2. Только водитель мопеда, занимающего левое положение на полосе движения.";
                    ans3.Text = "3. Только водитель мотоцикла, занимающего правое положение на полосе движения.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Никто из водителей.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 11:
                    txtQuestion.Text = "Как Вам следует поступить в данной ситуации?";

                    ans1.Text = "1. Проехать первым.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Использовать обочину для встречного разъезда.";
                    ans3.Text = "3. Уступить дорогу грузовому автомобилю.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Нарушил ли водитель автомобиля правила остановки?";

                    ans1.Text = "1. Нарушил.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Нарушил, если расстояние от автомобиля до линии разметки менее 3 м.";
                    ans3.Text = "3. Не нарушил.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 13:
                    txtQuestion.Text = "Вы намерены повернуть направо. Ваши действия?";

                    ans1.Text = "1. Проедете перекресток первым.";
                    ans2.Text = "2. Уступите дорогу только трамваю А.";
                    ans3.Text = "3. Уступите дорогу только трамваю Б.";
                    ans4.Text = "4. Уступите дорогу обоим трамваям.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 14:
                    txtQuestion.Text = "При движении прямо Вы:";

                    ans1.Text = "1. Имеете преимущество.";
                    ans2.Text = "2. Должны уступить дорогу только мотоциклу.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Должны уступить дорогу только автомобилю.";
                    ans4.Text = "4. Должны уступить дорогу обоим транспортным средствам.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 15:
                    txtQuestion.Text = "Кому Вы обязаны уступить дорогу при повороте налево?";

                    ans1.Text = "1. Только автобусу.";
                    ans2.Text = "2. Только грузовому автомобилю.";
                    ans3.Text = "3. Обоим транспортным средствам.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 16:
                    txtQuestion.Text = "Можно ли Вам въехать на железнодорожный переезд?";

                    ans1.Text = "1. Можно.";
                    ans2.Text = "2. Можно, если отсутствует приближающийся поезд.";
                    ans3.Text = "3. Нельзя.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "Разрешается ли перевозка людей в салоне легкового автомобиля, буксирующего неисправное транспортное средство?";

                    ans1.Text = "1. Разрешается.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Разрешается только при буксировке на жесткой сцепке.";
                    ans3.Text = "3. Запрещается.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "Водитель, в отношении которого имеются достаточные основания полагать, что он находится в состоянии опьянения, направляется на медицинское освидетельствование на состояние опьянения:";

                    ans1.Text = "1. При отказе от прохождения освидетельствования на состояние алкогольного опьянения.";
                    ans2.Text = "2. При несогласии с результатами освидетельствования на состояние алкогольного опьянения.";
                    ans3.Text = "3. При наличии достаточных оснований полагать, что водитель находится в состоянии опьянения, и отрицательном результате освидетельствования на состояние алкогольного опьянения.";
                    ans4.Text = "4. Во всех перечисленных случаях.";

                    bt4.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 19:
                    txtQuestion.Text = "Как следует поступить водителю при посадке в автомобиль, стоящий у тротуара или на обочине?";

                    ans1.Text = "1. Обойти автомобиль спереди.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Обойти автомобиль сзади.";
                    ans3.Text = "3. Допустимы оба варианта действий.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 20:
                    txtQuestion.Text = "Какова первая помощь при наличии признаков поверхностного термического ожога (покраснение и отек кожи, образование на месте ожога пузырей, наполненных прозрачной жидкостью, сильная боль)?";

                    ans1.Text = "1. Полить ожоговую поверхность холодной водой, накрыть стерильной салфеткой и туго забинтовать.";
                    ans2.Text = "2. Вскрыть ожоговые пузыри, очистить ожоговую поверхность от остатков одежды, накрыть стерильной салфеткой (не бинтовать), по возможности приложить холод, поить пострадавшего водой.";
                    ans3.Text = "3. Охладить ожоговую поверхность водой в течение 20 минут. Ожоговые пузыри не вскрывать, остатки одежды с обожженной поверхности не удалять, место ожога накрыть стерильной салфеткой (не бинтовать), по возможности приложить холод и поить пострадавшего водой.";
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
