using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using MediatrTutorial.Data;
using MediatrTutorial.Data.EventStore;
using MediatrTutorial.Infrastructure.Behaviours;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrTutorial
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddMediatR();
            services.AddSwagger();
            services.AddAutoMapper();
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseInMemoryDatabase("MediatorDB"));

            services.AddSingleton<IEventStoreDbContext, EventStoreDbContext>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(EventLoggerBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MediatR Tutorial");
                c.RoutePrefix = string.Empty;
            });

            app.UseErrorHandling();
            app.UseMvc();
        }
    }
}
