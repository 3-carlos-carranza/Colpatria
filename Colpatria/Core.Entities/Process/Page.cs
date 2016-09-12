#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=Page.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 10:44 a. m.</Date>
//   <Update> 2016-09-12 - 10:31 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Core.Entities.ProcessModel;

#endregion

namespace Core.Entities.Process
{
    public class Page : PageFlow
    {
        public Page()
        {
            Section = new HashSet<Section>();
        }

        public int Id { get; set; }
        public int ProcessId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsVisible { get; set; }
        public string NameAlias { get; set; }
        public bool Enable { get; set; }

        public virtual Process Process { get; set; }
        public virtual ICollection<Section> Section { get; set; }
    }
}