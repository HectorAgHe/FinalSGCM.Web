using FinalSGCM.Business.DTOs;
using FinalSGCM.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalSGCM.Web.Controllers
{
    [Route("api/v1/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GeyAll()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }


        [HttpGet("{PatientId}")]
        public async Task<IActionResult> GetById(int PatientId)
        {
            var patien = await _patientService.GetByIdAsync(PatientId);
            if(patien == null)
            {
                return NotFound(new { message = "No se encontro el paciente" });
            }
            return Ok(patien);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PatientCreateDto patientCreateDto)
        {
            try
            {
                await _patientService.AddAsync(patientCreateDto);
                return CreatedAtAction(
                    nameof(GetById),
                    new
                    {
                        PatientId = patientCreateDto.PatientId
                    },
                     patientCreateDto
                    ); // Code 201
            }catch(Exception ex)
            {
                return BadRequest(new { message = $" Error al agregar nuevo Paciente {ex.Message} "});
            }
            
        }



        [HttpDelete]

        public async Task<IActionResult> Delete(int PatientId)
        {
            try
            {

                var existingPatient = await _patientService.GetByIdAsync(PatientId);

                if (existingPatient == null)
                {
                    return NotFound(new { message = "No se encontro al Paciente" });
                }
                await _patientService.DeleteAsync(PatientId);
                return NoContent();
            }

            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al eliminar el consultorio" });



            }
        }


    }
}
