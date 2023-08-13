using dal;
using models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace wpf.Viewmodels
{
    public class ProfielViewmodel : BaseViewmodel
    {
        private Gebruiker _gebruiker;

        private ObservableCollection<Inschrijving> _lijstInschrijvingen;

        public Gebruiker Gebruiker
        {
            get { return _gebruiker; }
            set { _gebruiker = value; }
            
        }

        public ObservableCollection<Inschrijving> LijstInschrijvingen
        {
            get { return _lijstInschrijvingen; }
            set 
            {
                _lijstInschrijvingen = value;
                NotifyPropertyChanged();
            }
        }

        public ProfielViewmodel(Gebruiker gebruiker)
        {
            Gebruiker = gebruiker;
            if (Gebruiker != null)
            {
                LijstInschrijvingen = new ObservableCollection<Inschrijving>(DatabaseOperations.OphalenInschrijvingenViaGebruikerId(Gebruiker.Id));
            }
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public void Terug()
        {
            var mainView = Application.Current.Windows.OfType<MainView>().FirstOrDefault();
            mainView.mainFrame.GoBack();
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Terug":
                    return true;
                default:
                    return false;
            }
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Terug": Terug(); break;
            }
        }
    }
}
