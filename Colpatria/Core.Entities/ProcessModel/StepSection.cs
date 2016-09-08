namespace Core.Entities.ProcessModel
{
    public class StepSection
    {
        public long Id { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public int Step { get; set; }
        public Step StepId { get; set; }
    }
}