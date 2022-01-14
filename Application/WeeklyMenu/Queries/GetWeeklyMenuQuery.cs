using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using System.Linq;
using System;

namespace Application.WeeklyMenu.Queries
{
    public class GetWeeklyMenuQuery : IRequest<IEnumerable<WeeklyMenuItemDto>>
    {
        public class GetWeeklyMenuQueryHandler : IRequestHandler<GetWeeklyMenuQuery, IEnumerable<WeeklyMenuItemDto>>
        {

            private readonly IWeeklyMenuRepository _repository;
            private readonly IMapper _mapper;
            private static string[] Names = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            public GetWeeklyMenuQueryHandler(IWeeklyMenuRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<WeeklyMenuItemDto>> Handle(GetWeeklyMenuQuery request, CancellationToken cancellationToken)
            {
                var items = await _repository.GetFullWeekMenu();
                var response = _mapper.Map<IEnumerable<WeeklyMenuItemDto>>(items);

                response = response.Select(w => new { WeeklyMenu = w, Index = Array.IndexOf(Names, w.Day) })
                   .OrderBy(w => w.Index)
                   .Select(w => w.WeeklyMenu)
                   .ToList();

                return response;
            }


        }
    }
}
