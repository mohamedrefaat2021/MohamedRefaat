using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using MohamedRefaat.API.Configurations;
using MohamedRefaat.Infra.Data.Context;
using MohamedRefaat.Infra.IoC;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MohamedRefaat.Api
{
    public class Startup
    {

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MohamedRefaat"));
            }
            );

           // services.Configure<OutPatientConfig>(Configuration.GetSection("Features:OutPatient"));

            //services.AddOptions<OutPatientConfig>()
            //    .Bind(Configuration.GetSection("Features:OutPatient"))
            //    .ValidateDataAnnotations();

           // services.TryAddEnumerable(ServiceDescriptor.Singleton<IValidateOptions<OutPatientConfig>, OutPatientConfigurationValidation>());

            services.AddHostedService<ValidateOptionsService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200", "http://localhost:8081"
                                                      
                                         );
                                      builder.WithHeaders("content-type");
                                      builder.WithMethods("PUT");
                                      builder.WithMethods("DELETE");
                                  });
            });

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });


            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            //Add Swagger Doc
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();

            RegisterServices(services);
            services.RegisterAutoMapper();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            //if (env.IsDevelopment()){app.UseDeveloperExceptionPage();}
          //  app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                foreach (var desc in provider.ApiVersionDescriptions)
                    options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json",
                        desc.GroupName.ToUpperInvariant());
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);

        }
    }
}
