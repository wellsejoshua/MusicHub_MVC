using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace MusicHub.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        //Type is physical or digital
        [Required]
        [DisplayName("Type")]
        [MaxLength(100)]
        public string? Type { get; set; }

        [Required]
        [DisplayName("Product Name")]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "List Price")]
        [Range(1, 2000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 2000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 2000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 2000)]
        public double Price100 { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }

        //Navigation Propeties
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category? Category { get; set; }

    }
}
