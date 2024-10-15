using System.ComponentModel;
using System.Windows.Input;
using SearchQube.Helpers;

namespace SearchQube.ViewModels
{
    public class ErrorViewModel : INotifyPropertyChanged
    {
        private string _errorMessage;

        public ErrorViewModel()
        {
            BackCommand = new RelayCommand(Back);
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

        public ICommand BackCommand { get; }

        private void Back()
        {
            NavigationHelper.NavigateTo("HomeView");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
