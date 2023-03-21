using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropDealProject.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [ForeignKey("CropOnSale")]

        public int CropSaleId { get; set; }
        [ForeignKey("UserProfile")]

        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        
        public string CropName { get; set; }
        public string CropType { get; set; }
        public int CropQty { get; set; }
        public double OrderTotal { get; set; }
        public string Review { get; set; }

        //[JsonIgnore]
       //public virtual CropOnSale Crops {get;set;}
        
    }
}
