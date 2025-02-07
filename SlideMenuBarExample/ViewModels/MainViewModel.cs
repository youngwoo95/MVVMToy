using SlideMenuBarExample.Helper;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SlideMenuBarExample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ImageSource invertedhomeimage;
     

        public ImageSource InvertedHomeImage
        {
            get
            {
                return invertedhomeimage;
            }
            set
            {
                if(invertedhomeimage != value)
                {
                    invertedhomeimage = value;
                    OnPropertyChanged(nameof(InvertedHomeImage));
                }
            }
        }

        public MainViewModel()
        {
            // 원본 이미지 불러오기 (Build Action이 Content이고, Copy to Output Directory가 설정되어 있어야 한다)
            BitmapImage originalImage = new BitmapImage(new Uri("ico/home.ico", UriKind.Relative));
            InvertedHomeImage = ImageHelper.InvertImage(originalImage);
            //originalImage = new BitmapImage(new Uri("ico/home.ico", UriKind.Relative));
        }



    }
}
