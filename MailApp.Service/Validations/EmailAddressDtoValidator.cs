using FluentValidation;
using FluentValidation.Validators;
using MailApp.Core.DTOs;
using MailApp.Core.Services;
using MailApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailApp.Service.Validations
{
    public class EmailAddressDtoValidator : AbstractValidator<EmailAddressDto>
    {
        public EmailAddressDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("A valid email address is required.");
        }
    }
}

