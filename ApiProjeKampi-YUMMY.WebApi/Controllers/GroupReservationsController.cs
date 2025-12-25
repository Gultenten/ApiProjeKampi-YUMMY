using ApiProjeKampi_YUMMY.WebApi.Context;
using ApiProjeKampi_YUMMY.WebApi.Dtos.GroupReservationDtos;
using ApiProjeKampi_YUMMY.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi_YUMMY.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public GroupReservationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult GroupReservationList()
        {
            var values = _context.GroupReservations.ToList();
            return Ok(values);
        }




        [HttpPost]
        public IActionResult CreateGroupReservation(CreateGroupReservationDto createGroupReservationDto)
        {
            //_context.Categories.Add(category);
            //_context.SaveChanges();
            var values = _mapper.Map<GroupReservation>(createGroupReservationDto);
            _context.GroupReservations.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteGroupReservation(int id)
        {
            var value = _context.GroupReservations.Find(id);
            _context.GroupReservations.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");


        }

        [HttpGet("GetGroupReservation")]
        public IActionResult GetGroupReservation(int id)
        {
            var values = _context.GroupReservations.Find(id);
            return Ok(values);

        }

        [HttpPut]
        public IActionResult UpdateGroupReservation(UpdateGroupReservationDto updateGroupReservationDto)
        {
            //var values = _context.Categories.Update(category);
            //_context.SaveChanges();

            var values = _mapper.Map<GroupReservation>(updateGroupReservationDto);
            _context.GroupReservations.Update(values);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }

    }
}
