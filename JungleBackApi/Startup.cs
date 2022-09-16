using JungleBackApi.Controllers;
using JungleBackCore.Interfaces;
using JungleBackInfrastructure.Data;
using JungleBackInfrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JungleBackApi
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

            services.AddCors();
            services.AddControllers();
            services.AddDbContext<JungleBaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("JungleDatabase"))
            );

            services.AddTransient<IPersona, PersonaRepository>();
            services.AddTransient<IServicios, ServiciosRepository>();
            services.AddTransient<IProductos, ProductosRepository>();
            services.AddTransient<ITipoDocumento, TipoDocumentoRepository>();
            services.AddTransient<ITipoProducto, TipoProductoRepository>();
            services.AddTransient<IInventario, InventarioRepository>();
            services.AddTransient<ICita, CitaRepository>();
            services.AddTransient<IUsuario, UsuarioRepository>();
            services.AddTransient<IDetalleCita, DetalleCitaRepository>();
            services.AddTransient<IEstado, EstadoRepository>();
            services.AddTransient<IMovimientoInventario, MovimientoInventarioRepository>();
            services.AddTransient<IRoles, RolesRepository>();
            services.AddTransient<ITipoMovimientoInventario, TipoMovimientoInventarioRepository>();
            services.AddTransient<IUsuarioXrol, UsuarioXrolRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()

                );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            ///Scaffold-DbContext "Server=DESKTOP-1MQL68E;Database=JungleBase;Integrated Security = true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data
        }
    }
}
