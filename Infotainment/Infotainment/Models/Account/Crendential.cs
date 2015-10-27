using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotainment.Models
{
    public class Crendential  : IDisposable
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }


        #region Memory
        private bool disposed = false;
        ~Crendential()
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
