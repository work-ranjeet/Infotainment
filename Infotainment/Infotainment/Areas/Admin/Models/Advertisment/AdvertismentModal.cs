﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infotainment.Areas.Admin.Models
{
    public class AdvertismentModal :IDisposable
    {
        public System.String AdvertismentID
        {
            get;
            set;
        }

        [Display(Description ="Enter unique number")]
        [Required(ErrorMessage ="Enter Dispaly Order")]
        public System.Int32 DisplayOrder
        {
            get;
            set;
        }

        [Display(Description = "Enter Caption")]
        [Required(ErrorMessage = "Caption should not be empty")]
        public System.String Heading
        {
            get;
            set;
        }

        [Display(Description = "Enter web url")]
        [Required(ErrorMessage = "Web url should not be empty")]
        public System.String WebUrl
        {
            get;
            set;
        }

        [Display(Description = "Enter web url link")]
        [Required(ErrorMessage = "Web url link should not be empty")]
        public System.String WebLink
        {
            get;
            set;
        }

        [Display(Description = "Enter descripton")]
        [Required(ErrorMessage = "Description should not be empty")]
        public System.String ShortDesc
        {
            get;
            set;
        }

        [Display(Description = "Select Image")]
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
        ~AdvertismentModal()
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