using System.Windows;
using System.Windows.Controls;
using SearchQube.Helpers;
using SearchQube.Views;

namespace SearchQube
{
    public partial class App : Application
    {
        #region Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize and show the HomeView within a Frame
            var mainWindow = new Window();
            var frame = new Frame();
            frame.Navigate(new HomeView());
            mainWindow.Content = frame;
            NavigationHelper.Initialize(mainWindow);
            mainWindow.Show();
        }

        #endregion Methods
    }
}
