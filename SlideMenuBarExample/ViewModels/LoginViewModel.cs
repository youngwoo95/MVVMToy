using SlideMenuBarExample.Commands;
using SlideMenuBarExample.Commands.Interfaces;
using SlideMenuBarExample.Helpers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Input;

namespace SlideMenuBarExample.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string loginid;
        private string loginpassword;
        public ICommand LoginCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly HttpApiService HttpApiServices;
        private readonly IWindowService WindowService;
        private readonly IAuthService AuthService;

        public string LoginID
        {
            get => loginid;
            set
            {
                loginid = value;
                OnPropertyChanged(nameof(LoginID));
            }
        }

        public string LoginPasswword
        {
            get => loginpassword;
            set
            {
                loginpassword = value;
                OnPropertyChanged(nameof(loginpassword));
            }
        }

        public LoginViewModel(HttpApiService _httpapiservice, IWindowService _windowservice, IAuthService _authservice)
        {
            AuthService = _authservice;
            WindowService = _windowservice;
            LoginCommand = new RelayCommand<object>(ExecuteLogin);
            CancelCommand = new RelayCommand<object>(ExecuteCancel);

            this.HttpApiServices = _httpapiservice;
        }

        /// <summary>
        /// 로그인 버튼 이벤트
        /// </summary>
        /// <param name="parameter"></param>
        private async void ExecuteLogin(object parameter)
        {
            var loginData = new
            {
                UserId = LoginID,
                UserPassword = LoginPasswword
            };

            try
            {
                // 웹 서버의 로그인 API 앤드포인트 호출
                HttpResponseMessage response = await HttpApiServices.PostAsync("api/Login/Login", loginData);

                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<ResponseUnit<string>>();
                    if(responseBody.code == 200) // 일반 사용자
                    {
                        AuthService.Token = responseBody.data;
                        /*
                         
                         */

                        RequestClose?.Invoke(this, true);
                        // 일반 사용자는 그걸로 끝
                    }
                    else if(responseBody.code == 201) // 관리자
                    {
                        // 선택화면으로 변경되어야 하는데? 이건 어떻게하는거지?
                        AuthService.Token = responseBody.data;
                        // 관리자 일 경우, 사업장 선택 창을 띄워 선택 결과를 받음.
                        int placeResult = await WindowService.ShowPlaceSelectWindowAsync();
                        if(placeResult != -1)
                        {
                            AuthService.PlaceId = placeResult;
                            RequestClose?.Invoke(this, true);
                        }
                        else
                        {
                            Console.WriteLine("사업장을 선택하지 않았습니다.");
                        }
                    }
                    else
                    {
                        // 아이디 비밀번호가 안맞을때
                    }
                }
                else
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<ResponseUnit<string>>();
                    MessageBox.Show(responseBody?.data);

                }
            }
            catch(Exception ex)
            {

            }
        }


        // 로그인 성공 시 DialogResult(true) / 취소 시 DialogResult(false)를 알리기 위한 이벤트
        public event EventHandler<bool?> RequestClose;

        /// <summary>
        /// 취소 버튼 이벤트
        /// </summary>
        /// <param name="parameter"></param>
        private void ExecuteCancel(object parameter)
        {
            // 취소 시 DialogResult를 false로 전달하여 창을 닫음.
            RequestClose?.Invoke(this, false);
        }

    }
}
