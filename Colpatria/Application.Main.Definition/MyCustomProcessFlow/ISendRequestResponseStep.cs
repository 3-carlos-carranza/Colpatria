using System;
using Banlinea.ProcessFlow.Engine.Api;

namespace Application.Main.Definition.MyCustomProcessFlow
{
    public interface ISendRequestResponseStep : IStep
    {
        bool SendRequestMail();
    }
}