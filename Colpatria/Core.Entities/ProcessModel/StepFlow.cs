#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=Step.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-24  - 9:10 a. m.</Date>
//   <Update> 2016-08-26 - 10:17 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;

#endregion

namespace Core.Entities.ProcessModel
{
    public abstract class StepFlow
    {
        public string Description { get; set; }
        public bool Enable { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameClientAlias { get; set; }
        public int Order { get; set; }
        //public virtual int ProcessId { get; set; }
        //public int StateId { get; set; }
        public int StepType { get; set; }
        //public virtual ICollection<StepSectionFlow> StepSection { get; set; } = new HashSet<StepSectionFlow>();
        //public virtual ProcessFlow Process { get; set; }
        //public virtual StateFlow State { get; set; }
    }
}