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
using System.Security.AccessControl;
using System.Windows.Input;
using wpf.Views;

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
        private ObservableCollection<Groepsreis> _lijstGroepsreizen;
        private ObservableCollection<Groepsreis> _lijstGefilterdeReizen;
        private List<Thema> _lijstThemas;
        private string _zoekText;
        private Sorteervolgorde? _datumSorteervolgorde;
        private Sorteervolgorde? _prijsSorteervolgorde;
        private Thema _geselecteerdThema;
        private string _successMessage;
        private string _errorMessage;

        public Gebruiker Gebruiker
        {
            get { return _gebruiker; }
            set { _gebruiker = value; }
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

        public string SuccessMessage
        {
            get { return _successMessage; }
            set
            {
                _successMessage = value;
                NotifyPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewmodel() {
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
        //Uitloggen
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
        //Profiel openen
        public void OpenProfiel()
        {
            if (Gebruiker != null)
            {
                //ProfielViewmodel openen
                var profielVM = new ProfielViewmodel(Gebruiker);

                //ProfielView (page) openen
                var profielView = new ProfielView();
                profielView.DataContext = profielVM;
                var mainView = Application.Current.Windows.OfType<MainView>().FirstOrDefault();
                mainView.mainFrame.Content = profielView;
            }
        }

        //Admin paneel openen
        public void OpenAdmin()
        {
            if (Gebruiker != null && Gebruiker.Admin)
            {
                //AdminViewmodel openen
                var adminVM = new AdminViewmodel();

                //AdminView (page) openen
                var adminView = new AdminView();
                adminView.DataContext = adminVM;
                var mainView = Application.Current.Windows.OfType<MainView>().FirstOrDefault();
                mainView.mainFrame.Content = adminView;
            }
            else
            {
                ErrorMessage = "Je hebt geen admin rechten!";
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

        //Inschrijven
        private void Inschrijven(object parameter)
        {
            if (parameter is Groepsreis gr && Gebruiker != null)
            {
                if (KanInschrijven(gr))
                {
                    Inschrijving inschrijving = new Inschrijving
                    {
                        GroepsreisId = gr.Id,
                        GebruikerId = Gebruiker.Id
                    };

                    int ok = DatabaseOperations.ToevoegenInschrijving(inschrijving);

                    if (ok > 0)
                    {
                        LijstGroepsreizen = DatabaseOperations.OphalenGroepreizen();
                        SuccessMessage = "Je bent ingeschreven!";
                    }
                    else
                    {
                        ErrorMessage = "Er is iets misgelopen";
                    }
                }
            }
            else { ErrorMessage = "Er is iets misgelopen"; }
        }

        private bool KanInschrijven(Groepsreis gr)
        {
            List<string> errors = new List<string>();

            if (Gebruiker.LeeftijdscategorieId != gr.LeeftijdscategorieId)
            {
                errors.Add("Je leeftijdscategorie moet overeenkomen met de leeftijdscategie van de reis");
            }

            if (gr.Startdatum <= DateTime.Now)
            {
                errors.Add("Je bent te laat voor deze reis");
            }

            if (gr.Inschrijvingen.Count >= gr.MaxInschrijvingen)
            {
                errors.Add("Deze reis is al volgeboekt");
            }

            if (gr.Inschrijvingen.Any(i => i.GebruikerId == Gebruiker.Id))
            {
                errors.Add("Je bent al ingeschreven voor deze reis");
            }

            if (errors.Count > 0)
            {
                ErrorMessage = string.Join("\n", errors);
                return false;
            }

            ErrorMessage = "";
            return true;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Uitloggen":
                    return true;
                case "OpenProfiel":
                    return true;
                case "OpenAdmin":
                    return true;
                case "VerwijderFilters":
                    return !(string.IsNullOrWhiteSpace(ZoekText)
                     && DatumSorteervolgorde == null
                     && PrijsSorteervolgorde == null
                     && GeselecteerdThema == null);
                case "Inschrijven":
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
                case "OpenProfiel": OpenProfiel(); break;
                case "OpenAdmin": OpenAdmin(); break;
                case "VerwijderFilters": VerwijderFilters(); break;
                //case "Inschrijven": Inschrijven(); break;
            }
        }
    }
}