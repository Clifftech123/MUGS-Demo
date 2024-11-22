using Microsoft.AspNetCore.Mvc;
using MUGS2024dEMO.ApiService.Services;

namespace MUGS2024dEMO.ApiService.Controllers
{

    // get CountryList 
    /// <summary>
    /// Controller for handling country data related requests.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CountryDataController : ControllerBase
    {
        private readonly ICountryDataServices _countryDataServices;
        private readonly IRedisCache _redisCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryDataController"/> class.
        /// </summary>
        /// <param name="countryDataServices">The country data services.</param>
        /// <param name="redisCache">The Redis cache service.</param>
        public CountryDataController(ICountryDataServices countryDataServices, IRedisCache redisCache)
        {
            _countryDataServices = countryDataServices;
            _redisCache = redisCache;
        }

        /// <summary>
        /// Gets the list of countries.
        /// </summary>
        /// <returns>A list of countries.</returns>
        [HttpGet]
        [Route("countries")]
        public async Task<IActionResult> GetCountriesAsync()
        {
            var key = "CountryList";
            var cacheData = _redisCache.GetCacheData<string>(key);
            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            try
            {
                var countries = await _countryDataServices.GetCountriesAsync();
                if (countries != null)
                {
                    var expirationTime = DateTimeOffset.Now.AddMinutes(5);
                    _redisCache.SetCacheData(key, countries, expirationTime);
                    return Ok(countries);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the country by its code.
        /// </summary>
        /// <param name="code">The country code.</param>
        /// <returns>The country details.</returns>
        [HttpGet]
        [Route("country/{code}")]
        public async Task<IActionResult> GetCountryByCodeAsync(string code)
        {
            var key = $"Country_{code}";
            var cacheData = _redisCache.GetCacheData<string>(key);
            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            try
            {
                var country = await _countryDataServices.GetCountryByCodeAsync(code);
                if (country != null)
                {
                    var expirationTime = DateTimeOffset.Now.AddMinutes(5);
                    _redisCache.SetCacheData(key, country, expirationTime);
                    return Ok(country);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the country data with pagination and optional search query.
        /// </summary>
        /// <param name="offset">The offset for pagination.</param>
        /// <param name="limit">The limit for pagination.</param>
        /// <param name="searchQuery">The optional search query.</param>
        /// <returns>The paginated country data.</returns>
        [HttpGet]
        [Route("countrydata")]
        public async Task<IActionResult> GetCountryDataAsync([FromQuery] int offset = 1, [FromQuery] int limit = 10, string? searchQuery = null)
        {
            var key = $"CountryData_{offset}_{limit}_{searchQuery}";
            var cacheData = _redisCache.GetCacheData<string>(key);
            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            try
            {
                var countryData = await _countryDataServices.GetCountryDataAsync(offset, limit, searchQuery);
                if (countryData != null)
                {
                    var expirationTime = DateTimeOffset.Now.AddMinutes(5);
                    _redisCache.SetCacheData(key, countryData, expirationTime);
                    return Ok(countryData);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the regions by country code.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>The list of regions.</returns>
        [HttpGet]
        [Route("regions/{countryCode}")]
        public async Task<IActionResult> GetRegionsByCountryCodeAsync(string countryCode)
        {
            var key = $"Regions_{countryCode}";
            var cacheData = _redisCache.GetCacheData<string>(key);
            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            try
            {
                var regions = await _countryDataServices.GetRegionsByCountryCodeAsync(countryCode);
                if (regions != null)
                {
                    var expirationTime = DateTimeOffset.Now.AddMinutes(5);
                    _redisCache.SetCacheData(key, regions, expirationTime);
                    return Ok(regions);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the country flag by country code.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>The country flag.</returns>
        [HttpGet]
        [Route("flag/{countryCode}")]
        public async Task<IActionResult> GetCountryFlagAsync(string countryCode)
        {
            var key = $"Flag_{countryCode}";
            var cacheData = _redisCache.GetCacheData<string>(key);
            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            try
            {
                var flag = await _countryDataServices.GetCountryFlagAsync(countryCode);
                if (flag != null)
                {
                    var expirationTime = DateTimeOffset.Now.AddMinutes(5);
                    _redisCache.SetCacheData(key, flag, expirationTime);
                    return Ok(flag);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the phone code by country short code.
        /// </summary>
        /// <param name="countryCode">The country short code.</param>
        /// <returns>The phone code.</returns>
        [HttpGet]
        [Route("phonecode/{countryCode}")]
        public async Task<IActionResult> GetPhoneCodeByCountryShortCodeAsync(string countryCode)
        {
            var key = $"PhoneCode_{countryCode}";
            var cacheData = _redisCache.GetCacheData<string>(key);
            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            try
            {
                var phoneCode = await _countryDataServices.GetPhoneCodeByCountryShortCodeAsync(countryCode);
                if (phoneCode != null)
                {
                    var expirationTime = DateTimeOffset.Now.AddMinutes(5);
                    _redisCache.SetCacheData(key, phoneCode, expirationTime);
                    return Ok(phoneCode);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the country by phone code.
        /// </summary>
        /// <param name="phoneCode">The phone code.</param>
        /// <returns>The country details.</returns>
        [HttpGet]
        [Route("countrybyphonecode/{phoneCode}")]
        public async Task<IActionResult> GetCountryByPhoneCodeAsync(string phoneCode)
        {
            var key = $"CountryByPhoneCode_{phoneCode}";
            var cacheData = _redisCache.GetCacheData<string>(key);
            if (cacheData != null)
            {
                return Ok(cacheData);
            }

            try
            {
                var country = await _countryDataServices.GetCountryByPhoneCodeAsync(phoneCode);
                if (country != null)
                {
                    var expirationTime = DateTimeOffset.Now.AddMinutes(5);
                    _redisCache.SetCacheData(key, country, expirationTime);
                    return Ok(country);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
