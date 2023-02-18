using PDD.pages.sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;using System.Threading.Tasks;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PDD.pages
{
    /// <summary>
    /// Логика взаимодействия для Theory.xaml
    /// </summary>
    public partial class Theory : Page
    {
        public Theory()
        {
            InitializeComponent();


        }

        private void GeneralProvisionsItem_Selected(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section1());
        }

        private void Section2Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section2());
        }

        private void Section3Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section3());
        }

        private void Section4Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section4());
        }

        private void Section5Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section5());
        }

        private void Section6Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section6());
        }

        private void Section7Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section7());
        }

        private void Section8Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section8());

        }

        private void Section9Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section9());
        }

        private void Section10Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section10());
        }

        private void Section11Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section11());
        }

        private void Section12Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section12());
        }

        private void Section13Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section13());
        }

        private void Section14Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section14());
        }

        private void Section15Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section15());
        }

        private void Section16Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section16());

        }

        private void Section17Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section17());
        }

        private void Section18Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section18());
        }

        private void Section19Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section19());
        }

        private void Section20Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section20());

        }

        private void Section21Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section21());
        }

        private void Section22Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section22());
        }

        private void Section23Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section23());
        }

        private void Section24Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section24());
        }

        private void Section25Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section25());
        }

        private void Section26Page(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Section26());

        }

        private void backButton2_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(null);
        }

        private void SearchBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ScrollViewerBox.Visibility = Visibility.Visible;
            SearchStack.Visibility = Visibility.Visible;
            frame.Visibility = Visibility.Hidden;

        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Section1 sec1 = new Section1();
            Section2 sec2 = new Section2();
            Section3 sec3 = new Section3();
            Section4 sec4 = new Section4();
            Section5 sec5 = new Section5();
            Section6 sec6 = new Section6();
            Section7 sec7 = new Section7();
            Section8 sec8 = new Section8();
            Section9 sec9 = new Section9();
            Section10 sec10 = new Section10();
            Section11 sec11 = new Section11();
            Section12 sec12 = new Section12();
            Section13 sec13 = new Section13();
            Section14 sec14 = new Section14();
            Section15 sec15 = new Section15();
            Section16 sec16 = new Section16();
            Section17 sec17 = new Section17();
            Section18 sec18 = new Section18();
            Section19 sec19 = new Section19();
            Section20 sec20 = new Section20();
            Section21 sec21 = new Section21();
            Section22 sec22 = new Section22();
            Section23 sec23 = new Section23();
            Section24 sec24 = new Section24();
            Section25 sec25 = new Section25();
            Section26 sec26 = new Section26();

            string search = SearchBox.Text.ToLower();

            SearchStack.Children.Clear();



            foreach (var item in sec1.SctackPanelSec1.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                item.Text.ToLower();

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;

                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec2.SctackPanelSec2.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec3.SctackPanelSec3.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec4.SctackPanelSec4.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec5.SctackPanelSec5.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec6.SctackPanelSec6.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec7.SctackPanelSec7.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec8.SctackPanelSec8.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec9.SctackPanelSec9.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec10.SctackPanelSec10.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec11.SctackPanelSec11.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec12.SctackPanelSec12.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec13.SctackPanelSec13.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec14.SctackPanelSec14.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec15.SctackPanelSec15.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec16.SctackPanelSec16.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec17.SctackPanelSec17.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec18.SctackPanelSec18.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec19.SctackPanelSec19.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec20.SctackPanelSec20.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec21.SctackPanelSec21.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec22.SctackPanelSec22.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec23.SctackPanelSec23.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec24.SctackPanelSec24.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec25.SctackPanelSec25.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

            foreach (var item in sec26.SctackPanelSec26.Children.OfType<TextBlock>().ToList())
            {
                if (search == "")
                {
                    break;
                }

                if (item.Text.Contains(search))
                {
                    var a = new TextBlock();
                    a.TextWrapping = TextWrapping.Wrap;
                    a.Text = item.Text;
                    SearchStack.Children.Add(a);
                    SearchStack.Children.Add(new Separator());
                }
            }

        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScrollViewerBox.Visibility = Visibility.Hidden;
            SearchStack.Visibility = Visibility.Hidden;
            frame.Visibility = Visibility.Visible;

        }
    }
}
