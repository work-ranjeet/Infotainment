using Infotainment.Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Areas.Admin.Models
{

    public class CreateStateNews :IDisposable
    {
        public CreateStateNews()
        {
            States = new List<IStateCode>();
        }

        [Required]
        public string Heading { get; set; }

        [Required]
        public HttpPostedFileBase Image { get; set; }

        [Required]
        public string ShortDesc { get; set; }

        [Required]
        public string  Caption { get; set; }

        public string CaptionLink { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [Required]
        public string StateCode { get; set; }

        [Required]
        public bool IsTopTenNews { get; set; }

        public List<IStateCode> States
        {
            get; set;
        }

        #region Memory
        private bool disposed = false;
        ~CreateStateNews()
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