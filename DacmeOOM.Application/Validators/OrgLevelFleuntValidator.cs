using DacmeOOM.Core.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Domain.Validators
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
