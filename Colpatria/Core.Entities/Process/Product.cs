#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=Product.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-12 - 11:15 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;

#endregion

namespace Core.Entities.Process
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<Execution> Execution { get; } = new HashSet<Execution>();

        public virtual ICollection<ProductProcess> ProductProcess { get; } = new HashSet<ProductProcess>();
    }
}