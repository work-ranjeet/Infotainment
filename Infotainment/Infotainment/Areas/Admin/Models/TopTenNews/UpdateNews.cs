using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Areas.Admin.Models
{
    public class UpdateNews :IDisposable
    {
        //[Required]
        //public string EditorID { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [Required]
        public string Heading { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public HttpPostedFileBase Image { get; set; }

        [Required]
        public string ShortDesc { get; set; }

        [AllowHtml]
        //[Required]
        public string Description { get; set; }


        #region /// Memory Management
        private bool disposed = false;
        ~UpdateNews()
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