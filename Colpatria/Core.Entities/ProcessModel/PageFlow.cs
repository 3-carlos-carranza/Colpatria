#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=Page.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-24  - 9:10 a. m.</Date>
//   <Update> 2016-08-26 - 9:59 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;

#endregion

namespace Core.Entities.ProcessModel
{
    public abstract class PageFlow
    {
        public bool Enable { get; set; }
        public int Id { get; set; }
        public bool IsVisible { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public int Order { get; set; }
        public virtual ICollection<SectionFlow> Section { get; set; }
    }
}