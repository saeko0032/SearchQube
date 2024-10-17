using System.Collections.ObjectModel;
using System.Windows.Input;
using SearchQube.Models;
using CommunityToolkit.Mvvm.Input;
using SearchQube.Services;
using SearchQube.Helpers;
using System; // NavigationHelper が定義されている名前空間をインポート

namespace SearchQube.ViewModels
{
    public class ReturnEquipmentListViewModel : ViewModelBase
    {
        #region Fields

        private readonly DatabaseService _databaseService;

        #endregion Fields

        #region Constructors

        public ReturnEquipmentListViewModel()
        {
            _databaseService = new DatabaseService();
            ConfirmedEquipments = ExcelService.ConfirmedEquipments;
            OkCommand = new RelayCommand(ExecuteOkCommand);
        }

        #endregion Constructors

        #region Properties

        public ReadOnlyObservableCollection<Equipment> ConfirmedEquipments { get; }

        public ICommand OkCommand { get; }

        #endregion Properties

        #region Methods

        private void ExecuteOkCommand()
        {
            foreach (var equipment in ConfirmedEquipments)
            {
#pragma warning disable CS8604 // Null 参照引数の可能性があります。
                _databaseService.DeleteEquipment(equipment.TerminalId);
#pragma warning restore CS8604 // Null 参照引数の可能性があります。
            }

            // Navigate to Success screen
            NavigationHelper.NavigateTo("SuccessView");
        }

        #endregion Methods
    }
}
