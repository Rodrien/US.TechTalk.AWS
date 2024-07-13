using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System.Net;
using System.Text.Json;
using US.TechTalk.AWS.API.Contracts.Data;

namespace US.TechTalk.AWS.API.Repositories
{
    public class UrudatosRepository(IAmazonDynamoDB dynamoDb) : IUrudatosRepository
    {
        private readonly IAmazonDynamoDB _dynamoDb = dynamoDb;
        private readonly string _tableName = "urudatos";

        public async Task<bool> CreateAsync(UrudatoDto urudato)
        {
            urudato.UpdatedAt = DateTime.UtcNow;
            var customerAsJson = JsonSerializer.Serialize(urudato);
            var customerAsAttributes = Document.FromJson(customerAsJson).ToAttributeMap();

            var createItemRequest = new PutItemRequest
            {
                TableName = _tableName,
                Item = customerAsAttributes,
                ConditionExpression = "attribute_not_exists(pk) and attribute_not_exists(sk)"
            };

            var response = await _dynamoDb.PutItemAsync(createItemRequest);
            return response.HttpStatusCode == HttpStatusCode.OK;
        }

        public async Task<UrudatoDto?> GetAsync(Guid id)
        {
            var getItemRequest = new GetItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
            {
                { "pk", new AttributeValue { S = id.ToString() } },
                { "sk", new AttributeValue { S = id.ToString() } }
            }
            };

            var response = await _dynamoDb.GetItemAsync(getItemRequest);
            if (response.Item.Count == 0)
            {
                return null;
            }

            var itemAsDocument = Document.FromAttributeMap(response.Item);
            return JsonSerializer.Deserialize<UrudatoDto>(itemAsDocument.ToJson());
        }
    }
}