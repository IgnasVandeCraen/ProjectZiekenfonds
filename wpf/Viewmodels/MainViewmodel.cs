using models;
using dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Azure;
using System.Globalization;

namespace wpf.Viewmodels
{
    public class MainViewmodel : BaseViewmodel
    {
        private Gebruiker _gebruiker;
        private Uri _currentPage;
        private List<Groepsreis> _lijstGroepsreizen;

        public Gebruiker Gebruiker
        {
            get { return _gebruiker; }
            set { _gebruiker = value; }
        }

        public Uri CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                NotifyPropertyChanged();
            }
        }

        public List<Groepsreis> LijstGroepsreizen
        {
            get { return _lijstGroepsreizen; }
            set 
            {
                _lijstGroepsreizen = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewmodel() {
            CurrentPage = new Uri("pack://application:,,,/Views/GroepsreizenView.xaml");
            LijstGroepsreizen = DatabaseOperations.OphalenGroepreizen();
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public void Uitloggen()
        {
            Gebruiker = null;

            //Login openen
            var loginVM = new LoginViewmodel();

            var loginView = new LoginView();
            loginView.DataContext = loginVM;
            loginView.Show();

            //Main sluiten
            var mainView = Application.Current.Windows.OfType<MainView>().FirstOrDefault();
            if (mainView != null)
            {
                mainView.Close();
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Uitloggen":
                    return true;
                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Uitloggen": Uitloggen(); break;
            }
        }
    }
}