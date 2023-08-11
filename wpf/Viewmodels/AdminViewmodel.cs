using dal;
using models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpf.Viewmodels
{
    public class AdminViewmodel : BaseViewmodel
    {
        private ObservableCollection<Groepsreis> _lijstGroepsreizen;
        private Groepsreis _geselecteerdeGroepreis;
        private List<Leeftijdscategorie> _lijstLeeftijdscategorieen;
        private List<Bestemming> _lijstBestemmingen;
        private List<Thema> _lijstThemas;
        private bool _kanToevoegen;
        private bool _kanAanpassen;
        private string _successMessage;
        private string _errorMessage;

        public ObservableCollection<Groepsreis> LijstGroepsreizen
        {
            get { return _lijstGroepsreizen; }
            set
            {
                _lijstGroepsreizen = value;
                NotifyPropertyChanged();
            }
        }

        public Groepsreis GeselecteerdeGroepreis
        {
            get { return _geselecteerdeGroepreis; }
            set
            {
                _geselecteerdeGroepreis = value;
                NotifyPropertyChanged();
                KanToevoegen = false;
                KanAanpassen = true;
            }
        }

        public List<Leeftijdscategorie> LijstLeeftijdscategorieen
        {
            get { return _lijstLeeftijdscategorieen; }
            set { _lijstLeeftijdscategorieen = value; }
        }

        public List<Bestemming> LijstBestemmingen
        {
            get { return _lijstBestemmingen; }
            set { _lijstBestemmingen = value; }
        }

        public List<Thema> LijstThemas
        {
            get { return _lijstThemas; }
            set { _lijstThemas = value; }
        }

        public bool KanToevoegen
        {
            get { return _kanToevoegen; }
            set { _kanToevoegen = value; }
        }

        public bool KanAanpassen
        {
            get { return _kanAanpassen; }
            set { _kanAanpassen = value; }
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

        public AdminViewmodel()
        {
            Refresh();
            Nieuw();
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public void Refresh()
        {
            LijstGroepsreizen = new ObservableCollection<Groepsreis>(DatabaseOperations.OphalenGroepreizen());
            LijstLeeftijdscategorieen = new List<Leeftijdscategorie>(DatabaseOperations.OphalenLeeftijdscategorieen());
            LijstBestemmingen = new List<Bestemming>(DatabaseOperations.OphalenBestemmingen());
            LijstThemas = new List<Thema>(DatabaseOperations.OphalenThemas());
        }

        public void Terug()
        {
            var mainView = Application.Current.Windows.OfType<MainView>().FirstOrDefault();
            mainView.mainFrame.GoBack();
        }

        public void Nieuw()
        {
            GeselecteerdeGroepreis = new Groepsreis
            {
                Naam = "Nieuwe Groepsreis",
                Beschrijving = "",
                Startdatum = DateTime.Now,
                Einddatum = DateTime.Now.AddDays(7),
                MaxInschrijvingen = 2,
                Prijs = 0,
                LeeftijdscategorieId = 1,
                BestemmingId = null,
                ThemaId = null
            };
            KanToevoegen = true;
            KanAanpassen = false;
        }

        private void Toevoegen()
        {
            if (Validatie())
            {
                int ok = DatabaseOperations.ToevoegenGroepreis(GeselecteerdeGroepreis);

                if (ok > 0)
                {
                    Refresh();
                    SuccessMessage = "Groepreis toegevoegd";
                    ErrorMessage = "";
                }
                else
                {
                    ErrorMessage = "Er is iets misgelopen";
                    SuccessMessage = "";
                }
            }
        }

        private void Aanpassen()
        {
            if (Validatie())
            {
                int ok = DatabaseOperations.AanpassenGroepreis(GeselecteerdeGroepreis);

                if (ok > 0)
                {
                    Refresh();
                    SuccessMessage = "Groepreis aangepast";
                    ErrorMessage = "";
                }
                else
                {
                    ErrorMessage = "Er is iets misgelopen";
                    SuccessMessage = "";
                }
            }
        }

        private void Verwijderen()
        {
            int ok = DatabaseOperations.VerwijderenGroepreis(GeselecteerdeGroepreis);

            if (ok > 0)
            {
                Refresh();
                SuccessMessage = "Groepreis verwijdert";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = "Er is iets misgelopen";
                SuccessMessage = "";
            }
        }

        public bool Validatie()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(GeselecteerdeGroepreis.Naam) || GeselecteerdeGroepreis.Naam.Length > 50)
            {
                errors.Add("Naam is verplicht en mag maximaal 50 tekens bevatten.");
            }

            if (string.IsNullOrWhiteSpace(GeselecteerdeGroepreis.Beschrijving) || GeselecteerdeGroepreis.Beschrijving.Length > 200)
            {
                errors.Add("Beschrijving is verplicht en mag maximaal 200 tekens bevatten.");
            }

            if (GeselecteerdeGroepreis.Startdatum == DateTime.MinValue || GeselecteerdeGroepreis.Einddatum == DateTime.MinValue)
            {
                errors.Add("Startdatum en Einddatum zijn verplicht.");
            }
            else if (GeselecteerdeGroepreis.Startdatum >= GeselecteerdeGroepreis.Einddatum)
            {
                errors.Add("Startdatum moet voor de einddatum liggen.");
            }

            if (GeselecteerdeGroepreis.MaxInschrijvingen < 2 || GeselecteerdeGroepreis.MaxInschrijvingen > 6)
            {
                errors.Add("Max Inschrijvingen moet tussen 2 en 6 liggen.");
            }

            if (GeselecteerdeGroepreis.Prijs <= 0)
            {
                errors.Add("Prijs moet groter dan 0 zijn.");
            }

            if (GeselecteerdeGroepreis.LeeftijdscategorieId <= 0)
            {
                errors.Add("Selecteer een geldige leeftijdscategorie.");
            }

            if (errors.Count > 0)
            {
                ErrorMessage = string.Join("\n", errors);
                SuccessMessage = "";
                return false;
            }

            ErrorMessage = "";
            return true;
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Terug":
                    return true;
                case "Nieuw":
                    return true;
                case "Toevoegen":
                    return KanToevoegen;
                case "Aanpassen":
                    return KanAanpassen;
                case "Verwijderen":
                    return KanAanpassen;
                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Terug": Terug(); break;
                case "Nieuw": Nieuw(); break;
                case "Toevoegen": Toevoegen(); break;
                case "Aanpassen": Aanpassen(); break;
                case "Verwijderen": Verwijderen(); break;
            }
        }
    }
}
