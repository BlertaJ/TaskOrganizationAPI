using Application.Common.Interfaces.ProjectInterfaces;
using Application.Common.Interfaces.StatusInterfaces;
using Application.Common.Interfaces.TaskInterfaces;
using Application.Services.Project;
using Application.Services.Status;
using Application.Services.Task;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IStatusService, StatusService>();
            return services;
        }
    }
}
