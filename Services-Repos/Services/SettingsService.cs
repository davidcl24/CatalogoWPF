using System.Globalization;

namespace Services_Repos.Services
{
    public class SettingsService 
    {
        public void ChangeLang(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

    }
}
