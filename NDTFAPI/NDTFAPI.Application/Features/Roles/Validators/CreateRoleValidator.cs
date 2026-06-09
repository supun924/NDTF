using FluentValidation;
using NDTFAPI.Application.Features.Roles.Commands.CreateRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Roles.Validators
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
