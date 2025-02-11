using System.ComponentModel;

namespace SlideMenuBarExample.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool _isMenuVisible;
        
        /// <summary>
        /// 데이터 로드 중 표시할 로딩 상태
        /// </summary>
        public bool IsMenuVisible
        {
            get
            {
                return _isMenuVisible;
            }
            set
            {
                _isMenuVisible = value;
                OnPropertyChanged(nameof(IsMenuVisible));
            }
        }

        private bool _isOverlayVisible;
        public bool IsOverlayVisible
        {
            get
            {
                return _isOverlayVisible;
            }
            set
            {
                _isOverlayVisible = value;
                OnPropertyChanged(nameof(IsOverlayVisible));
            }
        }
        
        /// <summary>
        /// 지정한 비동기 작업을 실행하기 전후에 IsLoading 상태를 자동으로 처리하는 헬퍼메서드
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        protected async Task ExecuteWithLoadingAsync(Func<Task> action)
        {
            IsOverlayVisible = true;
            IsMenuVisible = false;

            try
            {
                await action();
            }
            finally
            {
                IsOverlayVisible = false;
                IsMenuVisible = true;
            }
        }

        protected async Task ExecuteInitializedAsync(Func<Task> action)
        {

        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
