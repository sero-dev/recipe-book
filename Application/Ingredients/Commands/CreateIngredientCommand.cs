using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Ingredients.Commands {
    public class CreateIngredientCommand : IRequest {
        public string Name { get; set; }

        public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand>
        {
            private readonly IIngredientRepository _repository;
            private readonly IMapper _mapper;

            public CreateIngredientCommandHandler(IIngredientRepository repository, IMapper mapper) 
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
            {
                var ingredient = _mapper.Map<Ingredient>(request);
                await _repository.AddAsync(ingredient);

                return Unit.Value;
            }
        }
    }
}