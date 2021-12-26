using AutoMapper;
using Education.Application.DTO;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Curses
{
    public class GetCurseByIdQuery
    {
        public class GetCurseByIdQueryRequest : IRequest<CurseDTO> {
            public Guid Id;
        }

        public class GetCurseByIdQueryHandler : IRequestHandler<GetCurseByIdQueryRequest, CurseDTO>
        {
            private readonly EducationDbContext _context;
            private readonly IMapper _mapper;
            public GetCurseByIdQueryHandler(EducationDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<CurseDTO> Handle(GetCurseByIdQueryRequest request, CancellationToken cancellationToken)
            {
                var curse = await _context.Curses.FirstOrDefaultAsync(x => x.CurseId == request.Id);
                var cursesDto = _mapper.Map<Curse, CurseDTO>(curse);
                return cursesDto;
            }
        }
    }
}
