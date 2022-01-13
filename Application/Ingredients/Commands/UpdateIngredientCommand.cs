using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Ingredients.Commands {
    public class UpdateIngredientCommand : IRequest<Unit> {
        public int Id { get; set; }
        public string Name {get; set;}

        public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand, Unit>
        {
            private IIngredientRepository _repository;
            private readonly IMapper _mapper;

            public UpdateIngredientCommandHandler(IIngredientRepository repository, IMapper mapper) 
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
            {
                Ingredient ingredient = _mapper.Map<Ingredient>(request);
                await _repository.UpdateAsync(ingredient);
                return Unit.Value;
            }
        }
    }
}