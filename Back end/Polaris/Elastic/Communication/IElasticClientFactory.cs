namespace Elastic.Communication.Nest
{
    public interface IElasticClientFactory<TElasticClient>
    {
        void CreateInitialClient(string address);
        TElasticClient GetElasticClient();
    }
}