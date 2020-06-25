using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Application.Interfaces;
using TaskManagement.DapperInfrastructure.Repositories;
using TaskManagement.DapperInfrastructure.UOW;

namespace TaskManagement.DapperInfrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDapperInfrastruction(this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }

}
