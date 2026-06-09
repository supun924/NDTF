using FluentValidation;
using NDTFAPI.Application.Features.Drivers.Commands.UpdateDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Drivers.Validators
{
    public class UpdateDriverValidator : AbstractValidator<UpdateDriverCommand>
    {
        public UpdateDriverValidator()
        {
            RuleFor(x => x.LicenseNumber)
                .NotEmpty();

            RuleFor(x => x.NICNumber)
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();

            RuleFor(x => x.MobileNumber)
                .NotEmpty();
        }
    }
}
