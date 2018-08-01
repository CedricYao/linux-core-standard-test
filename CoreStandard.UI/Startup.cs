using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoreStandard.UI.Data;
using CoreStandard.UI.IoC;
using HelloWorld;
using HelloWorld_Full;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreStandard.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<CoreStandardDbContext>(o => o.UseInMemoryDatabase("corestandard"));

            var builder = new ContainerBuilder();
            builder.RegisterModule<UiModule>();
            builder.RegisterModule<HelloWorldModule>();
            builder.RegisterModule<HelloWorldFullModule>();
            builder.Populate(services);
            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
