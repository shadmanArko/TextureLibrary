using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextureLibrary.Dtos;
using TextureLibrary.Models;

namespace TextureLibrary.Services
{
    public interface ITextureService
    {
        Task<Texture> Insert(TextureDto textureDto);
        Task<Texture> Update(string id, TextureDto textureDto);
        Task<Texture> GetById(string id);
        Task<List<Texture>> GetAll();
    }
}
