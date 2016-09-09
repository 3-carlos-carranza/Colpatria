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
    
    public partial class StepMapping:EntityTypeConfiguration<Core.Entities.Process.Step>
    {
        
        public StepMapping()
        {
    	this.Map(s => s.MapInheritedProperties());
                // Primary Key
    			
                this.HasKey(t => t.Id);
    
    
                // Properties
     
                    this.Property(t => t.Name).IsRequired()
    .HasMaxLength(500);
    
    
     
                    this.Property(t => t.Description).HasMaxLength(500);
    
    
    
                this.ToTable("Step","Process");
        this.Property(t => t.Id).HasColumnName("Id");
        this.Property(t => t.ProcessId).HasColumnName("ProcessId");
        this.Property(t => t.Name).HasColumnName("Name");
        this.Property(t => t.Description).HasColumnName("Description");
        this.Property(t => t.AutoAdvance).HasColumnName("AutoAdvance");
        this.Property(t => t.NameClientAlias).HasColumnName("NameClientAlias");
        this.Property(t => t.ParentId).HasColumnName("ParentId");
        this.Property(t => t.Order).HasColumnName("Order");
        this.Property(t => t.IsPre).HasColumnName("IsPre");
        this.Property(t => t.StateId).HasColumnName("StateId");
        this.Property(t => t.Enable).HasColumnName("Enable");
        this.Property(t => t.StepType).HasColumnName("StepType");
    
                // Relationships
                this.HasRequired(t => t.Process)
                    .WithMany(t => t.Step)
                    .HasForeignKey(d => d.ProcessId);
                this.HasRequired(t => t.State)
                    .WithMany(t => t.Step)
                    .HasForeignKey(d => d.StateId);
    
    
    
        }
    
        
        
        
        
        
        
        
        
        
        
        
        
    
        
        
        
        
        
    }
}
