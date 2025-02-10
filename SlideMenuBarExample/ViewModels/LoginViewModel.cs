using SlideMenuBarExample.Commands;
using SlideMenuBarExample.Helpers;
using System.Windows.Input;

namespace SlideMenuBarExample.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string loginid;
        private string loginpassword;

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

        // 로그인 성공 시 DialogResult(true) / 취소 시 DialogResult(false)를 알리기 위한 이벤트
        public event EventHandler<bool?> RequestClose;

        public ICommand LoginCommand { get; }
        public ICommand CancelCommand { get; }

        private readonly HttpApiService HttpApiServices;
        

        public LoginViewModel(HttpApiService _httpapiservice)
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
            CancelCommand = new RelayCommand(ExecuteCancel);

            this.HttpApiServices = _httpapiservice;
        }

        /// <summary>
        /// 로그인 버튼 이벤트
        /// </summary>
        /// <param name="parameter"></param>
        private void ExecuteLogin(object parameter)
        {
            if (LoginID == "admin" && LoginPasswword == "1234")
            {
                // 로그인 성공 알림 (DialogResult를 True로 전달)
                RequestClose?.Invoke(this, true);
            }
            else
            {
                Console.WriteLine(LoginID);
                Console.WriteLine(LoginPasswword);
            }
        }

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
