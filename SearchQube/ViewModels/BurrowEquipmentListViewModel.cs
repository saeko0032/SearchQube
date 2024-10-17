using System.Collections.ObjectModel;
using System.Windows.Input;
using SearchQube.Models;
using SearchQube.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace SearchQube.ViewModels
{
    public class BurrowEquipmentListViewModel : ViewModelBase
    {
        #region Fields

        private readonly DatabaseService _databaseService;

        #endregion Fields

        #region Constructors

        public BurrowEquipmentListViewModel()
        {
            _databaseService = new DatabaseService();
            ConfirmedEquipments = ExcelService.ConfirmedEquipments;
            OkCommand = new RelayCommand(ExecuteOkCommand);
        }

        #endregion Constructors

        #region Properties

        public ReadOnlyObservableCollection<Equipment> ConfirmedEquipments { get; }
        //        public ObservableCollection<Equipment> EquipmentList { get; set; }

        public ICommand OkCommand { get; }

        #endregion Properties

        #region Methods

        private void ExecuteOkCommand()
        {
            foreach (var equipment in ConfirmedEquipments)
            {
                _databaseService.AddEquipment(equipment);
            }

            // Navigate to Success screen
            Helpers.NavigationHelper.NavigateTo("SuccessView");
        }

        #endregion Methods
    }
}
