using Microsoft.EntityFrameworkCore; 

namespace SistemaTitulos.Data.SeedData
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            await context.Database.MigrateAsync();

            










            

            
        }
    }
}
