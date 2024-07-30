﻿using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using obsCommon.configFontIcon.queryPresentation.GrpcServices;

namespace obsCommon.configFontIcon.queryPresentation.Abstractions
{
    public static class EndpointRegistration
    {
        /// <summary>
        /// Map presentation layer endpoints
        /// </summary>
        /// <param name="app"></param>
        /// <returns>The endpoint route builder with mapped presentation layer endpoints</returns>
        public static IEndpointRouteBuilder MapPresentation(this IEndpointRouteBuilder app)
        {
            app.MapControllers();
            app.MapGrpcService<FontIconGrpcService>();
            app.MapGrpcReflectionService();
            var apiVersionSet = app.NewApiVersionSet().HasApiVersion(new ApiVersion(1)).ReportApiVersions().Build();

            //create api version prefix group
            var versionGroup = app.MapGroup("api/v{apiVersion:apiVersion}").WithApiVersionSet(apiVersionSet);
            versionGroup.MapFontIconEndpoints();
            return app;
        }
    }
}
