using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace U0K109_HFT_2021221.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public virtual ICollection<AppleProduct> Products { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual AppleService AppleService { get; set; }
        [ForeignKey(nameof(AppleService))]
        public int ServiceID { get; set; }
        public Customer()
        {
            Products = new HashSet<AppleProduct>();
        }
        public override string ToString()
        {
            string cname = "-";
            string cemail = "-";
            if (Name != null)
            {
                cname = Name;
            }
            if (Email != null)
            {
                cemail = Email;
            }
            return "Customer ID: " + CustomerID + "\nName: " + cname + "\nEmail: " + cemail + "\nUsed this Apple service (service id): " + ServiceID;
        }
    }
}
