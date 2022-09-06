﻿using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreatedLanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
            //CreateMap<IPaginate<Language>, LanguageListModel>().ReverseMap();
            //CreateMap<Language, LanguageListDto>().ReverseMap();
            //CreateMap<Language, LanguageGetByIdDto>().ReverseMap();
        }
    }
}