using Education.Application.Curses;
using Education.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurseController : ControllerBase
    {
        private IMediator _mediator;
        public CurseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CurseDTO>>> Get()
        {
            return await _mediator.Send(new GetCurseQuery.GetCurseQueryRequest());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateCurseCommand.CreateCurseCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
