using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Recipes.Commands {
    public class UpdateRecipeCommand : IRequest<Unit> {
        public int Id { get; set; }
        public string Name {get; set;}

        public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, Unit>
        {
            private IRecipeRepository _repository;
            private readonly IMapper _mapper;

            public UpdateRecipeCommandHandler(IRecipeRepository repository, IMapper mapper) 
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
            {
                Recipe recipe = _mapper.Map<Recipe>(request);
                await _repository.UpdateAsync(recipe);
                return Unit.Value;
            }
        }
    }
}