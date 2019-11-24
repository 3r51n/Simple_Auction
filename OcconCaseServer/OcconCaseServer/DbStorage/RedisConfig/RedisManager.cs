using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace Occon.Server.Api.DataStorage.RedisConfig
{
    public class RedisManager : IDbProvider
    {
        private string _redisKey;
        private static IDatabase _database;
        

        public RedisManager(string redisKey)
        {
            if (_database == null)
                _database = RedisStore.RedisDb;

            _redisKey = redisKey;
        }


        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        private T Deserialize<T>(string serialized)
        {
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public T Get<T>(string key)
        {
            var value = _database.HashGet(_redisKey, key);
            if (value.IsNull)
                return default;

            return Deserialize<T>(value.ToString());
        }

        public bool Remove<T>(string key)
        {
            return _database.HashDelete(_redisKey, key);
        }


        public T Get<T>(object id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist<T>(string key)
        {
            return _database.HashExists(_redisKey, key);
        }


        public bool Remove<T>(object id)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, T value)
        {
            if (value == null)
                return;

            _database.HashSet(_redisKey, key, Serialize(value));
        }

    }
}
