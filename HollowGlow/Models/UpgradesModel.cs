using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HollowGlow.Models;

namespace HollowGlow.Models
{
    public class UpgradesModel
    {
        [Key]
        public int Id { get; set; }
        public int MainBuilding { get; set; }
        public int Miner{ get; set; }
        public int Defence{ get; set; }

        public int? UserId { get; set; }
        public UserModel user { get; set; }
    }
}
