using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Recipes.Queries {
    public class GetRecipeByIdQuery : IRequest<RecipeDto> {
        public int Id {get; set;}

        public class GetRecipeByIdHandler : IRequestHandler<GetRecipeByIdQuery, RecipeDto>
        {
            private readonly IRecipeRepository _repository;
            private readonly IMapper _mapper;


            public GetRecipeByIdHandler(IRecipeRepository repository, IMapper mapper) {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<RecipeDto> Handle(GetRecipeByIdQuery request, CancellationToken cancellationToken)
            {
                var item = _repository.Get(request.Id);
                var recipe = _mapper.Map<RecipeDto>(item);
                return recipe;
            }
        }
    }
}