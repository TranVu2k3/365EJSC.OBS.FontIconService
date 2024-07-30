using MediatR;
using Microsoft.AspNetCore.Http;
using obsCommon.configFontIcon.queryPresentation.Abstractions;
using UserCases;

namespace APIs
{
    public class FontIconApiV1 : ApplicationApi
    {
        public static async Task<IResult> GetFontIconByIdV1(string id, IMediator mediator)
        {
            var query = new GetFontIconByIdQuery { Id = id };
            var result = await mediator.Send(query);
            return TypedResults.Ok(result);
        }
        public static async Task<IResult> GetAllFontIconV1(IMediator mediator)
        {
            var query = new GetAllFontIconQuery();
            var result = await mediator.Send(query);
            return TypedResults.Ok(result);
        }
    }
}
