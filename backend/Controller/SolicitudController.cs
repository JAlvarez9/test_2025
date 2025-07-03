namespace backend.Controller
{
    public record NewSolicitud(string Titulo, string Descripcion, string Prioridad);

    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController(ISolicitudService solicitudService) : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var solicitudes = await solicitudService.GetAllAsync();
                return Ok(solicitudes);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al obtener las solicitudes: {ex.Message}"
                );
            }
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var solicitud = await solicitudService.GetByIdAsync(id);
                if (solicitud == null)
                {
                    return NotFound($"Solicitud con ID {id} no encontrada.");
                }
                return Ok(solicitud);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al obtener la solicitud: {ex.Message}"
                );
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] NewSolicitud solicitud)
        {
            try
            {
                var createdSolicitud = await solicitudService.CreateAsync(solicitud);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al crear la solicitud: {ex.Message}"
                );
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Solicitud solicitud)
        {
            try
            {
                var updatedSolicitud = await solicitudService.UpdateAsync(solicitud);
                return Ok(updatedSolicitud);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al actualizar la solicitud: {ex.Message}"
                );
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await solicitudService.DeleteAsync(id);
                if (result)
                {
                    return NoContent();
                }
                return NotFound($"Solicitud con ID {id} no encontrada.");
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al eliminar la solicitud: {ex.Message}"
                );
            }
        }

        [HttpPut]
        [Route("UpdateEstado/{id:int}/{estado:required}")]
        public async Task<IActionResult> UpdateEstado(int id, string estado)
        {
            try
            {
                var result = await solicitudService.ChangeEstadoAsync(id, estado);
                return result == null ? NoContent() : NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al actualizar el estado de la solicitud: {ex.Message}"
                );
            }
        }

        [HttpPut]
        [Route("UpdatePrioridad/{id:int}/{prioridad:required}")]
        public async Task<IActionResult> UpdatePrioridad(int id, string prioridad)
        {
            try
            {
                await solicitudService.ChangePrioridadAsync(id, prioridad);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error al actualizar la prioridad de la solicitud: {ex.Message}"
                );
            }
        }
    }
}
