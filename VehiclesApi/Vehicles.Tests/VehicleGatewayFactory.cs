using System;
using Moq;
using Vehicles.Gateways;

namespace Vehicles.Tests;

public class VehicleGatewayFactory
{
    public static IVehicleGateway MakeVehicleGateway()
    {
        var gatewayMock = new Mock<IVehicleGateway>();

        gatewayMock
            .Setup(e => e.GetVehicles("gateway exception"))
            .Throws<Exception>();

        gatewayMock
            .Setup(e => e.GetVehicles("user 2"))
            .Returns(new[]
            {
                new VehicleModel
                {
                    Model = "S1",
                    VehicleId = "1",
                    DateOfConstruction = new DateTime(2022, 01, 01)
                }
            });

        gatewayMock
            .Setup(e => e.GetVehicles("user 3"))
            .Returns(new[]
            {
                new VehicleModel
                {
                    Model = "M4",
                    VehicleId = "4",
                    DateOfConstruction = new DateTime(2021, 01, 01)
                },
                new VehicleModel
                {
                    Model = "I7",
                    VehicleId = "5",
                    DateOfConstruction = new DateTime(2022, 01, 01)
                }
            });

        return gatewayMock.Object;
    }
}