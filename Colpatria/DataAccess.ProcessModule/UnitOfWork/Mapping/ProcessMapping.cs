//------------------------------------------------------------------------------
// <auto-generated>
// </auto-generated>
//------------------------------------------------------------------------------




using System.Data.Entity.ModelConfiguration;
using Core.Entities.Process;


namespace DataAccess.ProcessModule.UnitOfWork.Mapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProcessMapping:EntityTypeConfiguration<Core.Entities.Process.Process>
    {
        
        public ProcessMapping()
        {
    	this.Map(s => s.MapInheritedProperties());
                // Primary Key
    			
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.Name).IsRequired()
    .HasMaxLength(50);
    
    
     
                    this.Property(t => t.Description).HasMaxLength(500);
    
    
    
                this.ToTable("Process","Process");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.Name).HasColumnName("Name");
        this.Property(t => t.Description).HasColumnName("Description");
        this.Property(t => t.CreateDate).HasColumnName("CreateDate");
        this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
        this.Property(t => t.FunctionaryAssignationProcessType).HasColumnName("FunctionaryAssignationProcessType");
        this.Property(t => t.FormGenerationOption).HasColumnName("FormGenerationOption");
        this.Property(t => t.ProcessType).HasColumnName("ProcessType");
        this.Property(t => t.FinancialEntityType).HasColumnName("FinancialEntityType");
    
    
        }
    
        
        
        
        
        
        
        
        
        
    
        
        
        
        
        
    }
}
