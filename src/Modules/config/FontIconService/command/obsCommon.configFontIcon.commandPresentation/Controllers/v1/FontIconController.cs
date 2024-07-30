using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserCases;
using obsCommon.configFontIcon.commandPresentation.Abstractions;
using obsCommon.configFontIcon.commandPresentation.Constants;
using obsCommon.configFontIcon.commandPresentation.DTOs;

namespace obsCommon.configFontIcon.commandPresentation.Controllers.v1
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
        [HttpPost]
        public async Task<IActionResult> CreateFontIconV1(CreateFontIconCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFontIconV1(string id, [FromBody] UpdateFontIconRequestDTO request)
        {
            var command = new UpdateFontIconCommand
            {
                Description = request.Description,
                Id = id,
                Type = request.Type,
                Version = request.Version,
                IsActived = request.IsActived,
            };
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
