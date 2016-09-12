#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=FieldInSectionFlow.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 11:02 a. m.</Date>
//   <Update> 2016-09-12 - 11:53 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

namespace Core.Entities.ProcessModel
{
    public abstract class FieldInSectionFlow
    {
        public virtual int Id { get; set; }
        public virtual int FieldId { get; set; }
        public virtual int SectionId { get; set; }
        public virtual int Order { get; set; }
        public virtual bool IsVisible { get; set; }
        public virtual bool IsReadOnly { get; set; }
        public virtual bool IsRequired { get; set; }
        public virtual int Applicant { get; set; }
        public virtual FieldFlow Field { get; set; }
        public virtual SectionFlow Section { get; set; }
    }
}