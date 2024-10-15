using System;
using System.ComponentModel;
using System.Windows.Input;
using SearchQube.Helpers;

namespace SearchQube.ViewModels
{
    public class SuccessViewModel : INotifyPropertyChanged
    {
        private string _successMessage;

        public SuccessViewModel()
        {
            HomeCommand = new RelayCommand(NavigateToHome);
            LogOutCommand = new RelayCommand(LogOut);
        }

        public string SuccessMessage
        {
            get => _successMessage;
            set
            {
                _successMessage = value;
                OnPropertyChanged(nameof(SuccessMessage));
            }
        }

        public ICommand HomeCommand { get; }
        public ICommand LogOutCommand { get; }

        private void NavigateToHome()
        {
            NavigationHelper.NavigateTo("HomeView");
        }

        private void LogOut()
        {
            // Clear SESAID property value
            // Navigate to Home screen
            NavigationHelper.NavigateTo("HomeView");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
