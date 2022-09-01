using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureService(IServiceCollection services)
        {
            services.AddDbContext<TarefaContext>(x => x.UseSqlite("Data source=tarefas.db"));
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
            
            app.Run();
        }
    }
}