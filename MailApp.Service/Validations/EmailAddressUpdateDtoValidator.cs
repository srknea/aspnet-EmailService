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
    public class EmailAddressUpdateDtoValidator : AbstractValidator<EmailAddressUpdateDto>
    {
        public EmailAddressUpdateDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(64).WithMessage("{PropertyName} alanı 64 karakterden uzun olamaz.")
                .EmailAddress().WithMessage("A valid email address is required.");
        }
    }
}

