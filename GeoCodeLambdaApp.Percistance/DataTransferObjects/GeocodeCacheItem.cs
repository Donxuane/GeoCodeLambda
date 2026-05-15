using Amazon.DynamoDBv2.DataModel;

namespace GeoCodeLambdaApp.Percistance.DataTransferObjects;

[DynamoDBTable("GeoCode")]
public class GeocodeCacheItem
{
    [DynamoDBHashKey("adress")]
    public string Address { get; set; }

    public string ResponseJson { get; set; }

    public long Ttl { get; set; }
}
