using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using TaskManagement.Repository;
using TaskManagement.Service;
using UserManagement.Model;

namespace TaskManagement
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

      #region DI
      //ToDo - DI without importing namespace
      services.AddTransient<IJobRepository, JobRepository>();
      services.AddTransient<IJobService, JobService>();
      #endregion

      #region db connection
      string mySqlConnectionStr = Configuration.GetConnectionString("JobDbConnection");
      services.AddDbContextPool<JobDBContext>(options => options.UseNpgsql(mySqlConnectionStr));
      #endregion

      #region authentication

      //var audienceConfig = Configuration.GetSection("Audience");

      //var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
      //var tokenValidationParameters = new TokenValidationParameters
      //{
      //  ValidateIssuerSigningKey = true,
      //  IssuerSigningKey = signingKey,
      //  ValidateIssuer = true,
      //  ValidIssuer = audienceConfig["Iss"],
      //  ValidateAudience = true,
      //  ValidAudience = audienceConfig["Aud"],
      //  ValidateLifetime = true,
      //  ClockSkew = TimeSpan.Zero,
      //  RequireExpirationTime = true,
      //};

      //services.AddAuthentication(o =>
      //{
      //  o.DefaultAuthenticateScheme = "TestKey";
      //  o.DefaultChallengeScheme = "TestKey";
      //})
      //.AddJwtBearer("TestKey", x =>
      //{
      //  x.RequireHttpsMetadata = false;
      //  x.TokenValidationParameters = tokenValidationParameters;
      //});

      #endregion

      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      var configBuider = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

      configBuider.Build();

      app.UseHttpsRedirection();

      app.UseRouting();

      //app.UseAuthentication();
      //app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
