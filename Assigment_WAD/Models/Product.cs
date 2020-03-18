using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Assigment_WAD.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        [Range(0,9999,ErrorMessage = "Price is not be bigger than 9999 and shorter than 0")]
        public double Price  { get; set; }
        [Required]
        public String Picture { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a correct license")]
        public EnumGender Gender { get; set; }
        public enum EnumGender
        {
            Boy = 1,
            Girl= 2,
            All = 3
        }

        public int QuantityProductDefault = 1;
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        [DisplayName("Category")]
        public virtual Category Category { get; set; }

    }
}