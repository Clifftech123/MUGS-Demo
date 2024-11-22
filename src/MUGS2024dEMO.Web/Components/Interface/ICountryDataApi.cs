using Refit;

namespace MUGS2024dEMO.Web.Components.Interface
{
    /// <summary>
    /// Interface for accessing country data API endpoints.
    /// </summary>
    public interface ICountryDataApi
    {
        /// <summary>
        /// Gets a list of all countries.
        /// </summary>
        /// <returns>A JSON string containing the list of countries.</returns>
        [Get("/api/countrydata/countries")]
        Task<string> GetCountriesAsync();

        /// <summary>
        /// Gets the details of a country by its code.
        /// </summary>
        /// <param name="code">The country code.</param>
        /// <returns>A JSON string containing the country details.</returns>
        [Get("/api/countrydata/country/{code}")]
        Task<string> GetCountryByCodeAsync(string code);

        /// <summary>
        /// Gets country data with pagination and optional search query.
        /// </summary>
        /// <param name="offset">The page offset.</param>
        /// <param name="limit">The number of countries per page.</param>
        /// <param name="searchQuery">The search query to filter countries by name.</param>
        /// <returns>A JSON string containing the country data.</returns>
        [Get("/api/countrydata/countrydata")]
        Task<string> GetCountryDataAsync([Query] int offset = 1, [Query] int limit = 10, [Query] string? searchQuery = null);

        /// <summary>
        /// Gets the regions of a country by its code.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>A JSON string containing the regions of the country.</returns>
        [Get("/api/countrydata/regions/{countryCode}")]
        Task<string> GetRegionsByCountryCodeAsync(string countryCode);

        /// <summary>
        /// Gets the flag of a country by its code.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>A JSON string containing the country flag.</returns>
        [Get("/api/countrydata/flag/{countryCode}")]
        Task<string> GetCountryFlagAsync(string countryCode);

        /// <summary>
        /// Gets the phone code of a country by its short code.
        /// </summary>
        /// <param name="countryCode">The country short code.</param>
        /// <returns>A JSON string containing the phone code of the country.</returns>
        [Get("/api/countrydata/phonecode/{countryCode}")]
        Task<string> GetPhoneCodeByCountryShortCodeAsync(string countryCode);

        /// <summary>
        /// Gets the country details by its phone code.
        /// </summary>
        /// <param name="phoneCode">The phone code.</param>
        /// <returns>A JSON string containing the country details.</returns>
        [Get("/api/countrydata/countrybyphonecode/{phoneCode}")]
        Task<string> GetCountryByPhoneCodeAsync(string phoneCode);
    }
}
