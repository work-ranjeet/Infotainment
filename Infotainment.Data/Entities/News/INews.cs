using System;
namespace Infotainment.Models.Entities
{
    public interface INews : INewsHeading
    {
        string ImageUrl { get; set; }
        string ShortDesc { get; set; }
        string NewsDesc { get; set; }
    }
}
