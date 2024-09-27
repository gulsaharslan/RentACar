using FluentValidation;
using RentACar.Application.Features.Mediator.Commands.ReviewCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Validators.ReviewValidator
{
	public class CreateReviewValidator:AbstractValidator<CreateReviewCommand>
	{
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Ad Soyad boş bırakılamaz");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Ad Soyad 5 karakterden az olamaz");
			RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Puan değeri boş bırakılamaz");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum boş bırakılamaz");
			RuleFor(x => x.Comment).MinimumLength(20).WithMessage("Yorum 20 karakterden az olamaz");
			RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Yorum 500 karakterden fazla olamaz");
		}
	}
}
