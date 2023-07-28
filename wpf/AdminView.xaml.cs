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

namespace wpf
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Page
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void Terug_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroepsreizenView());
        }

        private void Gebruikers_Click(object sender, RoutedEventArgs e)
        {
            adminFrame.NavigationService.Navigate(new AdminGebruikersView());
        }

        private void Reizen_Click(object sender, RoutedEventArgs e)
        {
            adminFrame.NavigationService.Navigate(new ThirdPage());
        }
    }
}
