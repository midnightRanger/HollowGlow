using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HollowGlow.Models;

namespace HollowGlow.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int Coins { get; set; }
        public UpgradesModel UpgradesModel { get; set; }
    }
}
