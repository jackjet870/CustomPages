﻿using Autofac;
using Autofac.Core;
using CustomPages.Core.Widgets.Descriptor;
using CustomPages.Core.Widgets.Render;
using CustomPages.Core.Widgets.Render.Provider;
using Microsoft.Extensions.DependencyInjection;

namespace CustomPages.Extensions.DependencyInjection
{
    internal class CustomModule : Module
    {
        #region Overrides of Module

        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="builder">The builder through which components can be
        ///             registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewWidgetRenderer>().Named<IWidgetRenderer>("View");
        }

        #endregion Overrides of Module
    }

    public static class CustomPageCoreServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomPageCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IWidgetHarvester, WidgetHarvester>();
            serviceCollection.AddInstance<IModule>(new CustomModule());

            return serviceCollection;
        }
    }
}