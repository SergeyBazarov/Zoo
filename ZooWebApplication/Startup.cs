using Data;
using Data.Gateway;
using Domain.Gateway;
using Domain.Interactor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LogisticWebApplication {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public static ZooDbContext Context = new ZooDbContext();

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            
            services.AddDbContext<ZooDbContext>(options =>
                options.UseSqlite("Data Source=zoo.db")
            );

            services.Add(
                new ServiceDescriptor(
                    typeof(IZooGateway), typeof(ZooGatewayDb), ServiceLifetime.Singleton
                )
            );

            services.Add(
                new ServiceDescriptor(
                    typeof(IWorkersGateway), typeof(WorkersGatewayDb), ServiceLifetime.Singleton
                )
            );

            services.Add(
                new ServiceDescriptor(
                    typeof(IAnimalsGateway), typeof(AnimalsGatewayDb), ServiceLifetime.Singleton
                )
            );

            services.Add(new ServiceDescriptor(typeof(IAddAnimalInZooInteractor),
                typeof(AddAnimalInZooInteractor), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(IAddZooInteractor),
                typeof(AddZooInteractor), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(IAddWorkerInZooInteractor),
                typeof(AddWorkerInZooInteractor), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(ILoadAnimalsInZooInteractor),
                typeof(LoadAnimalsInZooInteractor), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(ILoadZooInteractor),
                typeof(LoadZooInteractor), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(ILoadWorkersInZooInteractor),
                typeof(LoadWorkersInZooInteractor), ServiceLifetime.Scoped));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}