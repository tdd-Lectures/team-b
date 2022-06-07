using System;
using System.Collections.Generic;
using Vehicles.Gateways;

namespace Vehicles.Services
{
    public class VehicleServices : IVehicleServices
    {
        private IVehicleGateway _vehicleGateway;

        public VehicleServices(IVehicleGateway vehicleGateway)
        {
            _vehicleGateway = vehicleGateway;
        }

        public IEnumerable<Vehicle> GetVehicles(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
