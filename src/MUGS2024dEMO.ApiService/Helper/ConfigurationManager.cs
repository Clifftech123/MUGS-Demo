

namespace MUGS2024dEMO.ApiService.Helper
{
    public static class ConfigurationManager
    {
        public static IConfiguration AppSetting { get; }

        static ConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string GetRedisURL()
        {
            return AppSetting.GetValue<string>("ConnectionStrings:RedisURL");
        }
    }
}
