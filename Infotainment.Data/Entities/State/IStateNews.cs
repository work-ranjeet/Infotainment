namespace Infotainment.Data.Controls
{
    public interface IStateNews
    {
        System.String NewsID
        {
            get;
            set;
        }

        System.String EditorID
        {
            get;
            set;
        }

        System.String ImageUrl
        {
            get;
            set;
        }

        System.String ImageCaption
        {
            get;
            set;
        }

        System.String ImageCaptionLink
        {
            get;
            set;
        }

        System.Int32 DisplayOrder
        {
            get;
            set;
        }

        System.String Heading
        {
            get;
            set;
        }

        System.String ShortDescription
        {
            get;
            set;
        }

        System.String NewsDescription
        {
            get;
            set;
        }

        System.Int32 LanguageID
        {
            get;
            set;
        }

        System.String StateCode
        {
            get;
            set;
        }

        System.String StateName
        {
            get;
            set;
        }

        System.Int32 IsApproved
        {
            get;
            set;
        }

        System.Int32 IsActive
        {
            get;
            set;
        }

        System.Int32 IsTopNews
        {
            get;
            set;
        }

        System.Boolean IsRss
        {
            get;
            set;
        }

        System.DateTime DttmCreated
        {
            get;
            set;
        }

        System.DateTime DttmModified
        {
            get;
            set;
        }
    }
}