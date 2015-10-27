﻿namespace Infotainment.Data.Controls
{
    public interface IImageDetail
    {
        System.String ImageID
        {
            get;
            set;
        }
       

        System.String ImageUrl
        {
            get;
            set;
        }

        System.Int32 ImageType
        {
            get;
            set;
        }

        System.Int32 IsNewsImage
        {
            get;
            set;
        }

        System.Int32 IsActive
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