using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HollowGlow.Models
{
    public class UpgradesShopModel
    {
        [Key]
        public int Id { get; set; }
        public int Lvl { get; set; }
        public int Cost { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int IsBought { get; set;  }
    }
}
