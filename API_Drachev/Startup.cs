using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.IO;

namespace API_Drachev
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "����������� ��� ������������� ��������",
                    Description = "������ ����������� ��� ������������� �������� ����������� � �������"
                }
                );
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "����������� ��� ������������� ��������",
                    Description = "������ ����������� ��� ������������� �������� ����������� � �������"
                }
                );

                var filtePath = Path.Combine(System.AppContext.BaseDirectory, "API_Drachev.xml");
                c.IncludeXmlComments(filtePath);
            }
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c => { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "������� GET"); 
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "������� POST"); });
        }
    }
}
