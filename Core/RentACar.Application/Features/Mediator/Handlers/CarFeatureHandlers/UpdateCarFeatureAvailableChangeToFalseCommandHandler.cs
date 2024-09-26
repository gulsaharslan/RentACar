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
    public class UpdateCarFeatureAvailableChangeToFalseCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChangeToFalseCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateCarFeatureAvailableChangeToFalseCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(UpdateCarFeatureAvailableChangeToFalseCommand request, CancellationToken cancellationToken)
        {
             _carFeatureRepository.ChangeCarFeatureAvailableToFalse(request.Id);
        }
    }
}
