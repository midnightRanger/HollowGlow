using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HollowGlow.Models
{
    public class BuildingModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int TypeId { get; set; }
        public BuildingTypeModel Type { get; set; }

        public List<BuildingGradesModel> Grades { get; set; }
    }
}
