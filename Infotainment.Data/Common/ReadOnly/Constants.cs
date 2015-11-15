using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotainment.Data
{
    public enum ImageType
    {
        TopNewsImage = 1
    }

    public enum AdvertismentType
    {
        TopNewsAdd = 1
    }

    public enum Position
    {
        TopLeft = 1,
        TopRight = 2,
        BottmLeft = 3,
        BottomRight = 4,
        Center = 5,
        CenterLeft = 6,
        CenterRight = 7,
        PageRight = 8,
        PageLeft = 9,
        PageTop = 10,
        PageBottom = 11
    }
    public class Constants
    {
        public static readonly string UserSessionKey = "UserLoginDetail";

    }

    public class ImagePath
    {
        public static readonly string TopTenNewsImage = "~/Images/Top-ten";
        public static readonly string TopTenAdvertisment = "~/Images/Advertisment/Topten";

    }
}
