//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Entities.SQL.Process
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExtendedDataList
    {
        public int Id { get; set; }
        public Nullable<int> ListId { get; set; }
        public string Value { get; set; }
        public Nullable<int> IdParent { get; set; }
        public Nullable<int> OriginalValue { get; set; }
        public Nullable<int> Order { get; set; }
    
        public virtual ExtendedList ExtendedList { get; set; }
    }
}
