using Crud_with_mongodb.interfaces.IMongoCrudService;
using Crud_with_mongodb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Namespace;
public class UserDAL : IMongoCrudService<Users>
{
    private IMongoCollection<Users> mongoCollection;
    private MongoClient mongoClient;

    public UserDAL(IOptions<DbConfiguration> DbConfig)
    {
        mongoClient = new MongoClient(DbConfig.Value.ClientUrl);
        var database = mongoClient.GetDatabase(DbConfig.Value.Database);
        mongoCollection = database.GetCollection<Users>(DbConfig.Value.Collection);
    }

    public async Task<List<Users>> Get_All_Records()
    {
        return await mongoCollection.Find(x => true).ToListAsync();
    }

    public async Task<Users> Get_A_Single_Record(string id)
    {
        return await mongoCollection.Find(x => x._id == id).FirstOrDefaultAsync();
    }

    public async Task<string> Insert_Record(Users obj)
    {
        string result = string.Empty;
        try
        {
            await mongoCollection.InsertOneAsync(obj);
            result = "inserted";
        }
        catch (Exception e)
        {
            result = e.Message;
        }
        return result;
    }

    public async Task<string> Update_Record(Users obj)
    {
        string result = string.Empty;
        try
        {
            var filter = Builders<Users>.Filter.Eq(x => x._id,  obj._id);
            var builder = Builders<Users>.Update
                                            .Set(x => x.Age, obj.Age)
                                            .Set(x => x.Name, obj.Name)
                                            .Set(x => x.Todo, obj.Todo);
            var updateResult = await mongoCollection.UpdateOneAsync(filter, builder);
            if (updateResult.IsAcknowledged)
            {
                result = "Record Updated";
            }
        }
        catch (Exception e)
        {
            result = e.Message;
        }
        return result;
    }
    public async Task<string> Delete_Record(string Id)
    {
        string result = string.Empty;
        try
        {
            var filter = Builders<Users>.Filter.Eq(x => x._id, Id);
            var deleteResult = await mongoCollection.DeleteOneAsync(filter);
            if (deleteResult.IsAcknowledged)
            {
                result = "Record Deleted";
            }
        }
        catch (Exception e)
        {
            result = e.Message;
        }
        return result;
    }
}
