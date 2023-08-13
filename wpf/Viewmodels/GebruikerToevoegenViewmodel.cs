using dal;
using models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using wpf.Views;

namespace wpf.Viewmodels
{
    public class GebruikerToevoegenViewmodel : BaseViewmodel
    {
        private Gebruiker _gebruiker { get; set; }
        private List<Leeftijdscategorie> _lijstLeeftijdscategorieen { get; set; }
        private string _successMessage;
        private string _errorMessage;

        public Gebruiker Gebruiker
        {
            get { return _gebruiker; }
            set
            {
                _gebruiker = value;
                NotifyPropertyChanged();
            }
        }

        public List<Leeftijdscategorie> LijstLeeftijdscategorieen
        {
            get { return _lijstLeeftijdscategorieen; }
            set { _lijstLeeftijdscategorieen = value; }
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

        public GebruikerToevoegenViewmodel()
        {
            Gebruiker = new Gebruiker();
            LijstLeeftijdscategorieen = new List<Leeftijdscategorie>(DatabaseOperations.OphalenLeeftijdscategorieen());
        }

        public void Toevoegen()
        {
            if (GebruikerValidatie())
            {
                int ok = DatabaseOperations.ToevoegenGebruiker(Gebruiker);

                if (ok > 0)
                {
                    SuccessMessage = "Gebruiker toegevoegd";
                    ErrorMessage = "";
                    Gebruiker = new Gebruiker();
                }
                else
                {
                    ErrorMessage = "Er is iets misgelopen";
                    SuccessMessage = "";
                }
            }
        }

        public void Annuleren()
        {
            var gebruikerToevoegenView = Application.Current.Windows.OfType<GebruikerToevoegenView>().FirstOrDefault();
            if (gebruikerToevoegenView != null)
            {
                gebruikerToevoegenView.Close();
            }
        }

        public bool GebruikerValidatie()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Gebruiker.Email) || Gebruiker.Email.Length > 100)
            {
                errors.Add("Email is verplicht en mag maximaal 100 tekens bevatten.");
            }

            if (string.IsNullOrWhiteSpace(Gebruiker.Wachtwoord) || Gebruiker.Wachtwoord.Length > 100)
            {
                errors.Add("Wachtwoord is verplicht en mag maximaal 100 tekens bevatten.");
            }

            if (string.IsNullOrWhiteSpace(Gebruiker.Voornaam) || Gebruiker.Voornaam.Length > 25)
            {
                errors.Add("Voornaam is verplicht en mag maximaal 25 tekens bevatten.");
            }

            if (string.IsNullOrWhiteSpace(Gebruiker.Achternaam) || Gebruiker.Achternaam.Length > 25)
            {
                errors.Add("Achternaam is verplicht en mag maximaal 25 tekens bevatten.");
            }

            if (Gebruiker.LeeftijdscategorieId <= 0)
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
        
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Toevoegen":
                    return true;
                case "Annuleren":
                    return true;
                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Toevoegen": Toevoegen(); break;
                case "Annuleren": Annuleren(); break;
            }
        }
    }
}
