using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using RentACar.Application.Interfaces.CarInterfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        private readonly ICarRepository _carRepository;
        public CreateCarCommandHandler(IRepository<Car> repository, ICarRepository carRepository)
        {
            _repository = repository;
            _carRepository = carRepository;
        }
        public async Task Handle(CreateCarCommand command)
        {
          var car = new Car
            {
                BigImageUrl = command.BigImageUrl,
                Luggage = command.Luggage,
                Km = command.Km,
                Model = command.Model,
                Seat = command.Seat,
                Transmission = command.Transmission,
                CoverImageUrl = command.CoverImageUrl,
                BrandID = command.BrandID,
                Fuel = command.Fuel
          };

            await _repository.CreateAsync(car);

            _carRepository.AddAllFeaturesToNewCar(car);
        }
    }
}
