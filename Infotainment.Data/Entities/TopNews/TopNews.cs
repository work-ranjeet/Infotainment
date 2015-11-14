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
* Developed By: Oct-11-15, Ranjeet
*****************************************************************************/
#endregion

using System;
namespace Infotainment.Data.Controls
{
    public class TopNews : ITopNews
    {
        private System.String _TopNewsID;
        private System.String _ImageUrl;
        private System.String _EditorID;
        private System.Int32 _DisplayOrder;
        private System.String _Heading;
        private System.String _ShortDescription;
        private System.String _NewsDescription;
        private System.Int32 _LanguageID;
        private System.Int32 _IsApproved;
        private System.Int32 _IsActive;
        private System.DateTime _DttmCreated;
        private System.DateTime _DttmModified;

        public TopNews()
        {
            this._TopNewsID = null;
            this._EditorID = null;
            this._DisplayOrder = System.Int32.MinValue;
            this._Heading = null;
            this._ShortDescription = null;
            this._NewsDescription = null;
            this._LanguageID = System.Int32.MinValue;
            this._IsApproved = System.Int32.MinValue;
            this._IsActive = System.Int32.MinValue;
            this._DttmCreated = System.DateTime.MinValue;
            this._DttmModified = System.DateTime.MinValue;
        }

        public System.String TopNewsID
        {
            get
            {
                return this._TopNewsID;
            }
            set
            {
                this._TopNewsID = value;
            }
        }

        public bool TopNewsIDIsNull
        {
            get
            {
                return ((this._TopNewsID == null) || !(this._TopNewsID != null && this._TopNewsID.Length > 0));
            }
        }

        public System.String EditorID
        {
            get
            {
                return this._EditorID;
            }
            set
            {
                this._EditorID = value;
            }
        }

        public bool EditorIDIsNull
        {
            get
            {
                return ((this._EditorID == null) || !(this._EditorID != null && this._EditorID.Length > 0));
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

        public bool HeadingIsNull
        {
            get
            {
                return ((this._Heading == null) || !(this._Heading != null && this._Heading.Length > 0));
            }
        }

        public System.String ShortDescription
        {
            get
            {
                return this._ShortDescription;
            }
            set
            {
                this._ShortDescription = value;
            }
        }

        public bool ShortDescriptionIsNull
        {
            get
            {
                return ((this._ShortDescription == null) || !(this._ShortDescription != null && this._ShortDescription.Length > 0));
            }
        }

        public System.String NewsDescription
        {
            get
            {
                return this._NewsDescription;
            }
            set
            {
                this._NewsDescription = value;
            }
        }

        public bool NewsDescriptionIsNull
        {
            get
            {
                return ((this._NewsDescription == null) || !(this._NewsDescription != null && this._NewsDescription.Length > 0));
            }
        }

        public System.Int32 LanguageID
        {
            get
            {
                return this._LanguageID;
            }
            set
            {
                this._LanguageID = value;
            }
        }

        public bool LanguageIDIsNull
        {
            get
            {
                return (this._LanguageID == System.Int32.MinValue);
            }
        }

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

        public bool IsApprovedIsNull
        {
            get
            {
                return (this._IsApproved == System.Int32.MinValue);
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

    }
}
