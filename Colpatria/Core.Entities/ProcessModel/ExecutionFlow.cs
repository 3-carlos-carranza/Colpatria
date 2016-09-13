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
    public enum StepType
    {
        Success = 1,
        Faile = 2,
        Error = 0
    }

    public abstract class ExecutionFlow
    {
        public virtual long Id { get; set; }
        public virtual int CurrentStepId { get; set; }
       // public virtual StepFlow CurrentStep { get; set; }
        public virtual int CurrentSectionId { get; set; }
       // public virtual SectionFlow CurrentSection { get; set; }
        public virtual int ProcessId { get; set; }
        public virtual long ProductId { get; set; }
       // public virtual ProcessFlow Process { get; set; }
    }
}