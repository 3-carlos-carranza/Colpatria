using Application.Main.Definition.Arguments;

namespace Application.Main.Definition.Services
{
    public interface ISubmitFormAppService
    {
        bool SaveForm(IStepArgument submitFormStepArgument);
    }
}