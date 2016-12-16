using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    [Table("Shop")]
    public class Shop : CommonProperties
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Shop name is required")]
        [Display(Name = "Shop Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage="Address is required")]
        [Display(Name = "Address")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(300)]
        public string Address { get; set; }

        [Required(ErrorMessage="Email address is required")]
        [Display(Name = "Email Address")]
        [Column(TypeName = "VARCHAR")]
        [EmailAddress(ErrorMessage = "Please Input Valid Email Address")]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Web Address")]
        [Column(TypeName = "VARCHAR")]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Please provide valid web address")]
        [StringLength(100)]
        public string WebAddress { get; set; }

        [Required(ErrorMessage="Phone number is required")]
        [Display(Name = "Phone Number")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string Phone { get; set; }

        public int FinancialYearId { get; set; }
        [ForeignKey("FinancialYearId")]
        public virtual FinancialYear FinancialYear { get; set; }
        public virtual ICollection<Product>Products { get; set; }

        [Required(ErrorMessage = "Create/Modification Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Create/Modification Date")]
        public DateTime ModifiedDate { get; set; }
    }
}