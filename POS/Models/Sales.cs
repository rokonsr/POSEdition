using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    [Table("Sales")]
    public class Sales
    {
        //public const string SalesInvoicePrefix = "SInv-";


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesId { get; set; }

        [Required(ErrorMessage = "Please enter an invoice number")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
   
        public string SalesInvoiceNo { get; set; }

        [Required(ErrorMessage = "Please select a date")]
        public DateTime SalesDate { get; set; }

        [Required(ErrorMessage = "Please choose a Customer")]
        public int CustomerId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Remarks { get; set; }

        public double OverallDiscount { get; set; }
        public virtual ICollection<SalesDetail> SalesDetailses { get; set; }
    }
}