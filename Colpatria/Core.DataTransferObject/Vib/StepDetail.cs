#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=StepDetail.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 11:16 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using Core.Entities.Process;

#endregion

namespace Core.DataTransferObject.Vib
{
    public class StepDetail : Step
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string Action { get; set; }
    }
}