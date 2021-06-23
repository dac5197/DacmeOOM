using DacmeOOM.Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Application.Validators
{
    public class OrgLevelFleuntValidator : AbstractValidator<OrgLevelModel>
    {
        public OrgLevelFleuntValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty() //.WithMessage("")
                .MaximumLength(3); //.WithMessage("");

        }
        
    }
}
