using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using GeoCodeLambdaApp.Domain.Interfaces.Services;
using GeoCodeLambdaApp.Percistance.DataTransferObjects;
namespace GeoCodeLambdaApp.Percistance.Services
{
    public class DynamoCacheService : IDynamoCacheService
    {
        private readonly IDynamoDBContext _context;

        public DynamoCacheService(IAmazonDynamoDB dynamoDb)
        {
            _context = new DynamoDBContext(dynamoDb);
        }

        public async Task<string?> GetCachedGeocodeAsync(string address)
        {
            var item = await _context.LoadAsync<GeocodeCacheItem>(address);

            if (item == null)
                return null;

            return item.ResponseJson;
        }

        public async Task SaveToCacheAsync(string address, string responseJson)
        {
            var item = new GeocodeCacheItem
            {
                Address = address,
                ResponseJson = responseJson,
                Ttl = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + (30 * 24 * 60 * 60) // 30 days
            };

            await _context.SaveAsync(item);
        }
    }
}
