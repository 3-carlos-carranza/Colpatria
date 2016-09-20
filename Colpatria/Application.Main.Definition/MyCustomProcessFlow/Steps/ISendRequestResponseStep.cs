using Banlinea.ProcessFlow.Engine.Api;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps
{
    public interface ISendRequestResponseStep : IStep
    {
        bool SendRequestMail();
    }
}