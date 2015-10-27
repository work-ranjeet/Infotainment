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
* Developed By: Oct-14-15, Ranjeet
*****************************************************************************/
#endregion

using System;


namespace Infotainment.Data.Entities
{
	public class UserAddress : IUserAddress
    {
		private System.String _AddressID;
		private System.Int64 _UserID;
		private System.String _CareOf;
		private System.String _Address1;
		private System.String _Address2;
		private System.String _City;
		private System.String _State;
		private System.String _Country;
		private System.String _MobileNo;
		private System.String _PhoneNo;
		private System.DateTime _DttmCreated;
		private System.DateTime _DttmModified;

		public UserAddress()
		{
			this._AddressID = null;
			this._UserID = System.Int64.MinValue;
			this._CareOf = null;
			this._Address1 = null;
			this._Address2 = null;
			this._City = null;
			this._State = null;
			this._Country = null;
			this._MobileNo = null;
			this._PhoneNo = null;
			this._DttmCreated = System.DateTime.MinValue;
			this._DttmModified = System.DateTime.MinValue;
		}

		public System.String AddressID
		{
			get
			{
				return this._AddressID;
			}
			set
			{
				this._AddressID = value;
			}
		}

		public bool AddressIDIsNull
		{
			get
			{
				return ((this._AddressID == null) || !(this._AddressID != null && this._AddressID.Length > 0));
			}
		}

		public System.Int64 UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				this._UserID = value;
			}
		}

		public bool UserIDIsNull
		{
			get
			{
				return (this._UserID == System.Int64.MinValue);
			}
		}

		public System.String CareOf
		{
			get
			{
				return this._CareOf;
			}
			set
			{
				this._CareOf = value;
			}
		}

		public bool CareOfIsNull
		{
			get
			{
				return ((this._CareOf == null) || !(this._CareOf != null && this._CareOf.Length > 0));
			}
		}

		public System.String Address1
		{
			get
			{
				return this._Address1;
			}
			set
			{
				this._Address1 = value;
			}
		}

		public bool Address1IsNull
		{
			get
			{
				return ((this._Address1 == null) || !(this._Address1 != null && this._Address1.Length > 0));
			}
		}

		public System.String Address2
		{
			get
			{
				return this._Address2;
			}
			set
			{
				this._Address2 = value;
			}
		}

		public bool Address2IsNull
		{
			get
			{
				return ((this._Address2 == null) || !(this._Address2 != null && this._Address2.Length > 0));
			}
		}

		public System.String City
		{
			get
			{
				return this._City;
			}
			set
			{
				this._City = value;
			}
		}

		public bool CityIsNull
		{
			get
			{
				return ((this._City == null) || !(this._City != null && this._City.Length > 0));
			}
		}

		public System.String State
		{
			get
			{
				return this._State;
			}
			set
			{
				this._State = value;
			}
		}

		public bool StateIsNull
		{
			get
			{
				return ((this._State == null) || !(this._State != null && this._State.Length > 0));
			}
		}

		public System.String Country
		{
			get
			{
				return this._Country;
			}
			set
			{
				this._Country = value;
			}
		}

		public bool CountryIsNull
		{
			get
			{
				return ((this._Country == null) || !(this._Country != null && this._Country.Length > 0));
			}
		}

		public System.String MobileNo
		{
			get
			{
				return this._MobileNo;
			}
			set
			{
				this._MobileNo = value;
			}
		}

		public bool MobileNoIsNull
		{
			get
			{
				return ((this._MobileNo == null) || !(this._MobileNo != null && this._MobileNo.Length > 0));
			}
		}

		public System.String PhoneNo
		{
			get
			{
				return this._PhoneNo;
			}
			set
			{
				this._PhoneNo = value;
			}
		}

		public bool PhoneNoIsNull
		{
			get
			{
				return ((this._PhoneNo == null) || !(this._PhoneNo != null && this._PhoneNo.Length > 0));
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

	}

}
