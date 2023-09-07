using AutoMapper;
using MailApp.Core.DTOs;
using MailApp.Core.Model;
using NLayerApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<EmailAddress, EmailAddressDto>().ReverseMap();
            CreateMap<EmailLog, EmailLogDto>().ReverseMap();
            CreateMap<EmailAddress, EmailAddressWithEmailLogDto>();

        }
    }
}
