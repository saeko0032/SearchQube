using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using SearchQube.Models;
using SearchQube.Services;
using SearchQube.Helpers;
using CommunityToolkit.Mvvm.Input;

namespace SearchQube.ViewModels
{
    public class ReturnViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly ExcelService _excelService;
        private readonly RFIDCardService _rfidCardService;
        private ObservableCollection<Equipment> _equipmentList;
        private string _statusMessage;

        #endregion Fields

        #region Constructors

#pragma warning disable CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。

        public ReturnViewModel()
#pragma warning restore CS8618 // null 非許容のフィールドには、コンストラクターの終了時に null 以外の値が入っていなければなりません。Null 許容として宣言することをご検討ください。
        {
            _rfidCardService = new RFIDCardService();
            _excelService = new ExcelService();

            EquipmentList = new ObservableCollection<Equipment>();

            OkCommand = new RelayCommand(ExecuteOkCommand);
            BackCommand = new RelayCommand(ExecuteBackCommand);
        }

        #endregion Constructors

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion Events

        #region Properties

        public ICommand BackCommand { get; }

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

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties

        #region Methods

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExecuteBackCommand()
        {
            NavigationHelper.NavigateTo("BurrowOrReturnView");
        }

        private async void ExecuteOkCommand()
        {
            StatusMessage = "Reading equipment information...";
            var equipment = await _rfidCardService.ReadEquipmentInfoAsync();

            if (equipment != null)
            {
#pragma warning disable CS8604 // Null 参照引数の可能性があります。
                var isMatched = _excelService.CompareTerminalId(equipment.TerminalId);
#pragma warning restore CS8604 // Null 参照引数の可能性があります。

                if (isMatched)
                {
                    //EquipmentList.Add(equipment);
                    NavigationHelper.NavigateTo("ReturnEquipmentListView");
                }
                else
                {
                    StatusMessage = "Error: Unknown Equipment";
                    NavigationHelper.NavigateTo("ErrorView");
                }
            }
            else
            {
                StatusMessage = "Error: Failed to read equipment information";
            }
        }

        #endregion Methods
    }
}
