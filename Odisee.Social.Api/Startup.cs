using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Odisee.Social.Api.Filters;
using Odisee.Social.Api.Infrastructure;
using Odisee.Social.Api.Services;
using Odisee.Social.Api.ViewModels;
using Odisee.Social.DAL;

namespace Odisee.Social.Api
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
            // Add connectionstring
            var connection = "Filename=./social.sqlite";
			services.AddDbContext<SocialContext>(opt => opt.UseSqlite(connection));

            services.AddAutoMapper();

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(JsonExceptionFilter));
                opt.Filters.Add(typeof(LinkRewriterFilter));

                // Require HTTPS for all controllers
                //opt.Filters.Add(new RequireHttpsAttribute()); // Todo: Implement HTTPS Attribute

                var jsonFormatter = opt.OutputFormatters.OfType<JsonOutputFormatter>().Single();
                opt.OutputFormatters.Remove(jsonFormatter);
                opt.OutputFormatters.Add(new IonOutputFormatter(jsonFormatter));
            }
            );
            services.AddRouting(opt => opt.LowercaseUrls = true);

            // Pass the DbContext to the interfaces
            services.AddScoped<IDataAccessService<SocialProfileViewModel>, DefaultSocialProfileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Rewrite to redirect traffic to https
                var options = new RewriteOptions().AddRedirectToHttps();
                app.UseRewriter(options);
            }

            app.UseMvc();
        }
    }
}
