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
    /// Interaction logic for GroepsreizenView.xaml
    /// </summary>
    public partial class GroepsreizenView : Page
    {
        public GroepsreizenView()
        {
            InitializeComponent();
        }

        private void Profiel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AdminPaneel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminView());
        }
    }
}
