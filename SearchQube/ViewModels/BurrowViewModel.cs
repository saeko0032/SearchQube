using System;
using System.ComponentModel;
using System.Windows.Input;
using SearchQube.Helpers;
using SearchQube.Models;
using SearchQube.Services;
using CommunityToolkit.Mvvm.Input;

namespace SearchQube.ViewModels
{
    public class BurrowViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly ExcelService _excelService;
        private readonly RFIDCardService _rfidCardService;
        private string _equipmentInfo;
        private string _terminalId;

        #endregion Fields

        #region Constructors

#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。

        public BurrowViewModel()
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        {
            _rfidCardService = new RFIDCardService();
            _excelService = new ExcelService();

            OkCommand = new RelayCommand(ExecuteOkCommand);
            BackCommand = new RelayCommand(ExecuteBackCommand);

            WaitForRFIDCardInput();
        }

        #endregion Constructors

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion Events

        #region Properties

        public ICommand BackCommand { get; }

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

        public string TerminalId
        {
            get => _terminalId;
            set
            {
                _terminalId = value;
                OnPropertyChanged(nameof(TerminalId));
            }
        }

        #endregion Properties

        #region Methods

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExecuteBackCommand()
        {
            NavigationHelper.NavigateBack();
        }

        private void ExecuteOkCommand()
        {
            if (_excelService.CompareTerminalId(TerminalId))
            {
                NavigationHelper.NavigateTo("BurrowEquipmentListView");
            }
            else
            {
                NavigationHelper.NavigateTo("ErrorView");
            }
        }

        private async void WaitForRFIDCardInput()
        {
            var equipment = await _rfidCardService.ReadEquipmentInfoAsync();
            if (equipment != null)
            {
                TerminalId = equipment.TerminalId ?? string.Empty; // Null非許容参照型の修正
                EquipmentInfo = equipment.Info ?? string.Empty; // Null非許容参照型の修正
            }
        }

        #endregion Methods
    }
}
