using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Ingredients.Queries {
    public class SearchByIngredientNameQuery : IRequest<IEnumerable<IngredientDto>> {
        public string Name { get; set; }

        public class SearchByIngredientNameQueryHandler : IRequestHandler<SearchByIngredientNameQuery, IEnumerable<IngredientDto>>
        {
            private readonly IIngredientRepository _repository;
            private readonly IMapper _mapper;

            public SearchByIngredientNameQueryHandler(IIngredientRepository repository, IMapper mapper) 
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<IngredientDto>> Handle(SearchByIngredientNameQuery request, CancellationToken cancellationToken)
            {
                var item = await _repository.FindAsync(ingredient => ingredient.Name.ToLower().Contains(request.Name.ToLower()));
                var ingredients = _mapper.Map<IEnumerable<IngredientDto>>(item);

                return ingredients;
            }
        }
    }
}