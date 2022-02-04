using System.Collections.Generic;
using System.Linq;
using RestAPI.Models;

namespace RestAPI.Dtos
{
    public class Converter
    {
        public static CarDto DbCarToDto(Car car)
        {
            return new CarDto
            {
                Brand = car.Brand,
                EngineNumber = car.EngineNumber,
                Id = car.Id,
                Price = car.Price,
                RegoNumber = car.RegoNumber,
                Year = car.Year
            };
        }

        public static IEnumerable<CarDto> DbCarsToDtos(IEnumerable<Car> cars)
        {
            var carDtos = cars.Select(
                car => new CarDto
                {
                    Brand = car.Brand,
                    EngineNumber = car.EngineNumber,
                    Id = car.Id,
                    Price = car.Price,
                    RegoNumber = car.RegoNumber,
                    Year = car.Year
                }
            );

            return carDtos;
        }
    }
}