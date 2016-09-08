#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=Section.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-24  - 9:10 a. m.</Date>
//   <Update> 2016-08-26 - 9:46 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;

#endregion

namespace Core.Entities.ProcessModel
{
    public class Section
    {
        public string Action { get; set; }
        public string ActionMethod { get; set; }
        public string Controller { get; set; }
        public string Description { get; set; }
        public bool Enable { get; set; }
        public long Id { get; set; }
        public bool IsVisible { get; set; }
        public string Name { get; set; }
        public string NameAlias { get; set; }
        public int Order { get; set; }
        public long PageId { get; set; }
        public bool? ReadOnly { get; set; }
        public int Type { get; set; }
        public Page Page { get; set; }
        public IEnumerable<FieldInSection> FieldInSection { get; set; }
        public IEnumerable<StepSection> StepSection { get; set; }
    }
}