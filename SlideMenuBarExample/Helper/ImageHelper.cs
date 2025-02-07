using System.Windows.Media.Imaging;
using System.Windows;

namespace SlideMenuBarExample.Helper
{
    public class ImageHelper
    {
        public static WriteableBitmap InvertImage(BitmapSource source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            int width = source.PixelWidth;
            int height = source.PixelHeight;
            // Bgra32와 같이 32비트 픽셀 포맷일 경우, 한 픽셀 당 4바이트 사용
            int bytesPerPixel = (source.Format.BitsPerPixel + 7) / 8;
            int stride = width * bytesPerPixel;
            byte[] pixels = new byte[height * stride];

            // 픽셀 데이터 복사
            source.CopyPixels(pixels, stride, 0);

            // 각 픽셀의 R, G, B 채널 값을 반전 (Alpha는 그대로 둠)
            for (int i = 0; i < pixels.Length; i += bytesPerPixel)
            {
                // pixels[i]   : Blue
                // pixels[i+1] : Green
                // pixels[i+2] : Red
                // pixels[i+3] : Alpha
                pixels[i] = (byte)(255 - pixels[i]);     // Blue 채널
                pixels[i + 1] = (byte)(255 - pixels[i + 1]); // Green 채널
                pixels[i + 2] = (byte)(255 - pixels[i + 2]); // Red 채널
                                                             // pixels[i+3] (Alpha)는 그대로 둡니다.
            }

            // 반전된 픽셀 데이터를 새로운 WriteableBitmap에 적용
            WriteableBitmap invertedBitmap = new WriteableBitmap(width, height, source.DpiX, source.DpiY, source.Format, null);
            invertedBitmap.WritePixels(new Int32Rect(0, 0, width, height), pixels, stride, 0);

            return invertedBitmap;
        }
    }
}
