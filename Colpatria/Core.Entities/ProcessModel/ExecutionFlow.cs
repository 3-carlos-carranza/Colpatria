#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ProcessExecution.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-24  - 9:10 a. m.</Date>
//   <Update> 2016-08-26 - 11:08 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

#endregion

namespace Core.Entities.ProcessModel
{
    public abstract class ExecutionFlow
    {
        public long Id { get; set; }
        public int CurrentStepId { get; set; }
        public virtual StepFlow CurrentStep { get; set; }
        public int CurrentSectionId { get; set; }
        public virtual SectionFlow CurrentSection { get; set; }
        public int ProcessId { get; set; }
        public long ProductId { get; set; }
        public virtual ProcessFlow Process { get; set; }
    }
}