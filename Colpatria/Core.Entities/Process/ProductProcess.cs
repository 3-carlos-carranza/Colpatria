//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Entities.Process
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductProcess
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public long ProductId { get; set; }
    
        public virtual Process Process { get; set; }
        public virtual Product Product { get; set; }
    }
}