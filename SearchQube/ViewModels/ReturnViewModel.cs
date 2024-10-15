using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SearchQube.Models;
using SearchQube.Services;
using SearchQube.Helpers;

namespace SearchQube.ViewModels
{
    public class ReturnViewModel : INotifyPropertyChanged
    {
        private readonly RFIDCardService _rfidCardService;
        private readonly ExcelService _excelService;
        private readonly NavigationHelper _navigationHelper;

        private string _statusMessage;
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

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

        public ReturnViewModel()
        {
            _rfidCardService = new RFIDCardService();
            _excelService = new ExcelService();
            _navigationHelper = new NavigationHelper();

            EquipmentList = new ObservableCollection<Equipment>();

            OkCommand = new RelayCommand(ExecuteOkCommand);
            BackCommand = new RelayCommand(ExecuteBackCommand);
        }

        private async void ExecuteOkCommand(object parameter)
        {
            StatusMessage = "Reading equipment information...";
            var equipment = await _rfidCardService.ReadEquipmentAsync();

            if (equipment != null)
            {
                var isMatched = _excelService.CompareEquipmentId(equipment.Id);

                if (isMatched)
                {
                    EquipmentList.Add(equipment);
                    _navigationHelper.NavigateTo("ReturnEquipmentListView");
                }
                else
                {
                    StatusMessage = "Error: Unknown Equipment";
                    _navigationHelper.NavigateTo("ErrorView");
                }
            }
            else
            {
                StatusMessage = "Error: Failed to read equipment information";
            }
        }

        private void ExecuteBackCommand(object parameter)
        {
            _navigationHelper.NavigateTo("BurrowOrReturnView");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
