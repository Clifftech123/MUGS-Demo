
namespace MUGS2024dEMO.ApiService.Services
{
    public  interface ICountryDataServices
    {
         Task<string> GetCountriesAsync();
        Task<string> GetCountryByCodeAsync(string code);
        Task<string> GetCountryByPhoneCodeAsync(string phoneCode);
        Task<string> GetCountryDataAsync(int offset = 1, int limit = 10, string? searchQuery = null);
        Task<string> GetCountryFlagAsync(string countryCode);
        Task<string> GetPhoneCodeByCountryShortCodeAsync(string countryCode);
        Task<string> GetRegionsByCountryCodeAsync(string countryCode);
        
    }
}