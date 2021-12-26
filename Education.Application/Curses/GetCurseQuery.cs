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
    public class GetCurseQuery
    {
        public class GetCurseQueryRequest : IRequest<List<CurseDTO>> { }

        public class GetCurseQueryHandler : IRequestHandler<GetCurseQueryRequest, List<CurseDTO>>
        {
            private readonly EducationDbContext _context;
            private readonly IMapper _mapper;
            public GetCurseQueryHandler(EducationDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<CurseDTO>> Handle(GetCurseQueryRequest request, CancellationToken cancellationToken)
            {
                var curses = await _context.Curses.ToListAsync();
                var cursesDto = _mapper.Map<List<Curse>,List<CurseDTO>>(curses);
                return cursesDto;
            }
        }
    }
}
