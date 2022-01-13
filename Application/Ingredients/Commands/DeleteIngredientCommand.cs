using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Ingredients.Commands {
    public class DeleteIngredientCommand : IRequest<Unit> {
        public int Id { get; set; }

        public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand, Unit>
        {
            private IIngredientRepository _repository;
            public DeleteIngredientCommandHandler(IIngredientRepository repository) 
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
            {
                await _repository.RemoveAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}