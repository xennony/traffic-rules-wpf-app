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
    public partial class _11 : Page
    {
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        int questionNumber = 1;

        int i;

        int score;

        bool flag = true;

        bool isFirstAnswer = true;


        ResultWindow resWin = new ResultWindow();


        public _11()
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

                if (!MainWindow.globalArray.Contains(11) && isFirstAnswer)
                {
                    MainWindow.globalArray.Add(11);
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
                    MainWindow.statisticGlobalArray[10] = 1;
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
                    txtQuestion.Text = "Какие транспортные средства относятся к маршрутным транспортным средствам?";

                    ans1.Text = "1. Автобусы (в том числе маломестные, междугородние и школьные).";
                    ans2.Text = "2. Автобусы, троллейбусы и трамваи, предназначенные для перевозки людей и движущиеся по установленному маршруту с обозначенными местами остановок.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Любые транспортные средства, перевозящие пассажиров.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 2:
                    txtQuestion.Text = "Двигаясь в населенном пункте, Вы можете продолжить движение:";

                    ans1.Text = "1. Только в направлении Б.";
                    bt1.Tag = "1";
                    ans2.Text = "2. В направлениях А или Б.";
                    ans3.Text = "3. В любом направлении из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 3:
                    txtQuestion.Text = "Этот знак указывает:";

                    ans1.Text = "1. Расстояние до конца тоннеля.";
                    ans2.Text = "2. Расстояние до места аварийной остановки.";
                    ans3.Text = "3. Направление движения к аварийному выходу и расстояние до него.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 4:
                    txtQuestion.Text = "До какого места действует требование данного знака?";

                    ans1.Text = "1. До ближайшего по ходу движения перекрестка.";
                    ans2.Text = "2. До места установки знака «Конец зоны с ограничением максимальной скорости».";
                    bt2.Tag = "1";
                    ans3.Text = "3. До конца населенного пункта.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 5:
                    txtQuestion.Text = "Эта разметка, нанесенная на полосе движения:";

                    ans1.Text = "1. Предоставляет Вам преимущество при перестроении на правую полосу.";
                    ans2.Text = "2. Информирует Вас о том, что дорога поворачивает направо.";
                    ans3.Text = "3. Предупреждает Вас о приближении к сужению проезжей части.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 6:
                    txtQuestion.Text = "Запрещается выполнять обгон транспортного средства, имеющего нанесенные на наружные поверхности специальные цветографические схемы:";

                    ans1.Text = "1. Только при включении на нем специального звукового сигнала.";
                    ans2.Text = "2. Только при включении на нем проблесковых маячков синего (синего и красного) цвета.";
                    ans3.Text = "3. При наличии обоих перечисленных условий.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 7:
                    txtQuestion.Text = "Обязаны ли Вы в данной ситуации подать сигнал правого поворота?";

                    ans1.Text = "1. Обязаны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Обязаны только в темное время суток.";
                    ans3.Text = "3. Не обязаны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 8:
                    txtQuestion.Text = "По какой траектории Вам разрешено выполнить поворот направо?";

                    ans1.Text = "1. Только по А.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только по Б.";
                    ans3.Text = "3. По любой из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 9:
                    txtQuestion.Text = "Вам можно выполнить разворот:";

                    ans1.Text = "1. Только по траектории А.";
                    ans2.Text = "2. По траекториям А или В.";
                    bt2.Tag = "1";
                    ans3.Text = "3. По любой траектории из указанных.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 10:
                    txtQuestion.Text = "В каких случаях разрешается выезжать за пределы правой полосы, если Вы управляете транспортным средством, скорость которого по техническим причинам не может быть более 40 км/ч?";

                    ans1.Text = "1. Только при перестроении перед поворотом налево либо разворотом.";
                    ans2.Text = "2. Только при обгоне или объезде.";
                    ans3.Text = "3. Во всех перечисленных случаях.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 11:
                    txtQuestion.Text = "Водитель обгоняемого транспортного средства:";

                    ans1.Text = "1. Должен снизить скорость.";
                    ans2.Text = "2. Должен сместиться как можно правее.";
                    ans3.Text = "3. Не должен препятствовать обгону путем повышения скорости движения или иными действиями.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 12:
                    txtQuestion.Text = "Кто из водителей нарушил правила стоянки?";

                    ans1.Text = "1. Оба.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Только водитель автомобиля А.";
                    ans3.Text = "3. Только водитель автомобиля Б.";
                    ans4.Text = "4. Никто не нарушил.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 13:
                    txtQuestion.Text = "Обязаны ли Вы при повороте направо уступить дорогу автомобилю, выполняющему разворот?";

                    ans1.Text = "1. Обязаны.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Не обязаны.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Hidden; bt4.Visibility = Visibility.Hidden;

                    break;

                case 14:
                    txtQuestion.Text = "В каком случае Вы имеете право проехать перекресток первым?";

                    ans1.Text = "1. Только при движении прямо.";
                    ans2.Text = "2. При движении прямо и налево.";
                    bt2.Tag = "1";
                    ans3.Text = "3. При движении прямо, налево и в обратном направлении.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 15:
                    txtQuestion.Text = "Вы намерены продолжить движение прямо. При желтом мигающем сигнале светофора следует:";

                    ans1.Text = "1. Проехать перекресток первым.";
                    bt1.Tag = "1";
                    ans2.Text = "2. Уступить дорогу только грузовому автомобилю.";
                    ans3.Text = "3. Уступить дорогу только трамваю.";
                    ans4.Text = "4. Уступить дорогу обоим транспортным средствам.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 16:
                    txtQuestion.Text = "С какой максимальной скоростью разрешается движение транспортных средств в жилых зонах и на дворовых территориях?";

                    ans1.Text = "1. 10 км/ч.";
                    ans2.Text = "2. 20 км/ч.";
                    bt2.Tag = "1";
                    ans3.Text = "3. 40 км/ч.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 17:
                    txtQuestion.Text = "При движении в темное время суток вне населенных пунктов необходимо использовать:";

                    ans1.Text = "1. Только фары ближнего света.";
                    ans2.Text = "2. Только фары дальнего света.";
                    ans3.Text = "3. Фары ближнего или дальнего света.";
                    bt3.Tag = "1";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 18:
                    txtQuestion.Text = "В каких случаях водители привлекаются к уголовной ответственности за нарушения Правил, повлекшие тяжкие последствия?";

                    ans1.Text = "1. Только при причинении смерти человеку.";
                    ans2.Text = "2. При причинении смерти человеку или тяжкого вреда здоровью человека.";
                    bt2.Tag = "1";
                    ans3.Text = "3. При наличии пострадавшего (вне зависимости от степени тяжести полученных им повреждений) или причинении крупного материального ущерба.";
                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Hidden;

                    break;

                case 19:
                    txtQuestion.Text = "В случае остановки на подъеме (спуске) при наличии тротуара можно предотвратить самопроизвольное скатывание автомобиля, повернув его передние колеса в положение:";

                    ans1.Text = "1. А и Г.";
                    ans2.Text = "2. Б и В.";
                    ans3.Text = "3. А и В.";
                    bt3.Tag = "1";
                    ans4.Text = "4. Б и Г.";

                    pictureBox.Source = new BitmapImage(new Uri("pack://application:,,,/img/Template.jpg"));

                    bt1.Visibility = Visibility.Visible; bt2.Visibility = Visibility.Visible;
                    bt3.Visibility = Visibility.Visible; bt4.Visibility = Visibility.Visible;

                    break;

                case 20:
                    txtQuestion.Text = "Какое расстояние проедет транспортное средство за время, равное среднему времени реакции водителя, при скорости движения около 90 км/час?";

                    ans1.Text = "1. Примерно 15 м.";
                    ans2.Text = "2. Примерно 25 м.";
                    bt2.Tag = "1";
                    ans3.Text = "3. Примерно 35 м.";
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
