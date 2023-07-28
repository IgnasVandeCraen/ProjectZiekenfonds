using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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

namespace wpf
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            testFrame.Navigate(new Uri("SecondPage.xaml", UriKind.Relative));
        }

        private void GoToSecondPage_Click(object sender, RoutedEventArgs e)
        {
            SecondPage secondPage = new SecondPage();

            testFrame.NavigationService.Navigate(secondPage);
        }
        private void GoToThirdPage_Click(object sender, RoutedEventArgs e)
        {
            ThirdPage thirdPage = new ThirdPage();

            testFrame.NavigationService.Navigate(thirdPage);
        }
    }
}
