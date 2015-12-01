using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Infotainment.Models.Mailing
{
    public class Mail
    {
        [Required]
        [Display(Name ="Your Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Your Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Your Number")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Your Subject")]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Your Message")]
        public string Message { get; set; }

    }
}