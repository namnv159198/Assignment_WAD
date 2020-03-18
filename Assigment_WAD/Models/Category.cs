using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assigment_WAD.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [DisplayName("Category ")]
        public String CategoryName { get; set; }
    }
}