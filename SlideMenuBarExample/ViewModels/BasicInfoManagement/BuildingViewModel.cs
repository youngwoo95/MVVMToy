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

        // 테이블 데이터 컬렉션
        public ObservableCollection<PlaceBuilding> PlaceBuildings { get; set; } = new ObservableCollection<PlaceBuilding>();

        // 행 더블클릭 시 호출될 메서드
        public ICommand RowDoubleClickCommand { get; }

        private readonly HttpApiService HttpApiService;
        private readonly IAuthService AuthService;

        public BuildingViewModel(HttpApiService _httpapiservice, IAuthService _authservice)
        {
            this.AuthService = _authservice;
            this.HttpApiService = _httpapiservice;
            RowDoubleClickCommand = new RelayCommand<PlaceBuilding>(OnRowDoubleClick);
            _ = LoadBuildingListAsync();
        }

        private async Task LoadBuildingListAsync()
        {
            await ExecuteWithLoadingAsync(async () =>
            {
                HttpResponseMessage response = await HttpApiService.GetAsync("api/Building/sign/MyBuildings", AuthService.Token);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<ResponseUnit<ObservableCollection<PlaceBuilding>>>();
                    if (responseBody != null && responseBody.code == 200)
                    {
                        PlaceBuildings = responseBody.data;
                        OnPropertyChanged(nameof(PlaceBuildings));
                    }
                }
            });
        }

        private async void OnRowDoubleClick(PlaceBuilding item)
        {
            IsOverlayVisible = false;
            IsMenuVisible = false;
            //CurrentSubView = App.ServiceProvider.GetRequiredService<BuildingEditViewModel>();
            CurrentSubView = ActivatorUtilities.CreateInstance<BuildingEditViewModel>(App.ServiceProvider, item.Id);


        }
    }
}
