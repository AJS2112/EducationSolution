using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Curses
{
    public class CreateCurseCommand
    {
        public class CreateCurseCommandRequest : IRequest {
            public string Title { get; set; }
            public string  Description { get; set; }
            public DateTime PublishDate { get; set; }
            public decimal Price { get; set; }
        }

        public class CreateCurseCommandRequestValidation : AbstractValidator<CreateCurseCommandRequest>
        {
            public CreateCurseCommandRequestValidation()
            {
                RuleFor(x => x.Description);
                RuleFor(x => x.Title);
            }
        }

        public class CreateCurseCommandHandler : IRequestHandler<CreateCurseCommandRequest>
        {
            private readonly EducationDbContext _context;
            public CreateCurseCommandHandler(EducationDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(CreateCurseCommandRequest request, CancellationToken cancellationToken)
            {
                var curse = new Curse
                {
                    CurseId = Guid.NewGuid(),
                    Title=request.Title,
                    Description=request.Description,
                    CreationDate=DateTime.UtcNow,
                    PublishDate=request.PublishDate,
                    Price=request.Price
                };

                _context.Add(curse);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Can't Create Curse");
                }
            }
        }
    }
}
