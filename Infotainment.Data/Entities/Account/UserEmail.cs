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
	public class UserEmail : IUserEmail
    {
		private System.String _EmailID;
		private System.Int64 _UserID;
		private System.String _Email;
		private System.Int32 _IsActive;
		private System.Int32 _IsVerified;
		private System.Int32 _IsVerCodeSent;
		private System.String _VerificationCode;
		private System.DateTime _DttmCreated;
		private System.DateTime _DttmModified;

		public UserEmail()
		{
			this._EmailID = null;
			this._UserID = System.Int64.MinValue;
			this._Email = null;
			this._IsActive = System.Int32.MinValue;
			this._IsVerified = System.Int32.MinValue;
			this._IsVerCodeSent = System.Int32.MinValue;
			this._VerificationCode = null;
			this._DttmCreated = System.DateTime.MinValue;
			this._DttmModified = System.DateTime.MinValue;
		}

		public System.String EmailID
		{
			get
			{
				return this._EmailID;
			}
			set
			{
				this._EmailID = value;
			}
		}

		public bool EmailIDIsNull
		{
			get
			{
				return ((this._EmailID == null) || !(this._EmailID != null && this._EmailID.Length > 0));
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

		public System.String Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				this._Email = value;
			}
		}

		public bool EmailIsNull
		{
			get
			{
				return ((this._Email == null) || !(this._Email != null && this._Email.Length > 0));
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

		public System.Int32 IsVerified
		{
			get
			{
				return this._IsVerified;
			}
			set
			{
				this._IsVerified = value;
			}
		}

		public bool IsVerifiedIsNull
		{
			get
			{
				return (this._IsVerified == System.Int32.MinValue);
			}
		}

		public System.Int32 IsVerCodeSent
		{
			get
			{
				return this._IsVerCodeSent;
			}
			set
			{
				this._IsVerCodeSent = value;
			}
		}

		public bool IsVerCodeSentIsNull
		{
			get
			{
				return (this._IsVerCodeSent == System.Int32.MinValue);
			}
		}

		public System.String VerificationCode
		{
			get
			{
				return this._VerificationCode;
			}
			set
			{
				this._VerificationCode = value;
			}
		}

		public bool VerificationCodeIsNull
		{
			get
			{
				return ((this._VerificationCode == null) || !(this._VerificationCode != null && this._VerificationCode.Length > 0));
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
