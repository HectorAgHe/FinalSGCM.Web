using FinalSGCM.Business.DTOs;
using FinalSGCM.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace FinalSGCM.Web.Controllers
{
    [Route("api/v1/medics")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMedicService _medicService;
        public MedicController(IMedicService medicService)
        {
            _medicService = medicService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medics = await _medicService.GetAllAsync();
            if(medics.Count() > 0)
            {
                return Ok(medics);
            }
            return NotFound(new { message = "No hay medicos disponibles" });
          
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medic = await _medicService.GetByIdAsync(id);
            if(medic == null)
            {
                return NotFound(new {message="El medico no se encontro"});
            }
            return Ok(medic);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MedicCreateDto dto)
        {
            try
            {
                await _medicService.AddAsync(dto);
                return CreatedAtAction(
                        nameof(GetById),
                        new { id = dto.MedicId }, dto.MedicId);
            }
            catch (Exception e)
            {

                return BadRequest(new { message = e.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MedicCreateDto dto ) {
            //if (dto.MedicId == id) {
            //    return NotFound(new { message = "el id no coincide con el del producto a editar" });
            //}
            try
            {
                await _medicService.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
                
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _medicService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new {message= e.Message});  
                
            }
        }
    }
}
