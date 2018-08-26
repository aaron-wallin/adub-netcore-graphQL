using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreGraphQL.Api.Models;
using NetCoreGraphQL.Api.Models.GraphTypes;
using NetCoreGraphQL.Data.Repositories;
using NetCoreGraphSQL.Shared.RepoDefinitions;

namespace NetCoreGraphQL.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IApplicationRepository, ApplicationRepository>();
            services.AddSingleton<IDecisionRepository, DecisionRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ApplicationDataQuery>();
            services.AddSingleton<ApplicationType>();
            services.AddSingleton<DecisionType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new ApplicationDataSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
