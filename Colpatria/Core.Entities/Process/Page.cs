//   -----------------------------------------------------------------------
//   <copyright file=Page.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

#region

using System.Collections.Generic;
using Banlinea.ProcessFlow.Model;

#endregion

namespace Core.Entities.Process
{
    public class Page : PageFlow
    {
        public int ProcessId { get; set; }
        public virtual Process Process { get; set; }
        public virtual ICollection<Section> Section { get; set; } = new HashSet<Section>();
    }
}