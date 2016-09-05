using Application.Main.Definition.Enumerations;

namespace Application.Main.Definition.Responses
{
    public interface IInterfaceResponse
    {
        InterfaceTypeResponse InterfaceTypeResponse { get; }
        string FriendlyUrl { get; set; }
        string ActionMethod { get; set; }
        string PartialView { get; set; }
        string Action { get; set; }
        string Controller { get; set; }
    }
}