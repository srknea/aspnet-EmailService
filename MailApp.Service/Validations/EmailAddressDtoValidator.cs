using FluentValidation;
using MailApp.Core.DTOs;
using MailApp.Core.Services;
using MailApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Service.Validations
{
    public class EmailAddressDtoValidator : AbstractValidator<EmailAddressDto>
    {
        protected readonly AppDbContext _context;

        public EmailAddressDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("{PropertyName} is required");
        }
    }
}

