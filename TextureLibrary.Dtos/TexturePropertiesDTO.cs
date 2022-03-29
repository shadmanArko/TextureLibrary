using Microsoft.AspNetCore.Http;

namespace TextureLibrary.Dtos
{
    public class TexturePropertiesDTO
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Finish { get; set; }
        public string Size { get; set; }
        public IFormFile Photo { get; set; }

    }
}