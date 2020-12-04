using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [ForeignKey("CategoryId")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Post Title")]
        public string PostTitle { get; set; }

        [Display(Name = "Post Description")]
        public string PostDescription { get; set; }

        [Display(Name = "Post Content")]
        public string PostContent { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Date Update")]
        public DateTime? DateUpdate { get; set; }


        public Category Category { get; set; }

    }
}
