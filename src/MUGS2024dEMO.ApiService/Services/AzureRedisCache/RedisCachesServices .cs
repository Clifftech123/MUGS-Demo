using MUGS2024dEMO.ApiService.Helper;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace MUGS2024dEMO.ApiService.Services.AzureRedisCache
{
    /// <summary>
    /// Provides services for interacting with Azure Redis Cache.
    /// </summary>
    public class RedisCachesServices : IRedisCache
    {
        private readonly IDatabase _database;
        private readonly IConnectionMultiplexer _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedisCachesServices"/> class.
        /// </summary>
        public RedisCachesServices()
        {
            _connection = ConnectionHelper.Connection;
            _database = _connection.GetDatabase();
        }

        /// <summary>
        /// Retrieves the cached data for the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the cached data.</typeparam>
        /// <param name="key">The key of the cached data.</param>
        /// <returns>The cached data if found; otherwise, the default value of <typeparamref name="T"/>.</returns>
        public T GetCacheData<T>(string key)
        {
            var value = _database.StringGet(key);
            if (!value.IsNullOrEmpty)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        /// <summary>
        /// Removes the cached data with the specified key.
        /// </summary>
        /// <param name="key">The key of the cached data to remove.</param>
        /// <returns>A result indicating whether the key was removed.</returns>
        public object RemoveData(string key)
        {
            return _database.KeyDelete(key);
        }

        /// <summary>
        /// Sets the cached data for the specified key with an expiration time.
        /// </summary>
        /// <typeparam name="T">The type of the data to cache.</typeparam>
        /// <param name="key">The key of the data to cache.</param>
        /// <param name="value">The data to cache.</param>
        /// <param name="expirationTime">The expiration time for the cached data.</param>
        /// <returns><c>true</c> if the data was successfully cached; otherwise, <c>false</c>.</returns>
        public bool SetCacheData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime - DateTimeOffset.Now;
            var isSet = _database.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }

        /// <summary>
        /// Asynchronously removes cached data that matches the specified pattern.
        /// </summary>
        /// <param name="pattern">The pattern to match keys against.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task RemoveByPatternAsync(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                return;

            var endpoints = _connection.GetEndPoints();
            foreach (var endpoint in endpoints)
            {
                var server = _connection.GetServer(endpoint);
                var keys = server.Keys(pattern: $"{pattern}*", database: _database.Database);
                foreach (var key in keys)
                {
                    await _database.KeyDeleteAsync(key);
                }
            }
        }
    }
}
