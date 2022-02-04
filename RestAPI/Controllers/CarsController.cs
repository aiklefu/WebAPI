using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Dtos;
using RestAPI.Models;
using RestAPI.Repos;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly IRepo _repo;

        public CarsController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<CarDto> GetCars()
        {
            var cars = _repo.GetCars();
            var carDtos = Converter.DbCarsToDtos(cars);
            return carDtos;
        }

        [HttpGet("{id}")]
        public ActionResult<CarDto> GetCar(Guid id)
        {
            var car = _repo.GetCar(id);

            if (car is null)
            {
                return NotFound();
            }

            var carDto = Converter.DbCarToDto(car);
            return Ok(carDto);
        }

        [HttpPost]
        public ActionResult<CarDto> CreateCar(CreateCarDto createCarDto)
        {
            Car car = new Car()
            {
                Id = Guid.NewGuid(),
                Brand = createCarDto.Brand,
                EngineNumber = createCarDto.EngineNumber,
                Price = createCarDto.Price,
                RegoNumber = createCarDto.RegoNumber,
                Year = createCarDto.Year
            };
            _repo.CreateCar(car);

            return CreatedAtAction(nameof(GetCar), new CarDto { Id = car.Id }, Converter.DbCarToDto(car));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCar(Guid id, UpdateCarDto updatecarDto)
        {
            var currentCar = _repo.GetCar(id);

            if (currentCar is null)
            {
                return NotFound();
            }

            Car updatedCar = new Car()
            {
                Brand = updatecarDto.Brand,
                EngineNumber = updatecarDto.EngineNumber,
                Price = updatecarDto.Price,
                RegoNumber = updatecarDto.RegoNumber,
                Year = updatecarDto.Year,
                Id = currentCar.Id
            };

            _repo.UpdateCar(updatedCar);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCar(Guid id)
        {
            var currentCar = _repo.GetCar(id);

            if (currentCar is null)
            {
                return NotFound();
            }

            _repo.DeleteCar(id);
            return NoContent();
        }
    }
}

