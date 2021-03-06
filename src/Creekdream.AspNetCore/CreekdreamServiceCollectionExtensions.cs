﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace Creekdream.AspNetCore
{
    /// <summary>
    /// Creekdream application service injection
    /// </summary>
    public static class CreekdreamServiceCollectionExtensions
    {
        /// <summary>
        /// Add an application framework service
        /// </summary>
        public static IServiceProvider AddCreekdream(this IServiceCollection services, Action<AppOptionsBuilder> options = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            var builder = new AppOptionsBuilder();
            options?.Invoke(builder);
            return builder.Build(services);
        }
    }
}

