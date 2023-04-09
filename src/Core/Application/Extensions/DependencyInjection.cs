
// /*
//  * This is another variant that I have noticed in many huge solutions.
//  * Let’s say you have around 100 interfaces and 100 implementations.
//  * Do you add all these 100 lines of code to the Startup.cs to register them in the container?
//  * That would be insane from the maintainability point of view.
//  * To keep things clean, what we can do is,Create a DependencyInjection static Class for every layer of
//  * the solution and only add the corresponding. required services to the corresponding Class.
// */

// namespace Kasi.Application.Extensions
// {
//     public static class DependencyInjection
//     {
//         // Here we will just Add Mediator to the service collection. We will implement the Mediator pattern later in this tutorial.
//         public static void AddApplication(this IServiceCollection services)
//         {
//             services.AddMediatR(Assembly.GetExecutingAssembly());
//         }
//     }
// }