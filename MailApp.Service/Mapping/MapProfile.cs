using AutoMapper;
using MailApp.Core.DTOs;
using MailApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailApp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EmailAddress, EmailAddressDto>().ReverseMap();
            CreateMap<EmailAddress, EmailAddressUpdateDto>().ReverseMap();
            CreateMap<EmailLog, EmailLogDto>().ReverseMap();
            CreateMap<EmailAddress, EmailAddressWithEmailLogDto>();
            CreateMap<EmailLog, EmailLogWithEmailAddressDto>();
            CreateMap<EmailLog, SendEmailDto>().ReverseMap();
            CreateMap<EmailAddress, EmailAddressCreateDto>().ReverseMap();
        }
    }
}
