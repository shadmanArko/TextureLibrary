using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TextureLibrary.Dtos
{
    public class TextureDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Finish { get; set; }
        public string Size { get; set; }
        public IFormFile Photo { get; set; }
    }
}
