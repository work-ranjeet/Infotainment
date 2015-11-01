using System;
namespace Infotainment.Models.Entities
{
    public interface INews : INewsHeading
    {
        string ImageUrl { get; set; }
        string ShortDescription { get; set; }
        string NewsDescription { get; set; }
    }
}
