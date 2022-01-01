using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;

namespace Application.WeeklyMenu.Queries
{
    public class GetWeeklyMenuQuery : IRequest<IEnumerable<WeeklyMenuItemDto>>
    {
        public class GetWeeklyMenuQueryHandler : IRequestHandler<GetWeeklyMenuQuery, IEnumerable<WeeklyMenuItemDto>>
        {

            private readonly IWeeklyMenuRepository _repository;
            private readonly IMapper _mapper;

            public GetWeeklyMenuQueryHandler(IWeeklyMenuRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<WeeklyMenuItemDto>> Handle(GetWeeklyMenuQuery request, CancellationToken cancellationToken)
            {
                var items = await _repository.GetFullWeekMenu();
                var response = _mapper.Map<IEnumerable<WeeklyMenuItemDto>>(items);
                return response;
            }
           
        }
    }
}
