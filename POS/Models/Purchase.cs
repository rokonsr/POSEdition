using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POS.Models
{
    [Table("Purchase")]
    public class Purchase : CommonProperties
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseId { get; set; }

        [Required(ErrorMessage = "Please enter an invoice number")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        [Required(ErrorMessage = "Please select a date")]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Please choose a supplier")]
        public int SupplierId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Remarks { get; set; }

        public double PaidAmount { get; set; }
        public double DueAmount { get; set; }

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}