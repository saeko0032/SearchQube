using System.ComponentModel;
using System.Windows.Input;
using SearchQube.Helpers;
using CommunityToolkit.Mvvm.Input;

namespace SearchQube.ViewModels
{
    public class BurrowOrReturnViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _errorMessage;

        #endregion Fields

        #region Constructors

#pragma warning disable CS8618 // null �񋖗e�̃t�B�[���h�ɂ́A�R���X�g���N�^�[�̏I������ null �ȊO�̒l�������Ă��Ȃ���΂Ȃ�܂���BNull ���e�Ƃ��Đ錾���邱�Ƃ����������������B

        public BurrowOrReturnViewModel()
#pragma warning restore CS8618 // null �񋖗e�̃t�B�[���h�ɂ́A�R���X�g���N�^�[�̏I������ null �ȊO�̒l�������Ă��Ȃ���΂Ȃ�܂���BNull ���e�Ƃ��Đ錾���邱�Ƃ����������������B
        {
            BurrowCommand = new RelayCommand(NavigateToBurrow);
            ReturnCommand = new RelayCommand(NavigateToReturn);
        }

        #endregion Constructors

        #region Events

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion Events

        #region Properties

        public ICommand BackCommand { get; }

        public ICommand BurrowCommand { get; }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand ReturnCommand { get; }

        #endregion Properties

        #region Methods

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NavigateToBurrow()
        {
            NavigationHelper.NavigateTo("BurrowView");
        }

        private void NavigateToReturn()
        {
            NavigationHelper.NavigateTo("ReturnView");
        }

        #endregion Methods
    }
}
