using SearchQube.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchQube.Views
{
    /// <summary>
    /// BurrowOrReturnView.xaml の相互作用ロジック
    /// </summary>
    public partial class BurrowOrReturnView : Page
    {
        #region Constructors

        public BurrowOrReturnView()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.NavigateTo("HomeView");
        }

        private void BurrowButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.NavigateTo("BurrowView");
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.NavigateTo("ReturnView");
        }

        #endregion Methods
    }
}
