using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCases;
using obsCommon.configFontIcon.commandPresentation.Abstractions;
using obsCommon.configFontIcon.commandPresentation.DTOs;

namespace APIs
{
    public class FontIconApiV1 : ApplicationApi
    {
        public static async Task<IResult> CreateFontIconV1([FromBody] CreateFontIconCommand command, IMediator mediator)
        {
            var result = await mediator.Send(command);
            return TypedResults.Ok(result);
        }
        public static async Task<IResult> UpdateFontIconV1(string id, [FromBody] UpdateFontIconRequestDTO request, IMediator mediator)
        {
            var command = new UpdateFontIconCommand
            {
                Description = request.Description,
                Id = id,
                Type = request.Type,
                Version = request.Version,
                IsActived = request.IsActived
            };
            var result = await mediator.Send(command);
            return TypedResults.Ok(result);
        }
    }
}
