using System;
using System.ComponentModel;
using System.Windows.Input;
using SearchQube.Helpers;
using SearchQube.Models;
using SearchQube.Services;
using CommunityToolkit.Mvvm.Input;

namespace SearchQube.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly ExcelService _excelService;
        private readonly ICCardService _icCardService;
        private string _employeeId;
        private string _errorMessage;

        #endregion Fields

        #region Constructors

#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。

        public HomeViewModel()
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        {
            _icCardService = new ICCardService();
            _excelService = new ExcelService();
            ScanCommand = new RelayCommand(ScanEmployeeId);
        }

        #endregion Constructors

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion Events

        #region Properties

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

        #endregion Properties

        #region Methods

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ScanEmployeeId()
        {
            try
            {
                var user = _icCardService.ReadUserInformation();
#pragma warning disable CS8604 // Null 参照引数の可能性があります。
                if (user != null && _excelService.CompareEmployeeId(user.EmployeeId))
                {
                    NavigationHelper.NavigateTo("BurrowOrReturnView");
                }
                else
                {
                    ErrorMessage = "Unregistered user.<br/> Please request registration from the Astera administrator.";
                    NavigationHelper.NavigateTo("ErrorView", ErrorMessage);
                }
#pragma warning restore CS8604 // Null 参照引数の可能性があります。
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                NavigationHelper.NavigateTo("ErrorView");
            }
        }

        #endregion Methods
    }
}
