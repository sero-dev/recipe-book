using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Ingredients.Queries {
    public class GetAllIngredientsQuery : IRequest<IEnumerable<IngredientDto>> {

        public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, IEnumerable<IngredientDto>>
        {
            private readonly IIngredientRepository _repository;
            private readonly IMapper _mapper;

            public GetAllIngredientsQueryHandler(IIngredientRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<IngredientDto>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
            {
                var items = await _repository.GetAllAsync();
                var ingredients = _mapper.Map<List<IngredientDto>>(items);
                return ingredients;
            }
        }
    }
}