using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using MediatR;

namespace Application.Recipes.Commands {
    public class DeleteRecipeCommand : IRequest<Unit> {
        public int Id { get; set; }

        public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, Unit>
        {
            private IRecipeRepository _repository;
            public DeleteRecipeCommandHandler(IRecipeRepository repository) 
            {
                _repository = repository;
            }

            public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
            {
                await _repository.RemoveAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}