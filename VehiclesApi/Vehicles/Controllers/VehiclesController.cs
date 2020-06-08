using System;
using Microsoft.AspNetCore.Mvc;
using Vehicles.Services;

namespace Vehicles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleServices _services;

        public VehiclesController(IVehicleServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetVehicles(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
