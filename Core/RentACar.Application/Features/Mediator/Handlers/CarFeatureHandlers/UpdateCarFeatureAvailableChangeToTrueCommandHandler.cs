using MediatR;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvailableChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChangeToTrueCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateCarFeatureAvailableChangeToTrueCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(UpdateCarFeatureAvailableChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            _carFeatureRepository.ChangeCarFeatureAvailableToTrue(request.Id);
        }
    }
}
