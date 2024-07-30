using APIs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using obsCommon.configFontIcon.queryPresentation.Constants;

namespace obsCommon.configFontIcon.queryPresentation.Abstractions
{
    public static class FontIconEndpoints
    {
        public static void MapFontIconEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup(RouterConstants.FONTICON_ROUTE_MINIMAL);
            group.MapGet("{id}", FontIconApiV1.GetFontIconByIdV1).MapToApiVersion(1);
            group.MapGet(RouterConstants.GET_ALL, FontIconApiV1.GetAllFontIconV1).MapToApiVersion(1);
        }
    }
}
