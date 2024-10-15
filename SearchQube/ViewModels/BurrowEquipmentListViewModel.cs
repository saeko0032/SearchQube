using System.Collections.ObjectModel;
using System.Windows.Input;
using SearchQube.Models;
using SearchQube.Services;

namespace SearchQube.ViewModels
{
    public class BurrowEquipmentListViewModel : ViewModelBase
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Equipment> EquipmentList { get; set; }

        public ICommand OkCommand { get; }

        public BurrowEquipmentListViewModel()
        {
            _databaseService = new DatabaseService();
            EquipmentList = new ObservableCollection<Equipment>();
            OkCommand = new RelayCommand(ExecuteOkCommand);
        }

        private void ExecuteOkCommand(object parameter)
        {
            foreach (var equipment in EquipmentList)
            {
                _databaseService.AddEquipment(equipment);
            }

            // Navigate to Success screen
            NavigationHelper.NavigateTo("SuccessView");
        }
    }
}
