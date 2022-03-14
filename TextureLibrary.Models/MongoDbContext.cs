using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TextureLibrary.Models
{
    public class MongoDbContext
    {
        public readonly IMongoClient Client;
        public readonly IMongoDatabase Database;

        public MongoDbContext(MongoDbSettings mongoDbSettings)
        {
            Client = new MongoClient(mongoDbSettings.Host);
            Database = Client.GetDatabase(mongoDbSettings.Name);
        }
    }
}
