using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Gateways;
using Vehicles.Tests;

namespace Vehicles.Services
{
    public class VehicleServices : IVehicleServices
    {
        private readonly IVehicleGateway _vehicleGateway;
        private readonly ISecurityGateway _securityGateway;

        public VehicleServices(IVehicleGateway vehicleGateway, ISecurityGateway securityGateway)
        {
            _vehicleGateway = vehicleGateway;
            _securityGateway = securityGateway;
        }

        public IEnumerable<Vehicle> GetVehicles(string userId)
        {
            if (userId == "") throw new InvalidUserException();

            if ( _securityGateway.CheckUser(userId)==UserState.UNSAFE)
                throw new UnsafeUserException();

            if ( _securityGateway.CheckUser(userId)==UserState.REMOVED)
            {
                throw new RemovedUserException();
            }
            
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