using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NcNews.Data;
using Newtonsoft.Json.Serialization;
using Npgsql;
using AutoMapper;
using System.Reflection;

namespace NcNews
{
 public class Startup
 {
  public Startup(IConfiguration configuration, IWebHostEnvironment env)
  {
   Environment = env;
   Configuration = configuration;
  }

  public IConfiguration Configuration { get; }
  public IWebHostEnvironment Environment { get; }

  // This method gets called by the runtime. Use this method to add services to the container.
  public void ConfigureServices(IServiceCollection services)
  {
   var builder = new NpgsqlConnectionStringBuilder();
   builder.ConnectionString = Configuration.GetConnectionString("NcNewsConnection");
   builder.Username = Configuration["UserID"];
   builder.Password = Configuration["Password"];
   services.AddDbContext<NcNewsContext>(options => options.UseNpgsql(builder.ConnectionString));
   services.AddScoped<IUserRepository, UserRepository>();
   services.AddScoped<ITopicRepo, TopicRepository>();
   services.AddScoped<IArticleRepo, ArticleRepo>();
   services.AddScoped<ICommentRepo, CommentRepo>();
   services.AddAutoMapper(Assembly.GetExecutingAssembly());
   services.AddControllers();

   services.AddControllers().AddNewtonsoftJson(s =>
   {
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
   });

   if (Environment.IsDevelopment())
   {
    services.AddDbContext<NcNewsContext>(options =>
    options.UseNpgsql(Configuration.GetConnectionString("NcNewsConnection")));
   }
   else
   {
    services.AddDbContext<NcNewsContext>(options =>
options.UseNpgsql(Configuration.GetConnectionString("NcNewsConnection")));
   }
  }

  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NcNewsContext context)
  {
   context.Database.Migrate();
   if (env.IsDevelopment())
   {
    app.UseDeveloperExceptionPage();
   }

   app.UseHttpsRedirection();


   app.UseRouting();

   app.UseAuthorization();

   app.UseEndpoints(endpoints =>
   {
    endpoints.MapControllers();
   });
  }
 }
}
