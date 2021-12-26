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
        public class GetCurseQueryRequest : IRequest<List<Curse>> { }

        public class GetCurseQueryHandler : IRequestHandler<GetCurseQueryRequest, List<Curse>>
        {
            private readonly EducationDbContext _context;
            public GetCurseQueryHandler(EducationDbContext context)
            {
                _context = context;
            }

            public async Task<List<Curse>> Handle(GetCurseQueryRequest request, CancellationToken cancellationToken)
            {
                var curses = await _context.Curses.ToListAsync();
                return curses;
            }
        }
    }
}
