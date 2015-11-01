using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Infotainment.Data.Controls;

namespace Infotainment.Areas.Admin.Models
{
    public class TopNewsListFilter
    {
        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }
       
        public bool IsActive { get; set; }

        public bool IsApproved { get; set; }

        [Required]
        public string Header { get; set; }

        public ConcurrentBag<ITopNews> TopNewsList { get; set; }
    }
}