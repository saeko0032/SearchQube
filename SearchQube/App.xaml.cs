using System.Windows;

namespace SearchQube
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize and show the HomeView
            var homeView = new Views.HomeView();
            homeView.Show();
        }
    }
}
