#region Copyright(c) 2015-2020. All Rights Reserved 
/*****************************************************************************
**                                                                          **
**                                                                          **
**                  WARNING --- TRADE SECRET --- WARNING                    **
**                                                                          **
**  This computer program is protected by copyright law and international   **
**  treaties. Unauthorized or distribution of this program, or any portion  **
**  of it may result in severe civil and criminal penalties, and will be    **
**  prosecuted to the maximum extent possible under the law.		           **
**                                                                          **
**                                                                          **
******************************************************************************
*
* Developed By: Oct-19-15, Ranjeet
*****************************************************************************/
#endregion

using System;


namespace Infotainment.Data.Controls
{
    public class ImageDetail : IImageDetail, IDisposable
    {
        private System.String _ImageID;
        private System.String _ImageUrl;
        private System.Int32 _ImageType;
        private System.String _Caption;
        private System.Int32 _IsFirst;
        private System.Int32 _IsActive;
        private System.DateTime _DttmCreated;
        private System.DateTime _DttmModified;

        public ImageDetail()
        {
            this._ImageID = null;
            this._ImageUrl = null;
            this._ImageType = System.Int32.MinValue;
            this._Caption = null;
            this._IsFirst = System.Int32.MinValue;
            this._IsActive = System.Int32.MinValue;
            this._DttmCreated = System.DateTime.MinValue;
            this._DttmModified = System.DateTime.MinValue;
        }

        public System.String ImageID
        {
            get
            {
                return this._ImageID;
            }
            set
            {
                this._ImageID = value;
            }
        }

        public bool ImageIDIsNull
        {
            get
            {
                return ((this._ImageID == null) || !(this._ImageID != null && this._ImageID.Length > 0));
            }
        }
       

        public System.String ImageUrl
        {
            get
            {
                return this._ImageUrl;
            }
            set
            {
                this._ImageUrl = value;
            }
        }

        public bool ImageUrlIsNull
        {
            get
            {
                return ((this._ImageUrl == null) || !(this._ImageUrl != null && this._ImageUrl.Length > 0));
            }
        }

        public System.Int32 ImageType
        {
            get
            {
                return this._ImageType;
            }
            set
            {
                this._ImageType = value;
            }
        }

        public bool ImageTypeIsNull
        {
            get
            {
                return (this._ImageType == System.Int32.MinValue);
            }
        }

        public System.String Caption
        {
            get
            {
                return this._Caption;
            }
            set
            {
                this._Caption = value;
            }
        }

        public bool CaptionIsNull
        {
            get
            {
                return ((this._Caption == null) || !(this._Caption != null && this._Caption.Length > 0));
            }
        }


        public System.Int32 IsFirst
        {
            get
            {
                return this._IsFirst;
            }
            set
            {
                this._IsFirst = value;
            }
        }

        public bool IsFirstImageIsNull
        {
            get
            {
                return (this._IsFirst == System.Int32.MinValue);
            }
        }

        public System.Int32 IsActive
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
                return (this._IsActive == System.Int32.MinValue);
            }
        }

        public System.DateTime DttmCreated
        {
            get
            {
                return this._DttmCreated;
            }
            set
            {
                this._DttmCreated = value;
            }
        }

        public bool DttmCreatedIsNull
        {
            get
            {
                return (this._DttmCreated == System.DateTime.MinValue);
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
        ~ImageDetail()
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
