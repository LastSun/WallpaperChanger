using System.Runtime.InteropServices;

namespace Core
{
    public class WallpaperHandler
    {
        public const int SpiSetdeskwallpaper = 20;
        public const int SpifUpdateinifile = 1;
        public const int SpifSendchange = 2;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public bool SetWallpaper(string fileName)
        {
            return SystemParametersInfo(SpiSetdeskwallpaper, 0, fileName, SpifUpdateinifile | SpifSendchange);
        }
    }
}
