using System;

namespace RestAPI.Dtos
{
    public class CarDto
    {
        public Guid Id { get; set; }

        public string Brand { get; set; }

        public string EngineNumber { get; set; }

        public string RegoNumber { get; set; }

        public decimal Price { get; set; }
        public int Year { get; set; }
    }
}
