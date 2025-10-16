using FinalSGCM.Business.DTOs;
using FinalSGCM.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalSGCM.Web.Controllers
{
    [Route("api/v1/specialities")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;
        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var specialities = await _specialityService.GetAllAsync();
            if (specialities.Count() > 0)
            {
                return Ok(specialities);
            }
            return NotFound(new { message = "No hay ninguna especialidad disponible" });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var speciality = await _specialityService.GetByIdAsync(id);
            if (speciality == null) {
                return NotFound(new { message = "La especialidad no se encontro" });
            }
            return Ok(speciality);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SpecialityCreateDto dto)
        {
            await _specialityService.AddAsync(dto);
            return CreatedAtAction(
                    nameof(GetById),
                    new { id = dto.SpecialityId }, dto);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SpecialityCreateDto dto)
        {
            try
            {
                await _specialityService.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new { mesage = e.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await _specialityService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return NotFound(new { mesage = e.Message });
            }
        }
    }
}
