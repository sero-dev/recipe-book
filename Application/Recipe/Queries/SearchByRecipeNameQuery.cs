using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Recipes.Queries {
    public class SearchByRecipeNameQuery : IRequest<IEnumerable<RecipeDto>> {
        public string Name { get; set; }

        public class SearchByRecipeNameQueryHandler : IRequestHandler<SearchByRecipeNameQuery, IEnumerable<RecipeDto>>
        {
            private readonly IRecipeRepository _repository;
            private readonly IMapper _mapper;

            public SearchByRecipeNameQueryHandler(IRecipeRepository repository, IMapper mapper) {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<RecipeDto>> Handle(SearchByRecipeNameQuery request, CancellationToken cancellationToken)
            {
                var item = await _repository.FindAsync(recipe => recipe.Name.ToLower().Contains(request.Name.ToLower()));
                var recipes = _mapper.Map<IEnumerable<RecipeDto>>(item);

                return recipes;
            }
        }
    }
}