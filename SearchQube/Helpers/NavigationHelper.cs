using SearchQube.ViewModels;
using SearchQube.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SearchQube.Helpers
{
    public static class NavigationHelper
    {
        #region Fields

        private static Window? _mainWindow;

        #endregion Fields

        #region Methods

        public static void Initialize(Window mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public static void NavigateBack()
        {
            // Implement navigation back logic if needed
        }

#pragma warning disable CS8625 // null リテラルを null 非許容参照型に変換できません。

        public static void NavigateTo(string viewName, object parameter = null)
#pragma warning restore CS8625 // null リテラルを null 非許容参照型に変換できません。
        {
            if (_mainWindow == null)
                throw new InvalidOperationException("Main window is not initialized.");

            var viewType = Type.GetType($"SearchQube.Views.{viewName}");
            if (viewType == null)
                throw new ArgumentException($"View '{viewName}' not found.");

            var view = Activator.CreateInstance(viewType) as Page;
            if (view == null)
                throw new InvalidOperationException($"View '{viewName}' could not be created.");

            if (view is ErrorView && parameter is string errorMessage)
            {
                var viewModel = new ErrorViewModel { ErrorMessage = errorMessage };
                view.DataContext = viewModel;
            }
            _mainWindow.Content = view;
        }
    }

    #endregion Methods
}
