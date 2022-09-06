using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _LanguageRepository;

        public LanguageBusinessRules(ILanguageRepository LanguageRepository)
        {
            _LanguageRepository = LanguageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _LanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");
        }

        public void LanguageNameShouldNotBeEmpty(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new BusinessException("Language name should not be empty.");
        }
    }
}
