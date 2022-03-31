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

        public async Task<Texture> Insert(TexturePropertiesDTO texturePropertiesDto, string id)
        {
            Texture texture = await GetById(id);
            TextureProperties textureProperties = new TextureProperties();

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Textures/");

            if ((!Directory.Exists(path)))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = texturePropertiesDto.Photo.FileName;
            string ext = Path.GetExtension(fileName);

            fileName = Path.GetRandomFileName();
            fileName = Path.GetFileNameWithoutExtension(fileName);
            fileName = fileName + ext;
            var filePath = "Textures/" + fileName;

            using (var stream = System.IO.File.Create(filePath))
            {
                await texturePropertiesDto.Photo.CopyToAsync(stream);
                stream.Flush();
            }

            textureProperties.Name = texturePropertiesDto.Name;
            textureProperties.Finish = texturePropertiesDto.Finish;
            textureProperties.Size = texturePropertiesDto.Size;
            textureProperties.Photo = filePath;
            


            texture.TextureProperties.Add(textureProperties);

            //texture.WallType = textureDto.WallType;

            //foreach (var TextureProperties in textureDto.TexturePropertiesDtos)
            //{
            //    string fileName = TextureProperties.Photo.FileName;
            //    string ext = Path.GetExtension(fileName);

            //    fileName = Path.GetRandomFileName();
            //    fileName = Path.GetFileNameWithoutExtension(fileName);
            //    fileName = fileName + ext;
            //    var filePath = "Textures/" + fileName;

            //    using (var stream = System.IO.File.Create(filePath))
            //    {
            //        await TextureProperties.Photo.CopyToAsync(stream);
            //        stream.Flush();
            //    }

            //    //Texture texture = new Texture();
            //    TextureProperties textureProperties = new TextureProperties();
            //    textureProperties.Name = TextureProperties.Name;
            //    textureProperties.Finish = TextureProperties.Finish;
            //    textureProperties.Size = TextureProperties.Size;
            //    textureProperties.Photo = filePath;
            //    texture.TextureProperties.Add(textureProperties);
            //}

            var x = await _textureRepository.Insert(texture);
            return texture;
        }

        //public async Task<Texture> Insert(TextureDto textureDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Texture> Insert(TexturePropertiesDTO texturePropertiesDto)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Texture> Update(string id, TextureDto textureDto)
        {
            throw new NotImplementedException();
        }

        //public async Task<Texture> Update(string id, TextureDto textureDto)
        //{
        //    var texture = await _textureRepository.GetById(id);
        //    texture.Name = textureDto.Name;
        //    texture.Category = textureDto.Category;
        //    texture.Finish = textureDto.Finish;
        //    texture.Size = textureDto.Size;
        //    var x = await _textureRepository.Update(texture);
        //    return x;
        //}

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
