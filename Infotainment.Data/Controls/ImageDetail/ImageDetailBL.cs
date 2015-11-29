using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotainment.Data.Controls
{
    public class ImageDetailBL
    {
        public static ImageDetailBL Instance
        {
            get { return new ImageDetailBL(); }
        }

        public IEnumerable<IImageDetail> SelectImageList(string NewsID)
        {
            return ImageDetailDb.Instance.SelectImageList(NewsID);
        }

        public IEnumerable<IImageDetail> SelectInterNewsImageList(string NewsID)
        {
            return ImageDetailDb.Instance.SelectInterNewsImageList(NewsID);
        }
    }
}
