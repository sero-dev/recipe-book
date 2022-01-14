using Application.Interfaces;
using Application.WeeklyMenu.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.WeeklyMenu.Commands
{
    public class UpdateWeeklyMenuCommand : IRequest
    {
        public IEnumerable<WeeklyMenuItemDto> Menu { get; set; }

        public UpdateWeeklyMenuCommand(IEnumerable<WeeklyMenuItemDto> menu)
        {
            Menu = menu;
        }

        public class UpdateWeeklyMenuCommandHandler : IRequestHandler<UpdateWeeklyMenuCommand>
        {

            private readonly IWeeklyMenuRepository _repository;
            private readonly IMapper _mapper;

            public UpdateWeeklyMenuCommandHandler(IWeeklyMenuRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateWeeklyMenuCommand request, CancellationToken cancellationToken)
            {
                var entities = _mapper.Map<IEnumerable<WeeklyMenuItem>>(request.Menu);
                await _repository.UpdateRangeAsync(entities);

                return Unit.Value;
            }
        }
    }
}
