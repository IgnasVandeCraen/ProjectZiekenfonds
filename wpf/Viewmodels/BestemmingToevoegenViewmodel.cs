using dal;
using models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using wpf.Views;

namespace wpf.Viewmodels
{
    public class BestemmingToevoegenViewmodel : BaseViewmodel
    {
        private Bestemming _bestemming { get; set; }
        private AdminViewmodel _adminViewmodel;
        private string _successMessage;
        private string _errorMessage;

        public Bestemming Bestemming
        {
            get { return _bestemming; }
            set
            {
                _bestemming = value;
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

        public BestemmingToevoegenViewmodel(AdminViewmodel adminViewmodel)
        {
            _adminViewmodel = adminViewmodel;
            Bestemming = new Bestemming();
        }

        public void Toevoegen()
        {
            if (BestemmingValidatie())
            {
                int ok = DatabaseOperations.ToevoegenBestemming(Bestemming);

                if (ok > 0)
                {
                    SuccessMessage = "Bestemming toegevoegd";
                    ErrorMessage = "";
                    Bestemming = new Bestemming();
                    _adminViewmodel.Refresh();
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
            var bestemmingToevoegenView = Application.Current.Windows.OfType<BestemmingToevoegenView>().FirstOrDefault();
            if (bestemmingToevoegenView != null)
            {
                bestemmingToevoegenView.Close();
            }
        }

        public bool BestemmingValidatie()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Bestemming.Adres) || Bestemming.Adres.Length > 100)
            {
                errors.Add("Adres is verplicht en mag maximaal 100 tekens bevatten.");
            }

            if (string.IsNullOrWhiteSpace(Bestemming.Plaats) || Bestemming.Plaats.Length > 50)
            {
                errors.Add("Plaats is verplicht en mag maximaal 50 tekens bevatten.");
            }

            if (string.IsNullOrWhiteSpace(Bestemming.Postcode) || Bestemming.Postcode.Length > 10)
            {
                errors.Add("Postcode is verplicht en mag maximaal 10 tekens bevatten.");
            }

            if (string.IsNullOrWhiteSpace(Bestemming.Land) || Bestemming.Land.Length > 50)
            {
                errors.Add("Land is verplicht en mag maximaal 50 tekens bevatten.");
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
