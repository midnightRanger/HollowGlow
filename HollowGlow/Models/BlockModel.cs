using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HollowGlow.Models
{
    public class BlockModel
    {
        [Key]
        public int Id { get; set; }

        public string Timestamp { get; set; }

        public string Data { get; set; }

        public string Hash { get; set; }

        public int Nonce { get; set; }

        public int UserId { get; set; }
    }
}
