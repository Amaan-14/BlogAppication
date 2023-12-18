using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Blog Id")]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public virtual Category Categories { get; set; }

        [Display(Name = "Photo1")]
        public string Photo1 { get; set; }

        [Display(Name = "Description1")]
        public string Description1 { get; set; }

        [Display(Name = "Photo2")]
        public string Photo2 { get; set; }

        [Display(Name = "Description2")]
        public string Description2 { get; set; }

        [Display(Name = "Photo3")]
        public string Photo3 { get; set; }

        [Display(Name = "Description3")]
        public string Description3 { get; set; }

        [Display(Name = "Photo4")]
        public string Photo4 { get; set; }

        [Display(Name = "Description4")]
        public string Description4 { get; set; }

        [Display(Name = "Photo5")]
        public string Photo5 { get; set; }

        [Display(Name = "Description5")]
        public string Description5 { get; set; }

        

    }
}