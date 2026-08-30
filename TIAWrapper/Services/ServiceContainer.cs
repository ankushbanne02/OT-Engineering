using TIAWrapper.Interfaces;
using TIAWrapper.Managers;

namespace TIAWrapper.Services;

public static class ServiceContainer
{
    public static ITIAPortalManager PortalManager { get; } = new TIAPortalManager();
}
