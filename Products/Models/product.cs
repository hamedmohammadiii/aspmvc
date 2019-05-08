using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Brand Name")]
        [Required]
        public string BrandName { get; set; }
        [Display(Name = "Model Number")]
        [Required]
        public string ModelNo { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Type")]
        public int? TypeId { get; set; }
        public virtual ProductType Type { get; set; }
        
    }
}