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
    [Serializable]
    public class Users : IUsers
    {
        private System.Int64 _UserID;
        private System.String _FName;
        private System.String _MName;
        private System.String _LName;
        private System.String _Gender;
        private System.DateTime _Dob;
        private System.Int32 _Age;
        private System.Int16 _MariedSatus;
        private System.Int16 _IsActive;
        private System.Int16 _IsNew;
        private System.String _EmailID;
        private System.String _Email;
        private System.String _AddressID;
        private System.String _MobileNo;
        private System.String _Password;

        private System.DateTime _DttmCreated;
        private System.DateTime _DttmModified;


        public Users()
        {
            this._UserID = System.Int64.MinValue;
            this._FName = null;
            this._MName = null;
            this._LName = null;
            this._Gender = null;
            this._Dob = System.DateTime.MinValue;
            this._Age = System.Int32.MinValue;
            this._MariedSatus = System.Int16.MinValue;
            this._IsActive = System.Int16.MinValue;
            this._IsNew = System.Int16.MinValue;
            this._EmailID = null;
            this._Email = null;
            this._AddressID = null;
            this._MobileNo = null;
            this._Password = null;
            this._DttmCreated = System.DateTime.MinValue;
            this._DttmModified = System.DateTime.MinValue;
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

        public System.String FName
        {
            get
            {
                return this._FName;
            }
            set
            {
                this._FName = value;
            }
        }

        public bool FNameIsNull
        {
            get
            {
                return ((this._FName == null) || !(this._FName != null && this._FName.Length > 0));
            }
        }

        public System.String MName
        {
            get
            {
                return this._MName;
            }
            set
            {
                this._MName = value;
            }
        }

        public bool MNameIsNull
        {
            get
            {
                return ((this._MName == null) || !(this._MName != null && this._MName.Length > 0));
            }
        }

        public System.String LName
        {
            get
            {
                return this._LName;
            }
            set
            {
                this._LName = value;
            }
        }

        public bool LNameIsNull
        {
            get
            {
                return ((this._LName == null) || !(this._LName != null && this._LName.Length > 0));
            }
        }

        public System.String Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                this._Gender = value;
            }
        }

        public bool GenderIsNull
        {
            get
            {
                return ((this._Gender == null) || !(this._Gender != null && this._Gender.Length > 0));
            }
        }

        public System.DateTime Dob
        {
            get
            {
                return this._Dob;
            }
            set
            {
                this._Dob = value;
            }
        }

        public bool DobIsNull
        {
            get
            {
                return (this._Dob == System.DateTime.MinValue);
            }
        }

        public System.Int32 Age
        {
            get
            {
                return this._Age;
            }
            set
            {
                this._Age = value;
            }
        }

        public bool AgeIsNull
        {
            get
            {
                return (this._Age == System.Int32.MinValue);
            }
        }

        public System.Int16 MariedSatus
        {
            get
            {
                return this._MariedSatus;
            }
            set
            {
                this._MariedSatus = value;
            }
        }

        public bool MariedSatusIsNull
        {
            get
            {
                return (this._MariedSatus == System.Int16.MinValue);
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

        public System.Int16 IsNew
        {
            get
            {
                return this._IsNew;
            }
            set
            {
                this._IsNew = value;
            }
        }

        public bool IsNewIsNull
        {
            get
            {
                return (this._IsNew == System.Int16.MinValue);
            }
        }


        public System.String EmailID
        {
            get { return this._EmailID; }
            set { this._EmailID = value; }
        }

        public bool EmailIDIsNull
        {
            get
            {
                return ((this._EmailID == null) || !(this._EmailID != null && this._EmailID.Length > 0));
            }
        }

        public System.String Email
        {
            get { return this._Email; }
            set { this._Email = value; }
        }

        public bool EmailIsNull
        {
            get
            {
                return ((this._Email == null) || !(this._Email != null && this._Email.Length > 0));
            }
        }

        public System.String AddressID
        {
            get { return this._AddressID; }
            set { this._AddressID = value; }
        }

        public bool AddressIDIsNull
        {
            get
            {
                return ((this._AddressID == null) || !(this._AddressID != null && this._AddressID.Length > 0));
            }
        }

        public System.String MobileNo
        {
            get { return this._MobileNo; }
            set { this._MobileNo = value; }
        }

        public bool MobileNoIsNull
        {
            get
            {
                return ((this._MobileNo == null) || !(this._MobileNo != null && this._MobileNo.Length > 0));
            }
        }

        public System.String Password
        {
            get { return this._Password; }
            set { this._Password = value; }
        }

        public bool PasswordIsNull
        {
            get
            {
                return ((this._Password == null) || !(this._Password != null && this._Password.Length > 0));
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
