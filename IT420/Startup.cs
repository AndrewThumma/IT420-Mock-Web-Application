using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Data;
using IT420.Data.BlogData;
using IT420.Data.ExpertData;
using IT420.Data.TalkData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IT420
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
            services.AddDbContextPool<IT420DBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IT420DB"));
            });

            //services.AddScoped<ITalkData, sqlTalkData>();
            services.AddScoped<ITalkData, sqlTalkData>();
            services.AddScoped<ITypeData, sqlTalkTypeData>();
            services.AddScoped<ITalkCommentData, sqlTalkCommentData>();
            
            services.AddScoped<IBlogData, sqlBlogData>();
            services.AddScoped<IBlogTypeData, sqlBlogTypeData>();
            
            services.AddScoped<IExpertData, sqlExpertData>();
            services.AddScoped<IExpertQuestionData, sqlExpertQuestionData>();
            services.AddScoped<IExpertAnswerData, sqlExpertAnswerData>();
            services.AddScoped<IExpertQuestionTypeData, sqlExpertTypeData>();

            services.AddScoped<IAccountData, sqlAccountData>();

            services.AddRazorPages().AddMvcOptions(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy => policy.RequireClaim("IsAdmin", "True"));
                options.AddPolicy("IsExpert", policy => policy.RequireClaim("IsExpert", "True"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
