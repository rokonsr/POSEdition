using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    [Table("Product")]
    public class Product : CommonProperties
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [RegularExpression(@"^([A-Z a-z ]+)*$", ErrorMessage = "Only characters are allowed!")]
        [Required(ErrorMessage = "Product Name is Required")]
        [Display(Name = "Product Name")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "Shop")]
        public int ShopId { get; set; }
        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [Display(Name = "Measurement")]
        public int MeasurementId { get; set; }
        [ForeignKey("MeasurementId")]
        public virtual Measurement Measurement { get; set; }

        [RegularExpression(@"^([0-9 ]+)*$", ErrorMessage = "Only numbers are allowed!")]
        [Display(Name = "Stock")]
        public double Stock { get; set; }

        [Required(ErrorMessage = "Create/Modification Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                       ApplyFormatInEditMode = true)]
        [Display(Name = "Create/Modification Date")]
        public DateTime ModifiedDate { get; set; }

        //public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }

    }
}