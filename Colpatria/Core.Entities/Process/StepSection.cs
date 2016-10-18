using Banlinea.ProcessFlow.Model;

namespace Core.Entities.Process
{
    public class StepSection : StepSectionFlow
    {
        public new int Id { get; set; }
        public new int StepId { get; set; }
        public new int SectionId { get; set; }
        public Section Section { get; set; }
        public Step Step { get; set; }
    }
}