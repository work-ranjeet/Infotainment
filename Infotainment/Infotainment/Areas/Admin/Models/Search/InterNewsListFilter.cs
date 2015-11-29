using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Infotainment.Data.Controls;

namespace Infotainment.Areas.Admin.Models
{
    public class InterNewsListFilter : IDisposable
    {
        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }
       
        public bool IsActive { get; set; }

        public bool IsApproved { get; set; }

        [Required]
        public string Header { get; set; }

        public ConcurrentBag<IInterNews> NewsList { get; set; }

        #region Memory
        private bool disposed = false;
        ~InterNewsListFilter()
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