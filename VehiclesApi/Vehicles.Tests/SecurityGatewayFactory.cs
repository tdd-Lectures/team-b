using Moq;

namespace Vehicles.Tests;

public class SecurityGatewayFactory
{
    public static ISecurityGateway MakeSecurityGateway()
    {
        Mock<ISecurityGateway> mock = new Mock<ISecurityGateway>();
        mock.Setup(m => m.CheckUser("Removed User")).Returns(UserState.REMOVED);
        mock.Setup(m => m.CheckUser("Unsafe User")).Returns(UserState.UNSAFE);

        ISecurityGateway securityGateway = mock.Object;
        return securityGateway;
    }
}