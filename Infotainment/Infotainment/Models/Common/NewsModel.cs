using Infotainment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infotainment.Models.Common
{
    public class NewsModel : INewDesc, IDisposable
    {
        public string NewsID { get; set; }

        public int DisplayOrder { get; set; }

        public string Heading { get; set; }

        public string ImageUrl { get; set; }

        public string ImageCaption { get; set; }

        public string ShortDesc { get; set; }

        public string NewsDesc { get; set; }

        public bool IsRss { get; set; }

        #region Memory
        private bool disposed = false;
        ~NewsModel()
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