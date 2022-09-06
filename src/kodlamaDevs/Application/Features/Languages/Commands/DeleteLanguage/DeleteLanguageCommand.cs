using Application.Features.Languages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<DeletedLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgramingLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public DeleteProgramingLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {

                Language? language = await _languageRepository.GetAsync(b => b.Id == request.Id);
                Language deletedLanguage = await _languageRepository.DeleteAsync(language);
                DeletedLanguageDto DeletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguage);

                return DeletedLanguageDto;
            }
        }
    }
}
