using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infotainment.Data.Controls;

namespace Infotainment.Areas.Admin.Models
{
    public class TopNewsActivationlList
    {
        public string Message { get; set; }

        public List<TopNewsActivation> ActivationlList { get; set; }
    }

    public class TopNewsActivation
    {
        public bool Selected { get; set; }

        public string TopNewsID { get; set; }

        public string ImageUrl { get; set; }

        public int IsActive { get; set; }

        public string Heading { get; set; }       

        public DateTime DttmCreated { get; set; }


    }
}