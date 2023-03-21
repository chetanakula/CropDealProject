using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropDealProject.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
            CropOnSales = new HashSet<CropOnSale>();
            //InvoiceDealers = new HashSet<Invoice>();
            //InvoiceFarmers = new HashSet<Invoice>();
        }

        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNo { get; set; }
        public string UserAddress { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
        public long UserAccNo { get; set; }
        public string UserIfsc { get; set; }
        public string UserBankName { get; set; }
        public string UserStatus { get; set; }

        [JsonIgnore]
        public virtual ICollection<CropOnSale> CropOnSales { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Invoice> InvoiceDealers { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Invoice> InvoiceFarmers { get; set; }
    }
}
