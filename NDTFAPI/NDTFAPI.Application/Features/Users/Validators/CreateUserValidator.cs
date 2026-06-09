using FluentValidation;
using NDTFAPI.Application.Features.Users.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDTFAPI.Application.Features.Users.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.Username)
                .NotEmpty();

            RuleFor(x => x.Password)
                .MinimumLength(8);

            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.RoleId)
                .GreaterThan(0);
        }
    }
}
