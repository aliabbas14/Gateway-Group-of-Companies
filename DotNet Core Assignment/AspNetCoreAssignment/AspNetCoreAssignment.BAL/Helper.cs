using AspNetCoreAssignment.DAL.Interface;
using AspNetCoreAssignment.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAssignment.BAL
{
    public static class Helper
    {
        public static void Configure(ref IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
