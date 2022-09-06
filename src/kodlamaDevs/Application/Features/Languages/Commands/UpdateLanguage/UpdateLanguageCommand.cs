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

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommand : IRequest<UpdatedLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
        {
            private readonly ILanguageRepository _LanguageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _LanguageBusinessRules;

            public UpdateLanguageCommandHandler(ILanguageRepository LanguageRepository, IMapper mapper, LanguageBusinessRules LanguageBusinessRules)
            {
                _LanguageRepository = LanguageRepository;
                _mapper = mapper;
                _LanguageBusinessRules = LanguageBusinessRules;
            }

            public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
            {

                Language mappedLanguage = _mapper.Map<Language>(request);
                Language updatedLanguage = await _LanguageRepository.UpdateAsync(mappedLanguage);
                UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(updatedLanguage);

                return updatedLanguageDto;
            }
        }
    }
}
