using System.ComponentModel;
using System.Windows.Input;
using SearchQube.Helpers;

namespace SearchQube.ViewModels
{
    public class BurrowOrReturnViewModel : INotifyPropertyChanged
    {
        private string _errorMessage;

        public BurrowOrReturnViewModel()
        {
            BurrowCommand = new RelayCommand(NavigateToBurrow);
            ReturnCommand = new RelayCommand(NavigateToReturn);
            BackCommand = new RelayCommand(NavigateBack);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand BurrowCommand { get; }
        public ICommand ReturnCommand { get; }
        public ICommand BackCommand { get; }

        private void NavigateToBurrow()
        {
            NavigationHelper.NavigateTo("BurrowView");
        }

        private void NavigateToReturn()
        {
            NavigationHelper.NavigateTo("ReturnView");
        }

        private void NavigateBack()
        {
            NavigationHelper.NavigateBack();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
