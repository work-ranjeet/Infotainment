using Infotainment.Data.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infotainment.Areas.Admin.Models
{
    public class TopNewsApprovalList
    {
        public string Message { get; set; }

        public IList<TopNewsApproval> ApprovalList { get; set; }
    }

    public class TopNewsApproval
    {
        public bool Selected { get; set; }

        public string TopNewsID { get; set; }

        public int IsApproved { get; set; }

        public string Heading { get; set; }

        public DateTime DttmCreated { get; set; }

    }
   
}