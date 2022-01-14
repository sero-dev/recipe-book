using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Recipes.Queries {
    public class GetRecipeByIdQuery : IRequest<RecipeDetailedResponse> {
        public int Id {get; set;}

        public class GetRecipeByIdQueryHandler : IRequestHandler<GetRecipeByIdQuery, RecipeDetailedResponse>
        {
            private readonly IRecipeRepository _repository;
            private readonly IMapper _mapper;


            public GetRecipeByIdQueryHandler(IRecipeRepository repository, IMapper mapper) 
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<RecipeDetailedResponse> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
            {
                var item = await _repository.GetFullRecipe(request.Id);
                var recipe = _mapper.Map<RecipeDetailedResponse>(item);
                return recipe;
            }
        }
    }
}