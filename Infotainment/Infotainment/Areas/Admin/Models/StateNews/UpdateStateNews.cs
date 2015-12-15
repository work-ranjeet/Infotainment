using Infotainment.Data.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Areas.Admin.Models
{
    public class UpdateStateNews : IDisposable
    {
        public string NewsID { get; set; }

        public string EditorID { get; set; }

        [Required]
        public string Heading { get; set; }

        public string ImageUrl { get; set; }

        public string Caption { get; set; }

        public string CaptionLink { get; set; }

        public HttpPostedFileBase Image { get; set; }

        [Required]
        public bool IsActiveNews { get; set; }

        [Required]
        public bool IsApprovedNews { get; set; }

        [Required]
        public bool IsTopTenNews { get; set; }

        [Required]
        public  string ShortDesc { get; set; }

        [AllowHtml]
        public  string Description { get; set; }


        #region /// Memory Management
        private bool disposed = false;
        ~UpdateStateNews()
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