using Banlinea.ProcessFlow.Model;

namespace Core.Entities.Process
{
    public class FieldInSection : FieldInSectionFlow
    {
        public override int Id { get; set; }
        public int ExtendedFieldId { get; set; }
        public override int SectionId { get; set; }
        public override int Order { get; set; }
        public override bool IsVisible { get; set; }
        public override bool IsReadOnly { get; set; }
        public override bool IsRequired { get; set; }
        public override int Applicant { get; set; }
        public virtual ExtendedField ExtendedField { get; set; }
        public virtual Section Section { get; set; }
    }
}
