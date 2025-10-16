using FinalSGCM.Business.DTOs;
using FinalSGCM.Business.Services.Interfaces;
using FinalSGCM.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalSGCM.Web.Controllers
{
    [Route("api/v1/offices")]
    [ApiController]
    public class OfficeController : ControllerBase
    {

        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var offices = await _officeService.GetAllAsync();
            return Ok(offices);

        }


        [HttpGet("{OfficeId}")]

        public async Task<IActionResult> GetById(int OfficeId)
        {
            var office = await _officeService.GetByIdAsync(OfficeId);
            if(office == null)
            {
                return NotFound(new {message = "No se encontro el consultorio"});
            }
            return Ok(office);  
        }



        [HttpPost]
        
        public async Task<IActionResult> Create([FromBody] OfficeCreateDto officeCreateDto)
        {
            try
            {
                await _officeService.AddAsync(officeCreateDto);
                return CreatedAtAction(
                    nameof(GetById),
                    new{
                        OfficeId = officeCreateDto.OfficeId
                    },
                        officeCreateDto                     
                    ); //201
            }catch (Exception ex)
            {
                return BadRequest(new {messaje = $"Error al crear nuevo consultorio"});
            }
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int OfficeId)
        {
            try
            {
                var existingOffice = await _officeService.GetByIdAsync(OfficeId);
                if (existingOffice == null)
                {
                    return NotFound(new { message = "Consultorio no encontrado" });
                }
                await _officeService.DeleteAsync(OfficeId);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error al eliminar el consultorio" });
            }
        }


    }
}
