using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HollowGlow.Models
{
    public class BuildingTypeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BuildingModel> Buildings { get; set; }
    }
}
