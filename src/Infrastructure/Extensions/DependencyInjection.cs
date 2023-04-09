// namespace Kasi.Infrastructure.Extensions
// {
//     public static class DependencyInjection
//     {
//         public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
//         {
//             services.AddDbContext<ApplicationDbContext>( options =>
//             {
//                 options.UseNpgsql(
//                     configuration.GetConnectionString("ApplicationDbContext"),
//                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
//                 );
//             });

//             services.AddScoped<IApplicationDbContext>(provider =>
//             {
//                 return provider.GetService<ApplicationDbContext>();
//             });
//         }
//     }
// }