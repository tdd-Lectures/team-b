using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vehicles.Gateways;
using Vehicles.Services;
using Vehicles.Tests;

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
            return HandleException(() =>  Ok(_services.GetVehicles(userId)));
        }

        private IActionResult HandleException(Func<OkObjectResult> okObjectResult)
        {
            try
            {
                return okObjectResult();
            }
            catch (UnsafeUserException)
            {
                return StatusCode(401);
            }
            catch (RemovedUserException)
            {
                return StatusCode(403);
            }
            catch (InvalidUserException)
            {
                return BadRequest();
            }
            catch (GatewayException)
            {
                return StatusCode(500);
            }
        }
    }
}

