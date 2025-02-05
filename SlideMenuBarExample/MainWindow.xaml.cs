using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SlideMenuBarExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 메뉴가 열려있는 상태를 나타내는 플래그 (초기값 true: 열림)
        private bool isMenuOpen = false;

        public MainWindow()
        {
            InitializeComponent();
            // 초기 상태에서 메뉴를 열어둔 상태이므로, TranslateTransform.X는 0이어야 함.
            MenuTranslate.X = -150;
        }

        // 마우스가 메뉴 영역으로 들어왔을 때 호출
        private void SlideMenu_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isMenuOpen)
            {
                DoubleAnimation openAnimation = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                    From = -150,  // 닫힌 상태의 X 오프셋
                    To = 0        // 열린 상태의 X 오프셋
                };
                MenuTranslate.BeginAnimation(TranslateTransform.XProperty, openAnimation);
                isMenuOpen = true;
            }
        }

        // 마우스가 메뉴 영역을 벗어났을 때 호출
        private void SlideMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isMenuOpen)
            {
                DoubleAnimation closeAnimation = new DoubleAnimation
                {
                    Duration = TimeSpan.FromSeconds(0.4),
                    From = 0,     // 열린 상태의 X 오프셋
                    To = -150     // 닫힌 상태의 X 오프셋 (메뉴가 왼쪽으로 숨겨짐)
                };
                MenuTranslate.BeginAnimation(TranslateTransform.XProperty, closeAnimation);
                isMenuOpen = false;
            }
        }
    }
}