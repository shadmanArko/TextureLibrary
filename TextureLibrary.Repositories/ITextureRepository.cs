using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextureLibrary.Models;

namespace TextureLibrary.Repositories
{
    public interface ITextureRepository
    {
        Task<Texture> Insert(Texture texture);
        Task<Texture> Update(Texture texture);
        Task<Texture> GetById(string id);
        Task<List<Texture>> GetAll();

    }
}
