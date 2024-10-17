using System.ComponentModel;
using System.Windows.Input;
using SearchQube.Helpers;
using CommunityToolkit.Mvvm.Input;

namespace SearchQube.ViewModels
{
    public class ErrorViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _errorMessage;

        #endregion Fields

        #region Constructors

#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。

        public ErrorViewModel()
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        {
            BackCommand = new RelayCommand(BackToHome);
        }

        #endregion Constructors

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion Events

        #region Properties

        public ICommand BackCommand { get; }

        // TODO: Does not work correctly...
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        #endregion Properties

        #region Methods

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void BackToHome()
        {
            NavigationHelper.NavigateTo("HomeView");
        }

        #endregion Methods
    }
}
