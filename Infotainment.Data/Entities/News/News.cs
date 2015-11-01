using System;
using System.Collections.Generic;
using System.Linq;

namespace Infotainment.Models.Entities
{
    public class News : INews, INewsHeading
    {
        public string NewsID { get; set; }

        public int DisplayOrder { get; set; }

        public string Heading { get; set; }

        public string ImageUrl { get; set; }

        public string ShortDescription { get; set; }

        public string NewsDescription { get; set; }
    }

    //public class TopTenNewsList
    //{
    //    public IEnumerable<TopTenNews> TopTenNewsList { get; set; }
    //}
}