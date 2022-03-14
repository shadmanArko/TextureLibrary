using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using TextureLibrary.Models;

namespace TextureLibrary.Repositories
{
    public class TextureRepository: ITextureRepository
    {
        protected IMongoCollection<Texture> Collection;


        public TextureRepository(MongoDbContext mongoDbContext)
        {
            Collection = mongoDbContext.Database.GetCollection<Texture>("Textures");
        }


        public async Task<Texture> Insert(Texture texture)
        {
            await Collection.InsertOneAsync(texture);
            return texture;
        }

        public async Task<Texture> Update(Texture texture)
        {
            var filter = Builders<Texture>.Filter.Where(x => x.Id == texture.Id);
            await Collection.ReplaceOneAsync(filter, texture);
            return texture;
        }

        public async Task<Texture> GetById(string id)
        {
            var texture = await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return texture;
        }

        public async Task<List<Texture>> GetAll()
        {
            var texture = await Collection.FindAsync(x => true);
            return texture.ToList();
        }
    }
}
