using models;
using dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Windows;
using System.ComponentModel.DataAnnotations;

namespace wpf.Viewmodels
{
    public class LoginViewmodel : BaseViewmodel
    {
        private string _email;
        private string _wachtwoord;
        private string _errorMessage;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyPropertyChanged();
            }
        }
        
        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set
            {
                _wachtwoord = value;
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

        public LoginViewmodel() {
            //Veranderen naar placeholders!!
            Email = "gebruiker2@example.com";
            Wachtwoord = "wachtwoord2";
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public void Inloggen()
        {
            if (Valideren()) {
                Gebruiker g = DatabaseOperations.OphalenGebruikerViaEmail(Email);

                if (g != null)
                {
                    if (Wachtwoord == g.Wachtwoord)
                    {
                        //MainViewmodel openen
                        var mainVM = new MainViewmodel();
                        mainVM.Gebruiker = g;

                        //GroepreizenView (page) openen
                        var groepsreizenView = new GroepsreizenView();
                        groepsreizenView.DataContext = mainVM;

                        //MainView (window) openen
                        var mainView = new MainView();
                        mainView.DataContext = mainVM;
                        mainView.mainFrame.Content = groepsreizenView;
                        mainView.Show();

                        //Login sluiten
                        var loginView = Application.Current.Windows.OfType<LoginView>().FirstOrDefault();
                        if (loginView != null)
                        {
                            loginView.Close();
                        }
                    } else
                    {
                        ErrorMessage = "Wachtwoord is niet correct";
                    }
                } else
                {
                    ErrorMessage = "Email is niet correct";
                }
            }
        }

        public bool Valideren()
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Email))
            {
                errors.Add("Email is een verplicht veld");
            }
            else if (!new EmailAddressAttribute().IsValid(Email))
            {
                errors.Add("Email is niet geldig");
            }

            if (string.IsNullOrWhiteSpace(Wachtwoord))
            {
                errors.Add("Wachtwoord is een verplicht veld");
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
                case "Inloggen":
                    return true;
                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Inloggen": Inloggen(); break;
            }
        }
    }
}
