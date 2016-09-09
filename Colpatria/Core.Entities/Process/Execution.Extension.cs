using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Process
{
    partial class StepSection : Core.Entities.ProcessModel.StepSectionFlow
    {
    }

    partial class ExtendedField : Core.Entities.ProcessModel.FieldFlow
    {

    }

    partial class FieldInSection : Core.Entities.ProcessModel.FieldInSectionFlow
    {

    }

    partial class Process : Core.Entities.ProcessModel.ProcessFlow
    {

    }

    partial class Section : Core.Entities.ProcessModel.SectionFlow
    {
    }

    partial class Page : Core.Entities.ProcessModel.PageFlow
    {

    }

    partial class Step : Core.Entities.ProcessModel.StepFlow
    {

    }
    partial class State : Core.Entities.ProcessModel.StateFlow
    {

    }

    partial class Execution :Core.Entities.ProcessModel.ExecutionFlow
    {
        [NotMapped]
        public int? CurrentPageId { get; set; }

        [NotMapped]
        public long UserId { get; set; }

        [NotMapped]
        public long Month { get; set; }
    }
}