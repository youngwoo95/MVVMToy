using SlideMenuBarExample.Commands.Interfaces;
using SlideMenuBarExample.Helpers;
using System.Net;
using System.Net.Http;

namespace SlideMenuBarExample.ViewModels.BasicInfoManagement
{
    public class BuildingEditViewModel : ViewModelBase
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

        private int BuildingId { get; }

        private readonly HttpApiService HttpApiService;
        private readonly IAuthService AuthService;

       
        public BuildingEditViewModel(int buildingid, HttpApiService _httpapiservice, IAuthService _authservice)
        {
            BuildingId = buildingid;
            this.AuthService = _authservice;
            this.HttpApiService = _httpapiservice;
            _ = LoadBuildingEditAsync();
            
            Console.WriteLine(BuildingId);
        }

        private async Task LoadBuildingEditAsync()
        {
            await ExecuteWithLoadingAsync(async () =>
            {
                HttpResponseMessage response = await HttpApiService.GetAsync($"api/Building/sign/DetailBuilding?buildingid={BuildingId}", AuthService.Token);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(responseBody);
                    Console.WriteLine("");

                }
            });

            
        }


    }
}
