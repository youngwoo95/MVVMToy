using SlideMenuBarExample.ViewModels;
using System.Windows;

namespace SlideMenuBarExample.Views
{
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow(LoginViewModel viewModel)
        {
            InitializeComponent();

            // LoginViewModel 인스턴스 생성 및 DataContext 설정
            this.DataContext = viewModel;

            // ViewModel의 RequestClose 이벤트를 구독하여 창을 닫음
            viewModel.RequestClose += (s, dialogResult) =>
            {
                this.DialogResult = dialogResult;
                this.Close();
            };

            // PasswordBox의 PasswordChanged 이벤트에서 ViewModel의 Password 업데이트
            txtPassword.PasswordChanged += (s, e) =>
            {
                viewModel.LoginPasswword = txtPassword.Password;
            };

        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(DataContext is LoginViewModel vm)
            {
                vm.LoginPasswword = txtPassword.Password;
                if (string.IsNullOrEmpty(vm.LoginPasswword))
                    txtPasswordHint.Visibility = Visibility.Visible;
                else
                    txtPasswordHint.Visibility = Visibility.Collapsed;
            }

        }
    }
}
