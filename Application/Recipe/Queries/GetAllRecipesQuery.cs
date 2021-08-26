using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Recipes.Queries {
    public class GetAllRecipesQuery : IRequest<IEnumerable<RecipeDto>> {

        public class GetAllRecipesQueryHandler : IRequestHandler<GetAllRecipesQuery, IEnumerable<RecipeDto>>
        {
            private readonly IRecipeRepository _repository;
            private readonly IMapper _mapper;

            public GetAllRecipesQueryHandler(IRecipeRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<RecipeDto>> Handle(GetAllRecipesQuery request, CancellationToken cancellationToken)
            {
                var items = _repository.GetAll();
                var recipes = _mapper.Map<List<RecipeDto>>(items);
                return recipes;
            }
        }
    }
}