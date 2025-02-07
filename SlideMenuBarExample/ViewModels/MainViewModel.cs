using SharpVectors.Dom.Css;
using SlideMenuBarExample.Commands;
using System.Windows.Input;

namespace SlideMenuBarExample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Home 버튼 커맨드
        /// </summary>
        public ICommand ShowHomeCommand { get; }

        /// <summary>
        /// 기본정보관리 버튼 커맨드
        /// </summary>
        public ICommand BasicInfoCommand { get; }

        /// <summary>
        /// Setting 버튼 커맨드
        /// </summary>
        public ICommand ShowSettingCommend { get; }

        private ViewModelBase currentviewmodel;

        /// <summary>
        /// 현재 화면이 무엇인지 알려주는 뷰모델
        /// </summary>
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return currentviewmodel;
            }
            set
            {
                currentviewmodel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public MainViewModel()
        {
            CurrentViewModel = new HomeViewModel();
            ShowHomeCommand = new RelayCommand(param => CurrentViewModel = new HomeViewModel());
            BasicInfoCommand = new RelayCommand(param => CurrentViewModel = new BasicInfoViewModel());
            ShowSettingCommend = new RelayCommand(param => CurrentViewModel = new SettingViewModel());

        }



    }
}
