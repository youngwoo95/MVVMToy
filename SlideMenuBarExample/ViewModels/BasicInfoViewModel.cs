using SlideMenuBarExample.Commands;
using SlideMenuBarExample.Commands.Interfaces;
using SlideMenuBarExample.ViewModels.BasicInfoManagement;
using System.Windows.Input;

namespace SlideMenuBarExample.ViewModels
{
    public class BasicInfoViewModel : ViewModelBase
    {
        private ViewModelBase _currentSubView;
        public ViewModelBase CurrentSubView
        {
            get => _currentSubView;
            set
            {
                _currentSubView = value;
                OnPropertyChanged(nameof(CurrentSubView));
            }
        }

        private bool _isOverlayVisible;
        public bool IsOverlayVisible
        {
            get => _isOverlayVisible;
            set
            {
                _isOverlayVisible = value;
                OnPropertyChanged(nameof(IsOverlayVisible));
            }
        }

        // 새로 추가: 메뉴 표시 여부 프로퍼티
        private bool _isMenuVisible = true;
        public bool IsMenuVisible
        {
            get => _isMenuVisible;
            set
            {
                _isMenuVisible = value;
                OnPropertyChanged(nameof(IsMenuVisible));
            }
        }

        public ICommand BuildingCommand { get; }
        public ICommand LocationCommand { get; }
        public ICommand UnitCommand { get; }

        public BasicInfoViewModel()
        {
            
            IsMenuVisible = true; // 기본적으로 메뉴는 보임

            // 초기 화면을 설정 (예: 건물 관리 화면)
            IsOverlayVisible = false; // 기본적으로 오버레이 숨김

            // 각 Command에서 화면 전환 전후에 오버레이 효과를 적용할 수 있습니다.
            BuildingCommand = new RelayCommand(_ => SwitchSubView(new BuildingViewModel()));
            //LocationCommand = new RelayCommand(_ => SwitchSubView(new LocationViewModel()));
            //UnitCommand = new RelayCommand(_ => SwitchSubView(new UnitViewModel()));
        }

        private async void SwitchSubView(ViewModelBase newViewModel)
        {
            IsMenuVisible = false; // 메뉴 숨김 (화면 전환 시 메뉴도 사라지게 함)

            // 오버레이 활성화 (예: 전환 전 로딩 화면 표시)
            IsOverlayVisible = true;

            // 전환 효과(애니메이션, 딜레이 등)를 주고 싶다면 await Task.Delay() 등 사용 가능
            await Task.Delay(300); // 300ms 딜레이 예시

            // 화면 전환
            CurrentSubView = newViewModel;

            // 전환 후 오버레이 숨김
            IsOverlayVisible = false;
        }

    }
}
