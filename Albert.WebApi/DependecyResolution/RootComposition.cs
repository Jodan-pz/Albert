using Albert.Common.Interfaces;
using Albert.DataLayer;
using Albert.Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Yoda.Common.Interfaces;
using Yoda.Common.UnitOfWork;
using Yoda.EntityFramework;
using Yoda.EntityFramework.Extensions;

namespace Albert.WebApi.DependencyResolution
{
    public static class RootComposition
    {
        public static IServiceCollection ConfigureAlbertDI(this IServiceCollection services, IConfigurationRoot config)
        {
            // add data context (EF)

            // MS SQL SERVER
            //          services.AddDataContextFactory<AlbertDbContextFactory, SchoolContext>(
            // (sp, opts) => opts.UseSqlServer(
            //                                         config.GetConnectionString("DefaultConnection"),
            //                                         b => b.UseRowNumberForPaging()
            //                                         ) 
            //)
            // SQL LITE
            //         services.AddDataContextFactory<AlbertDbContextFactory, SchoolContext>(
            // (sp, opts) => opts.UseSqlite(config.GetConnectionString("DefaultConnection")))


            services.AddDataContextFactory<EFDbContextFactory<SchoolContext>, SchoolContext>(
                (sp, opts) => opts.UseMySQL(config.GetConnectionString("DefaultConnection")))

                     //.AddSingleton<IQuerySpecFactory, AlbertQuerySpecFac>() // add test query spec factory
                     //.AddScoped<IUnitOfWork, Tests.AlbertUOW>()             // add test unit of work

                     .AddSingleton<IQuerySpecFactory, BaseQuerySpecFactory>()
                     .AddSingleton<IQuerySpec, StudentQuerySpec>()
                     .AddSingleton<IQuerySpec, CourseQuerySpec>()

                    .AddScoped<IUnitOfWork, EFUnitOfWork>()             // add unit of work & services
                    .AddTransient<ISimpleService, SimpleService>()      // add simple service
                    .AddAutoMapper();                                   // add auto mapper

            return services;
        }
    }

}