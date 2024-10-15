using System;
using System.ComponentModel;
using System.Windows.Input;
using SearchQube.Helpers;
using SearchQube.Models;
using SearchQube.Services;

namespace SearchQube.ViewModels
{
    public class BurrowViewModel : INotifyPropertyChanged
    {
        private readonly RFIDCardService _rfidCardService;
        private readonly ExcelService _excelService;
        private readonly NavigationHelper _navigationHelper;

        private string _terminalId;
        private string _equipmentInfo;

        public string TerminalId
        {
            get => _terminalId;
            set
            {
                _terminalId = value;
                OnPropertyChanged(nameof(TerminalId));
            }
        }

        public string EquipmentInfo
        {
            get => _equipmentInfo;
            set
            {
                _equipmentInfo = value;
                OnPropertyChanged(nameof(EquipmentInfo));
            }
        }

        public ICommand OkCommand { get; }
        public ICommand BackCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public BurrowViewModel()
        {
            _rfidCardService = new RFIDCardService();
            _excelService = new ExcelService();
            _navigationHelper = new NavigationHelper();

            OkCommand = new RelayCommand(ExecuteOkCommand);
            BackCommand = new RelayCommand(ExecuteBackCommand);

            WaitForRFIDCardInput();
        }

        private async void WaitForRFIDCardInput()
        {
            var equipment = await _rfidCardService.ReadEquipmentInfoAsync();
            if (equipment != null)
            {
                TerminalId = equipment.TerminalId;
                EquipmentInfo = equipment.Info;
            }
        }

        private void ExecuteOkCommand(object parameter)
        {
            if (_excelService.CompareTerminalId(TerminalId))
            {
                _navigationHelper.NavigateTo("BurrowEquipmentListView");
            }
            else
            {
                _navigationHelper.NavigateTo("ErrorView");
            }
        }

        private void ExecuteBackCommand(object parameter)
        {
            _navigationHelper.NavigateBack();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
