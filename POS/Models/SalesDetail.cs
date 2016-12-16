using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    [Table("SalesDetail")]
    public class SalesDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesDetailId { get; set; }

        public int SalesId { get; set; }
        [ForeignKey("SalesId")]
        public virtual Sales Sales { get; set; }

        [Required(ErrorMessage = "Please choose a product")]
        public int ProductId { get; set; }
        public int BarCode { get; set; }
        public double Quantity { get; set; }
        public double SRate { get; set; }
        public double Vat { get; set; }
        public double LineDiscount { get; set; }
    }
}