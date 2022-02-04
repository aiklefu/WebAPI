using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class Car
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string EngineNumber { get; set; }

        public string RegoNumber { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Year { get; set; }
    }
}
