namespace Crud_with_mongodb.interfaces.IMongoCrudService;
public interface IMongoCrudService<T>
{
    //basic set of operations to be performed for all documents
    public Task<List<T>> Get_All_Records();
    public Task<T> Get_A_Single_Record(string objId);
    public Task<string> Insert_Record(T obj);
    public Task<string> Update_Record(T obj);
    public Task<string> Delete_Record(string objId);
}
