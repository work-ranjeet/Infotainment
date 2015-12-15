using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotainment.Data
{
    public enum NewsType
    {
        TopNews = 1,
        InternationalNews = 3
    }
    public enum ImageType
    {
        TopNewsImage = 1,
        InterNewsImage = 2,
        StateNewsImage = 3
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
}
