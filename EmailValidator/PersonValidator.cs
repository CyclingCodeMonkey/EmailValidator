using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace EmailValidator
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.EmailAddress).EmailAddress()
                .WithMessage("Not valid email address, please come again!");
        }
    }
}
