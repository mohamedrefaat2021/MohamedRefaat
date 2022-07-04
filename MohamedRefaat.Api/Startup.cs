using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MohamedRefaat.API.Configurations;
using MohamedRefaat.Application.DTOs;
using MohamedRefaat.Application.Middlewares;
using MohamedRefaat.Domain.Helper;
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
            services.AddControllers()
                  .AddFluentValidation(s => { s.RegisterValidatorsFromAssemblyContaining<BaseDto>(); })
                  .ConfigureApiBehaviorOptions(options =>
                  {
                      options.InvalidModelStateResponseFactory = context =>
                      {
                          var messages = context.ModelState.Values
                              .Where(x => x.ValidationState == ModelValidationState.Invalid)
                              .SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                          return new BadRequestObjectResult(ServiceResponse<List<string>>.ValidationException(messages));
                      };
                  })
                .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MohamedRefaat"));
            }
            );



            services.AddHostedService<ValidateOptionsService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200", "http://localhost:8081"
                                                        , "http://10.1.0.53:8081", "http://asc-panmedica:8081"
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
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

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
