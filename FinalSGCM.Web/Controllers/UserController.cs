using FinalSGCM.Business.DTOs;
using FinalSGCM.Business.Services.Implementations;
using FinalSGCM.Business.Services.Interfaces;
using FinalSGCM.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalSGCM.Web.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);

        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetById(int UserId)
        {
            var user = await _userService.GetByIdAsync(UserId);
            if (user == null)
            {
                return NotFound(new { message = "No se encontro al usuario" });
            }
            return Ok(user);

        }


        [HttpPost]
        public async Task<IActionResult>Create([FromBody] UserCreateDto userCreateDto)
        {
            try
            {
                await _userService.AddAsync(userCreateDto);
                return CreatedAtAction(
                    nameof(GetById),
                    new
                    {
                      UserId = userCreateDto.UserId 
                    },
                    userCreateDto
                    ); // code201
            }catch (Exception)
            {
                return BadRequest(new{ message = $"Error al crear nuevo usuario"} );
            }
        }




        [HttpPut("{UserId}")]
        public async Task<IActionResult> Update(int UserId, UserCreateDto userCreateDto)
        {

            if (UserId != userCreateDto.UserId)
            {
                return BadRequest(new { message = "El ID de la ruta no coincide con el ID del Consultorio" }); // Respuesta HTTP 400 Bad Request con un mensaje.
            }
            var existingProduct = await _userService.GetByIdAsync(UserId);
            if (existingProduct == null)
            {
                return NotFound(new { message = "Producto no encontrado" });    // Respuesta HTTP 404 Not Found con un mensaje.
            }


            try
            {
                await _userService.UpdateAsync(UserId, userCreateDto);

                return NoContent();                                             // Retorna 204 No Content para indicar que la operación fue exitosa.
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Hubo un error al actualizar el consultorio: {ex.Message}" });  // Retorna 400 Bad Request con un mensaje de error.
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int UserId)
        {
            try
            {
                var existingUser = await _userService.GetByIdAsync(UserId);
                
                if(existingUser == null)
                {
                    return NotFound(new { message = "Usuario no encontrado" });
                }

                await _userService.DeleteAsync(UserId);
                return NoContent();

            }catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al eliminar" });
            }

        }
    }
}
