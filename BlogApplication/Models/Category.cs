using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        public string Name { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}