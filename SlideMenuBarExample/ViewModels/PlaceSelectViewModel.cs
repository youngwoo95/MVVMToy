using SlideMenuBarExample.Commands;
using SlideMenuBarExample.Commands.Interfaces;
using SlideMenuBarExample.Helpers;
using SlideMenuBarExample.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Input;

namespace SlideMenuBarExample.ViewModels
{
    public class PlaceSelectViewModel : ViewModelBase
    {
        private readonly HttpApiService HttpApiServices;

        public ObservableCollection<AdminPlace> PlaceList { get; set; } = new ObservableCollection<AdminPlace>();

        public AdminPlace? SelectedPlaces => PlaceList.FirstOrDefault(m => m.isSelected);

        private readonly IAuthService AuthService;

        // 창 닫힘 요청 이벤트 (매개변수: bool?로 DialogResult를 전달)
        public event EventHandler<bool?>? RequestClose;

        /// <summary>
        /// 선택버튼
        /// </summary>
        public ICommand SelectCommand { get; }

        public PlaceSelectViewModel(HttpApiService _httpapiservice, IAuthService _authservice)
        {
            AuthService = _authservice;
            this.HttpApiServices = _httpapiservice;
            // 페이지가 로드될 때 사업장 목록을 불러온다.
            _ = LoadPlaceListAsync();

            SelectCommand = new RelayCommand(SelectPlace);
        }

        public async Task LoadPlaceListAsync()
        {
            //Console.WriteLine(AuthService.ToString);
            //string jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWR4IjoiMyIsIk5hbWUiOiLquYDsmqnsmrAiLCJqdGkiOiI1Y2ZiYmQyOS05MmI2LTRhMDgtYjBhNS0yNzZlOWRlNThiMTkiLCJBbGFybVlOIjoiVHJ1ZSIsIkFkbWluWU4iOiJUcnVlIiwiVXNlclR5cGUiOiJBRE1JTiIsIkFkbWluSWR4IjoiMyIsIlJvbGUiOiLrp4jsiqTthLAiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJNYXN0ZXIiLCJVc2VyUGVybXMiOiJ7XCJVc2VyUGVybV9CYXNpY1wiOlwiMlwiLFwiVXNlclBlcm1fTWFjaGluZVwiOlwiMlwiLFwiVXNlclBlcm1fRWxlY1wiOlwiMlwiLFwiVXNlclBlcm1fTGlmdFwiOlwiMlwiLFwiVXNlclBlcm1fRmlyZVwiOlwiMlwiLFwiVXNlclBlcm1fQ29uc3RydWN0XCI6XCIyXCIsXCJVc2VyUGVybV9OZXR3b3JrXCI6XCIyXCIsXCJVc2VyUGVybV9CZWF1dHlcIjpcIjJcIixcIlVzZXJQZXJtX1NlY3VyaXR5XCI6XCIyXCIsXCJVc2VyUGVybV9NYXRlcmlhbFwiOlwiMlwiLFwiVXNlclBlcm1fRW5lcmd5XCI6XCIyXCIsXCJVc2VyUGVybV9Vc2VyXCI6XCIyXCIsXCJVc2VyUGVybV9Wb2NcIjpcIjJcIn0iLCJWb2NQZXJtcyI6IntcIlZvY01hY2hpbmVcIjpcIlRydWVcIixcIlZvY0VsZWNcIjpcIlRydWVcIixcIlZvY0xpZnRcIjpcIlRydWVcIixcIlZvY0ZpcmVcIjpcIkZhbHNlXCIsXCJWb2NDb25zdHJ1Y3RcIjpcIlRydWVcIixcIlZvY05ldHdvcmtcIjpcIlRydWVcIixcIlZvY0JlYXV0eVwiOlwiVHJ1ZVwiLFwiVm9jU2VjdXJpdHlcIjpcIlRydWVcIixcIlZvY0RlZmF1bHRcIjpcIlRydWVcIn0iLCJleHAiOjE3MzkyMzkwNTUsImlzcyI6Imh0dHBzOi8vc3dzLnMtdGVjLmNvLmtyLyIsImF1ZCI6Imh0dHBzOi8vc3dzLnMtdGVjLmNvLmtyLyJ9.m940jSLcQXAWZnlU2U9PhPl2SZXJUMyCslr0JqZVcZ4";

            HttpResponseMessage response = await HttpApiServices.GetAsync("api/Login/sign/AdminPlaceList", AuthService.Token);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<ResponseUnit<ObservableCollection<AdminPlace>>>();
                
                if (responseBody != null && responseBody.code == 200)
                {
                    PlaceList = responseBody.data;
                    OnPropertyChanged(nameof(PlaceList));
                }
            }
        }

        /// <summary>
        /// 사업장 선택
        /// </summary>
        /// <param name="parameter"></param>
        private async void SelectPlace(object parameter)
        {
            // API 요청 -> 
            HttpResponseMessage response = await HttpApiServices.GetAsync($"api/Login/sign/SelectPlace?placeid={SelectedPlaces!.Id}", AuthService.Token);
            if(response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<ResponseUnit<string>>();
                if (responseBody!.code == 200)
                {
                    AuthService.Token = responseBody.data;
                    AuthService.PlaceId = SelectedPlaces!.Id;

                    Console.WriteLine(AuthService.Token);
                    Console.WriteLine(AuthService.PlaceId);

                    JwtHelper.DecodeJWTToken(responseBody.data, AuthService);
                    
                    Console.WriteLine(SelectedPlaces.Name.ToString());

                    // 작업 완료 후 창 닫힘 요청 (DialogResult true 전달)
                    RequestClose?.Invoke(this, true);
                }
                else
                {
                    MessageBox.Show(responseBody.message, "알림", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("잘못된 요청입니다.", "알림", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
