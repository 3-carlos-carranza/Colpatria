//------------------------------------------------------------------------------
// <auto-generated>
// </auto-generated>
//------------------------------------------------------------------------------




using System.Data.Entity.ModelConfiguration;
using Core.Entities.SQL;


namespace DataAccess.ProcessModule.UnitOfWork.Mapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class StepSectionMapping:EntityTypeConfiguration<Core.Entities.SQL.StepSection>
    {
        
        public StepSectionMapping()
        {
                // Primary Key
                this.HasKey(t => t.Id);
    
    
                // Properties
    
                this.ToTable("StepSection","Req");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.StepId).HasColumnName("StepId");
        this.Property(t => t.SectionId).HasColumnName("SectionId");
    
                // Relationships
                this.HasRequired(t => t.Section)
                    .WithMany(t => t.StepSection)
                    .HasForeignKey(d => d.SectionId);
                this.HasRequired(t => t.Step)
                    .WithMany(t => t.StepSection)
                    .HasForeignKey(d => d.StepId);
    
    
    
        }
    
        
        
        
    
        
        
    }
}
