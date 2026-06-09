using FluentValidation;
using NDTFAPI.Application.Features.Fines.Commands.IssueFine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Fines.Validators
{
    public class IssueFineValidator : AbstractValidator<IssueFineCommand>
    {
        public IssueFineValidator()
        {
            RuleFor(x => x.DriverId)
                .GreaterThan(0);

            RuleFor(x => x.VehicleId)
                .GreaterThan(0);

            RuleFor(x => x.StationId)
                .GreaterThan(0);

            RuleFor(x => x.ViolationIds)
                .NotEmpty();
        }
    }
}
