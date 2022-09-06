using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommand : IRequest<CreatedLanguageDto>
    {
        public string Name { get; set; }

        public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreatedLanguageDto>
        {
            private readonly ILanguageRepository _LanguageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _LanguageBusinessRules;

            public CreateLanguageCommandHandler(ILanguageRepository LanguageRepository, IMapper mapper, LanguageBusinessRules LanguageBusinessRules)
            {
                _LanguageRepository = LanguageRepository;
                _mapper = mapper;
                _LanguageBusinessRules = LanguageBusinessRules;
            }

            public async Task<CreatedLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
            {
                await _LanguageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
                _LanguageBusinessRules.LanguageNameShouldNotBeEmpty(request.Name);

                Language mappedLanguage = _mapper.Map<Language>(request);
                Language createdLanguage = await _LanguageRepository.AddAsync(mappedLanguage);
                CreatedLanguageDto createdLanguageDto = _mapper.Map<CreatedLanguageDto>(createdLanguage);

                return createdLanguageDto;
            }
        }
    }
}
