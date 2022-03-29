using System.Collections.Generic;

namespace TextureLibrary.Dtos
{
    public class TextureDto
    {
        public string WallType { get; set; }

        public List<TexturePropertiesDTO> TexturePropertiesDtos { get; set; }

        public TextureDto()
        {
            TexturePropertiesDtos = new List<TexturePropertiesDTO>();
        }
    }
}
