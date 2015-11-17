using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infotainment.Areas.Admin.Models
{
    public class AdvertismentModel :IDisposable
    {
        public System.String AdvertismentID
        {
            get;
            set;
        }

        public System.Int32 DisplayOrder
        {
            get;
            set;
        }

        public System.String Heading
        {
            get;
            set;
        }

       
        public System.String WebUrl
        {
            get;
            set;
        }
        public System.String WebLink
        {
            get;
            set;
        }

      
        public System.String ShortDesc
        {
            get;
            set;
        }

       
        public HttpPostedFileBase Image
        {
            get;
            set;
        }

        public System.String ImgUrl
        {
            get;
            set;
        }

        public bool IsApproved
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        #region Memory
        private bool disposed = false;
        ~AdvertismentModel()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }


                disposed = true;
            }
        }
        #endregion
    }
}