﻿using Infotainment.Data.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infotainment.Areas.Admin.Models
{
    public class TopNewsApprovalList :IDisposable
    {
        public string Message { get; set; }

        public IList<TopNewsApproval> ApprovalList { get; set; }

        #region Memory
        private bool disposed = false;
        ~TopNewsApprovalList()
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

    public class TopNewsApproval :IDisposable
    {
        public bool Selected { get; set; }

        public string TopNewsID { get; set; }

        public string ImageUrl { get; set; }

        public int IsApproved { get; set; }

        public string Heading { get; set; }

        public DateTime DttmCreated { get; set; }

        #region Memory
        private bool disposed = false;
        ~TopNewsApproval()
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