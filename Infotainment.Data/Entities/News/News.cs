using System;
using System.Collections.Generic;
using System.Linq;

namespace Infotainment.Models.Entities
{
    public class News : INews
    {
        public string NewsID { get; set; }

        public int DisplayOrder { get; set; }

        public string Heading { get; set; }

        public string ImageUrl { get; set; }

        public string ImageCaption { get; set; }

        public string ShortDesc { get; set; }

        public string NewsDesc { get; set; }

        public string EditorID { get; set; }

        public string EditorName { get; set; }

        public System.DateTime DttmCreated { get; set; }
    }

    //public class TopTenNewsList
    //{
    //    public IEnumerable<TopTenNews> TopTenNewsList { get; set; }
    //}
}