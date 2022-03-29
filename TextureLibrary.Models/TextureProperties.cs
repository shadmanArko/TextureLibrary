using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureLibrary.Models
{
    public class TextureProperties:BaseModel

    {
        public string Name { get; set; }
        public string Finish { get; set; }
        public string Size { get; set; }
        public string Photo { get; set; }
    }
}
