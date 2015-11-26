using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infotainment.Data.Entities
{
    public class UserGroup :IDisposable
    {
        private System.Int32 _GroupID;
        private System.String _GroupType;
        private System.String _GroupDetails;
        private System.Int16 _IsActive;
        private System.DateTime _DttmCreate;
        private System.DateTime _DttmModified;

        public UserGroup()
        {
            this._GroupID = System.Int32.MinValue;
            this._GroupType = null;
            this._GroupDetails = null;
            this._IsActive = System.Int16.MinValue;
            this._DttmCreate = System.DateTime.MinValue;
            this._DttmModified = System.DateTime.MinValue;
        }

        public System.Int32 GroupID
        {
            get
            {
                return this._GroupID;
            }
            set
            {
                this._GroupID = value;
            }
        }

        public bool GroupIDIsNull
        {
            get
            {
                return (this._GroupID == System.Int32.MinValue);
            }
        }

        public System.String GroupType
        {
            get
            {
                return this._GroupType;
            }
            set
            {
                this._GroupType = value;
            }
        }

        public bool GroupTypeIsNull
        {
            get
            {
                return ((this._GroupType == null) || !(this._GroupType != null && this._GroupType.Length > 0));
            }
        }

        public System.String GroupDetails
        {
            get
            {
                return this._GroupDetails;
            }
            set
            {
                this._GroupDetails = value;
            }
        }

        public bool GroupDetailsIsNull
        {
            get
            {
                return ((this._GroupDetails == null) || !(this._GroupDetails != null && this._GroupDetails.Length > 0));
            }
        }

        public System.Int16 IsActive
        {
            get
            {
                return this._IsActive;
            }
            set
            {
                this._IsActive = value;
            }
        }

        public bool IsActiveIsNull
        {
            get
            {
                return (this._IsActive == System.Int16.MinValue);
            }
        }

        public System.DateTime DttmCreate
        {
            get
            {
                return this._DttmCreate;
            }
            set
            {
                this._DttmCreate = value;
            }
        }

        public bool DttmCreateIsNull
        {
            get
            {
                return (this._DttmCreate == System.DateTime.MinValue);
            }
        }

        public System.DateTime DttmModified
        {
            get
            {
                return this._DttmModified;
            }
            set
            {
                this._DttmModified = value;
            }
        }

        public bool DttmModifiedIsNull
        {
            get
            {
                return (this._DttmModified == System.DateTime.MinValue);
            }
        }

        #region Memory
        private bool disposed = false;
        ~UserGroup()
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
