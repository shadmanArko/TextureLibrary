using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace TextureLibrary.Models
{
    public class Texture: BaseModel
    {
        public string WallType { get; set; }
        public List<TextureProperties> TextureProperties { get; set; }
    }
}
