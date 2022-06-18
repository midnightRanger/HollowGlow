using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HollowGlow.Models
{
    public class BuildingGradesModel
    {
        [Key]
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int Lvl { get; set; }
        public int? Income { get; set; }
        public int? Defense { get; set; }
        public int Cost { get; set; }
        public BuildingModel Building { get; set; }
        public List<UserModel> Buyers { get; set; } = new List<UserModel>();
    }
}
