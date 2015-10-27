using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Infotainment.Areas.Admin.Models
{
    public class NewsListFilter
    {
        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        public int IsActive { get; set; }

        [Required]
        public int IsApproved { get; set; }

        [Required]
        public string Header { get; set; }
    }
}