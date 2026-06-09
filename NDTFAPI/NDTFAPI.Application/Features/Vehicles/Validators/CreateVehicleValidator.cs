using FluentValidation;
using NDTFAPI.Application.Features.Vehicles.Commands.CreateVehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Vehicles.Validators
{
    public class CreateVehicleValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleValidator()
        {
            RuleFor(x => x.RegistrationNumber)
                .NotEmpty();

            RuleFor(x => x.DriverId)
                .GreaterThan(0);

            RuleFor(x => x.VehicleType)
                .NotEmpty();
        }
    }
}
