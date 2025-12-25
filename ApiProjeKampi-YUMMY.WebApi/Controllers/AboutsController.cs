using ApiProjeKampi_YUMMY.WebApi.Context;
using ApiProjeKampi_YUMMY.WebApi.Dtos.AboutDtos;
using ApiProjeKampi_YUMMY.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi_YUMMY.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {

        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public AboutsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _context.Abouts.ToList();
            return Ok(values);
        }



        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            //_context.Categories.Add(category);
            //_context.SaveChanges();
            var values = _mapper.Map<About>(createAboutDto);
            _context.Abouts.Add(values);
            _context.SaveChanges();
            return Ok("Hakkımda Alanı Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return Ok("Hakkımda Alanı Silme İşlemi Başarılı");


        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var values = _context.Abouts.Find(id);
            return Ok(values);

        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            //var values = _context.Categories.Update(category);
            //_context.SaveChanges();

            var values = _mapper.Map<About>(updateAboutDto);
            _context.Abouts.Update(values);
            _context.SaveChanges();
            return Ok("Hakkımda Alanı Güncelleme İşlemi Başarılı");
        }
    }
}
