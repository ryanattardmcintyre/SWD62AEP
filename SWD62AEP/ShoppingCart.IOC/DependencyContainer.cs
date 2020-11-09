using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services )
        {
            //when are these instances triggered?
            //as soon as the application starts?
            //as soon as the user makes the first call?
            //as soon as the user makes the second call? and so on so forth
            //...

            //answer: https://www.tutorialsteacher.com/core/dependency-injection-in-aspnet-core

            /*
             * 
             *  Singleton: IoC container will create and share a single instance of a service throughout the application's lifetime.
                Transient: The IoC container will create a new instance of the specified service (e.g ProductsService) type every time you ask for it.
                Scoped: IoC container will create an instance of the specified service type once per request and will be shared in a single request.
             */


           



            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();

        }


    }
}
