using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyMovie.Models;
using MyMovie.Services;

namespace MyMovie
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //services.AddSingleton<IWelcomeServices, WelcomeServices>();//注册服务  单例模式  接口 实现类  整个项目只会一次
            //services.AddTransient<IWelcomeServices, WelcomeServices>();//注册服务  每次请求都会生成此实例
            //services.AddScoped<IWelcomeServices, WelcomeServices>();//注册服务  每次http请求

            services.AddScoped<IRepository<Student>, InMemoryRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //处理http请求

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IConfiguration configuration,
            IWelcomeServices welcomeMyApp,//自定义的
            ILogger<Startup> logger//日志

            )//自定义服务
        {
            //错误处理
            // env.IsEnvironment("123"); env.IsDevelopment()  设置位于  \Properties\launchSettings.json ASPNETCORE_ENVIRONMENT
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();//静态文件  wwwroot 
            app.UseCookiePolicy();
            //app.Run(async (context) =>
            //{
            //    //系统环境变量优先级高   appsettings.Development 开发模式   appsettings   系统>开发>app
            //    var losgLevel = configuration["Logging:LogLevel:Default"];
            //    await context.Response.WriteAsync("hello world");
            //});

            //次次都是主页
            //app.UseWelcomePage();
            //当访问/Welcome 则跳到欢迎页
            //app.UseWelcomePage(new WelcomePageOptions 
            //{
            //    Path = "/Welcome"
            //});

            //自定义中间件
            //app.Use(next =>
            //{
            //    logger.LogInformation("app use...");
            //    return async httpContext =>
            //    {
            //        logger.LogInformation("async httpcontext...");
            //        if (httpContext.Request.Path.StartsWithSegments("/first"))
            //        {
            //            logger.LogInformation("first...");
            //            await httpContext.Response.WriteAsync("first!!");
            //        }
            //        else
            //        {
            //            logger.LogInformation("next...");
            //            await next(httpContext);
            //        }
            //    };

            //});


            app.UseMvc(routes =>
            {
                //约定路由  可不写  直接在控制器上写  如 homecontroller
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
