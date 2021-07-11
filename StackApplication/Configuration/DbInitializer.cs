using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StackApplication.Repositories;

namespace StackApplication.Configuration
{
    public static class DbInitializer
    {
        
        public static void InitializeEmployeeStack(StackContext<Employee> stackContext)
        {
            stackContext.Database.EnsureCreated();
        }


    }
}
