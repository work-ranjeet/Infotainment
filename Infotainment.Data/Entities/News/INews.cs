﻿using System;
namespace Infotainment.Models.Entities
{
    public interface INewDesc : INewsHeading
    {
        string ImageUrl { get; set; }

        string ImageCaption { get; set; }
        string ShortDesc { get; set; }
        string NewsDesc { get; set; }

        bool IsRss { get; set; }
    }

    public interface INews : INewDesc, INewsHeading
    {
        System.DateTime DttmCreated { get; set; }
    }
}
