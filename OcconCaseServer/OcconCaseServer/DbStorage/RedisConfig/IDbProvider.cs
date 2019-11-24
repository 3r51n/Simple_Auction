namespace Occon.Server.Api.DataStorage.RedisConfig
{
    public interface IDbProvider
    {
        void Set<T>(string key, T value);
        T Get<T>(string key);
        T Get<T>(object id);
        bool Remove<T>(string key);
        bool Remove<T>(object id);
        bool IsExist<T>(string key);
    }
}
