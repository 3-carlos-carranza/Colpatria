#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=Input.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-26  - 11:03 a. m.</Date>
//   <Update> 2016-08-26 - 11:03 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

namespace Core.Entities.ProcessModel
{
    public class Input
    {
        public string DataTag { get; set; }
        public InputType Type { get; set; }
    }
}