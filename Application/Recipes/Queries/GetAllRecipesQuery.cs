using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Recipes.Queries {
    public class GetAllRecipesQuery : IRequest<IEnumerable<RecipeResponse>> {

        public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQuery, IEnumerable<RecipeResponse>>
        {
            private readonly IRecipeRepository _repository;
            private readonly IMapper _mapper;

            public GetAllRecipesQueryHandler(IRecipeRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<RecipeResponse>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
            {
                var items = await _repository.GetAllAsync();
                var recipes = _mapper.Map<List<RecipeResponse>>(items);
                return recipes;
            }
        }
    }
}