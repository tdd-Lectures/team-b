using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Gateways;

namespace Vehicles.Services
{
    public class VehicleServices : IVehicleServices
    {
        private readonly IVehicleGateway _vehicleGateway;

        public VehicleServices(IVehicleGateway vehicleGateway)
        {
            _vehicleGateway = vehicleGateway;
        }

        public IEnumerable<Vehicle> GetVehicles(string userId)
        {
            if (userId == "") throw new InvalidUserException();

            try
            {
                return _vehicleGateway.GetVehicles(userId)
                    .Select(e => new Vehicle
                    {
                        Model = e.Model,
                        VehicleId = e.VehicleId,
                        YearOfConstruction = e.DateOfConstruction.Year
                    });
            }
            catch (Exception)
            {
                throw new GatewayException();
            }
    
        }
    }
}