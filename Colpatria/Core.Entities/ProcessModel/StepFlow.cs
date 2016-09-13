#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=StepFlow.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-12 - 10:36 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;

#endregion

namespace Core.Entities.ProcessModel
{
    public abstract class StepFlow
    {
        public virtual string Description { get; set; }
        public virtual bool Enable { get; set; }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string NameClientAlias { get; set; }
        public virtual int Order { get; set; }
        public virtual int ProcessId { get; set; }
        public virtual int StateId { get; set; }
        public virtual int StepType { get; set; }

      //  public virtual ICollection<StepSectionFlow> StepSection { get; set; } = new HashSet<StepSectionFlow>();
      //  public virtual ProcessFlow Process { get; set; }
      //  public virtual StateFlow State { get; set; }
    }
}