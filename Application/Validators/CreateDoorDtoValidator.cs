using Application.Dto.DoorsDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CreateDoorDtoValidator : AbstractValidator<CreateDoorDto>
    {
        public CreateDoorDtoValidator()
        {
            #region Name

            RuleFor(x => x.Name).NotEmpty().WithMessage("Object can not have an empty name");
            RuleFor(x => x.Name).Length(3, 100).WithMessage("The title must be between 3 and 100 characters long");

            #endregion
        }
    }
}
