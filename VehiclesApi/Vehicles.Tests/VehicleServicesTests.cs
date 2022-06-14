using NUnit.Framework;
using Vehicles.Gateways;
using Vehicles.Services;

namespace Vehicles.Tests
{
    public class VehicleServicesTests
    {

        private static VehicleServices MakeVehicleServices()
        {
            return new VehicleServices(
                VehicleGatewayFactory.MakeVehicleGateway(), SecurityGatewayFactory.MakeSecurityGateway()
            );
        }

        [Test]
        public void Getting_vehicles_from_a_invalid_user_throws_invalid_user_exception()
        {
            var services = MakeVehicleServices();

            Assert.Throws<InvalidUserException>(() => services.GetVehicles(""));
        }

        [Test]
        public void Getting_vehicles_from_a_user_that_doesnt_have_vehicles_returns_empty_list()
        {
            var services = MakeVehicleServices();

            var vehicles = services.GetVehicles("user 1");
            
            Assert.That(vehicles, Is.Empty);
        }

        [Test]
        public void Getting_vehicles_from_user_2_returns_vehicles_from_given_user()
        {
            var services = MakeVehicleServices();

            var vehicles = services.GetVehicles("user 2");
            
            Assert.That(vehicles, Is.EqualTo(new []
            {
                new Vehicle
                {
                    Model = "S1",
                    VehicleId = "1",
                    YearOfConstruction = 2022
                }
            }));
        }
        
        [Test]
        public void Getting_vehicles_from_user_3_returns_vehicles_from_given_user()
        {
            var services = MakeVehicleServices();

            var vehicles = services.GetVehicles("user 3");
            
            Assert.That(vehicles, Is.EqualTo(new []
            {
                new Vehicle
                {
                    Model = "M4",
                    VehicleId = "4",
                    YearOfConstruction = 2021
                },
                new Vehicle
                {
                    Model = "I7",
                    VehicleId = "5",
                    YearOfConstruction = 2022
                }
            }));
        }
        
        [Test]
        public void Getting_vehicles_when_gateway_throws_exception_throws_gateway_exception()
        {
            var services = MakeVehicleServices();

            Assert.Throws<GatewayException>(() => services.GetVehicles("gateway exception"));
        }


        [Test]
        public void Getting_vehicles_from_unsafe_user_returns_UnsafeUserException()
        {
            var services = MakeVehicleServices();

            Assert.Throws<UnsafeUserException>(() => services.GetVehicles("Unsafe User"));
        }
        
        [Test]
        public void Getting_vehicles_from_removed_user_returns_RemovedUserException()
        {
            var services = MakeVehicleServices();

            Assert.Throws<RemovedUserException>(() => services.GetVehicles("Removed User"));
        }
    }
}
