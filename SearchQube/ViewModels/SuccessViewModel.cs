using System;
using System.ComponentModel;
using System.Windows.Input;
using SearchQube.Helpers;
using CommunityToolkit.Mvvm.Input;

namespace SearchQube.ViewModels
{
    public class SuccessViewModel : INotifyPropertyChanged
    {
        #region Constructors

#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。

        public SuccessViewModel()
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        {
            HomeCommand = new RelayCommand(NavigateToHome);
            LogOutCommand = new RelayCommand(LogOut);
        }

        #endregion Constructors

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion Events

        #region Properties

        public ICommand HomeCommand { get; }

        public ICommand LogOutCommand { get; }

        #endregion Properties

        #region Methods

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LogOut()
        {
            // Clear SESAID property value
            // Navigate to Home screen
            NavigationHelper.NavigateTo("HomeView");
        }

        private void NavigateToHome()
        {
            NavigationHelper.NavigateTo("BurrowOrReturnView");
        }

        #endregion Methods
    }
}
