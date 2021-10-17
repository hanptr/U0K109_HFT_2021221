using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace U0K109_HFT_2021221.Models
{
    public class AppleService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string Location { get; set; }
        [NotMapped]
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<AppleProduct> Products { get; set; }
        public AppleService()
        {
            Customers = new HashSet<Customer>();
            Products = new HashSet<AppleProduct>();
        }
    }
}
