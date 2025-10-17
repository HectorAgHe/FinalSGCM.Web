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
            if (office == null)
            {
                return NotFound(new { message = "No se encontro el consultorio" });
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
                    new {
                        OfficeId = officeCreateDto.OfficeId
                    },
                        officeCreateDto
                    ); //201
            } catch (Exception)
            {
                return BadRequest(new { messaje = $"Error al crear nuevo consultorio" });
            }
        }



        [HttpPut("{OfficeId}")]
        public async Task<IActionResult> Update(int OfficeId, OfficeCreateDto officeCreateDto)
        {

            if (OfficeId != officeCreateDto.OfficeId)
            {
                return BadRequest(new { message = "El ID de la ruta no coincide con el ID del Consultorio" }); // Respuesta HTTP 400 Bad Request con un mensaje.
            }
            var existingProduct = await _officeService.GetByIdAsync(OfficeId);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Producto no encontrado" });    // Respuesta HTTP 404 Not Found con un mensaje.
            }


            try
            {
                await _officeService.UpdateAsync(OfficeId, officeCreateDto);

                return NoContent();                                             // Retorna 204 No Content para indicar que la operación fue exitosa.
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Hubo un error al actualizar el consultorio: {ex.Message}" });  // Retorna 400 Bad Request con un mensaje de error.
            }
        }




        [HttpDelete("{OfficeId}")]
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
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error al eliminar el consultorio" });
            }
        }


    }
}
