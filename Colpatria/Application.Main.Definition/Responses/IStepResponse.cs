using Core.Entities.SQL.Enumerations;

namespace Application.Main.Definition.Responses
{
    public interface IStepResponse
    {
        long ProductId { get; set; }
        long ExecutionId { get; set; }
        int PageId { get; set; }
        int SectionId { get; set; }
        string Code { get; set; }
        ExecutionState ExecutionState { get; set; }
    }
}