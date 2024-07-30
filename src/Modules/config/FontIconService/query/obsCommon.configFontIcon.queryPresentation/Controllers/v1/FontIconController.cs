using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using obsCommon.configFontIcon.queryPresentation.Abstractions;
using obsCommon.configFontIcon.queryPresentation.Constants;
using UserCases;

namespace obsCommon.configFontIcon.queryPresentation.Controllers.v1
{
    [ApiVersion(1)]
    [Route(RouterConstants.FONTICON_ROUTE)]
    public class FontIconController : ApiController
    {
        private readonly IMediator mediator;

        public FontIconController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [MapToApiVersion(1)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFontIconByIdV1(string id)
        {
            var query = new GetFontIconByIdQuery
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [MapToApiVersion(1)]
        [HttpGet(RouterConstants.GET_ALL)]
        public async Task<IActionResult> GetAllFontIconV1()
        {
            var query = new GetAllFontIconQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
