using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Areas.Admin.Models
{

    public class CreateTopTenNews
    {
        //[Required]
        //public string EditorID { get; set; }

        //[Required]
        //public int DisplayOrder { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public HttpPostedFileBase Image { get; set; }

        [Required]
        public string  ShortDesc { get; set; }

        [AllowHtml]
        //[Required]
        public string Description { get; set; }

        //[Required]
        //public int LanguageID { get; set; }

        
    }
}