//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Process
{
    using System;
    using System.Collections.Generic;
    
    public partial class WebServiceConsultation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ExecutionId { get; set; }
        public string Payload { get; set; }
        public string WebServiceName { get; set; }
        public int TypeOfConsultation { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
