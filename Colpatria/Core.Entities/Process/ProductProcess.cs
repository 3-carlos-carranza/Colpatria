#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ProductProcess.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 10:44 a. m.</Date>
//   <Update> 2016-09-12 - 11:10 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

namespace Core.Entities.Process
{
    public class ProductProcess
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public long ProductId { get; set; }

        public virtual Process Process { get; set; }
        public virtual Product Product { get; set; }
    }
}