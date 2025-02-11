using SlideMenuBarExample.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace SlideMenuBarExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Minimum_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Maximum_Click(object sender, RoutedEventArgs e)
        {
            // 현재 창 상태가 Maximized가 아니면 전체화면으로 전환
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowStyle = WindowStyle.None;      // 창 테두리 제거
                this.ResizeMode = ResizeMode.NoResize;      // 창 크기 조절 불가
                this.WindowState = WindowState.Maximized;    // 최대화 상태
                this.Topmost = true;                         // 다른 창 위에 항상 표시
            }
            // 이미 전체화면이면 원래 모드로 복원
            else
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.ResizeMode = ResizeMode.CanResize;
                this.WindowState = WindowState.Normal;
                this.Topmost = false;
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // 마우스 왼쪽 버튼이 눌린 상태이면 DragMove()를 호출하여 창 이동
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}