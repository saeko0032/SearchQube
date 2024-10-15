using System;
using System.Windows;
using System.Windows.Controls;

namespace SearchQube.Helpers
{
    public static class NavigationHelper
    {
        private static Window _mainWindow;

        public static void Initialize(Window mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public static void NavigateTo(string viewName)
        {
            if (_mainWindow == null)
                throw new InvalidOperationException("Main window is not initialized.");

            var viewType = Type.GetType($"SearchQube.Views.{viewName}");
            if (viewType == null)
                throw new ArgumentException($"View '{viewName}' not found.");

            var view = Activator.CreateInstance(viewType) as UserControl;
            if (view == null)
                throw new InvalidOperationException($"View '{viewName}' could not be created.");

            _mainWindow.Content = view;
        }

        public static void NavigateBack()
        {
            // Implement navigation back logic if needed
        }
    }
}
