using MediatR;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateFeatureWithCarFeaturesCommandHandler : IRequestHandler<CreateFeatureWithCarFeaturesCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateFeatureWithCarFeaturesCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }
        public async Task Handle(CreateFeatureWithCarFeaturesCommand request, CancellationToken cancellationToken)
        {
            var feature = new Feature
            {
                Name = request.Name
            };

            // Repository aracılığıyla tüm araçlara false olarak ekle
             _carFeatureRepository.AddNewFeatureToAllCars(feature);
        }
    }
}
