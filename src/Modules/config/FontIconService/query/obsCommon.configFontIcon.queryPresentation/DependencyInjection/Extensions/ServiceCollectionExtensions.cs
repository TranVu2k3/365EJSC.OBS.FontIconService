﻿using Microsoft.Extensions.DependencyInjection;

namespace obsCommon.configFontIcon.queryPresentation.DependencyInjection.Extensions
{
    /// <summary>
    /// Extension methods for adding services to the service collection.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>The service collection with added services</returns>
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            // Add gRPC services
            services.AddGrpc();
            // Add gRPC reflection services
            services.AddGrpcReflection();
            return services;
        }
    }
}
