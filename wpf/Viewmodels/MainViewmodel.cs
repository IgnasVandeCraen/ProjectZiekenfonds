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
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;

namespace wpf.Viewmodels
{
    public class MainViewmodel : BaseViewmodel
    {
        public enum Sorteervolgorde
        {
            Oplopend,
            Aflopend
        }

        private Gebruiker _gebruiker;
        private Uri _currentPage;
        private ObservableCollection<Groepsreis> _lijstGroepsreizen;
        private ObservableCollection<Groepsreis> _lijstGefilterdeReizen;
        private List<Thema> _lijstThemas;
        private string _zoekText;
        private Sorteervolgorde? _datumSorteervolgorde;
        private Sorteervolgorde? _prijsSorteervolgorde;
        private Thema _geselecteerdThema;

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

        public ObservableCollection<Groepsreis> LijstGroepsreizen
        {
            get { return _lijstGroepsreizen; }
            set 
            {
                _lijstGroepsreizen = value;
                FilterReizen();
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Groepsreis> LijstGefilterdeReizen
        {
            get { return _lijstGefilterdeReizen; }
            set
            {
                _lijstGefilterdeReizen = value;
                NotifyPropertyChanged();
            }
        }

        public List<Thema> LijstThemas
        {
            get { return _lijstThemas; }
            set
            {
                _lijstThemas = value;
            }
        }

        public string ZoekText
        {
            get { return _zoekText;  }
            set 
            {
                _zoekText = value;
                FilterReizen();
                NotifyPropertyChanged();
            }
        }

        public Array SorteervolgordeWaardes => Enum.GetValues(typeof(Sorteervolgorde));

        public Sorteervolgorde? DatumSorteervolgorde
        {
            get { return _datumSorteervolgorde; }
            set
            {
                _datumSorteervolgorde = value;
                FilterReizen();
                NotifyPropertyChanged();
            }
        }

        public Sorteervolgorde? PrijsSorteervolgorde
        {
            get { return _prijsSorteervolgorde; }
            set
            {
                _prijsSorteervolgorde = value;
                FilterReizen();
                NotifyPropertyChanged();
            }
        }

        public Thema GeselecteerdThema
        {
            get { return _geselecteerdThema; }
            set
            {
                _geselecteerdThema = value;
                FilterReizen();
                NotifyPropertyChanged();
            }
        }

        public MainViewmodel() {
            CurrentPage = new Uri("pack://application:,,,/Views/GroepsreizenView.xaml");
            LijstGroepsreizen = DatabaseOperations.OphalenGroepreizen();
            LijstThemas = DatabaseOperations.OphalenThemas();
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
        //Filters
        private void FilterReizen()
        {
            var gefilterdeReizen = LijstGroepsreizen.ToList();

            //Zoeken
            if (!string.IsNullOrWhiteSpace(ZoekText))
            {
                string zoekTextLowerCase = ZoekText.ToLower();
                gefilterdeReizen = gefilterdeReizen.Where(gr => gr.Naam.ToLower().Contains(zoekTextLowerCase)).ToList();
            }

            //Datum
            if (DatumSorteervolgorde == Sorteervolgorde.Oplopend)
            {
                gefilterdeReizen = gefilterdeReizen.OrderBy(gr => gr.Startdatum).ToList();
            }
            else if (DatumSorteervolgorde == Sorteervolgorde.Aflopend)
            {
                gefilterdeReizen = gefilterdeReizen.OrderByDescending(gr => gr.Startdatum).ToList();
            }

            //Prijs
            if (PrijsSorteervolgorde == Sorteervolgorde.Oplopend)
            {
                gefilterdeReizen = gefilterdeReizen.OrderBy(gr => gr.Prijs).ToList();
            }
            else if (PrijsSorteervolgorde == Sorteervolgorde.Aflopend)
            {
                gefilterdeReizen = gefilterdeReizen.OrderByDescending(gr => gr.Prijs).ToList();
            }

            //Thema
            if (GeselecteerdThema != null)
            {
                gefilterdeReizen = gefilterdeReizen.Where(gr => gr.Thema.Equals(GeselecteerdThema)).ToList();
            }

            LijstGefilterdeReizen = new ObservableCollection<Groepsreis>(gefilterdeReizen);
        }
        private void VerwijderFilters()
        {
            ZoekText = null;
            DatumSorteervolgorde = null;
            PrijsSorteervolgorde = null;
            GeselecteerdThema = null;

            FilterReizen();
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Uitloggen":
                    return true;
                case "VerwijderFilters":
                    return !(string.IsNullOrWhiteSpace(ZoekText)
                     && DatumSorteervolgorde == null
                     && PrijsSorteervolgorde == null
                     && GeselecteerdThema == null);
                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Uitloggen": Uitloggen(); break;
                case "VerwijderFilters": VerwijderFilters(); break;
            }
        }
    }
}