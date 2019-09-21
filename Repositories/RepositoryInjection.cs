using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pishkhan.Repositories
{
    public class RepositoryInjection
    {
        public static void Inject(IServiceCollection services)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            var repo = assembly.GetTypes()
                .Where(c => c.IsClass && !c.IsAbstract && typeof(IBaseRepository).IsAssignableFrom(c))
                .ToList();

            foreach (var item in repo)
            {
                services.AddScoped(item);
            }

        }
    }
}
