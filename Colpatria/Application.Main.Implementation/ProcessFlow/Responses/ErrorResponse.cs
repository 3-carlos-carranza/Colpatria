using Application.Main.Definition.Responses;
using Core.Entities.SQL.Enumerations;

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class ErrorResponse : IStepResponse
    {
        public long ProductId { get; set; }
        public long ExecutionId { get; set; }
        public int PageId { get; set; }
        public int SectionId { get; set; }
        public string Code { get; set; }
        public ExecutionState ExecutionState { get; set; }
    }
}