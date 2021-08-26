using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.Commands {
    public class CreateRecipeCommand : IRequest {
        public string Name { get; set; }

        public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand>
        {
            private readonly IRecipeRepository _repository;
            private readonly IMapper _mapper;

            public CreateRecipeCommandHandler(IRecipeRepository repository, IMapper mapper) {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
            {
                var recipe = _mapper.Map<Recipe>(request);
                _repository.Add(recipe);

                return Unit.Value;
            }
        }
    }
}