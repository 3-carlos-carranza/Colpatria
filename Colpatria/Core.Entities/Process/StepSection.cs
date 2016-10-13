#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=StepSection.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 10:44 a. m.</Date>
//   <Update> 2016-09-12 - 10:35 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using Banlinea.ProcessFlow.Model;

#endregion

namespace Core.Entities.Process
{
    public class StepSection : StepSectionFlow
    {
        public new int Id { get; set; }
        public new int StepId { get; set; }
        public new int SectionId { get; set; }

        public Section Section { get; set; }

        public Step Step { get; set; }
    }
}