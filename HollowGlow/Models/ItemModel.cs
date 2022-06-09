using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HollowGlow.Models;

namespace HollowGlow.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }
        public int Name{ get; set; }
        public int Class { get; set; }
        public int Cost { get; set; }

        public int? UserId { get; set; }
        public UserModel user { get; set; }
    }
}
