using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EShopWebMvc.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Category name cannot be empty")]
        [MinLength(3, ErrorMessage ="Minimum 3 characters required")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage ="Maximum 500 characters allowed")]
        public string Description { get; set; }
    }
}
