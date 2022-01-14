using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Ingredients.Queries {
    public class GetIngredientByIdQuery : IRequest<IngredientResponse> {
        public int Id {get; set;}

        public class GetIngredientByIdQueryHandler : IRequestHandler<GetIngredientByIdQuery, IngredientResponse>
        {
            private readonly IIngredientRepository _repository;
            private readonly IMapper _mapper;


            public GetIngredientByIdQueryHandler(IIngredientRepository repository, IMapper mapper) 
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IngredientResponse> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
            {
                var item = await _repository.GetAsync(request.Id);
                var ingredient = _mapper.Map<IngredientResponse>(item);
                return ingredient;
            }
        }
    }
}