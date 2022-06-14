namespace Vehicles.Tests;

public interface ISecurityGateway
{
    UserState CheckUser(string userId);
}