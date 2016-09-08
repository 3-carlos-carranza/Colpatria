#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=FieldInSection.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-24  - 9:10 a. m.</Date>
//   <Update> 2016-08-26 - 9:49 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

namespace Core.Entities.ProcessModel
{
    public class FieldInSection
    {
        public int Id { get; set; }
        public long FieldId { get; set; }
        public int SectionId { get; set; }
        public int Order { get; set; }
        public bool IsVisible { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsRequired { get; set; }
        public int Applicant { get; set; }
        public Field Field { get; set; }
        public Section Section { get; set; }
    }
}