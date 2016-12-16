using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    [Table("Supplier")]
    public class Supplier : CommonProperties
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }

        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Supplier name is required")]
        [Display(Name = "Supplier Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }

        [RegularExpression(@"^([0-9]+)*$", ErrorMessage = "Only Numbers are allowed!")]
        [Required(ErrorMessage = "Phone name is required")]
        [Display(Name = "Phone Number")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [Display(Name = "Email Address")]
        [Column(TypeName = "VARCHAR")]
        [EmailAddress(ErrorMessage = "Please Input Valid Email Address")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage="Address is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Address { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}