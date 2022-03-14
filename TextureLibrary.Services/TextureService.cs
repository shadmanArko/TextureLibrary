using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextureLibrary.Dtos;
using TextureLibrary.Models;
using TextureLibrary.Repositories;

namespace TextureLibrary.Services
{
    public class TextureService:ITextureService
    {
        private readonly ITextureRepository _textureRepository;

        public TextureService(ITextureRepository textureRepository)
        {
            _textureRepository = textureRepository;
        }

        public async Task<Texture> Insert(TextureDto textureDto)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Textures/");

            if ((!Directory.Exists(path)))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = textureDto.Photo.FileName;
            string ext = Path.GetExtension(fileName);

            fileName = Path.GetRandomFileName();
            fileName = Path.GetFileNameWithoutExtension(fileName);
            fileName = fileName + ext;
            var filePath = "Textures/" + fileName;

            using (var stream = System.IO.File.Create(filePath))
            {
                await textureDto.Photo.CopyToAsync(stream);
                stream.Flush();
            }

            Texture texture = new Texture();
            texture.Name = textureDto.Name;
            texture.Category = textureDto.Category;
            texture.Finish = textureDto.Finish;
            texture.Size = textureDto.Size;
            texture.Photo = filePath;

            var x = await _textureRepository.Insert(texture);
            return texture;

        }

        public async Task<Texture> Update(string id, TextureDto textureDto)
        {
            var texture = await _textureRepository.GetById(id);
            texture.Name = textureDto.Name;
            texture.Category = textureDto.Category;
            texture.Finish = textureDto.Finish;
            texture.Size = textureDto.Size;
            var x = await _textureRepository.Update(texture);
            return x;
        }

        public async Task<Texture> GetById(string id)
        {
            var texture = await _textureRepository.GetById(id);
            return texture;
        }

        public async Task<List<Texture>> GetAll()
        {
            var texture = await _textureRepository.GetAll();
            return texture;
        }
    }
}
