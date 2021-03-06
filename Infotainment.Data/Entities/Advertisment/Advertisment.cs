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
* Developed By: Nov-15-15, Ranjeet
*****************************************************************************/
#endregion

using System;
using Newtonsoft.Json;


namespace Infotainment.Data.Entities
{
	public class Advertisment : IAdvertisment, IDisposable
    {
		private System.String _AdvertismentID;
		private System.Int32 _DisplayOrder;
		private System.String _Heading;
		private System.String _WebUrl;
        private System.String _WebLink;
        private System.String _ShortDesc;
		private System.String _ImgUrl;
		private System.Int32 _AdvertismentType;
		private System.Int32 _Position;
		private System.Int32 _IsApproved;
		private System.Int32 _IsActive;
		private System.DateTime _DttmCreated;
		private System.DateTime _DttmModified;

		public Advertisment()
		{
			this._AdvertismentID = null;
			this._DisplayOrder = System.Int32.MinValue;
			this._Heading = null;
			this._WebUrl = null;
			this._ShortDesc = null;
			this._ImgUrl = null;
			this._AdvertismentType = System.Int32.MinValue;
			this._Position = System.Int32.MinValue;
			this._IsApproved = System.Int32.MinValue;
			this._IsActive = System.Int32.MinValue;
			this._DttmCreated = System.DateTime.MinValue;
			this._DttmModified = System.DateTime.MinValue;
		}

        [JsonIgnore]
        public System.String AdvertismentID
		{
			get
			{
				return this._AdvertismentID;
			}
			set
			{
				this._AdvertismentID = value;
			}
		}

        [JsonIgnore]
        public bool AdvertismentIDIsNull
		{
			get
			{
				return ((this._AdvertismentID == null) || !(this._AdvertismentID != null && this._AdvertismentID.Length > 0));
			}
		}

        [JsonIgnore]
        public System.Int32 DisplayOrder
		{
			get
			{
				return this._DisplayOrder;
			}
			set
			{
				this._DisplayOrder = value;
			}
		}

        [JsonIgnore]
        public bool DisplayOrderIsNull
		{
			get
			{
				return (this._DisplayOrder == System.Int32.MinValue);
			}
		}

		public System.String Heading
		{
			get
			{
				return this._Heading;
			}
			set
			{
				this._Heading = value;
			}
		}

        [JsonIgnore]
        public bool HeadingIsNull
		{
			get
			{
				return ((this._Heading == null) || !(this._Heading != null && this._Heading.Length > 0));
			}
		}

		public System.String WebUrl
		{
			get
			{
				return this._WebUrl;
			}
			set
			{
				this._WebUrl = value;
			}
		}

        [JsonIgnore]
        public bool WebUrlIsNull
		{
			get
			{
				return ((this._WebUrl == null) || !(this._WebUrl != null && this._WebUrl.Length > 0));
			}
		}

        public System.String WebLink
        {
            get
            {
                return this._WebLink;
            }
            set
            {
                this._WebLink = value;
            }
        }

        [JsonIgnore]
        public bool WebLinkIsNull
        {
            get
            {
                return ((this._WebLink == null) || !(this._WebLink != null && this._WebLink.Length > 0));
            }
        }

        public System.String ShortDesc
		{
			get
			{
				return this._ShortDesc;
			}
			set
			{
				this._ShortDesc = value;
			}
		}

        [JsonIgnore]
        public bool ShortDescIsNull
		{
			get
			{
				return ((this._ShortDesc == null) || !(this._ShortDesc != null && this._ShortDesc.Length > 0));
			}
		}

		public System.String ImgUrl
		{
			get
			{
				return this._ImgUrl;
			}
			set
			{
				this._ImgUrl = value;
			}
		}

        [JsonIgnore]
        public bool ImgUrlIsNull
		{
			get
			{
				return ((this._ImgUrl == null) || !(this._ImgUrl != null && this._ImgUrl.Length > 0));
			}
		}

        [JsonIgnore]
        public System.Int32 AdvertismentType
		{
			get
			{
				return this._AdvertismentType;
			}
			set
			{
				this._AdvertismentType = value;
			}
		}

        [JsonIgnore]
        public bool AdvertismentTypeIsNull
		{
			get
			{
				return (this._AdvertismentType == System.Int32.MinValue);
			}
		}

        [JsonIgnore]
        public System.Int32 Position
		{
			get
			{
				return this._Position;
			}
			set
			{
				this._Position = value;
			}
		}

        [JsonIgnore]
        public bool PositionIsNull
		{
			get
			{
				return (this._Position == System.Int32.MinValue);
			}
		}

        [JsonIgnore]
        public System.Int32 IsApproved
		{
			get
			{
				return this._IsApproved;
			}
			set
			{
				this._IsApproved = value;
			}
		}

        [JsonIgnore]
        public bool IsApprovedIsNull
		{
			get
			{
				return (this._IsApproved == System.Int32.MinValue);
			}
		}

        [JsonIgnore]
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

        [JsonIgnore]
        public bool IsActiveIsNull
		{
			get
			{
				return (this._IsActive == System.Int32.MinValue);
			}
		}

        [JsonIgnore]
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

        [JsonIgnore]
        public bool DttmCreatedIsNull
		{
			get
			{
				return (this._DttmCreated == System.DateTime.MinValue);
			}
		}

        [JsonIgnore]
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

        [JsonIgnore]
        public bool DttmModifiedIsNull
		{
			get
			{
				return (this._DttmModified == System.DateTime.MinValue);
			}
		}

        #region Memory
        private bool disposed = false;
        ~Advertisment()
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
