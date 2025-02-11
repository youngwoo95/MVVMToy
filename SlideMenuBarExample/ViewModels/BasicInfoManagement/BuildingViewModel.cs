using Microsoft.Extensions.DependencyInjection;
using SlideMenuBarExample.Commands;
using SlideMenuBarExample.Commands.Interfaces;
using SlideMenuBarExample.Helpers;
using SlideMenuBarExample.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Input;

namespace SlideMenuBarExample.ViewModels.BasicInfoManagement
{
    public class BuildingViewModel : ViewModelBase
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



        // 테이블 데이터 컬렉션
        public ObservableCollection<PlaceBuilding> PlaceBuildings { get; set; } = new ObservableCollection<PlaceBuilding>();

        // 행 더블클릭 시 호출될 메서드
        public ICommand RowDoubleClickCommand { get; }

        private readonly HttpApiService HttpApiService;
        private readonly IAuthService AuthService;

        public BuildingViewModel(HttpApiService _httpapiservice, IAuthService _authservice)
        {
            IsMenuVisible = false; // 기본적으로 메뉴는 보임
            IsOverlayVisible = false; // 기본적으로 오버레이 숨김

            this.AuthService = _authservice;
            this.HttpApiService = _httpapiservice;
            RowDoubleClickCommand = new RelayCommand<PlaceBuilding>(OnRowDoubleClick);
            _ = LoadBuildingListAsync();
        }

        private async Task LoadBuildingListAsync()
        {
            IsMenuVisible = true;

            IsOverlayVisible = true;

            HttpResponseMessage response = await HttpApiService.GetAsync("api/Building/sign/MyBuildings", AuthService.Token);
            if(response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<ResponseUnit<ObservableCollection<PlaceBuilding>>>();
                if(responseBody != null && responseBody.code == 200)
                {
                    PlaceBuildings = responseBody.data;
                    OnPropertyChanged(nameof(PlaceBuildings));
                }
            }
            
            IsOverlayVisible = false;
        }

        private async void OnRowDoubleClick(PlaceBuilding item)
        {
            
            await Task.Delay(300);

            //CurrentSubView = App.ServiceProvider.GetRequiredService<BuildingEditViewModel>();
            CurrentSubView = ActivatorUtilities.CreateInstance<BuildingEditViewModel>(App.ServiceProvider, item.Id);

            
        }
    }
}
