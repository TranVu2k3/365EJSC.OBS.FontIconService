using APIs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using obsCommon.configFontIcon.commandPresentation.Constants;

namespace obsCommon.configFontIcon.commandPresentation.Abstractions
{
    public static class FontIconEndpoints
    {
        public static void MapFontIconEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup(RouterConstants.FONTICON_ROUTE_MINIMAL);
            group.MapPost("", FontIconApiV1.CreateFontIconV1).MapToApiVersion(1);
            group.MapPut("{id}", FontIconApiV1.UpdateFontIconV1).MapToApiVersion(1);
        }
    }
}
