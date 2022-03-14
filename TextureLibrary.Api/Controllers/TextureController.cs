using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextureLibrary.Dtos;
using TextureLibrary.Services;

namespace TextureLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextureController : ControllerBase
    {
        private readonly ITextureService _textureService;

        public TextureController(ITextureService textureService)
        {
            _textureService = textureService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTexture([FromForm] TextureDto textureDto)
        {
            var texture = await _textureService.Insert(textureDto);
            
            return Ok(texture);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTexture(string id, TextureDto textureDto)
        {
            var texture = _textureService.Update(id, textureDto);
            return Ok(texture);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTextureById(string id)
        {
            var texture = await _textureService.GetById(id);

            return Ok(texture);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTextures()
        {
            var texture = await _textureService.GetAll();

            return Ok(texture);
        }

    }
}
