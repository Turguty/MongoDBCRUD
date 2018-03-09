using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApplication1.DataLayer
{
    public class MongoRepository
    {
        //delcaring mongo db
        private readonly IMongoDatabase _database;

        public MongoRepository(IOptions<Settings> settings)
        {
            try
            {
                var client = new MongoClient(settings.Value.ConnectionString);
                if (client != null)
                    _database = client.GetDatabase(settings.Value.Database);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to MongoDb server.", ex);
            }

        }

        public IMongoCollection<Users> users => _database.GetCollection<Users>("Users");

    }
}
