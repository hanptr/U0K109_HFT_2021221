using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace U0K109_HFT_2021221.Models
{
    public enum Type {Mac, iPhone, iPad, AppleWatch}
    public class AppleProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Serial { get; set; }
        public Type Type { get; set; }
        public string Color { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual AppleService AppleService { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(AppleService))]
        public int ServiceID { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        public override string ToString()
        {
            string pcolor = "-";
            if (Color!=null)
            {
                pcolor = Color;
            }
            return "Serial number: "+Serial+"\nType: "+Type+"\nColor: "+pcolor+"\nOwner (customer id): "+CustomerID+"\nIn this Apple service: "+ServiceID;
        }
    }
}
