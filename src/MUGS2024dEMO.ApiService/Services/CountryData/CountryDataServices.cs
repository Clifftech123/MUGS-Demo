


using CountryData.Standard;
using Newtonsoft.Json;

namespace MUGS2024dEMO.ApiService.Services
{
    public class CountryDataServices : ICountryDataServices
    {
        private readonly CountryHelper _countryHelper;

        public CountryDataServices(CountryHelper countryHelper)
        {
            _countryHelper = countryHelper;
        }

        /// <summary>
        /// Gets the list of countries asynchronously.
        /// </summary>
        /// <returns>A JSON string representing the list of countries.</returns>
        public Task<string> GetCountriesAsync()
        {
            var countries = _countryHelper.GetCountries();
            if (countries == null)
            {
                return Task.FromResult("[]");
            }

            return Task.FromResult(JsonConvert.SerializeObject(countries));
        }

        /// <summary>
        /// Gets the country by its code asynchronously.
        /// </summary>
        /// <param name="code">The country code.</param>
        /// <returns>A JSON string representing the country.</returns>
        public Task<string> GetCountryByCodeAsync(string code)
        {
            var country = _countryHelper.GetCountryByCode(code);
            if (country == null)
            {
                return Task.FromResult("{}");
            }

            return Task.FromResult(JsonConvert.SerializeObject(country));
        }

        /// <summary>
        /// Gets the country by its phone code asynchronously.
        /// </summary>
        /// <param name="phoneCode">The phone code.</param>
        /// <returns>A JSON string representing the country.</returns>

        public Task<string> GetCountryByPhoneCodeAsync(string phoneCode)
        {
            var country = _countryHelper.GetCountryByPhoneCode(phoneCode);
            if (country == null)
            {
                return Task.FromResult("{}");
            }

            return Task.FromResult(JsonConvert.SerializeObject(country));
        }

        /// <summary>
        /// Gets the country data asynchronously.
        /// </summary>
        /// <param name="offset">The offset for pagination.</param>
        /// <param name="limit">The limit for pagination.</param>
        /// <param name="searchQuery">The optional search query.</param>
        /// <returns>A JSON string representing the country data.</returns>

        public Task<string> GetCountryDataAsync(int offset = 1, int limit = 10, string? searchQuery = null)
        {
            var countries = _countryHelper.GetCountryData();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower();
                countries = countries.Where(x =>
                    x.CountryName.ToLower().Contains(searchQuery)
                ).ToList();
            }

            var paginatedCountries = countries.Skip((offset - 1) * limit).Take(limit).ToList();

            if (paginatedCountries == null || !paginatedCountries.Any())
            {
                return Task.FromResult("No countries found");
            }

            return Task.FromResult(JsonConvert.SerializeObject(paginatedCountries, Formatting.Indented));
        }


        /// <summary>
        /// Gets the phone code by the country short code asynchronously.
        /// </summary>
        /// <param name="countryCode">The country short code.</param>
        /// <returns>A string representing the phone code.</returns>

        public Task<string> GetCountryFlagAsync(string countryCode)
        {
            var country = _countryHelper.GetCountryByCode(countryCode);
            if (country == null)
            {
                return Task.FromResult("No country found");
            }

            return Task.FromResult(country.CountryFlag);
        }

        /// <summary>
        /// Gets the phone code by the country short code asynchronously.
        /// </summary>
        /// <param name="countryCode">The country short code.</param>
        /// <returns>A string representing the phone code.</returns>

        public Task<string> GetPhoneCodeByCountryShortCodeAsync(string countryCode)
        {
            var country = _countryHelper.GetCountryByCode(countryCode);
            if (country == null)
            {
                return Task.FromResult("No country found");
            }

            return Task.FromResult(country.PhoneCode);
        }

        /// <summary>
        /// Gets the regions by the country code asynchronously.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>

        public Task<string> GetRegionsByCountryCodeAsync(string countryCode)
        {
            var country = _countryHelper.GetCountryByCode(countryCode);
            if (country == null)
            {
                return Task.FromResult("No country found");
            }

            return Task.FromResult(JsonConvert.SerializeObject(country.Regions));
        }
    }
}