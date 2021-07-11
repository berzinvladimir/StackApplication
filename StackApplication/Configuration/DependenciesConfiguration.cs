using Microsoft.Extensions.DependencyInjection;
using StackApplication.Repositories;
using StackApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackApplication.Configuration
{
    public static class DependenciesConfiguration
    {

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStack<NameObject>, EfStack>();
        }

    
    }
}
