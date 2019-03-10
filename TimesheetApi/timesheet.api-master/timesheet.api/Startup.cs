using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using timesheet.business;
using timesheet.data;

namespace timesheet.api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            

            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddDbContext<TimesheetDb>();
            services.AddTransient<IEmployeeService,EmployeeService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITimesheetLogService, TimesheetLogService>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                                  builder => builder.AllowAnyOrigin()
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader()
                                                    .AllowCredentials());
            });

            services.AddDbContext<TimesheetDb>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("TimesheetDb")));
          //  services.AddSingleton<I, SystemDateTime>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors("CorsPolicy");
            //if (env.IsDevelopment())
            //{
                app.UseStaticFiles();
                app.UseDeveloperExceptionPage( );  
                app.UseDefaultFiles();
                app.UseCors(option => option.WithOrigins("http://localhost:4200"));
                app.UseMvc(routes =>
                    {
                        routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
                  }
                    );
            //}

        }
    }
}
