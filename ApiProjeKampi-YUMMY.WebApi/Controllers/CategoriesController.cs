using ApiProjeKampi_YUMMY.WebApi.Context;
using ApiProjeKampi_YUMMY.WebApi.Dtos.CategoryDtos;
using ApiProjeKampi_YUMMY.WebApi.Dtos.FeatureDtos;
using ApiProjeKampi_YUMMY.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi_YUMMY.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }




        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //_context.Categories.Add(category);
            //_context.SaveChanges();
            var values = _mapper.Map<Category>(createCategoryDto);
            _context.Categories.Add(values);
            _context.SaveChanges();
            return Ok("Kategori Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori Silme İşlemi Başarılı");


        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var values = _context.Categories.Find(id);
            return Ok(values);

        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            //var values = _context.Categories.Update(category);
            //_context.SaveChanges();

            var values = _mapper.Map<Category>(updateCategoryDto);
            _context.Categories.Update(values);
            _context.SaveChanges();
            return Ok("Kategori Güncelleme İşlemi Başarılı");
        }


    }
}
