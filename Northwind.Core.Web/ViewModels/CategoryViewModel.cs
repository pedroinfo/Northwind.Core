using System.ComponentModel.DataAnnotations;

namespace Northwind.Core.Web.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        
        public byte[] Picture { get; set; }
    }
}
