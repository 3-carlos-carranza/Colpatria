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
    
    public partial class ExtendedFile
    {
        public System.Guid Id { get; set; }
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long ExtendedFieldValueId { get; set; }
        public string InternetMimeType { get; set; }
    
        public virtual ExtendedFieldValue ExtendedFieldValue { get; set; }
    }
}
