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
    public class SendEmailDtoValidator : AbstractValidator<SendEmailDto>
    {
        public SendEmailDtoValidator()
        {
            RuleFor(x => x.Subject)
                .NotNull().NotEmpty().WithMessage("{PropertyName} alanı boş olamaz")
                .MaximumLength(255).WithMessage("{PropertyName} alanı 255 karakterden uzun olamaz.")

            RuleFor(x => x.Body)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(20000).WithMessage("{PropertyName} alanı 20000 karakterden uzun olamaz.");

            RuleFor(x => x.EmailAddressId)
                .GreaterThan(0).WithMessage("{PropertyName} is required");
        }
    }
}

//Length(min: 1, max: 255)