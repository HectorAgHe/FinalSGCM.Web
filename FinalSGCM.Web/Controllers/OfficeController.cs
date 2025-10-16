using FinalSGCM.Business.DTOs;
using FinalSGCM.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalSGCM.Web.Controllers
{
    [Route("api/v1/offices")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;
        public OfficeController(IOfficeService officeService )
        {
            _officeService = officeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var offices = await _officeService.GetAllAsync();
            if (offices.Count() > 0)
            {
                return Ok(offices);
            }
            return NotFound(new { message = "No hay consultorios" });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var office = await _officeService.GetByIdAsync(id);
            if (office == null) {
                return NotFound(new { message = "No se encontro ese consultorio por su id" });
            }
            return Ok(office);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]OfficeCreateDto dto)
        {
            try
            {
                await _officeService.AddAsync(dto);
                return CreatedAtAction(
                        nameof(GetById),
                        new { id = dto.OfficeId }, dto);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
                
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]OfficeCreateDto dto)
        {
            try
            {
                await _officeService.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message
                    });
                
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _officeService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new
                {
                    message = e.Message
                });

            }
        }
    }
}

