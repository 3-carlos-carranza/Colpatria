using Core.DataTransferObject.Vib;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps
{
    public interface ISendRequestResponseStep
    {
        string TemplateResponseRequest(UserInfoDto userInfoDto);
    }
}