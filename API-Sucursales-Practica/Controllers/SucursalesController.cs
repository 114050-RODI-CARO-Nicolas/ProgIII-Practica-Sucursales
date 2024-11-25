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

        [HttpGet("provincias")]
        public async Task<IActionResult> GetAllProvincias()
        {
            var response = await _sucursalService.GetAllProvinciasAsync();
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet("tipos")]
        public async Task<IActionResult> GetAllTipos()
        {
            var response = await _sucursalService.GetAllTiposAsync();
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }



        [HttpGet("sucursales")]
        public async Task<IActionResult> GetAllSucursales()
        {
            var response = await _sucursalService.GetAllSucursalesAsync();
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);
        }

        [HttpGet("sucursales/most-recent/not-buenos-aires")]
        public async Task<IActionResult> GetSucursalMostRecetNotBsAs()
        {
            var response = await _sucursalService.GetSucursalMostRecentNotBuenosAiresAsync();
            if (!response.Success)
            {
                return StatusCode(500, response);
            }
            return Ok(response);    
        }

        [HttpPost("sucursales")]
        public async Task<IActionResult> CreateSurcursal([FromBody] CreateSucursalDTO createSucursalDTO)
        {
            var response = await _sucursalService.CreateSucursalAsync(createSucursalDTO);
            if (!response.Success)
            {
                return StatusCode(500, response);

            }
            return StatusCode(201, response);
        }

        [HttpPut("sucursales")]
        public async Task<IActionResult> UpdateSucursal( [FromBody] UpdateSucursalDTO updateSucursalDTO)
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
