//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Entities.SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExecutionApplicant
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public long UserId { get; set; }
        public bool IsMain { get; set; }
        public int Applicant { get; set; }
    
        public virtual Execution Execution { get; set; }
    }
}
