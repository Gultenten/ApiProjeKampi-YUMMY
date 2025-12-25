using ApiProjeKampi_YUMMY.WebApi.Context;
using ApiProjeKampi_YUMMY.WebApi.Dtos.MessageDtos;
using ApiProjeKampi_YUMMY.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ApiProjeKampi_YUMMY.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var value = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(value));


        }

   


        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var value= _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var values = _context.Messages.Find(id);
            _context.Messages.Remove(values);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");

        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var values = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(values));
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }

        [HttpGet("MessageListIsReadyFalse")]
        public IActionResult MessageListIsReadyFalse()
        {
            var value = _context.Messages.Where(x => x.IsRead == false).ToList();
            return Ok(value);
        }




    }
}
