using System;
using System.ComponentModel;
using System.Windows.Input;
using SearchQube.Helpers;
using SearchQube.Models;
using SearchQube.Services;

namespace SearchQube.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private readonly ICCardService _icCardService;
        private readonly ExcelService _excelService;
        private string _employeeId;
        private string _errorMessage;

        public HomeViewModel()
        {
            _icCardService = new ICCardService();
            _excelService = new ExcelService();
            ScanCommand = new RelayCommand(ScanEmployeeId);
        }

        public string EmployeeId
        {
            get => _employeeId;
            set
            {
                _employeeId = value;
                OnPropertyChanged(nameof(EmployeeId));
            }
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

        public ICommand ScanCommand { get; }

        private void ScanEmployeeId()
        {
            try
            {
                var user = _icCardService.ReadUserInformation();
                if (user != null && _excelService.CompareEmployeeId(user.EmployeeId))
                {
                    NavigationHelper.NavigateTo("BurrowOrReturnView");
                }
                else
                {
                    ErrorMessage = "Unknown user";
                    NavigationHelper.NavigateTo("ErrorView");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                NavigationHelper.NavigateTo("ErrorView");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
