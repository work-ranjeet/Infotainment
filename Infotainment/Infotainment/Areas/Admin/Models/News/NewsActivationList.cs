using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infotainment.Data.Controls;

namespace Infotainment.Areas.Admin.Models
{
    public class NewsActivationlList :IDisposable
    {
        public string Message { get; set; }

        public string StateCode { get; set; }

        public List<NewsActivation> ActivationlList { get; set; }

        #region Memory
        private bool disposed = false;
        ~NewsActivationlList()
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

    public class NewsActivation :IDisposable
    {
        public bool Selected { get; set; }

        public string TopNewsID { get; set; }

        public string ImageUrl { get; set; }

        public int IsActive { get; set; }

        public int IsTopNews { get; set; }

        public string Heading { get; set; }       

        public DateTime DttmCreated { get; set; }

        #region Memory
        private bool disposed = false;
        ~NewsActivation()
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