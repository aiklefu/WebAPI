using System;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Dtos
{
    public class UpdateCarDto
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public string EngineNumber { get; set; }

        public string RegoNumber { get; set; }
        [Required]
        [Range(0, Int16.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(1900, 3000)]
        public int Year { get; set; }
    }
}
