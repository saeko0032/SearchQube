using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SearchQube.Models;
using SearchQube.Services;
using SearchQube.Helpers;

namespace SearchQube.ViewModels
{
    public class ReturnEquipmentListViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;
        private readonly NavigationHelper _navigationHelper;

        private ObservableCollection<Equipment> _equipmentList;
        public ObservableCollection<Equipment> EquipmentList
        {
            get => _equipmentList;
            set
            {
                _equipmentList = value;
                OnPropertyChanged();
            }
        }

        public ICommand OkCommand { get; }
        public ICommand BackCommand { get; }

        public ReturnEquipmentListViewModel()
        {
            _databaseService = new DatabaseService();
            _navigationHelper = new NavigationHelper();

            EquipmentList = new ObservableCollection<Equipment>();

            OkCommand = new RelayCommand(ExecuteOkCommand);
            BackCommand = new RelayCommand(ExecuteBackCommand);
        }

        private void ExecuteOkCommand(object parameter)
        {
            foreach (var equipment in EquipmentList)
            {
                _databaseService.DeleteEquipment(equipment.Id);
            }

            _navigationHelper.NavigateTo("SuccessView");
        }

        private void ExecuteBackCommand(object parameter)
        {
            _navigationHelper.NavigateTo("ReturnView");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
