
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Vehicles.Controllers;
using Vehicles.Services;

namespace Vehicles.Tests
{
    public class VehiclesControllerTests
    {
        private static VehiclesController MakeVehiclesController()
        {
            return new VehiclesController(
                new VehicleServices(VehicleGatewayFactory.MakeVehicleGateway(), SecurityGatewayFactory.MakeSecurityGateway())
            );
        }

        [Test]
        public void Getting_vehicles_when_data_source_fails_returns_500_status_code()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles("gateway exception") as StatusCodeResult;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(500));
        }

        [Test]
        public void Getting_vehicles_for_invalid_user_returns_400_status_code()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles("") as StatusCodeResult;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(400));
        }
        
        [Test]
        public void Getting_vehicles_for_removed_user_returns_403_status_code()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles("Removed User") as StatusCodeResult;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(403));
        }
        [Test]
        public void Getting_vehicles_for_unsafe_user_returns_401_status_code()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles("Unsafe User") as StatusCodeResult;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(401));
        }        
        [Test]
        public void Getting_vehicles_for_a_user_that_doesnt_have_vehicles_returns_200_status_code()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles("user 1") as ObjectResult;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
        
        [Test]
        public void Getting_vehicles_for_a_user_that_doesnt_have_vehicles_returns_an_empty_list()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles("user 1") as ObjectResult;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value as IEnumerable<Vehicle>, Is.Empty);
        }
        
        [Test]
        public void Getting_vehicles_for_user_2_returns_vehicles_from_given_user()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles("user 2") as ObjectResult;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value as IEnumerable<Vehicle>, Is.EqualTo(new []
            {
                new Vehicle
                {
                    Model = "S1",
                    VehicleId = "1",
                    YearOfConstruction = 2022
                }
            }));
        }
        
        //(userid, vehicleid) returns vehicle
        [Test]
        public void Getting_vehicle_1_for_user_2_returns_vehicle_1()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicle("user 2","1") as ObjectResult;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value as Vehicle, Is.EqualTo( 
                new Vehicle
                {
                    Model = "S1",
                    VehicleId = "1",
                    YearOfConstruction = 2022
                }
            ));
        }
        [Test]
        public void Getting_a_non_existing_vehicle_for_user_2_returns_404_not_found()
        {
            var controller = MakeVehiclesController();
            var result = controller.GetVehicle("user 2","non existing vehicle") as StatusCodeResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(404));
        }
        
        [Test]
        public void Getting_a_vehicle_for_user_1_returns_404_not_found()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicle("user 1","1") as StatusCodeResult;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(404));
            
        }
        
        // [Test]
        public void Getting_vehicle_1_for_removed_user_returns_403_status_code()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicle("Removed User","1") as StatusCodeResult;
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(403));
            
        }
        
    }
}
