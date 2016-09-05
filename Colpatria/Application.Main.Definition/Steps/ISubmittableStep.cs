using System.Threading.Tasks;
using Application.Main.Definition.Arguments;

namespace Application.Main.Definition.Steps
{
    public interface ISubmittableStep : IStep
    {
        Task<IStep> GetNextStep(IStepArgument stepArgument);
    }
}