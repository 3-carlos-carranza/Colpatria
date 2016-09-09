namespace Core.Entities.ProcessModel
{
    public abstract class StepSectionFlow
    {
        public long Id { get; set; }
        public int SectionId { get; set; }
        public virtual SectionFlow Section { get; set; }
        public int StepId { get; set; }
        public virtual StepFlow Step { get; set; }
    }
}