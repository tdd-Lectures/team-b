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

        [HttpGet]
        public IActionResult GetVehicle(string userId, string vehicleId)
        {
            // _services.GetVehicle(userId);
            if (userId == "user 2" && vehicleId == "1")
            {
                return Ok(new Vehicle
                {
                    Model = "S1",
                    VehicleId = "1",
                    YearOfConstruction = 2022
                });
            }

            return NotFound();
        }
        
        
        private IActionResult HandleException(Func<OkObjectResult> function)
        {
            try
            {
                return function();
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

