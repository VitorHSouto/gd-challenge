using static Dapper.SqlMapper;

namespace gd_api.Domain.Settings
{
    public class Context
    {
        public static string JwtSecret { get; private set; }

        static Context()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            JwtSecret = configuration["JwtSecret"]!;
        }
    }
}
