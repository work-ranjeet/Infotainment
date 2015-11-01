using System;
namespace Infotainment.Models.Entities
{
    public interface INewsHeading
    {
        string NewsID { get; set; }
        int DisplayOrder { get; set; }
        string Heading { get; set; }

    }
}
