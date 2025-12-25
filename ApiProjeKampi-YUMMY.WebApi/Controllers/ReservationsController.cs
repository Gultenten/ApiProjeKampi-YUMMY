using ApiProjeKampi_YUMMY.WebApi.Context;
using ApiProjeKampi_YUMMY.WebApi.Dtos.ReservationDtos;
using ApiProjeKampi_YUMMY.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi_YUMMY.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ReservationsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _context.Reservations.ToList();
            return Ok(values);
        }




        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDto createReservationDto)
        {
    
            var values = _mapper.Map<Reservation>(createReservationDto);
            _context.Reservations.Add(values);
            _context.SaveChanges();
            return Ok("Rezervasyon Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var value = _context.Reservations.Find(id);
            _context.Reservations.Remove(value);
            _context.SaveChanges();
            return Ok("Rezervasyon Silme İşlemi Başarılı");


        }

        [HttpGet("GetReservation")]
        public IActionResult GetReservation(int id)
        {
            var values = _context.Reservations.Find(id);
            return Ok(values);

        }

        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            //var values = _context.Categories.Update(category);
            //_context.SaveChanges();

            var values = _mapper.Map<Reservation>(updateReservationDto);
            _context.Reservations.Update(values);
            _context.SaveChanges();
            return Ok("Rezervasyon Güncelleme İşlemi Başarılı");
        }


        [HttpGet("GetTotalReservationCount")]
        public IActionResult GetTotalReservationCount()
        {
            var value = _context.Reservations.Count();
            return Ok(value);
        }



        [HttpGet("GetTotalCustomerCount")]
        public IActionResult GetTotalCustomerCount()
        {
            var value = _context.Reservations.Sum(x => x.CountOfPeople);
            return Ok(value);
        }


        [HttpGet("GetPendingReservation")]
        public IActionResult GetPendingReservation()
        {
            var value = _context.Reservations.Where(x => x.ReservationStatus=="Onay Bekliyor").Count();
            return Ok(value);
        }

        [HttpGet("GetApprovedReservation")]
        public IActionResult GetApprovedReservation()
        {
            var value = _context.Reservations.Where(x => x.ReservationStatus == "Onaylandı").Count();
            return Ok(value);
        }


        [HttpGet("GetReservationStats")]
        public IActionResult GetReservationStats()
        {
            DateTime today = DateTime.Today;
            DateTime fourMonthsAgo = today.AddMonths(-3);

            // 1. SQL tarafında sadece gruplama ve veri çekme
            var rawData = _context.Reservations
                .Where(r => r.ReservationDate >= fourMonthsAgo)
                .GroupBy(r => new { r.ReservationDate.Year, r.ReservationDate.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Approved = g.Count(x => x.ReservationStatus == "Onaylandı"),
                    Pending = g.Count(x => x.ReservationStatus == "Onay Bekliyor"),
                    Canceled = g.Count(x => x.ReservationStatus == "İptal Edildi")
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToList(); // Burada SQL biter, veriler RAM’e alınır

            // 2. Bellekte DTO'ya mapleme + tarih formatlama
            var result = rawData.Select(x => new ReservationChartDto
            {
                Month = new DateTime(x.Year, x.Month, 1).ToString("MMM yyyy"),
                Approved = x.Approved,
                Pending = x.Pending,
                Canceled = x.Canceled
            }).ToList();
            return Ok(result);
        }

    }
}

