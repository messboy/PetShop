using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace backend.ViewModel
{
    public class LogonViewModel
    {
        [Required]
        [Display(Name = "帳號")]
        public string Account { get; set; }
        [Required]
        [Display(Name = "密碼")]
        public string Password { get; set; }
        [Display(Name = "Remember me next time.")]
        public bool Remember { get; set; }
    }
}