﻿using Autofac;
using Autofac.Core;
using CustomPage.Core.Render;
using CustomPage.Core.Render.Provider;
using CustomPage.Core.Widgets.Descriptor;
using CustomPage.Core.Widgets.Render;
using Microsoft.Extensions.DependencyInjection;

namespace CustomPage.Extensions.DependencyInjection
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
            builder.RegisterType<ViewRenderer>().Named<IRenderer>("View");
            builder.RegisterType<ComponentRenderer>().Named<IRenderer>("Component");
            builder.RegisterType<WidgetRenderer>().As<IWidgetRenderer>();
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