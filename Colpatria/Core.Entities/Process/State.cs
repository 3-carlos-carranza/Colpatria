#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=State.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 10:44 a. m.</Date>
//   <Update> 2016-09-12 - 10:55 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Banlinea.ProcessFlow.Model;

#endregion

namespace Core.Entities.Process
{
    public class State : StateFlow
    {
        public State()
        {
            Step = new HashSet<Step>();
        }

        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override bool NotificationEnabled { get; set; }
        public override bool IsClosed { get; set; }
        public override bool IsRequesting { get; set; }


        public virtual ICollection<Step> Step { get; set; }
    }
}