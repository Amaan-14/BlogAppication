using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "User Id")]
        public int Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}