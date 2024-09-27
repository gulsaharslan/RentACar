using MediatR;
using RentACar.Application.Features.Mediator.Commands.FeatureCommands;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;
        private readonly ICarFeatureRepository _carFeatureRepository;
        public CreateFeatureCommandHandler(IRepository<Feature> repository, ICarFeatureRepository carFeatureRepository)
        {
            _repository = repository;
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = new Feature
            {
                Name = request.Name
            };

            await _repository.CreateAsync(feature);

             _carFeatureRepository.AddNewFeatureToAllCars(feature);
        }
    }
}
