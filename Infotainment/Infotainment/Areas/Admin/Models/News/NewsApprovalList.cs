using Infotainment.Data.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infotainment.Areas.Admin.Models
{
    public class NewsApprovalList :IDisposable
    {
        public string Message { get; set; }

        public string StateCode { get; set; }

        public IList<NewsApproval> ApprovalList { get; set; }

        #region Memory
        private bool disposed = false;
        ~NewsApprovalList()
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

    public class NewsApproval :IDisposable
    {
        public bool Selected { get; set; }

        public string TopNewsID { get; set; }

        public string ImageUrl { get; set; }

        public int IsApproved { get; set; }

        public int IsTopNews { get; set; }

        public string Heading { get; set; }

        public string StateCode { get; set; }

        public string StateName { get; set; }

        public DateTime DttmCreated { get; set; }

        #region Memory
        private bool disposed = false;
        ~NewsApproval()
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