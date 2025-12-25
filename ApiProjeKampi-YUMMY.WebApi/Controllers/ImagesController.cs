using ApiProjeKampi_YUMMY.WebApi.Context;
using ApiProjeKampi_YUMMY.WebApi.Dtos.ImageDtos;
using ApiProjeKampi_YUMMY.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi_YUMMY.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ImagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult ImageList()
        {
            var values = _context.Images.ToList();
            return Ok(values);
        }




        [HttpPost]
        public IActionResult CreateImage(CreateImageDto createImageDto)
        {
           
            var values = _mapper.Map<Image>(createImageDto);
            _context.Images.Add(values);
            _context.SaveChanges();
            return Ok("Görsel Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteImage(int id)
        {
            var value = _context.Images.Find(id);
            _context.Images.Remove(value);
            _context.SaveChanges();
            return Ok("Görsel Silme İşlemi Başarılı");


        }

        [HttpGet("GetImage")]
        public IActionResult GetImage(int id)
        {
            var values = _context.Images.Find(id);
            return Ok(values);

        }

        [HttpPut]
        public IActionResult UpdateImage(UpdateImageDto updateImageDto)
        {
            var values = _mapper.Map<Image>(updateImageDto);
            _context.Images.Update(values);
            _context.SaveChanges();
            return Ok("Görsel Güncelleme İşlemi Başarılı");
        }

    }
}
