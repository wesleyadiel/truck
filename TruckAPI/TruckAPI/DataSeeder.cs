using Data;

namespace TruckAPI
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DataDBContext>();
            context.Database.EnsureCreated();
        }

        private static void AddCaminhoes(DataDBContext context)
        {
            var caminhao = context.Caminhoes.FirstOrDefault();
            if (caminhao != null)
            {
                return;
            }
        }
    }
}
