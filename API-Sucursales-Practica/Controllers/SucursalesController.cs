using API_Sucursales_Practica.DTOs;
using API_Sucursales_Practica.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Sucursales_Practica.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {

        private readonly ISucursalService _sucursalService;
        private readonly IConfiguracionService _configuracionService;

        public SucursalesController(ISucursalService sucursalService, IConfiguracionService configuracionService)
        {
            _sucursalService=sucursalService;
            _configuracionService=configuracionService;
        }

        [HttpGet("configs")]
        public async Task<IActionResult> GetConfigs()
        {
            var response = await _configuracionService.GetConfiguracionesAsync();
            if (!response.Success)
            {
                return StatusCode(500, response.Message);
            }
            return Ok(response);
        }


        

        [HttpGet("sucursales/most-recent/not-buenos-aires")]
        public async Task<IActionResult> GetSucursalMostRecetNotBsAs()
        {
            var response = await _sucursalService.GetSucursalMostRecentNotBuenosAiresAsync();
            if (!response.Success)
            {
                return StatusCode(500, response.Message);
            }
            return Ok();    
        }

        [HttpPut("sucursales")]
        public async Task<IActionResult> UpdateSucursal(UpdateSucursalDTO updateSucursalDTO)
        {
            var response = await _sucursalService.UpdateSucursalAsync(updateSucursalDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }






    }
}
